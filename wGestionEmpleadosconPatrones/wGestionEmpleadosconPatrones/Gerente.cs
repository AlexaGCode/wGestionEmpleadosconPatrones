using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wGestionEmpleadosconPatrones
{
    public class Gerente : Empleado
    {
        public double BonoGerencial { get; set; }

        public Gerente(string nombre, double salarioBase, double bono) : base(nombre, salarioBase)
        {
            if (salarioBase > 5000000)
            {
                BonoGerencial = 0;
                MessageBox.Show("l gerente no puede recibir bono si su salario base es mayor a $5000.000", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                BonoGerencial = bono;
            }
        }

        public override double CalcularSalario()
        {
            return SalarioBase + BonoGerencial;
        }
    }
}
