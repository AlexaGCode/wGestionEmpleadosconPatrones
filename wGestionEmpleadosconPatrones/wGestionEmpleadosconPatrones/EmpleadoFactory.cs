using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wGestionEmpleadosconPatrones
{
    public class EmpleadoFactory
    {
        public static Empleado CrearEmpleado(string tipo, string nombre, double salario, double extra)
        {
            if (tipo == "Gerente")
            {
                return new Gerente(nombre, salario, extra);
            }
            else if (tipo == "Programador")
            {
                return new Programador(nombre, salario, extra);
            }
            else
            {
                throw new ArgumentException("Tipo de empleado no valido");
            }

        }
    }
}
