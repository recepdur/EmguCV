

using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
 
namespace WebCamera
{
    public partial class Camera : Form
    {
        private Capture capture = null;
        private Image<Bgr, Byte> bgrFrame;
 
        public Camera()
        {
            InitializeComponent();
        }
 
        private void Camera_Load(object sender, EventArgs e)
        {
            capture = new Capture(0);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FPS, 30);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT, 450);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_WIDTH, 370);
            Application.Idle += CameraFrame;
        }
 
        private void CameraFrame(object sender, EventArgs arg)
        {
            bgrFrame = capture.QueryFrame();
            if (bgrFrame != null)
            {                
                pictureBox1.Image = bgrFrame.ToBitmap();
            }
        }
    }
}
