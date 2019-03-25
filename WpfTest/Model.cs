using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace WpfTest
{
    public class Model : Notifier, IDataErrorInfo
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("name_changed"); }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; OnPropertyChanged("address_changed"); }
        }        

        public string Error
        {
            get
            {
                string error = "";
                error += this["Name"] == string.Empty ? "" : Environment.NewLine + this["Name"];
                error += this["Address"] == string.Empty ? "" : Environment.NewLine + this["Address"];
                return error;
            }
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Name":
                        return this.Name == string.Empty ? "Name is required" : string.Empty;

                    case "Address":
                        return this.Address == string.Empty ? "Address is required" : string.Empty;
                }

                return string.Empty;
            }
        }

        public Model()
        {

        }
    }
}
