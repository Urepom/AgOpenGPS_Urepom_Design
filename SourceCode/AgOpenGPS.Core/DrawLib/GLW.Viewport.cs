using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace AgOpenGPS.Core.DrawLib
{
    // GLW is short for GL Wrapper.
    // Please use this class in stead of direct calls to functions in the GL toolkit.
    public static partial class GLW
    {
        public static void LoadIdentity()
        {
            GL.LoadIdentity();
        }

        public static void MatrixModeProjection()
        {
            GL.MatrixMode(MatrixMode.Projection);
        }

        public static void MatrixModeModelView()
        {
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public static void Viewport(int width, int height)
        {
            GL.Viewport(0, 0, width, height);
        }

        public static void CreatePerspectiveFieldOfView()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            //58 degrees view
            Matrix4 mat = Matrix4.CreatePerspectiveFieldOfView(1.01f, 1.0f, 1.0f, 20000);
            GL.LoadMatrix(ref mat);

            GL.MatrixMode(MatrixMode.Modelview);
        }

        public static void ClearColorAndDepthBuffer()
        {
            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
        }

        public static void SetClearColor(float red, float green, float blue, float alpha)
        {
            GL.ClearColor(red, green, blue, alpha);
        }

        public static void Flush()
        {
            GL.Flush();
        }
    }
}
