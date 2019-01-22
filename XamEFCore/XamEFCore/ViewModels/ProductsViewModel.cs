using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamEFCore.Interfaces;
using XamEFCore.Models;
using XamEFCore.Services;
using XamEFCore.Repository.GenericRepository;

namespace XamEFCore.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {


        #region Repository DataAccess
        private ServiceBase<Product> repositoryGeneric;
        #endregion Repository DataAccess

        #region Attributes
        private ObservableCollection<Product> products;
        private string title;
        private double price;
        private bool isRefreshing;
        #endregion Attributes

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set { SetValue(ref products, value); }
        }

        public string Title
        {
            get { return title; }
            set { SetValue(ref title, value); }
        }
        
        public double Price
        {
            get { return price; }
            set { SetValue(ref price, value); }
        }        
       
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        private string respCreated;

        public string RespCreated
        {
            get { return respCreated; }
            set { SetValue(ref this.respCreated, value); }
        }


        // Constructors
        public ProductsViewModel()
        {            
            // Iniciar el repositorio generico
            this.repositoryGeneric = new ServiceBase<Product>();
                      
            LoadData();                                 
        }

        public ICommand CreateCommand
        {
            get
            {
                return new Command(CreateExecute);
            }
        }
       
        public ICommand RefreshCommand
        {
            get
            {
                return new Command(LoadData);
            }
        }       

        private void LoadData()
        {
            this.IsRefreshing = true;
            
            this.Products = new ObservableCollection<Product>(repositoryGeneric.Get());

            this.IsRefreshing = false;
        }      

        private void CreateExecute()
        {
            var product = new Product()
            {
                Title = this.Title,
                Price = this.Price
            };

            if (repositoryGeneric.Create(product))
            {
                this.RespCreated = $"Producto Creado Exitosamente";

                this.Title = string.Empty;
                this.Price = 0;
            }

            else
            {
                this.RespCreated = $"Error al Crear el Producto en la Base de Datos";
            }
        }       
    }
}
