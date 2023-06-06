 using ECommerce.Commands;
using ECommerce.DataAccess.Concretes;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Abstractions;
using ECommerce.Domain.Concretes;
using ECommerce.Domain.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Configuration;


namespace ECommerce.Domain.ViewModels
{
    public class AdminViewModel:BaseViewModel
    {
        public RelayCommand InsertCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand ShowCommand { get; set; }

        EECommerceDataContext dataContext=new EECommerceDataContext();

        public IRepository<Product> _productRepo { get; set; }
        public IRepository<Customer> _customerRepo { get; set; }

        private Customer selectedProduct;
        public Customer SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(); }
        }
        public AdminViewModel()
        {
            _customerRepo = new CustomerRepository();
            _productRepo = new ProductRepository();
            SelectedProduct = new Customer();

            DeleteCommand = new RelayCommand((o) =>
            {

                var myGrid = o as Grid;

                var stackpanel = myGrid.Children[1] as StackPanel;
                var scroll = myGrid.Children[2] as ScrollViewer;
                var dataGrid = scroll.Content as DataGrid;


               
                 if ( true)
                {
                    try
                    {
                        var product = dataGrid.SelectedItem as Product;

                        if (product != null)
                        {
                            _productRepo.DeleteData(product);
                            MessageBox.Show("Product has ben deleted");
                        }
                        else
                            MessageBox.Show("Select one of the product for delete");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }


            });

            ShowCommand = new RelayCommand((obj) =>
            {
                var myGrid = obj as Grid;

                var stackpanel = myGrid.Children[1] as StackPanel;
                var scroll = myGrid.Children[2] as ScrollViewer;
                var dataGrid = scroll.Content as DataGrid;


                if (dataGrid.ItemsSource != null)
                {
                    dataGrid.ItemsSource = null;
                }
                if (true)
                {
                    dataGrid.ItemsSource=_productRepo.GetAll();
                }

                else
                    MessageBox.Show("Please select one of the choices");
            });
           
            InsertCommand = new RelayCommand((obj) =>
            {

                InsertProduct insertProducWindow = new InsertProduct();
                var vm = new InsertProductViewModel(_productRepo);
                insertProducWindow.DataContext = vm;
                insertProducWindow.ShowDialog();
                //var author = new Product
                //{

                //    Name = ip.insertNameTxt.Text,
                //    Description =ip.insertDescriptionTxt.Text,
                //    //Discount=ip.insertDiscountTxt.ToString() ,
                //    //Price=ip.insertPriceTxt.Text.ToString(),
                //    //Quantity=ip.insertQuantityTxt.Text.ToString()

                //};
                //dataContext.Products.InsertOnSubmit(author);
                //dataContext.SubmitChanges();

            });
            UpdateCommand = new RelayCommand((obj) =>
            {


            });




        }
    }
}
