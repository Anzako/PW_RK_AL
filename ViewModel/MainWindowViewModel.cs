using Model;
using System.Collections;
using System.Windows.Input;

namespace ViewModel 
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly ModelAbstractApi _modelApi;
        private int _BallVal;
        private int _width;
        private int _height;
        private IList _ballsList;

        private int size = 0;
        private bool _isStop = false;
        private bool _isStart = false;
        private bool _isAdd = true;

        public ICommand addCommand { get; set; }
        public ICommand stopCommand;
        public ICommand RunCommand { get; set; }

        public MainWindowViewModel() : this(ModelAbstractApi.CreateModelApi(800, 400))
        { }

        public MainWindowViewModel(ModelAbstractApi modelAbstractApi)
        {
            BallVal = 0;
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
                isRun = true;
            }
            else
            {
                size = 0;
                isRun = false;
            }
            Balls = _modelApi.Start(BallVal);
        }

        public bool isStop
        {
            get { return _isStop; }
            set
            {
                _isStop = value;
                RaisePropertyChanged();
            }
        }

        public bool isRun
        {
            get { return _isStart; }
            set
            {
                _isStart = value;
                RaisePropertyChanged();
            }
        }

        public bool isAdd
        {
            get
            {
                return _isAdd;
            }
            set
            {
                _isAdd = value;

                RaisePropertyChanged();
            }
        }

        private void Stop()
        {
            isStop = false;
            isAdd = true;
            isRun = true;
            _modelApi.Stop();
        }
        private void Start()
        {
            isStop = true;
            isRun = false;
            isAdd = false;
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
