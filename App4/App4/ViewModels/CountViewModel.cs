using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App4.ViewModels
{
    public class CountViewModel : BaseViewModel
    {
        int _count;
        ICommand _buttonClickCommand;
        ICommand _buttonResetCommand;
        string _countConverted;

        public CountViewModel()
        {
            _count = 0;
        }

        public int Contador
        {
            get => _count;
            set
            {
                if (value == _count) return;
                {
                    _count = value;
                    CountConverter = $"Has dado click {_count} veces";
                    OnPropertyChanged();
                }
            }
        }

        public string CountConverter
        {
            get => _countConverted;
            set
            {
                if (string.Equals(_countConverted, value)) return;
                _countConverted = value;
                OnPropertyChanged();
            }
        }

        public ICommand ButtonClickCommand
        {
            get
            {
                if (_buttonClickCommand == null)
                 _buttonClickCommand = new Command(ButtonClickAction);
                return _buttonClickCommand;
            }
        }

        private void ButtonClickAction()
        {
            Contador++;
        }

        public ICommand ButtonResetCommand
        {
            get
            {
                if (_buttonResetCommand == null)
                    _buttonResetCommand = new Command(ButtonResetAction);
                return _buttonResetCommand;
            }
        }
        private void ButtonResetAction()
        {
            CountConverter = "Resetado pa";
            _count = 0;
        }
    }
}
