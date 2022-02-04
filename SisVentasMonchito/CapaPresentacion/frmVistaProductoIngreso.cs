using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmVistaProductoIngreso : Form
    {
        public frmVistaProductoIngreso()
        {
            InitializeComponent();
        }

        private void frmVistaProductoIngreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }


        //Ocultar columnas
        private void OcultarColumnas()
        {
            this.dgvListado.Columns[0].Visible = false;
            this.dgvListado.Columns[1].Visible = false;
            this.dgvListado.Columns[6].Visible = false;
            this.dgvListado.Columns[8].Visible = false;
        }


        //Metodo Mostrar
        private void Mostrar()
        {
            this.dgvListado.DataSource = NProducto.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }


        //Buscar por nombre
        private void BuscarNombre()
        {
            this.dgvListado.DataSource = NProducto.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            frmIngreso form = frmIngreso.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dgvListado.CurrentRow.Cells["IdProducto"].Value);
            par2 = Convert.ToString(this.dgvListado.CurrentRow.Cells["Nombre"].Value);
            form.setProducto(par1, par2);
            this.Hide();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) ||
                (e.KeyChar >= 91 && e.KeyChar <= 96) ||
                 (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("SOLO LETRAS", "ALERTA", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
