using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private ModelAbstractApi ModelLayer;

        public MainWindowViewModel()
        {

            ModelLayer = ModelLayer.CreateModelApi(30, 600, 480);

        }

    }
}
