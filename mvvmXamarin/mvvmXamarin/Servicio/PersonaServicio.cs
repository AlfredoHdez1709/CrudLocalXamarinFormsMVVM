using mvvmXamarin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace mvvmXamarin.Servicio
{
    public class PersonaServicio
    {
        public ObservableCollection<PersonasModel> personas { get; set; }

        public PersonaServicio()
        {
              if(personas == null)
            {
                personas = new ObservableCollection<PersonasModel>();
            }
        }

        public ObservableCollection<PersonasModel> consultar()
        {
            return personas;
        }
        public void Guardar(PersonasModel model)
        {
            personas.Add(model);
        }
        public void Modificar(PersonasModel modelo)
        {
            for (int i = 0; i < personas.Count; i++)
            {
                if(personas[i].Id == modelo.Id)
                {
                    personas[i] = modelo;
                }
            }
        }

        public void Eliminar(string idPersona)
        {
            PersonasModel modelo = personas.FirstOrDefault(p => p.Id == idPersona);
            personas.Remove(modelo);
        }
    }
}
