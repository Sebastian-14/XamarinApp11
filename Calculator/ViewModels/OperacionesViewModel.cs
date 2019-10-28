using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calculator.ViewModels
{
    class OperacionesViewModel : ViewModelBase
    {
        string inputString = "";
        string displayText = "";
        char[] specialChars = { '*', '#' };

        
        // Constructor
        public OperacionesViewModel()
        {
            SelectNumber = new Command<string>((key) =>
            {
                InputString += key;
            });

            Delete = new Command(() =>
            {
                InputString = InputString.Substring(0, InputString.Length - 1);
            },
                () =>
                {
                    return InputString.Length > 0;
                });
        }

        public string InputString
        {
            protected set
            {
                if (inputString != value)
                {
                    inputString = value;
                    OnPropertyChanged();
                    DisplayText = inputString;

                    ((Command)Delete).ChangeCanExecute();
                }
            }

            get { return inputString; }
        }

        public string DisplayText
        {
            protected set
            {
                if (displayText != value)
                {
                    displayText = value;
                    OnPropertyChanged();
                }
            }
            get { return displayText; }
        }

        // ICommand
        public ICommand SelectNumber { protected set; get; }

        public ICommand Delete { protected set; get; }

    }
}