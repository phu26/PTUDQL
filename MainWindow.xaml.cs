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
using Aspose.Cells;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using Fluent;

namespace ImPort
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
   
   
    public partial class MainWindow : RibbonWindow, INotifyPropertyChanged
    {
        public MainWindow()
        {

            InitializeComponent();
        }
        class OrderDetail : INotifyPropertyChanged
        {
           
            public string Name { get; set; }
            public int Price { get; set; }

            private int _quantity;
            public int Quantity
            {
                get => _quantity; set
                {
                    _quantity = value;
                    NotifyChange("Quantity");
                    NotifyChange("Total");
                }
            }

            private void NotifyChange(string v)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(v));
                }
            }

            public int Total { get => Price * _quantity; }

            public event PropertyChangedEventHandler PropertyChanged;
        }
        BindingList<OrderDetail> _details = new BindingList<OrderDetail>();
      
      

        public static Category cat = new Category();
       List<Category> _categories = new List<Category>();
        Category x = new Category();
        
        
        List<Hurom> _list = null;
        public event PropertyChangedEventHandler PropertyChanged;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            _details = new BindingList<OrderDetail>();
            orderListView.ItemsSource = _details;
            this.DataContext = this;

            using (var db = new HREntities())
            {

                string[] g = new string[100];
                var select = from s in db.Hurom select s;
                string a;
                int dem = 0;
                int s1 = 0;
                foreach (var data in select)
                {

                    //Category x = new Category()
                    //{
                    //    Name = data.Series,
                    //    Products = new List<Product>{
                    //                new Product() {
                    //                 Name =data.Name,
                    //                 Price =(int)data.Price,
                    //                ImagePath ="avatar01.jpg"
                    //                  },

                    //            }




                    // };

                    if (dem == 0)
                    {
                        x.Products = null;
                        x.Name = data.Series;
                        if (data.Avatar != null)
                        {
                            x.Name = data.Series;
                            BindingList<Product> Products = new BindingList<Product>() {
                            new Product()
                        {
                            Name = data.Name,
                            Price = (int)data.Price,
                            ImagePath = data.Avatar

                        },
                    };
                            x.Products = Products;
                        }
                        else
                        {
                            if (data.Name == null)
                            {
                                x.Name = data.Series;
                                x.Products = null;
                            }
                            else
                            {
                                x.Name = data.Series;
                                BindingList<Product> Products = new BindingList<Product>() {
                            new Product()
                        {
                            Name = data.Name,
                            Price = (int)data.Price,


                        },
                    };
                                x.Products = Products;
                            }

                        }



                        _categories.Add(x);
                        g[0] = x.Name;
                        dem++;
                    }

                    else
                    {
                        var k = data.Series;
                        for (int i = 0; i < dem; i++)
                        {
                            if (k == g[i])
                            {
                                if (data.Name == null)
                                {
                                    break;
                                }
                                if (data.Avatar != null)
                                {

                                    if (_categories[i].Products != null)
                                    {
                                        Product m = new Product(data.Name, (int)data.Price, data.Avatar);
                                        var l = m;
                                        _categories[i].Products.Add(m);
                                    }
                                    else
                                    {
                                        BindingList<Product> Products = new BindingList<Product>() {
                            new Product()
                        {
                            Name = data.Name,
                            Price = (int)data.Price,
                             ImagePath = data.Avatar,

                        },
                                };
                                        _categories[i].Products = Products;
                                    }

                                }
                                else
                                {
                                    if (_categories[i].Products != null)
                                    {
                                        Product m = new Product(data.Name, (int)data.Price, " ");
                                        var l = m;
                                        _categories[i].Products.Add(m);
                                    }
                                    else
                                    {
                                        BindingList<Product> Products = new BindingList<Product>() {
                            new Product()
                        {
                            Name = data.Name,
                            Price = (int)data.Price,


                        },
                                };
                                        _categories[i].Products = Products;
                                    }

                                }

                                break;

                            }

                            else
                            {
                                if (data.Avatar != null)
                                {
                                    if (i == dem - 1)
                                    {
                                        Category x = new Category();
                                        x.Name = data.Series;
                                        if (data.Name != null)
                                        {
                                            BindingList<Product> Products = new BindingList<Product>() {
                            new Product()
                        {
                            Name = data.Name,
                            Price = (int)data.Price,
                            ImagePath = data.Avatar

                        },
                                };
                                            x.Products = Products;
                                            _categories.Add(x);
                                            g[dem] = x.Name;
                                            s1++;
                                            dem++;
                                            break;
                                        }
                                        else
                                        {
                                            _categories.Add(x);
                                            g[dem] = x.Name;
                                            s1++;
                                            dem++;
                                            break;
                                        }

                                    }
                                }
                                else
                                {
                                    if (i == dem - 1)
                                    {
                                        Category x = new Category();
                                        x.Name = data.Series;
                                        if (data.Name != null)
                                        {
                                            BindingList<Product> Products = new BindingList<Product>() {
                            new Product()
                        {
                            Name = data.Name,
                            Price = (int)data.Price,


                        },
                                };
                                            x.Products = Products;
                                            _categories.Add(x);
                                            g[dem] = x.Name;
                                            s1++;
                                            dem++;
                                            break;
                                        }
                                        else
                                        {
                                            _categories.Add(x);
                                            g[dem] = x.Name;
                                            s1++;
                                            dem++;
                                            break;
                                        }

                                    }
                                }


                            }
                        }


                    }








                }


            }

            category.ItemsSource = _categories;


        }
        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            var db = new HREntities();
            _list = new List<Hurom>();

            string currentFolder = AppDomain.CurrentDomain.BaseDirectory;
            var baseFolder = currentFolder.Substring(0, currentFolder.Length - 1);

            //string avatar = currentFolder + "avatars/avatar01.jpg";
            //ava.Source = new BitmapImage(new Uri(avatar, UriKind.Absolute));
            //Debug.WriteLine(currentFolder);



           

            
            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                var filename = screen.FileName;

                var info = new FileInfo(filename);
                var folder = info.Directory;

                var workbook = new Workbook(filename);
                var sheet = workbook.Worksheets[0];

                var column = 'B';
                var row = 5;
                string[] t = new string[100];
                int z = 0;
                var cell = sheet.Cells[$"{column}{row}"];
                while (cell.Value != null)
                {
                    var id = sheet.Cells[$"B{row}"].StringValue;
                    var series = sheet.Cells[$"C{row}"].StringValue;
                    var name = sheet.Cells[$"D{row}"].StringValue;
                    var imagePath = sheet.Cells[$"F{row}"].StringValue;
                    imagePath = folder + @"\avatars\" + imagePath;
                    var imgInfo = new FileInfo(imagePath);
                    var price = sheet.Cells[$"E{row}"].StringValue;

                    var newName = Guid.NewGuid()
                        + "." + imgInfo.Extension;

                    imgInfo.CopyTo(baseFolder + @"\pic\" +
                        newName);

                    Debug.WriteLine($"{id} - {series} - {name} - {price} - {imagePath}");



                   

          

                
                   
                    if (z!=0)
                    {
                        for (int i=0;i<z; i++)
                    {
                            if(i==z-1)
                            {
                                if (series != t[i])
                                {
                                    t[z] = series;
                                    z++;
                                    var h = new Hurom()
                                    {

                                        Series = series,
                                        Name = name,
                                        Price = int.Parse(price),
                                        Avatar = newName

                                    };
                                    var h2 = new Hurom()
                                    {

                                        Series = series,

                                    };
                                    db.Hurom.Add(h2);
                                    db.Hurom.Add(h);
                                    break;
                                }
                                else
                                {
                                    var h = new Hurom()
                                    {

                                        Series = series,
                                        Name = name,
                                        Price = int.Parse(price),
                                        Avatar = newName

                                    };
                                    db.Hurom.Add(h);
                                    break;
                                }

                            }

                        }
                    }
                    else
                    {
                        t[z] = series;
                        z++;
                        var h = new Hurom()
                        {

                            Series = series,
                            Name = name,
                            Price = int.Parse(price),
                            Avatar = newName

                        };
                        var h2 = new Hurom()
                        {

                            Series = series,

                        };
                        db.Hurom.Add(h2);
                        db.Hurom.Add(h);
                    }

                   


                    //db.Products.Add(product);
                    //_list.Add(emloy);

                    row++;
                    cell = sheet.Cells[$"{column}{row}"];
                }
                MessageBox.Show("Done, all products have been imported");
                db.SaveChanges();
                MainWindow l = new MainWindow();
                this.Close();
                l.ShowDialog();
            }
        }
        public int FinalTotal
        {
            get => _details.Sum(detail => detail.Total);
            //get  {
            //    int sum = 0; 
            //    for (int i = 0; i < _details.Count; i++)
            //    {
            //        var detail = _details[i];
            //        sum += detail.Total;
            //    }
            //    return sum;
            //}
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var stackPanel = sender as StackPanel;
            var product = stackPanel.DataContext as Product;

            //var found = false;
            //OrderDetail foundDetail = null;

            //for (int i = 0; i < _details.Count; i++)
            //{
            //    var detail = _details[i];
            //    if (detail.ProductSKU == product.SKU)
            //    {
            //        found = true;
            //        foundDetail = detail;
            //        break;
            //    }
            //}
            var foundProduct = _details.FirstOrDefault(
                p => p.Name == product.Name);

            if (foundProduct != null)
            {
                foundProduct.Quantity++;
            }
            else
            {
                var detail = new OrderDetail()
                {
                    
                    Name = product.Name,
                    Quantity = 1,
                    Price = product.Price
                };

                _details.Add(detail);
            }

            NotifyChange("FinalTotal");
        }
        private void NotifyChange(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(v));
            }
        }
      
        private Category getcat()
        {
            Category cate = new Category();
            cate = category.SelectedItem as Category;
            return cate;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var menu = sender as System.Windows.Controls.MenuItem;
            if(menu ==null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa");
                return;
               
            }
            else
            {
                var product = menu.DataContext as Product;
                var cate = category.SelectedItem as Category;


                var db = new HREntities();
                string a = cate.Name;
                string b = product.Name;
                var kq = from s in db.Hurom where s.Series == a where s.Name == b select s;


                db.Hurom.Remove(kq.First());
                db.SaveChanges();




                MainWindow l = new MainWindow();
                this.Close();
                l.ShowDialog();
            }


           
          

           






        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var cate = category.SelectedItem as Category;
            if(cate==null)
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm cần thêm sản phẩm");
                return;
            }
            else
            {
                var screen = new AddProduct(cate);
                screen.ShowDialog();
            }
          

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            var cate = category.SelectedItem as Category;
            var db = new HREntities();
            if(cate ==null)
            {
                MessageBox.Show("Vui lòng chọn category cần xóa");
                return;
            }
            else
            {
                string a = cate.Name;

                var kq = from s in db.Hurom where s.Series == a select s;

                if (kq.Count() > 1)
                {
                    MessageBox.Show("còn sản phẩm không thể xóa Category này");

                }
                else
                {
                    if (kq.First().Name == null)
                    {
                        db.Hurom.Remove(kq.First());
                        db.SaveChanges();
                        MainWindow l = new MainWindow();
                        this.Close();
                        l.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("còn sản phẩm không thể xóa Category này");
                    }



                }
            }
            
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddCate n = new AddCate();
            this.Close();
            n.ShowDialog();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var cate = category.SelectedItem as Category;
            if(cate == null)
            {
                MessageBox.Show("chưa chọn category cần edit");
            }
            else
            {
                EditCate m = new EditCate(cate);
                this.Close();
                m.ShowDialog();
            }
           
        }
        private void BackstageTabItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
