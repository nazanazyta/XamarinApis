using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApis.Code;
using XamarinApis.Views;

namespace XamarinApis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainDoctoresView: MasterDetailPage
    {
        public MainDoctoresView()
        {
            InitializeComponent();
            ObservableCollection<MasterPageItem> menu = new ObservableCollection<MasterPageItem>();
            MasterPageItem doctoresview = new MasterPageItem
            {
                Titulo = "Doctores",
                Tipo = typeof(DoctoresView),
                Icono = "doctores.png"
            };
            menu.Add(doctoresview);
            MasterPageItem favoritosview = new MasterPageItem
            {
                Titulo = "Doctores favoritos",
                Tipo = typeof(DoctoresFavoritosView),
                Icono = "favoritos.png"
            };
            menu.Add(favoritosview);
            MasterPageItem insertarview = new MasterPageItem
            {
                Titulo = "Insertar doctores",
                Tipo = typeof(DoctorInsertarView),
                Icono = "nuevo.png"
            };
            menu.Add(insertarview);
            this.listviewMenu.ItemsSource = menu;
            //PONEMOS UNA PÁGINA COMO PRESENTACIÓN
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CochesView)));
            this.listviewMenu.ItemSelected += ListviewMenu_ItemSelected;
        }

        private void ListviewMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            var tipo = item.Tipo;
            Detail = new NavigationPage((Page)Activator.CreateInstance(tipo));
            IsPresented = false;
        }
    }
}