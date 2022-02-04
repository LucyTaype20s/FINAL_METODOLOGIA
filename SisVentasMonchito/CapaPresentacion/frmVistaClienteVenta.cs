using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//importamos
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmVistaClienteVenta : Form
    {
        public frmVistaClienteVenta()
        {
            InitializeComponent();
        }

        private void frmVistaClienteVenta_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        //Ocultar columnas
        private void OcultarColumnas()
        {
            this.dgvListado.Columns[0].Visible = false;
            this.dgvListado.Columns[1].Visible = false;
        }


        //Metodo Mostrar
        private void Mostrar()
        {
            this.dgvListado.DataSource = NCliente.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }


        //Buscar por Apellidos
        private void BuscarApellidos()
        {
            this.dgvListado.DataSource = NCliente.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }

        //Buscar por NumDocumento
        private void BuscarNumDocumento()
        {
            this.dgvListado.DataSource = NCliente.BuscarNumDocumento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Apellidos"))
            {
                this.BuscarApellidos();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNumDocumento();
            }
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            frmVenta form = frmVenta.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dgvListado.CurrentRow.Cells["IdCliente"].Value);
            par2 = Convert.ToString(this.dgvListado.CurrentRow.Cells["Apellidos"].Value) + " " +
                   Convert.ToString(this.dgvListado.CurrentRow.Cells["Nombre"].Value);

            form.setCliente(par1, par2);
            this.Hide();
        }
    }
}
