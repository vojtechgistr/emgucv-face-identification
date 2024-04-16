using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceIdentification
{
    internal static class Config
    {
        public static string FaceDatabasePath = "your_path_to\\db\\ObjectDatabase\\";
        public static string HaarCascadeClassifierPath = "your_path_to\\CascadeClassifiers\\haarcascade_frontalface_alt.xml";
        public static ImageFormat ImageFileExtension = ImageFormat.Bmp;
        public static int ActiveCameraIndex = 0; // 0 - default camera
        public static double EigenThreshold = 5200;
        public static double MinRecognitionAccuracyPercentage = 1;
        public static int DataImageResolution = 200;
    }
}
