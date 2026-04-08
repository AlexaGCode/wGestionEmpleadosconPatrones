using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wGestionEmpleadosconPatrones
{
    public class GestorEmpleados
    {
        private static GestorEmpleados _instancia;
        private List<Empleado> empleados;

        private GestorEmpleados()
        {
            empleados = new List<Empleado>();
        }

        public static GestorEmpleados Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new GestorEmpleados();
                }
                return _instancia;

            }
        }

        public void AgregarEmpleado(Empleado empleado)
        {
            empleados.Add(empleado);
        }

        public List<Empleado> ObtenerEmpleados() 
        {
            return empleados;
        }
    }
}
