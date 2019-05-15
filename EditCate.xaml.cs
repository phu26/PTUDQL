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
    /// Interaction logic for EditCate.xaml
    /// </summary>
    public partial class EditCate : Window
    {
        public Category _category;
        public EditCate(Category cat)
        {
            InitializeComponent();
            _category = cat;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Seriestxt == null )
            {
                MessageBox.Show("Không được để trống");
                return;
            }
            else
            {
                Category x = new Category();
                x.Name = Seriestxt.Text; ;

                x.Products = _category.Products;

                var db = new HREntities();
                string a = _category.Name;

                var kq = from s in db.Hurom where s.Series == a select s;
                foreach (var data in kq)
                {
                    db.Hurom.Remove(data);
                }

                for (int i = 0; i < x.Products.Count(); i++)
                {

                    var h = new Hurom()
                    {

                        Series = x.Name,
                        Name = x.Products[i].Name,
                        Price = x.Products[i].Price,
                        Avatar = x.Products[i].ImagePath

                    };
                    db.Hurom.Add(h);
                }





                db.SaveChanges();


                MainWindow xx = new MainWindow();
                this.Close();
                xx.ShowDialog();


            }

            this.DialogResult = true;
        }
    }
}
