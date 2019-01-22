using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamEFCore.Models;
using XamEFCore.Repository.GenericRepository;
using XamEFCore.Services;

namespace XamEFCore.ViewModels
{
    public class IngenioSINSViewModel : BaseViewModel
    {
        #region Services
        private WebService webService;        
        #endregion Services

        #region Repository DataAccess
        private ServiceBase<IngenioSINSRow> repositoryGeneric;
        #endregion Repository DataAccess

        #region Attributes
        private ObservableCollection<IngenioSINSRow> ingenios;
        private string nombre;
        private int ingenioSINSID;
        private bool proccesSync;
        private bool isRefreshing;
        #endregion Attributes

        #region Properties        
        public ObservableCollection<IngenioSINSRow> Ingenios
        {
            get { return ingenios; }
            set { SetValue(ref ingenios, value); }
        }
       
        public string Nombre
        {
            get { return nombre; }
            set { SetValue(ref nombre, value); }
        }

       
        public int IngenioSINSID
        {
            get { return ingenioSINSID; }
            set { SetValue(ref ingenioSINSID, value); }
        }
       
        public bool ProccesSync
        {
            get { return this.proccesSync; }
            set { SetValue(ref this.proccesSync, value); }
        }       

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        #endregion Properties

        #region Constructros
        public IngenioSINSViewModel()
        {
            // Iniciar el repositorio generico
            this.repositoryGeneric = new ServiceBase<IngenioSINSRow>();

            // Iniciar el Web Service
            this.webService = new WebService();            

            this.ProccesSync = false;

            LoadData();
        }
        #endregion Constructors

        #region Commands
        public ICommand SyncIngeniosCommand
        {
            get
            {
                return new Command(LoadDataApiIngenios);
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(LoadData);
            }
        }

        public ICommand DeleteIngeniosAllCommand
        {
            get
            {
                return new Command(DeleteIngeniosExecute);
            }
        }        
        #endregion Commands

        #region Methods
        private void LoadData()
        {
            this.IsRefreshing = true;

            this.Ingenios = new ObservableCollection<IngenioSINSRow>(repositoryGeneric.Get(null, i => i.OrderBy(c => c.IngenioSINSID), ""));

            this.IsRefreshing = false;
        }

        private async void LoadDataApiIngenios()
        {
            this.ProccesSync = true;
            var response = await this.webService.GetListRest<IngenioSINS>("http://test.asazgua.org.gt/datasnap/rest/TdmServerMethods/GetTableData/IngenioSINS", "2648", "123456");
            var list = ((response.DataResult as IngenioSINS).Result[0] as IngenioSINSResult).Rows;

            // Utilizar el repositorio generico para guardar la lista del serivicio en la bd local ef-core
            repositoryGeneric.SaveList(list);
            this.ProccesSync = false;
            LoadData();
        }

        private void DeleteIngeniosExecute()
        {
            this.ProccesSync = true;
            repositoryGeneric.DeleteList(this.Ingenios.ToList());
            this.ProccesSync = false;

            LoadData();
        }
        #endregion Methods
    }
}
