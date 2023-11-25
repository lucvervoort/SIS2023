
using Camera.MAUI;
using CodeProjectAI;
using System.Diagnostics;
//using UIKit;
using ZXing.Common;
using ZXing.PDF417.Internal;

namespace UraniumApp.Pages.FacesViews;

public partial class FacesViewPage : ContentPage
{
    //private bool _playing = false;
    const int _pingFrequency = 2;    // seconds
    const int _apiServerPort = 32168; // be default

    private readonly ApiClient _AIService = new(_apiServerPort);
    private bool _serverLive = false;
    private string _imageFileName = string.Empty;
    private string _faceImageFileName1 = string.Empty;
    private string _faceImageFileName2 = string.Empty;
    private string _recognizeImageFileName = string.Empty;
    private string _benchmarkFileName = string.Empty;
    private readonly List<string> _registerFileNames = new();

    private async void Ping(object sender, EventArgs e)
    {
        var response = await _AIService.Ping();
        if (_serverLive != response.success)
        {
            _serverLive = response.success;
            //if (response.success)
            //    SetStatus("Connection to AI Server established", Color.Green);
            //else
            //    ShowError("Unable to connect to AI server");
        }
    }

    private async void DetectFaceBtn_Click(object sender, EventArgs e)
    {
        ClearResults();
        SetStatus("Detecting faces.");

        if (string.IsNullOrWhiteSpace(_imageFileName))
        {
            ShowError("Image 1 must be selected.");
            return;
        }

        var result = await _AIService.DetectFaces(_imageFileName);
        if (result is DetectFacesResponse detectedFaces)
        {
            Image? image = GetImage(_imageFileName);
            if (image == null)
            {
                ShowError($"Unable to load image {_imageFileName}.");
                return;
            }

            /*
            Graphics canvas = Graphics.FromImage(image);
            Pen pen = new(Color.Yellow, 2);
            SolidBrush brush = new(Color.White);
            Font drawFont = new("Arial", 10);

            List<string> lines = new();

            if (detectedFaces.predictions is not null)
            {
                foreach (var (face, index) in detectedFaces.predictions
                    .Select((face, index) => (face, index)))
                {
                    lines.Add($"{index}: Confidence: {Math.Round(face.confidence, 3)}");

                    var rect = Rectangle.FromLTRB(face.x_min, face.y_min, face.x_max, face.y_max);
                    canvas.DrawRectangle(pen, rect);
                    canvas.DrawString(index.ToString(), drawFont, brush, face.x_min, face.y_min);
                }

                detectionResult.Lines = lines.ToArray();
            }

            pictureBox1.Image = image;
            */
            SetStatus("Face Detection complete");
        }
        else
        {
            ProcessError(result);
        }
    }

    private void ProcessError(ResponseBase result)
    {
    }

    private Image GetImage(string imageFileName)
    {
        return null;
    }

    private void ShowError(string v)
    {
    }

    private void SetStatus(string v)
    {
    }

    private void ClearResults()
    {
    }

    private async void CompareFacesBtn_Click(object sender, EventArgs e)
    {
        ClearResults();
        SetStatus("Comparing faces");

        if (string.IsNullOrWhiteSpace(_faceImageFileName1))
        {
            ShowError("Image 1 must be selected.");
            return;
        }
        if (string.IsNullOrWhiteSpace(_faceImageFileName2))
        {
            ShowError("Image 2 must be selected.");
            return;
        }

        var result = await _AIService.MatchFaces(_faceImageFileName1, _faceImageFileName2);
        if (result is MatchFacesResponse matchedFaces)
        {
            // detectionResult.Text = $"Similarity: {Math.Round(matchedFaces.similarity, 4)}";
            SetStatus("Face Comparison complete");
        }
        else
        {
            ProcessError(result);
        }
    }

    private async void DetectSceneBtn_Click(object sender, EventArgs e)
    {
        ClearResults();
        SetStatus("Detecting scene");

        if (string.IsNullOrWhiteSpace(_imageFileName))
        {
            ShowError("Image 1 must be selected.");
            return;
        }

        var result = await _AIService.DetectScene(_imageFileName);
        if (result is DetectSceneResponse detectedScene)
        {
            var image = GetImage(_imageFileName);
            // pictureBox1.Image = image;
            // detectionResult.Text = $"Confidence: {Math.Round(detectedScene.confidence, 3)} Label: {detectedScene.label}";
            SetStatus("Scene Detection complete");
        }
        else
        {
            ProcessError(result);
        }
    }

