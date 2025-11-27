
using Microsoft.EntityFrameworkCore;
using Modul_2.Models;
using Modul_2.ViewControllers;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Modul_2
{
    public partial class MainWindow : Window
    {
        private readonly Database _context;

        private ObservableCollection<ProductItemController> Products;
        public MainWindow(User user = null)
        {
            InitializeComponent();
            _context = new Database();
            if (user != null) 
            {
                RunUserName.Text = user.Fio;
                switch (user.IdRoleNavigation.Role1) 
                {
                    case "Авторизированный клиент":
                        {
                            break;
                        }
                    case "Менеджер":
                        {
                            PanelFind.Visibility = Visibility.Visible;
                            OpenOrdersButton.Visibility = Visibility.Visible;
                            break;
                        }
                    case "Администратор":
                        {
                            PanelFind.Visibility = Visibility.Visible;
                            PanelCRUD.Visibility = Visibility.Visible;
                            OpenOrdersButton.Visibility = Visibility.Visible;
                            BoxProducts.MouseDoubleClick += MouseDoubleEditProduct;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
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










                    var items = context.Products
                        .Include(e => e.IdProducerNavigation)
                        .Include(e => e.IdProviderNavigation)
                        .Include(e => e.IdCategoryProductNavigation)
                        .Include(e => e.IdTypeProductNavigation)
                        .ToList();

                    Products = new ObservableCollection<ProductItemController>(
                        items.Select(e => new ProductItemController(e))
                    );
                    BoxProducts.ItemsSource = Products;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Load error: {ex.Message}");
            }
        }

        private void ExitButton(object sender, RoutedEventArgs e)
        {
            Authorization authwindow = new Authorization();
            authwindow.Show();
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

        private void MouseDoubleEditProduct(object sender, System.Windows.Input.MouseButtonEventArgs e)
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
                        MessageBox.Show(selectedProduct.ToString());
                    }
                }

                listBox.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Upd error: {ex.Message}");
            }
        }
    }
}