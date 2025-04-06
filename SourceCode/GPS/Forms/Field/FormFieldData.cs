//Please, if you use this give me some credit
//Copyright BrianTee, copy right out of it.

using AgOpenGPS.Culture;
using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormFieldData : Form
    {
        private readonly FormGPS mf = null;

        public FormFieldData(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
            labelTotal.Text = gStr.gsTotal + ":";
            labelWorked.Text = gStr.gsWorked;
            labelApplied.Text = gStr.gsApplied + ":";
            labelApplied2.Text = gStr.gsApplied + ":";
            labelRemain.Text = gStr.gsRemain + ":";
            labelRemain2.Text = gStr.gsRemain + ":";
            labelOverlap.Text = gStr.gsOverlap + ":";
            labelActual.Text = gStr.gsActual;
            labelRate.Text = gStr.gsRate + ":";
            labelArea.Text = gStr.gsArea + ":";
            labelDistance.Text = gStr.gsDistance + ":";

        }
        private void FormFieldData_Load(object sender, EventArgs e)
        {
            timer1_Tick(this, EventArgs.Empty);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblEastingField.Text = Math.Round(mf.pn.fix.easting, 1).ToString();
            //lblNorthingField.Text = Math.Round(mf.pn.fix.northing, 1).ToString();

            lblOverlapPercent.Text = mf.fd.ActualOverlapPercent;

            if (mf.isMetric)
            {
                lblWorkRate.Text = mf.fd.WorkRateHectares;
                lblApplied.Text = mf.fd.WorkedHectares;
                lblActualLessOverlap.Text = mf.fd.ActualAreaWorkedHectares;
                labelAreaValue.Text = mf.fd.WorkedUserHectares + " ha";
                labelDistanceDriven.Text = mf.fd.DistanceUserMeters + " m";

            }
            else
            {
                lblWorkRate.Text = mf.fd.WorkRateAcres;
                lblApplied.Text = mf.fd.WorkedAcres;
                lblActualLessOverlap.Text = mf.fd.ActualAreaWorkedAcres;
                labelAreaValue.Text = mf.fd.WorkedUserAcres +" ac";
                labelDistanceDriven.Text = mf.fd.DistanceUserFeet + " ft";
            }

            if (mf.bnd.bndList.Count > 0)
            {
                lblTimeRemaining.Text = mf.fd.TimeTillFinished;
                lblRemainPercent.Text = mf.fd.WorkedAreaRemainPercentage;
                lblTotalArea.Visible = true;
                lblAreaRemain.Visible = true;
                lblTimeRemaining.Visible = true;
                lblRemainPercent.Visible = true;
                labelRemain.Visible = true;
                lblActualRemain.Visible = true;
                labelRemain2.Visible = true;

                if (mf.isMetric)
                {
                    lblTotalArea.Text = mf.fd.AreaBoundaryLessInnersHectares;
                    lblAreaRemain.Text = mf.fd.WorkedAreaRemainHectares;
                    lblActualRemain.Text = mf.fd.ActualRemainHectares;
                    
                }
                else
                {
                    lblTotalArea.Text = mf.fd.AreaBoundaryLessInnersAcres;
                    lblAreaRemain.Text = mf.fd.WorkedAreaRemainAcres;
                    lblActualRemain.Text = mf.fd.ActualRemainAcres;
                    
                }
            }
            else
            {
                lblTotalArea.Visible = false;
                lblAreaRemain.Visible = false;
                lblTimeRemaining.Visible = false;
                lblRemainPercent.Visible = false;
                lblActualRemain.Visible = false;
                labelRemain2.Visible = false;
                labelRemain.Visible = false;
                

                //if (mf.isMetric) lblActualLessOverlap.Text = 
                //        ((100-mf.fd.overlapPercent) * 0.01 * mf.fd.workedAreaTotal * glm.m2ha).ToString("N2");
                //else
                //    lblActualLessOverlap.Text =
                //    ((100-mf.fd.overlapPercent) * 0.01 * mf.fd.workedAreaTotal * glm.m2ac).ToString("N2");
            }
        }

        private void btnTripReset_Click(object sender, EventArgs e)
        {
            mf.fd.workedAreaTotalUser = 0;
            mf.fd.distanceUser = 0;
        }
    }
}

//lblLookOnLeft.Text = mf.tool.lookAheadDistanceOnPixelsLeft.ToString("N0");
//lblLookOnRight.Text = mf.tool.lookAheadDistanceOnPixelsRight.ToString("N0");
//lblLookOffLeft.Text = mf.tool.lookAheadDistanceOffPixelsLeft.ToString("N0");
//lblLookOffRight.Text = mf.tool.lookAheadDistanceOffPixelsRight.ToString("N0");

//lblLeftToolSpd.Text = (mf.tool.toolFarLeftSpeed*3.6).ToString("N1");
//lblRightToolSpd.Text = (mf.tool.toolFarRightSpeed*3.6).ToString("N1");

//lblSectSpdLeft.Text = (mf.section[0].speedPixels*0.36).ToString("N1");
//lblSectSpdRight.Text = (mf.section[mf.tool.numOfSections-1].speedPixels*0.36).ToString("N1");