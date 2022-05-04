using Model;
using System.Windows.Controls;
using System.Windows.Input;

namespace ViewModel 
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly ModelAbstractApi _modelApi;
        private int _BallVal;
        private int _width;
        private int _height;
        private ICommand addCommand;

        public MainWindowViewModel() : this(ModelAbstractApi.CreateModelApi(500, 400, 10))
        { }

        public MainWindowViewModel(ModelAbstractApi modelAbstractApi)
        {
            _modelApi = modelAbstractApi;
            _width = _modelApi.width;
            _height = _modelApi.height;
            addCommand = new RelayCommand(CreateEllipses);
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

        public Canvas Canvas
        {
            get => _modelApi.Canvas;
        }

        public ICommand AddCommand 
        { 
            get => addCommand; 
            set => addCommand = value; 
        }

        private void CreateEllipses()
        {
            _modelApi.CreateEllipses(BallVal);
        }
        
    }
}
