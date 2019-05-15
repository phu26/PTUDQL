using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
       
        Category _category;
        public AddProduct(Category cate)
        {
            InitializeComponent();
           
            _category = cate;
        }
       
       

            
        
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            using (var db = new HREntities())
            {
                if(nameTextBox.Text == "" || priceTextBox.Text == "")
                {
                    MessageBox.Show("phải nhập đầy đủ thông tin");
                    return;
                }
                else
                {
                    Product _product = new Product();
                    _product.Name = nameTextBox.Text;
                    _product.Price = int.Parse(priceTextBox.Text);
                    
                    if (_category.Products == null)
                    {
                        BindingList<Product> Products = new BindingList<Product>() {
                            new Product()
                        {
                            Name = _product.Name,
                            Price = _product.Price,


                        },
                                };
                        _category.Products = Products;
                    }
                    else
                    {
                        _category.Products.Add(_product);
                    }



                    var h = new Hurom()
                    {

                        Series = _category.Name,
                        Name = _product.Name,
                        Price = _product.Price,


                    };
                    db.Hurom.Add(h);
                    db.SaveChanges();
                    this.DialogResult = true;
                }

                
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
