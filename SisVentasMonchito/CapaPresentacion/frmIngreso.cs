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
    public partial class frmIngreso : Form
    {

        public int Idemplado;

        private bool IsNuevo;
        private DataTable dtDetalle;
        private decimal TotalPagado = 0;

        private static frmIngreso _instancia;
        public static frmIngreso GetInstancia()
        {
            if (_instancia==null)
            {
                _instancia = new frmIngreso();
            }
            return _instancia;
        }

        //Metodo para enviar los valores a la caja de texto txtidproveedor
        public void setProveedor(string idproveedor, string nombre)
        {
            this.txtIdProveedor.Text = idproveedor;
            this.txtProveedor.Text = nombre;
        }

        //Metodo para enviar los valores a la caja de texto txtidproducto
        public void setProducto(string idproducto, string nombre)
        {
            this.txtIdProducto.Text = idproducto;
            this.txtProducto.Text = nombre;
        }
        

        public frmIngreso()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtProveedor, "Seleccione el proveedor");
            this.ttMensaje.SetToolTip(this.txtSerie, "Ingrese serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtCorrelativo, "Ingrese correlativo del comprobante");
            this.ttMensaje.SetToolTip(this.txtStock, "Ingrese cantidad de compra");
            this.ttMensaje.SetToolTip(this.txtProducto, "Ingrese producto de compra");
            this.txtIdProveedor.Visible = false;
            this.txtIdProducto.Visible = false;
            this.txtProveedor.ReadOnly = true;
            this.txtProducto.ReadOnly = true;
        }


        //Mostrar mensaje de confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas 'BODEGA MONCHITO'", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Mostrar mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas 'BODEGA MONCHITO'", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        //Limpiar los controles del formulario Ingreso
        private void Limpiar()
        {
            this.txtIdIngreso.Text = string.Empty;
            this.txtIdProveedor.Text = string.Empty;
            this.txtProveedor.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.txtCorrelativo.Text = string.Empty;
            this.txtIgv.Text = string.Empty;
            this.lblTotalPagado.Text = "0,00";
            this.txtIgv.Text = "18";
            this.CrearTabla();
        }

        //Limpiar los controles del formulario Detalle de Ingreso
        private void LimpiarDetalle()
        {
            this.txtIdProducto.Text = string.Empty;
            this.txtProducto.Text = string.Empty;
            this.txtStock.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
        }


        //Habilitar los controls del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdIngreso.ReadOnly = !valor;
            this.txtSerie.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIgv.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.cbTipoComprobante.Enabled = valor;
            this.txtStock.ReadOnly = !valor;
            this.txtPrecioCompra.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.dtFechaProduccion.Enabled = valor;
            this.dtFechaVencimiento.Enabled = valor;

            this.btnBuscarProducto.Enabled = valor;
            this.btnBuscarProveedor.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
        }


        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
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
            this.dgvListado.DataSource = NIngreso.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }


        //Buscar por fechas
        private void BuscarFechas()
        {
            this.dgvListado.DataSource = NIngreso.BuscarFechas(this.dtFechaInicial.Value.ToString("dd/MM/yyyy"),
                                                               this.dtFechaFinal.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }

        //Buscar Mostrar Detalles
        private void MostrarDetalle()
        {
            this.dgvListadoDetalle.DataSource = NIngreso.MostrarDetalle(this.txtIdIngreso.Text);
        }



        //Crear tabla
        private void CrearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("IdProducto", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Producto", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("PrecioCompra", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("PrecioVenta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("StockInicial", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("FechaProduccion", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("FechaVencimiento", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("Subtotal", System.Type.GetType("System.Decimal"));

            //Relacionamos el dataGriedView con DataTable
            this.dgvListadoDetalle.DataSource = this.dtDetalle;
        }


        private void frmIngreso_Load(object sender, EventArgs e)
        {
            //El formulario se mostratara
            //arriba
            this.Top = 0;
            //izquiera
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.CrearTabla();
        }

        private void frmIngreso_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void frmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            frmVistaProveedorIngreso vista = new frmVistaProveedorIngreso();
            vista.ShowDialog();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            frmVistaProductoIngreso vista = new frmVistaProductoIngreso();
            vista.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Seguro de anular los registros?", "Sistema de Vendtas 'BODEGA MONCHITO'", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Respuesta = "";

                    //bucle que recorre toda las filas del datagriedview
                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        //Si esta marcado la fila
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            //capturamos el codigo Ingreso
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Respuesta = NIngreso.Anular(Convert.ToInt32(Codigo));

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Registro anulado correctamente");
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }
                    }

                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dgvListado.Columns[0].Visible = true;
            }
            else
            {
                this.dgvListado.Columns[0].Visible = false;
            }
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtSerie.Focus();
            this.LimpiarDetalle();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.LimpiarDetalle();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                string Respuesta = "";
                if (this.txtIdProveedor.Text == string.Empty || this.txtSerie.Text == string.Empty ||
                    this.txtCorrelativo.Text == string.Empty || this.txtIgv.Text == string.Empty )
                {
                    MensajeError("Ingrese todos los datos");
                    errorIcono.SetError(txtIdProveedor, "Ingrese Proveedor");
                    errorIcono.SetError(txtSerie, "Ingrese Serie");
                    errorIcono.SetError(txtCorrelativo, "Ingrese Correlativo");
                    errorIcono.SetError(txtIgv, "Ingrese igv");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        Respuesta = NIngreso.Insertar(dtFecha.Value,
                                                      cbTipoComprobante.Text, 
                                                      txtSerie.Text, 
                                                      txtCorrelativo.Text,
                                                      Convert.ToDecimal(txtIgv.Text),
                                                      Idemplado,
                                                      Convert.ToInt32(this.txtIdProveedor.Text),
                                                      "EMITIDO",
                                                      dtDetalle);
                    }
                    

                    if (Respuesta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se inserto el registro correctamente ");
                        }
                    }

                    else
                    {
                        this.MensajeError(Respuesta);
                    }

                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.LimpiarDetalle();
                    this.Mostrar();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                
                if (this.txtIdProducto.Text == string.Empty || this.txtStock.Text == string.Empty ||
                    this.txtPrecioCompra.Text == string.Empty || this.txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Ingrese todos los datos");
                    errorIcono.SetError(txtIdProducto, "Ingrese Producto");
                    errorIcono.SetError(txtStock, "Ingrese stock");
                    errorIcono.SetError(txtPrecioCompra, "Ingrese precio de compra");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese precio de venta");
                }
                else
                {
                    bool Registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["IdProducto"])==Convert.ToInt32(this.txtIdProducto.Text))
                        {
                            Registrar = false;
                            this.MensajeError("El producto ya se encuentra en el detalle de ingreso");
                        }
                    }

                    if (Registrar)
                    {
                        decimal Subtotal = Convert.ToDecimal(this.txtStock.Text) * Convert.ToDecimal(this.txtPrecioCompra.Text);
                        TotalPagado = TotalPagado + Subtotal;
                        this.lblTotalPagado.Text = TotalPagado.ToString("#0.00#");
                        //Agregamos el detalle al detallelistadodetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["IdProducto"] = Convert.ToInt32(this.txtIdProducto.Text);
                        row["Producto"] = this.txtProducto.Text;
                        row["PrecioCompra"] = Convert.ToDecimal(this.txtPrecioCompra.Text);
                        row["PrecioVenta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["StockInicial"] = Convert.ToInt32(this.txtStock.Text);
                        row["FechaProduccion"] = dtFechaProduccion.Value;
                        row["FechaVencimiento"] = dtFechaVencimiento.Value;
                        row["Subtotal"] = Subtotal;
                        this.dtDetalle.Rows.Add(row);
                        this.LimpiarDetalle();
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                //Capturamos el indice
                int IndiceFila = this.dgvListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[IndiceFila];
                //Volvemos a calular el Total pagado
                this.TotalPagado = this.TotalPagado - Convert.ToDecimal(row["Subtotal"].ToString());
                this.lblTotalPagado.Text = TotalPagado.ToString("#0.00#");
                //Quitamos la fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {

                MensajeError("No hay fila para quitar");
            }
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdIngreso.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["IdIngreso"].Value);
            this.txtProveedor.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Proveedor"].Value);
            this.dtFecha.Value = Convert.ToDateTime(this.dgvListado.CurrentRow.Cells["Fecha"].Value);
            this.cbTipoComprobante.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["TipoComprobante"].Value);
            this.txtSerie.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Serie"].Value);
            this.txtCorrelativo.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Correlativo"].Value);
            this.lblTotalPagado.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Total"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
        }

        private void txtProveedor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) ||
                (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("SOLO NUMEROS!", "ALERTA", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCorrelativo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) ||
                (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("SOLO NUMEROS!", "ALERTA", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) ||
                (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("SOLO NUMEROS!", "ALERTA", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtIgv_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtIgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) ||
                (e.KeyChar >= 58 && e.KeyChar <= 249))
            {
                MessageBox.Show("SOLO NUMEROS!", "ALERTA", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtSerie_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) ||
                (e.KeyChar==47)||
               (e.KeyChar >= 58 && e.KeyChar <= 250))
            {
                MessageBox.Show("SOLO NUMEROS!", "ALERTA", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) ||
                (e.KeyChar == 47) ||
               (e.KeyChar >= 58 && e.KeyChar <= 250))
            {
                MessageBox.Show("SOLO NUMEROS!", "ALERTA", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
