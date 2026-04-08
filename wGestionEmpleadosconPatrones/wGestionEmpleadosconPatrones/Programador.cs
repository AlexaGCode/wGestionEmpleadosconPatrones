using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wGestionEmpleadosconPatrones
{
    public class Programador : Empleado
    {
        public double HorasExtras { get; set; }

        public Programador(string nombre, double salarioBase, double horasExtras) : base(nombre, salarioBase)
        {
            if (salarioBase > 2500000)
            {
                HorasExtras = 0;
                MessageBox.Show("El programador no puede recibir pago por horas extras si su salario base es mayor a $2500.000", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                HorasExtras = horasExtras;
            }
        }

        public override double CalcularSalario()
        {
            return SalarioBase + (HorasExtras * 20);
        }
    }
}
