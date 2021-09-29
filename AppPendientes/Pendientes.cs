using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AppPendientes
{
    [DataContract(Name ="ToDo")]
    public class Pendientes
    {

        public delegate void Actualizar();
        public event Actualizar ListaActualizada;
        [DataMember]
        public List<String> Lista { get; private set; }

        public void Agregar(string pendiente)
        {
            if (Lista==null)
            {
                Lista = new();
            }
            Lista.Add(pendiente);
            ListaActualizada?.Invoke();
        }

        public void Borrar (string pendiente)
        {
            try { 
                int pos = Lista.IndexOf(pendiente);
                if (pos== -1)
                {
                    throw new ArgumentException("Pendiente no registrado");
                }
                else
                {
                    Lista.RemoveAt(pos);
                    ListaActualizada?.Invoke();
                }
            }
            catch
            {
                throw;
            }
            
        }

        public void Subir(string pendiente)
        {
            try
            {
                if (Lista == null)
                {
                    throw new NullReferenceException("La lista no ha sido creada");
                }
                else
                {
                    int pos = Lista.IndexOf(pendiente);
                    if (pos == -1)
                    {
                        throw new ArgumentException("El pendiente no existe");
                    }
                    else if (pos != 0)
                    {
                        Lista.RemoveAt(pos);
                        Lista.Insert(pos - 1, pendiente);
                        ListaActualizada?.Invoke();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Bajar(string pendiente)
        {
            if (Lista == null)
            {
                throw new NullReferenceException("La lista no ha sido creada");
            }
            else
            {
                int pos = Lista.IndexOf(pendiente);
                if (pos == -1)
                {
                    throw new ApplicationException("El pendiente no existe");
                }
                else if (pos != Lista.Count - 1)
                {
                    Lista.RemoveAt(pos);
                    Lista.Insert(pos + 1, pendiente);
                    ListaActualizada?.Invoke();
                }
            }
        }
    }
}
