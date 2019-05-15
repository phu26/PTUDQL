using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ImPort
{
    /// <summary>
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    
    public partial class EditProduct : Window
    {
        Product _product;
      
        public EditProduct(Product product)
        {
            InitializeComponent();

            _product = product;
            
           
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
           if(nameTextBox.Text == "" || priceTextBox.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên và giá sản phẩm");
                return;
            }

            else
            {
                _product.Name = nameTextBox.Text;
                _product.Price = int.Parse(priceTextBox.Text);
                this.DialogResult = true;
            }


        
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            nameTextBox.Text = _product.Name;
            priceTextBox.Text = _product.Price.ToString();
            
        }

        //private void OK_Click(object sender, RoutedEventArgs e)
        //{
        //    string currentFolder = AppDomain.CurrentDomain.BaseDirectory;
        //    var baseFolder = currentFolder.Substring(0, currentFolder.Length - 1);
        //    var screen = new OpenFileDialog();
        //    if (screen.ShowDialog() == true)
        //    {
        //        var filename = screen.FileName;

        //        var info = new FileInfo(filename);
        //        var folder = info.Directory;
        //        //var imagePath = info;
        //        //var imgInfo = new FileInfo(imagePath);
               

        //        //var newName = Guid.NewGuid()
        //        //    + "." + imgInfo.Extension;

        //        //imgInfo.CopyTo(baseFolder + @"\pic\" +
        //        //    newName);
        //    }
        //}

    }
}
