using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.IO;
using System.Threading;
using Emgu.CV.Util;
using System.Diagnostics;

namespace FaceIdentification
{
    public partial class Form1 : Form
    {
        private VideoCapture _videoCapture;
        private CascadeClassifier _haarCascade;

        private Image<Bgr, Byte> _currentFrame = null;
        private Mat _frame = new Mat();

        private readonly List<FaceData> _faceList = new List<FaceData>();
        private readonly VectorOfMat _imageList = new VectorOfMat();
        private readonly List<string> _nameList = new List<string>();
        private readonly VectorOfInt _labelList = new VectorOfInt();

        private EigenFaceRecognizer _recognizer;


        public Image<Gray, byte> DetectedFacePreview { get; private set; }
        public void ReloadDetectedFacePreview()
        {
            if (detectedFacePictureBox.InvokeRequired)
            {
                detectedFacePictureBox.Invoke(new ThreadStart(() =>
                {
                    detectedFacePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    detectedFacePictureBox.Image = DetectedFacePreview.ToBitmap();
                }));
            }
        }

        public Image<Gray, byte> RegisteredFacePreview { get; private set; }
        public void ReloadRegisteredFacePreview()
        {
            if (registeredFacePictureBox.InvokeRequired)
            {
                registeredFacePictureBox.Invoke(new ThreadStart(() =>
                {
                    registeredFacePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    registeredFacePictureBox.Image = RegisteredFacePreview.ToBitmap();
                }));
            }
        }


        public Form1()
        {
            InitializeComponent();
            ChangeEigenThreshold.Value = (decimal)Config.EigenThreshold;
            TriggerVideoCapture();
        }

        private void TriggerVideoCapture()
        {
            if (_videoCapture == null)
            {
                GetFaceList();

                _videoCapture = new VideoCapture(Config.ActiveCameraIndex);
                _videoCapture.ImageGrabbed += ProcessFrame;
                _videoCapture.Start();

                _frame = new Mat();
                return;
            }

            _videoCapture.Stop();
            _videoCapture.Dispose();
            _videoCapture = null;

            _frame.Dispose();
            _frame = null;
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            _videoCapture.Retrieve(_frame);
            _currentFrame = _frame.ToImage<Bgr, byte>().Resize(imageBox.Width, imageBox.Height, Inter.Cubic);
            if (_currentFrame.Data != null)
            {
                Mat grayFrame = new Mat();
                CvInvoke.CvtColor(_currentFrame, grayFrame, ColorConversion.Bgr2Gray);

                Rectangle[] foundObjects = _haarCascade.DetectMultiScale(grayFrame, 1.1, 5); // detekovat vlasy ??? neighbors
                if (foundObjects.Length == 0)
                {
                    imageBox.Image = _currentFrame;
                    _currentFrame?.Dispose();
                    return;
                }

                string faceName = "Unknown";
                var (closestObjectSize, closestObjectIndex) = foundObjects.Select((obj, i) => (obj.Width * obj.Height, i)).Max();
                Rectangle closestObject = foundObjects[closestObjectIndex];

                Image<Gray, byte> detectedFace = _currentFrame.Copy(closestObject).Convert<Gray, byte>();
                RecognizeFace(detectedFace, ref faceName);

                MCvScalar scalar = new MCvScalar(0, 0, 255);
                CvInvoke.Rectangle(_currentFrame, closestObject, new Bgr(Color.Red).MCvScalar, 2);
                CvInvoke.PutText(_currentFrame, faceName, new Point(closestObject.X, closestObject.Y - 5), FontFace.HersheyPlain, 2.2, scalar, 2);
            }

            imageBox.Image = _currentFrame;
            _currentFrame?.Dispose();
        }

