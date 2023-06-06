using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Services;
using ECommerce.Domain.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ECommerce.Domain.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        public RelayCommand ToLowerCommand { get; set; }
        public RelayCommand SelectProductCommand { get; set; }
        public RelayCommand AdminCommand { get; set; }
        bool _isCustomer;

        private readonly ProductService _productService;
        public MainViewModel()
        {
            _productService = new ProductService();
            filterText="Higher to Lower";
            AllProducts=_productService.GetFromHigherToLower(IsLower);
            ToLowerCommand=new RelayCommand((obj) =>
            {
                IsLower=!IsLower;
                if (!IsLower)
                {
                    FilterText="Lower to Higher";
                }
                else
                {
                    FilterText="Higher to Lower";

                }
                AllProducts=_productService.GetFromHigherToLower(IsLower);

            });
            SelectProductCommand = new RelayCommand((obj) =>
            {
                var vm = new ProductInfoViewModel();
                vm.ProductInfo = SelectedProduct;
                var view = new ProductÜindoü();
                view.DataContext = vm;
                view.ShowDialog();
            });

            AdminCommand=new RelayCommand((obj) =>
            {
                var button = obj as Button;
                    _isCustomer = false;

                    LoginWindow loginWindow = new LoginWindow();
                    LoginViewModel loginWindowViewModel = new LoginViewModel(_isCustomer);
                    loginWindow.DataContext = loginWindowViewModel;

                    loginWindow.ShowDialog();
                
            });
        }
       
        public bool IsLower { get; set; } = true;
        private string filterText;

        public string FilterText
        {
            get { return filterText; }
            set { filterText = value; OnPropertyChanged(); }
        }
        private ObservableCollection<Product> allProducts;
        public ObservableCollection<Product> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; OnPropertyChanged(); }
        }
        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(); }
        }

    }
}
