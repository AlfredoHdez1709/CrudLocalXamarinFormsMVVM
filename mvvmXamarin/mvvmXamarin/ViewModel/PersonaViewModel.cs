using mvvmXamarin.Model;
using mvvmXamarin.Servicio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mvvmXamarin.ViewModel
{
    public class PersonaViewModel:PersonasModel
    {
        public ObservableCollection<PersonasModel> Personas { get; set; }
        PersonaServicio servicio = new PersonaServicio();
        PersonasModel modelo;
        public PersonaViewModel()
        {
            Personas = servicio.consultar();
            GuardarCommand = new Command(async()=>await Guadar(), () => !IsBusy);
            ModificarCommand = new Command(async () => await Modificar(),() => !IsBusy);
            EliminarCommand = new Command(async () => await Eliminar(), () => !IsBusy);
            LimpiarCommand = new Command(Limpiar, () => !IsBusy);
        }

        //Comand permite eventos en vista

        public Command GuardarCommand { get; set; }
        public Command ModificarCommand { get; set; }
        public Command EliminarCommand { get; set; }
        public Command LimpiarCommand { get; set; }

        private async Task Guadar()
        {
            IsBusy = true;
            Guid IdPersona = Guid.NewGuid();
            modelo = new PersonasModel()
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Edad = Edad,
                Id = IdPersona.ToString()
            };
            servicio.Guardar(modelo);
            await Task.Delay(20000);
            IsBusy = false;
        }

        private async Task Modificar()
        {
            IsBusy = true;
            modelo = new PersonasModel()
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Edad = Edad,
                Id = Id
            };
            servicio.Modificar(modelo);
            await Task.Delay(20000);

            IsBusy = false;
        }

        private async Task Eliminar()
        {
            IsBusy = true;   
            servicio.Eliminar(Id);
            await Task.Delay(20000);
            IsBusy = false;
        }

        private void Limpiar()
        {
            Nombre = "";
            Apellido = "";
            Edad = 0;
            Id = "";
        }
    }
}