        public void GetFaceList()
        {
            if (!AreRequiredFilesValid())
            {
                MessageBox.Show("Required files are not valid and could not be fixed automatically.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _faceList.Clear();
            _imageList.Clear();
            _nameList.Clear();
            _labelList.Clear();
            _haarCascade = new CascadeClassifier(Config.HaarCascadeClassifierPath);

            string[] files = Directory.GetFiles(Config.FaceDatabasePath, $"*.{Config.ImageFileExtension}", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                string[] objectPath = file.Split('\\');

                if (objectPath.Length < 2)
                {
                    throw new Exception("Bad object path");
                }

                string objectName = objectPath[objectPath.Length - 2];
                string objectCreationDateRaw = objectPath[objectPath.Length - 1].Split('.')[0];

                FaceData faceData = new FaceData
                {
                    CreateDate = new DateTime(1970, 1, 1).AddMilliseconds(double.Parse(objectCreationDateRaw)),
                    FaceImage = new Image<Gray, byte>(file).Resize(200, 200, Inter.Cubic),
                    PersonName = objectName,
                };

                _faceList.Add(faceData);
            }

            int i = 0;
            foreach (var face in _faceList)
            {
                _imageList.Push(face.FaceImage.Mat);
                _nameList.Add(face.PersonName);
                _labelList.Push(new[] { i++ });
            }

            TrainEigenFaceRecognizer(_imageList, _labelList);
        }

        private void TrainEigenFaceRecognizer(VectorOfMat imageList, VectorOfInt labelList, double eigenThreshold = default)
        {

            if (imageList.Size == 0 || labelList.Size == 0)
            {
                MessageBox.Show("No data in database. If this is your first time, ignore this warning.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (imageList.Size != labelList.Size)
            {
                MessageBox.Show("Something went wrong when training EigenFaceRecognizer...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (eigenThreshold == default)
            {
                eigenThreshold = Config.EigenThreshold;
            }

            _recognizer = new EigenFaceRecognizer(_imageList.Size, eigenThreshold);
            _recognizer.Train(imageList, labelList);
        }

        private void RecognizeFace(Image<Gray, byte> detectedFace, ref string faceName)
        {
            detectedFace = detectedFace.Resize(Config.DataImageResolution, Config.DataImageResolution, Inter.Cubic);
            detectedFace._EqualizeHist();
            DetectedFacePreview = detectedFace;
            ReloadDetectedFacePreview();

            string tempName = faceName.Clone().ToString();
            if (_imageList.Size != 0 && _recognizer != null)
            {
                FaceRecognizer.PredictionResult result = _recognizer.Predict(detectedFace);

                if (result.Label != -1 && Config.MinRecognitionAccuracyPercentage < Config.EigenThreshold)
                {

                    if (ThresholdDistance.InvokeRequired)
                    {
                        ThresholdDistance.Invoke(new ThreadStart(() =>
                        {
                            ThresholdDistance.Text = "Threshold Distance: " + result.Distance;
                        }));
                    }

                    faceName = _nameList[result.Label];
                    RegisteredFacePreview = _faceList[result.Label].FaceImage;
                    ReloadRegisteredFacePreview();
                }
            }

            detectedFace.Dispose();

        }

        private bool AreRequiredFilesValid()
        {
            try
            {
                if (!File.Exists(Config.HaarCascadeClassifierPath))
                {
                    string message = "Could not find Haar Cascade Classifier file in: "
                                    + $"\"{Config.HaarCascadeClassifierPath}\"";
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!Directory.Exists(Config.FaceDatabasePath))
                {
                    Directory.CreateDirectory(Config.FaceDatabasePath);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }

            return true;
        }

        private void RegisterFaceButton_Click(object sender, EventArgs e)
        {
            if (!AreRequiredFilesValid())
            {
                MessageBox.Show("Required files are not valid and could not be fixed automatically.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (FaceNameTxtBox.Text == "")
            {
                MessageBox.Show("Invalid Face Name, please enter one!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int tries = 0;
            while (true)
            {
                if (DetectedFacePreview.Data != null)
                {
                    break;
                }

                if (tries > 100)
                {
                    MessageBox.Show("Could not capture face. Try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                tries++;
                Thread.Sleep(10); // NOTE: Wait for detected face to set
            }

            string objectFolderName = FaceNameTxtBox.Text;
            long currentMilliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            string fileName = $"{currentMilliseconds}.{Config.ImageFileExtension}";
            string directoryPath = Config.FaceDatabasePath + $@"{objectFolderName}\";

            registeringNotificationLabel.Visible = true;

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            Bitmap bpmImage = DetectedFacePreview.ToBitmap(Config.DataImageResolution, Config.DataImageResolution);
            bpmImage.Save(directoryPath + fileName, Config.ImageFileExtension);

            GetFaceList();
            MessageBox.Show($"Face registered under name \"{objectFolderName}\\{fileName}\" and re-trained current model.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            registeringNotificationLabel.Visible = false;
        }


        private void ReTrainModelButton_Click(object sender, EventArgs e)
        {
            GetFaceList();
        }

        private void ChangeEigenThreshold_ValueChanged(object sender, EventArgs e)
        {
            ChangeEigenThresholdValue((double)ChangeEigenThreshold.Value);
        }

        private void ChangeEigenThresholdValue(double value)
        {
            Config.EigenThreshold = value;

            if (_imageList.Size != 0)
            {
                TrainEigenFaceRecognizer(_imageList, _labelList);
            }
        }
    }
}
