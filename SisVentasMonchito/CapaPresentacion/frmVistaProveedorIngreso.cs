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
    public partial class frmVistaProveedorIngreso : Form
    {
        public frmVistaProveedorIngreso()
        {
            InitializeComponent();
        }

        private void frmVistaProveedorIngreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
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
            this.dgvListado.DataSource = NProveedor.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }


        //Buscar por RazonSocial
        private void BuscarRazonSocial()
        {
            this.dgvListado.DataSource = NProveedor.BuscarRazonSocial(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }

        //Buscar por NumDocumento
        private void BuscarNumDocumento()
        {
            this.dgvListado.DataSource = NProveedor.BuscarNumDocumento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Razon Social"))
            {
                this.BuscarRazonSocial();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNumDocumento();
            }
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            frmIngreso form = frmIngreso.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dgvListado.CurrentRow.Cells["IdProveedor"].Value);
            par2 = Convert.ToString(this.dgvListado.CurrentRow.Cells["RazonSocial"].Value);
            form.setProveedor(par1, par2);
            this.Hide();
        }
    }
}
