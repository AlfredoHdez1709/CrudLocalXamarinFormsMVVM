using mvvmXamarin.Model;
using mvvmXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mvvmXamarin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonaPage : ContentPage
    {
        PersonaViewModel context = new PersonaViewModel();
        public PersonaPage()
        {
            InitializeComponent();
            BindingContext = context;
            lvPersonas.ItemSelected += LvPersonas_ItemSelected;
        }

        private void LvPersonas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                PersonasModel  modelo = (PersonasModel)e.SelectedItem;
                context.Nombre = modelo.Nombre;
                context.Apellido = modelo.Apellido;
                context.Edad = modelo.Edad;
                context.Id = modelo.Id;

            }
        }
    }
}