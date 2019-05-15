using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddCate.xaml
    /// </summary>
    public partial class AddCate : Window
    {
        public AddCate()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if(Series.Text == "")
            {
                MessageBox.Show( "Vui lòng nhập tên category cần thêm");
                return;
            }
            else
            {
                var db = new HREntities();
                var h = new Hurom()
                {
                    Series = Series.Text,

                };
                db.Hurom.Add(h);
                db.SaveChanges();
                MainWindow l = new MainWindow();
                this.Close();
                l.ShowDialog();
            }
          
        }

        private void Series_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
