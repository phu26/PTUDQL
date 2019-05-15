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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImPort
{
    /// <summary>
    /// Interaction logic for ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        
        public ProductUserControl()
        {
            InitializeComponent();
           
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var product = this.DataContext as Product;
           if(product == null)
            {
                MessageBox.Show("vui lòng chọn sản phẩm cần chỉnh sửa");
            }
            else
            {
                var screen = new EditProduct(product);
                screen.ShowDialog();
            }
           
        }

    }
}
