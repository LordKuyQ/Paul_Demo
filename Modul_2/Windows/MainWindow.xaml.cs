
using Modul_2.ViewControllers;
using System.Windows;
using System.Windows.Controls;
using Modul_2.Models;

namespace Modul_2
{
    public partial class MainWindow : Window
    {
        private readonly Database _context;
        public MainWindow(User user = null)
        {
            InitializeComponent();
            _context = new Database();
            if (user != null) 
            {
                RunUserName.Text = user.Fio;

            }
            else
            {
                RunUserName.Text = "гость";
            }
            LoadEquip();
        }
        private void LoadEquip()
        {
            try
            {
                using (var context = new Database())
                {
                    BoxProducts.ItemsSource = context.Products
                            .Select(e => new ProductItemController(e))
                            .ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Load error: {ex.Message}");
            }
        }

        private void BoxProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is not ListBox listBox || listBox.SelectedItem is not ProductItemController item)
            {
                return;
            }
            if (item.DataContext is not Product selectedProduct)
            {
                return;
            }

            try
            {
                using (var context = new Database())
                {
                    var productToUpdate = context.Products.Find(selectedProduct.Id);
                    if (productToUpdate != null)
                    {
                        productToUpdate.Discount += 10;
                        context.SaveChanges();
                        _context.Entry(selectedProduct).Reload();
                    }
                }

                listBox.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Upd error: {ex.Message}");
            }
        }

        private void ExitButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddProductButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void DelProductButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void OpenOrdersButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}