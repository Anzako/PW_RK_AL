using Model;
using System.Collections;
using System.Windows.Input;

namespace ViewModel 
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly ModelAbstractApi _modelApi;
        private int _BallVal = 1;
        private int _width;
        private int _height;
        private IList _ballsList;

        private int size = 0;
        private bool _isStopEnabled = false;
        private bool _isStartEnabled = false;
        private bool _isAddEnabled = true;

        public ICommand addCommand { get; set; }
        public ICommand stopCommand;
        public ICommand RunCommand { get; set; }

        public MainWindowViewModel() : this(ModelAbstractApi.CreateModelApi(800, 400))
        { }

        public MainWindowViewModel(ModelAbstractApi modelAbstractApi)
        {
            _modelApi = modelAbstractApi;
            _width = _modelApi.Width;
            _height = _modelApi.Height;
            addCommand = new RelayCommand(AddBalls);
            StopCommand = new RelayCommand(Stop);
            RunCommand = new RelayCommand(Start);
        }

        public int BallVal
        {
            get { return _BallVal; }
            set
            {
                _BallVal = value;
                RaisePropertyChanged();
            }
        }

        public int Height
        {
            get { return _height;} 
        }

        public int Width
        {
            get { return _width; }
        }

        public ICommand AddCommand 
        { 
            get => addCommand; 
            set => addCommand = value; 
        }

        public ICommand StopCommand
        { 
            get; 
            set; 
        }

        private void AddBalls()
        {
            size += BallVal;
            if (size > 0)
            {
                isRunEnabled = true;
            }
            else
            {
                size = 0;
                isRunEnabled = false;
            }
            _ballsList = _modelApi.Start(BallVal);
            BallVal = 1;

        }

        public bool isStopEnabled
        {
            get { return _isStopEnabled; }
            set
            {
                _isStopEnabled = value;
                RaisePropertyChanged();
            }
        }

        public bool isRunEnabled
        {
            get { return _isStartEnabled; }
            set
            {
                _isStartEnabled = value;
                RaisePropertyChanged();
            }
        }

        public bool isAddEnabled
        {
            get
            {
                return _isAddEnabled;
            }
            set
            {
                _isAddEnabled = value;

                RaisePropertyChanged();
            }
        }

        private void Stop()
        {
            isStopEnabled = false;
            isAddEnabled = true;
            isRunEnabled = true;
            _modelApi.Stop();
        }
        private void Start()
        {
            isStopEnabled = true;
            isRunEnabled = false;
            isAddEnabled = false;
            _modelApi.StartMoving();
        }
        public IList Balls
        {
            get => _ballsList;
            set
            {
                if (value.Equals(_ballsList))
                {
                    return;
                }

                _ballsList = value;
                RaisePropertyChanged();
            }
        }

    }
}