    private async void DetectObjectsBtn_Click(object sender, EventArgs e)
    {
        ClearResults();
        SetStatus("Detecting objects");

        if (string.IsNullOrWhiteSpace(_imageFileName))
        {
            ShowError("Image 1 must be selected.");
            return;
        }

        Stopwatch stopwatch = Stopwatch.StartNew();
        ResponseBase result = await _AIService.DetectObjects(_imageFileName);
        stopwatch.Stop();

        if (result is DetectObjectsResponse detectedObjects)
        {
            /*
            List<string> lines = new();
            try
            {
                lines.Add(stopwatch.Elapsed.ToString());
                if (detectedObjects.predictions is not null)
                    foreach (var (detectedObj, index) in detectedObjects.predictions
                        .Select((detected, index) => (detected, index)))
                    {
                        lines.Add($"{index}: Conf: {Math.Round(detectedObj.confidence, 3)} {detectedObj.label}");

                        var rect = Rectangle.FromLTRB(detectedObj.x_min, detectedObj.y_min,
                                                      detectedObj.x_max, detectedObj.y_max);
                    }

                detectionResult.Lines = lines.ToArray();

                Image? image = GetImage(_imageFileName);
                if (image == null)
                {
                    ShowError($"Unable to load image {_imageFileName}.");
                    return;
                }

                Graphics canvas = Graphics.FromImage(image);
                Pen pen = new(Color.Yellow, 2);
                SolidBrush brush = new(Color.White);
                Font drawFont = new("Arial", 10);

                if (detectedObjects.predictions is not null)
                {
                    foreach (var (detectedObj, index) in detectedObjects.predictions
                        .Select((detected, index) => (detected, index)))
                    {
                        var rect = Rectangle.FromLTRB(detectedObj.x_min, detectedObj.y_min,
                                                      detectedObj.x_max, detectedObj.y_max);
                        canvas.DrawRectangle(pen, rect);
                        canvas.DrawString($"{index}:{detectedObj.label}", drawFont, brush,
                                          detectedObj.x_min, detectedObj.y_min);
                    }
                }

                SetStatus("Object Detection complete");
                pictureBox1.Image = image;
            }
            catch (Exception ex)
            {
                ProcessError(new ErrorResponse(ex.Message));
                detectionResult.Lines = lines.ToArray();
            }
            */
        }
        else
        {
            ProcessError(result);
        }
    }

    private async void ListFacesBtn_Click(object sender, EventArgs e)
    {
        ClearResults();
        SetStatus("Listing known faces");

        var result = await _AIService.ListRegisteredFaces();
        if (result is ListRegisteredFacesResponse registeredFaces)
        {
            if (result?.success ?? false)
            {
                List<string> lines = new();
                if (registeredFaces.faces != null)
                {
                    var faceMap = registeredFaces.faces.Select((face, Index) => (face, Index));
                    foreach (var (face, index) in faceMap)
                    {
                        lines.Add($"{index}: {face}");
                    }

                    // detectionResult.Lines = lines.ToArray();
                    SetStatus("Face Listing complete");
                }
            }
        }
        else
            ProcessError(result);
    }

    private async void DeleteFaceBtn_Click(object sender, EventArgs e)
    {
        ClearResults();
        SetStatus("Deleting registered face");

        var result = await _AIService.DeleteRegisteredFace("demo");
        if (result?.success ?? false)
            SetStatus("Completed Face deletion");
        else
            ProcessError(result);
    }

    public FacesViewPage()
    {
        InitializeComponent();
        /*
        cameraView.CamerasLoaded += CameraView_CamerasLoaded;

        cameraView.BarcodeDetected += CameraView_BarcodeDetected;
        cameraView.BarCodeOptions = new Camera.MAUI.ZXingHelper.BarcodeDecodeOptions
        {
            AutoRotate = true,
            PossibleFormats = { ZXing.BarcodeFormat.QR_CODE, ZXing.BarcodeFormat.UPC_EAN_EXTENSION, ZXing.BarcodeFormat.CODE_128 },
            ReadMultipleCodes = false,
            TryHarder = true,
            TryInverted = true
        };
        cameraView.BarCodeDetectionFrameRate = 10;
        cameraView.BarCodeDetectionMaxThreads = 5;
        cameraView.ControlBarcodeResultDuplicate = true;
        cameraView.BarCodeDetectionEnabled = false;

        barcodeImage.Barcode = "SIS 2023";
        */

        Task.Run(() => _AIService.Ping());
    }

    /*
    private void CameraView_CamerasLoaded(object sender, EventArgs e)
    {
        Debug.WriteLine("Cameras loaded");
        if (cameraView.NumCamerasDetected > 0)
        {
            if (cameraView.NumMicrophonesDetected > 0)
                cameraView.Microphone = cameraView.Microphones.First();
            cameraView.Camera = cameraView.Cameras.First();            
        }    
    }

    private void CameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        Debug.WriteLine("BarcodeText=" + args.Result[0].Text);
    }

    private void PlayClicked(object sender, EventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            if (await cameraView.StartCameraAsync() == CameraResult.Success)
            {
                _playing = true;
            }
        });
    }

    private void StopClicked(object sender, EventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            if (await cameraView.StopCameraAsync() == CameraResult.Success)
            {
                _playing = false;
            }
        });
    }

    private void MirrorClicked(object sender, EventArgs e)
    {
        cameraView.MirroredImage = !cameraView.MirroredImage;
    }

    private void SnapshotClicked(object sender, EventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            ImageSource imageSource = cameraView.GetSnapShot(Camera.MAUI.ImageFormat.PNG);
            //var result = cameraView.SaveSnapShot(Camera.MAUI.ImageFormat.PNG, @"c:/tmp");
        });
    }

    private void PictureClicked(object sender, EventArgs e)
    { 
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            var stream = await cameraView.TakePhotoAsync();
            if (stream != null)
            {
                var result = ImageSource.FromStream(() => stream);
                //snapPreview.Source = result;
            }
        });
    }

    private void FlashClicked(object sender, EventArgs e)
    {
        cameraView.FlashMode = FlashMode.Auto;
    }

    private void TorchClicked(object sender, EventArgs e)
    {
        cameraView.TorchEnabled = !cameraView.TorchEnabled;
    }

    private void ZoomInClicked(object sender, EventArgs e)
    {
        if (cameraView.MaxZoomFactor >= 2.5f)
            cameraView.ZoomFactor = 2.5f;
    }

    private void ZoomOutClicked(object sender, EventArgs e)
    {
        if (cameraView.MaxZoomFactor >= 2.5f)
            cameraView.ZoomFactor = 2.5f;
    }
    */
}
