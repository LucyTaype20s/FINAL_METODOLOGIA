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

namespace CapaPresentacion.Consultas
{
    public partial class frmConsultaStockProducto : Form
    {
        public frmConsultaStockProducto()
        {
            InitializeComponent();
        }


        //Ocultar columnas
        private void OcultarColumnas()
        {
            this.dgvListado.Columns[0].Visible = false;
        }


        //Metodo Mostrar
        private void Mostrar()
        {
            this.dgvListado.DataSource = NProducto.StockProducto();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }


        private void frmConsultaStockProducto_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }
    }
}
