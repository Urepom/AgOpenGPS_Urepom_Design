using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AgLibrary.Logging;

namespace AgOpenGPS
{
    public partial class FormEventViewer : Form
    {
        private readonly string _filename;
        private long _filePosition = 0;
        private int _sessionLength = 0;
        private Timer _refreshTimer;

        public FormEventViewer(string filename)
        {
            InitializeComponent();
            _filename = filename;
        }

        private void FormEventViewer_Load(object sender, EventArgs e)
        {
            LoadLog();

            _refreshTimer = new Timer { Interval = 1000 };
            _refreshTimer.Tick += (s, ev) => AppendNewContent();
            _refreshTimer.Start();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _refreshTimer?.Stop();
            _refreshTimer?.Dispose();
            base.OnFormClosed(e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLog();
        }

        // Full reload — used on open and manual refresh
        private void LoadLog()
        {
            string fileContent = "";
            try
            {
                fileContent = File.ReadAllText(_filename);
                _filePosition = new FileInfo(_filename).Length;
            }
            catch (Exception ex)
            {
                fileContent = "Catch -> error loading logfile: " + ex.Message;
                _filePosition = 0;
            }

            _sessionLength = Log.sbEvents.Length;

            rtbLogViewer.SuspendLayout();
            rtbLogViewer.Text = fileContent
                + "\r\n **** Current Session Below *****\r\n\r\n"
                + Log.sbEvents.ToString();
            ScrollToBottom();
            rtbLogViewer.ResumeLayout();
        }

        // Appends only new content since the last read — called by timer
        private void AppendNewContent()
        {
            bool hasNew = false;

            try
            {
                long currentSize = new FileInfo(_filename).Length;
                if (currentSize > _filePosition)
                {
                    using (var fs = new FileStream(_filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        fs.Seek(_filePosition, SeekOrigin.Begin);
                        using (var sr = new StreamReader(fs, Encoding.UTF8))
                        {
                            string newContent = sr.ReadToEnd();
                            if (!string.IsNullOrEmpty(newContent))
                            {
                                rtbLogViewer.AppendText(newContent);
                                hasNew = true;
                            }
                        }
                        _filePosition = currentSize;
                    }
                }
            }
            catch { }

            int currentSessionLength = Log.sbEvents.Length;
            if (currentSessionLength > _sessionLength)
            {
                rtbLogViewer.AppendText(Log.sbEvents.ToString().Substring(_sessionLength));
                _sessionLength = currentSessionLength;
                hasNew = true;
            }

            if (hasNew) ScrollToBottom();
        }

        private void ScrollToBottom()
        {
            rtbLogViewer.SelectionStart = rtbLogViewer.Text.Length;
            rtbLogViewer.ScrollToCaret();
        }
    }
}