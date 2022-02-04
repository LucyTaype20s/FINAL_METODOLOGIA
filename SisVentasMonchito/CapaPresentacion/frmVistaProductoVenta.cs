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
    public partial class frmVistaProductoVenta : Form
    {
        public frmVistaProductoVenta()
        {
            InitializeComponent();
        }

        //Ocultar columnas
        private void OcultarColumnas()
        {
            this.dgvListado.Columns[0].Visible = false;
            this.dgvListado.Columns[1].Visible = false;
        }


        ////Metodo Mostrar
        //private void Mostrar()
        //{
        //    this.dgvListado.DataSource = NProducto.Mostrar();
        //    this.OcultarColumnas();
        //    lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        //}


        //Buscar por Nombre
        private void MostrarProductoVentaxNombre()
        {
            this.dgvListado.DataSource = NVenta.MostrarProductoVentaNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }

        //Buscar por Codigo
        private void MostrarProductoVentaxCodigo()
        {
            this.dgvListado.DataSource = NVenta.MostrarProductoVentaCodigo(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }

        private void frmVistaProductoVenta_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Codigo"))
            {
                this.MostrarProductoVentaxCodigo();
            }
            else if (cbBuscar.Text.Equals("Nombre"))
            {
                this.MostrarProductoVentaxNombre();
            }
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            frmVenta form = frmVenta.GetInstancia();
            string Id, Nombre;
            decimal PrecioCompra, PrecioVenta;
            int StockActual;
            DateTime FechaVencimiento;

            Id = Convert.ToString(this.dgvListado.CurrentRow.Cells["IdDetalleIngreso"].Value);
            Nombre = Convert.ToString(this.dgvListado.CurrentRow.Cells["Nombre"].Value);
            PrecioCompra = Convert.ToDecimal(this.dgvListado.CurrentRow.Cells["PrecioCompra"].Value);
            PrecioVenta = Convert.ToDecimal(this.dgvListado.CurrentRow.Cells["PrecioVenta"].Value);
            StockActual = Convert.ToInt32(this.dgvListado.CurrentRow.Cells["StockActual"].Value);
            FechaVencimiento = Convert.ToDateTime(this.dgvListado.CurrentRow.Cells["FechaVencimiento"].Value);

            form.setProducto(Id, Nombre, PrecioCompra, PrecioVenta, StockActual, FechaVencimiento);
            this.Hide();

        }

        private void cbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
