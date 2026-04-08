using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wGestionEmpleadosconPatrones
{
    public partial class frmGestionEmpleados : Form
    {
        public frmGestionEmpleados()
        {
            InitializeComponent();
        }

        private void frmGestionEmpleados_Load(object sender, EventArgs e)
        {
            cmbTipoEmpleado.Items.Add("Gerente");
            cmbTipoEmpleado.Items.Add("Programador");
            cmbTipoEmpleado.SelectedIndex = 0;
        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            double salario = double.Parse(txtSalario.Text);
            double extra = double.Parse(txtExtra.Text);
            string tipo = cmbTipoEmpleado.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtSalario.Text, out salario) || salario <= 0)
            {
                MessageBox.Show("Ingrese un salario valido (mayor a cero).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtExtra.Text, out extra) || extra < 0)
            {
                MessageBox.Show("Ingrese un valor válido para bono u horas extras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //Factory Method
                Empleado nuevoEmpleado = EmpleadoFactory.CrearEmpleado(tipo, nombre, salario, extra);
                //Singleton
                GestorEmpleados.Instancia.AgregarEmpleado(nuevoEmpleado);
                MessageBox.Show("Empleado agregado correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " +ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtSalario.Clear();
            txtExtra.Clear();
            txtNombre.Focus();
            cmbTipoEmpleado.SelectedIndex = 0;
        }

        private void btnMostrarEmpleados_Click(object sender, EventArgs e)
        {
            lstEmpleados.Items.Clear();
            foreach (var emp in GestorEmpleados.Instancia.ObtenerEmpleados())
            {
                lstEmpleados.Items.Add($"{emp.Nombre} - Salario: {emp.CalcularSalario()}");
            }
        }
    }
}
