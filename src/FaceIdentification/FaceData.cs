using Emgu.CV.Structure;
using Emgu.CV;
using System;

namespace FaceIdentification
{
    class FaceData
    {
        public string PersonName { get; set; }
        public Image<Gray, byte> FaceImage { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
