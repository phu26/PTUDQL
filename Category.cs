using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImPort
{
    public class Category : INotifyPropertyChanged
    {
        private BindingList<Product> _products;
        public string Name { get; set; }

        public BindingList<Product> Products
        {
            get => _products; set
            {
                _products = value;
                NotifyChange("Products");
            }
        }
        public Category()
        {
            return;
        }
        
        public Category(string x)
        {
            Name = x;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class Product : INotifyPropertyChanged
    {
        private string _name;
        private int _price;

        public string ImagePath { get; set; }
        public string Name
        {
            get => _name; set
            {
                _name = value;
                NotifyChange("Name");
            }
        }
        public Product()
        {
            return;
        }
        public Product(string x,int y,string z)
        {
            Name = x;
            Price = y;
            ImagePath = z;
        }
        private void NotifyChange(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        public int Price
        {
            get => _price; set
            {
                _price = value;
                NotifyChange("Price");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
