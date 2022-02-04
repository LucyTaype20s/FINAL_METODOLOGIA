using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmReporteProductos : Form
    {
        public frmReporteProductos()
        {
            InitializeComponent();
        }

        private void frmReporteProductos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.sp_MostrarProducto' Puede moverla o quitarla según sea necesario.
            this.sp_MostrarProductoTableAdapter.Fill(this.dsPrincipal.sp_MostrarProducto);

            this.reportViewer1.RefreshReport();
        }
    }
}
