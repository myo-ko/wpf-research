using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace WpfTest
{
    public class Notifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string pName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(pName));
        }
    }

    public class EgVM : Notifier
    {
        private Model _model;

        public Model Model
        {
            get { return _model; }
            set { _model = value; OnPropertyChanged(); }
        }

        private ICommand _cmd;

        public ICommand Command
        {
            get { return _cmd; }
            set { _cmd = value; }
        }


        public EgVM()
        {
            Model = new Model();
            Command = new RelayCommand(ExecuteCommand, canExecuteCommand);
            
        }

        public bool canExecuteCommand(object para)
        {
            return Model.Error == string.Empty;            
        }

        public void ExecuteCommand(object para)
        {
            Console.WriteLine("Command executed");
            Model.Name = "new name";
        }
    }

    public class RequiredValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string v = (string)value;
            if (v == "")
            {
                return new ValidationResult(false, "The field is empty");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }


}
