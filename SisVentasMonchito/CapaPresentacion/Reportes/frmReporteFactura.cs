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
    public partial class frmReporteFactura : Form
    {

        private int _IdVenta;

        public int IdVenta { get => _IdVenta; set => _IdVenta = value; }

        public frmReporteFactura()
        {
            InitializeComponent();
        }

        

        private void frmReporteFactura_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.sp_ReporteFactura' Puede moverla o quitarla según sea necesario.

            try
            {
                this.sp_ReporteFacturaTableAdapter.Fill(this.dsPrincipal.sp_ReporteFactura, IdVenta);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

                this.reportViewer1.RefreshReport();
            }

            
        }
    }
}
