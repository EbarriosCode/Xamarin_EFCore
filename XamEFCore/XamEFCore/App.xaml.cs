using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEFCore.Interfaces;
using XamEFCore.Models;
using XamEFCore.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamEFCore
{
    public partial class App : Application
    {
        public static ProductsDbContext GetContext()
        {
            string DbPath = DependencyService.Get<IDataBaseService>().GetFullPath("efCore.db");

            return new ProductsDbContext(DbPath);
        }

        public App()
        {
            InitializeComponent();

            GetContext().Database.EnsureCreated();
            MainPage = new NavigationPage(new RootTabbedPage());
            //MainPage = new IngenioSINSPage();
        }
        
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
