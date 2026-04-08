using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wGestionEmpleadosconPatrones
{
    public abstract class Empleado
    {
        public string Nombre { get; set; }
        public double SalarioBase { get; set; }

        public Empleado(string nombre, double salarioBase)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacio");
            }
            if (salarioBase <= 0)
            {
                throw new ArgumentException("El salario base debe ser mayor a cero");
            }
            
            Nombre = nombre;
            SalarioBase = salarioBase;
        }

        public abstract double CalcularSalario();
    }
}
