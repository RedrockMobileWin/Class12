using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class12.ViewModels
{
    public class AnimationPageViewModel : BaseViewModel
    {
        private Models.Lastest _lastest;
        public Models.Lastest Lastest
        {
            get
            {
                return _lastest;
            }
            set
            {
                _lastest = value;
                RaisePropertyChanged(nameof(Lastest));
            }
        }
    }
}
