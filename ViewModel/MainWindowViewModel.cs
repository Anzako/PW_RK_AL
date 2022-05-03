using Model;
using System.Windows.Controls;
using System.Windows.Input;

namespace ViewModel 
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly ModelAbstractApi _modelApi;
        private int _BallVal;
        private ICommand addCommand;

        public MainWindowViewModel()
        {
            _modelApi = ModelAbstractApi.CreateModelApi(100,50,200);   //zmienić 
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
