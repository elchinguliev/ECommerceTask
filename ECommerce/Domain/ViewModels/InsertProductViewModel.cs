﻿using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Abstractions;
using ECommerce.Domain.Concretes;
using ECommerce.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ECommerce.Domain.ViewModels
{
    public class InsertProductViewModel:BaseViewModel
    {

        public RelayCommand InsertCommand { get; set; }
        public IRepository<Product> _productRepo { get; set; }


        public InsertProductViewModel(IRepository<Product> customers)
        {
            InsertProduct ip = new InsertProduct();
            _productRepo=new ProductRepository();
            _productRepo=customers;
            InsertCommand=new RelayCommand((obj) =>
            {
                var window = obj as Window;

                var prodcutName = ip.insertNameTxt.Text;
                var description = ip.insertDescriptionTxt.Text;
                var price = int.Parse(ip.insertPriceTxt.Text);
                var discount = int.Parse(ip.insertDiscountTxt.Text);
                int quantity = int.Parse(ip.insertQuantityTxt.Text);
                int id = _productRepo.GetAll().Last().Id;

                Product product = new Product
                {
                    Id=++id,
                    Name=prodcutName,
                    Description=description,
                    Price=price,
                    Discount=discount,
                    Quantity=quantity

                };
                _productRepo.AddData(product);



            });

        }


    }
}
