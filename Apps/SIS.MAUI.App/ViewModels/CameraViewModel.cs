using System.Collections.ObjectModel;
using System.ComponentModel;
using ZXing;
using Camera.MAUI.ZXingHelper;
using Camera.MAUI;
using CommunityToolkit.Maui.Views;
//using HomeKit;

namespace UraniumApp.ViewModels
{
    public class CameraViewModel : INotifyPropertyChanged
    {
        private CameraInfo _cameraInfo = null;
        public CameraInfo CameraInfo
        {
            get => _cameraInfo;
            set
            {
                _cameraInfo = value;
                OnPropertyChanged(nameof(CameraInfo));
                AutoStartPreview = false;
                OnPropertyChanged(nameof(AutoStartPreview));
                AutoStartPreview = true;
                OnPropertyChanged(nameof(AutoStartPreview));
            }
        }

        private CameraView _cameraView = null;
        public CameraView CameraView
        {
            get => _cameraView;
            set
            {
                _cameraView = value;
                OnPropertyChanged(nameof(CameraView));            }
        }

        private ObservableCollection<CameraInfo> _cameras = new();
        public ObservableCollection<CameraInfo> Cameras
        {
            get => _cameras;
            set
            {
                _cameras = value;
                OnPropertyChanged(nameof(Cameras));
            }
        }

        public int NumCameras
        {
            set
            {
                if (value > 0)
                    CameraInfo = Cameras.First();
            }
        }

        private MicrophoneInfo _micro = null;
        public MicrophoneInfo Microphone
        {
            get => _micro;
            set
            {
                _micro = value;
                OnPropertyChanged(nameof(Microphone));
            }
        }

        private ObservableCollection<MicrophoneInfo> _micros = new();
        public ObservableCollection<MicrophoneInfo> Microphones
        {
            get => _micros;
            set
            {
                _micros = value;
                OnPropertyChanged(nameof(Microphones));
            }
        }

        public int NumMicrophones
        {
            set
            {
                if (value > 0)
                    Microphone = Microphones.First();
            }
        }

        public MediaSource VideoSource { get; set; }

        public BarcodeDecodeOptions BarCodeOptions { get; set; }

        public string BarcodeText { get; set; } = "No barcode detected";
        public bool AutoStartPreview { get; set; } = false;
        public bool AutoStartRecording { get; set; } = false;

        private Result[] _barCodeResults;
        public Result[] BarCodeResults
        {
            get => _barCodeResults;
            set
            {                
                _barCodeResults = value;
                if (_barCodeResults != null && _barCodeResults.Length > 0)
                    BarcodeText = _barCodeResults[0].Text;
                else
                    BarcodeText = "No barcode detected";
                OnPropertyChanged(nameof(BarcodeText));
            }
        }

        private bool _takeSnapshot = false;
        public bool TakeSnapshot
        {
            get => _takeSnapshot;
            set
            {
                _takeSnapshot = value;
                OnPropertyChanged(nameof(TakeSnapshot));
            }
        }

        public float SnapshotSeconds { get; set; } = 0f;

        public string Seconds
        {
            get => SnapshotSeconds.ToString();
            set
            {
                if (float.TryParse(value, out float seconds))
                {
                    SnapshotSeconds = seconds;
                    OnPropertyChanged(nameof(SnapshotSeconds));
                }
            }
        }
        public Command StartCamera { get; set; }
        public Command StopCamera { get; set; }
        public Command TakeSnapshotCmd { get; set; }
        public Command SaveSnapshotCmd { get; set; }
        public string RecordingFile { get; set; }
        public Command StartRecording { get; set; }
        public Command StopRecording { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public CameraViewModel()
        {
            BarCodeOptions = new Camera.MAUI.ZXingHelper.BarcodeDecodeOptions
            {
                AutoRotate = true,
                PossibleFormats = { ZXing.BarcodeFormat.QR_CODE },
                ReadMultipleCodes = false,
                TryHarder = true,
                TryInverted = true
            };
            OnPropertyChanged(nameof(BarCodeOptions));
            StartCamera = new Command(() =>
            {
                AutoStartPreview = true;
                OnPropertyChanged(nameof(AutoStartPreview));
            });
            StopCamera = new Command(() =>
            {
                AutoStartPreview = false;
                OnPropertyChanged(nameof(AutoStartPreview));
            });
            TakeSnapshotCmd = new Command(() =>
            {
                TakeSnapshot = false;
                TakeSnapshot = true;
            });
            SaveSnapshotCmd = new Command(() =>
            {
                //var s = CameraView.SnapShot;

                var success = CameraView.SaveSnapShot(Camera.MAUI.ImageFormat.PNG, @"c:/tmp/picture.png");
            });
#if IOS
            RecordingFile = Path.Combine(FileSystem.Current.CacheDirectory, "Video.mov");
#else
            RecordingFile = Path.Combine(FileSystem.Current.CacheDirectory, "Video.mp4");
#endif
            OnPropertyChanged(nameof(RecordingFile));
            StartRecording = new Command(() =>
            {
                AutoStartRecording = true;
                OnPropertyChanged(nameof(AutoStartRecording));
            });
            StopRecording = new Command(() =>
            {
                AutoStartRecording = false;
                OnPropertyChanged(nameof(AutoStartRecording));
                VideoSource = MediaSource.FromFile(RecordingFile);
                OnPropertyChanged(nameof(VideoSource));
            });
            OnPropertyChanged(nameof(StartCamera));
            OnPropertyChanged(nameof(StopCamera));
            OnPropertyChanged(nameof(TakeSnapshotCmd));
            OnPropertyChanged(nameof(SaveSnapshotCmd));
            OnPropertyChanged(nameof(StartRecording));
            OnPropertyChanged(nameof(StopRecording));
        }
    }
}
