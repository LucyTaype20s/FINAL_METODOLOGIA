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
    public partial class frmVenta : Form
    {

        private bool IsNuevo = false;
        public int Idempleado;
        private DataTable dtDetalle;
        private decimal TotalPagado = 0;

        private static frmVenta _Instancia;

        public static frmVenta GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmVenta();
            }
            return _Instancia;
        }


        //Metodo para enviar los valores a la caja de texto txtidcliente
        public void setCliente(string idcliente, string nombre)
        {
            this.txtIdCliente.Text = idcliente;
            this.txtCliente.Text = nombre;
        }

        //Metodo para enviar los valores a la caja de texto txtidproducto
        public void setProducto(string idproducto, string nombre, decimal preciocompra, decimal precioventa,
                                int stock, DateTime fechavencimiento)
        {
            this.txtIdProducto.Text = idproducto;
            this.txtProducto.Text = nombre;
            this.txtPrecioCompra.Text = Convert.ToString(preciocompra);
            this.txtPrecioVenta.Text = Convert.ToString(precioventa);
            this.txtStockActual.Text = Convert.ToString(stock);
            this.dtFechaVencimiento.Value = fechavencimiento;

        }



        public frmVenta()
        {
            InitializeComponent();

            this.ttMensaje.SetToolTip(this.txtCliente, "Seleccione un cliente");
            this.ttMensaje.SetToolTip(this.txtSerie, "Ingrese un serie de comprobante");
            this.ttMensaje.SetToolTip(this.txtCorrelativo, "Ingrese correlativo de comprobante");
            this.ttMensaje.SetToolTip(this.txtCantidad, "Ingrese cantidad de producto");
            this.ttMensaje.SetToolTip(this.txtProducto, "Seleccione un producto");

            this.txtIdCliente.Visible = false;
            this.txtIdProducto.Visible = false;
            this.txtCliente.ReadOnly = true;
            this.txtProducto.ReadOnly = true;
            this.dtFechaVencimiento.Enabled = false;
            this.txtPrecioCompra.ReadOnly = true;
            this.txtStockActual.ReadOnly = true;
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
            this.txtIdVenta.Text = string.Empty;
            this.txtIdCliente.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
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
            this.txtStockActual.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
            this.txtDescuento.Text = string.Empty;
        }


        //Habilitar los controls del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdVenta.ReadOnly = !valor;
            this.txtSerie.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIgv.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.cbTipoComprobante.Enabled = valor;
            this.txtCantidad.ReadOnly = !valor;
            this.txtPrecioCompra.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.txtStockActual.ReadOnly = !valor;
            this.txtDescuento.ReadOnly = !valor;
            this.dtFechaVencimiento.Enabled = valor;

            this.btnBuscarProducto.Enabled = valor;
            this.btnBuscarCliente.Enabled = valor;
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
            this.dgvListado.DataSource = NVenta.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }


        //Buscar por fechas
        private void BuscarFechas()
        {
            this.dgvListado.DataSource = NVenta.BuscarFechas(this.dtFechaInicial.Value.ToString("dd/MM/yyyy"),
                                                               this.dtFechaFinal.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }

        //Buscar Mostrar Detalles
        private void MostrarDetalle()
        {
            this.dgvListadoDetalle.DataSource = NVenta.MostrarDetalle(this.txtIdVenta.Text);
        }



        //Crear tabla
        private void CrearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("IdDetalleIngreso", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Producto", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Cantidad", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("PrecioVenta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Subtotal", System.Type.GetType("System.Decimal"));

            //Relacionamos el dataGriedView con DataTable
            this.dgvListadoDetalle.DataSource = this.dtDetalle;
        }

        private void txtStockActual_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmVistaClienteVenta vista = new frmVistaClienteVenta();
            vista.ShowDialog();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            frmVistaProductoVenta vista = new frmVistaProductoVenta();
            vista.ShowDialog();
        }

        private void frmVenta_Load(object sender, EventArgs e)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Seguro de eliminar los registros?", "Sistema de Vendtas 'BODEGA MONCHITO'", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
                            //capturamos el codigo categoria
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Respuesta = NVenta.Eliminar(Convert.ToInt32(Codigo));

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Registro elimino correctamente");
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

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdVenta.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["IdVenta"].Value);
            this.txtCliente.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Cliente"].Value);
            this.dtFecha.Value = Convert.ToDateTime(this.dgvListado.CurrentRow.Cells["Fecha"].Value);
            this.cbTipoComprobante.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["TipoComprobante"].Value);
            this.txtSerie.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Serie"].Value);
            this.txtCorrelativo.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Correlativo"].Value);
            this.lblTotalPagado.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Total"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
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
            this.LimpiarDetalle();
            this.Habilitar(true);
            this.txtSerie.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.LimpiarDetalle();
            this.Habilitar(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Respuesta = "";
                if (this.txtIdCliente.Text == string.Empty || this.txtSerie.Text == string.Empty ||
                    this.txtCorrelativo.Text == string.Empty || this.txtIgv.Text == string.Empty)
                {
                    MensajeError("Ingrese todos los datos");
                    errorIcono.SetError(txtIdCliente, "Ingrese Cliente");
                    errorIcono.SetError(txtSerie, "Ingrese Serie");
                    errorIcono.SetError(txtCorrelativo, "Ingrese Correlativo");
                    errorIcono.SetError(txtIgv, "Ingrese igv");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        Respuesta = NVenta.Insertar(Convert.ToInt32(this.txtIdCliente.Text),
                                                      Idempleado,
                                                      dtFecha.Value,
                                                      cbTipoComprobante.Text,
                                                      txtSerie.Text,
                                                      txtCorrelativo.Text,
                                                      Convert.ToDecimal(txtIgv.Text),
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

                if (this.txtIdProducto.Text == string.Empty || this.txtCantidad.Text == string.Empty ||
                    this.txtDescuento.Text == string.Empty || this.txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Ingrese todos los datos");
                    errorIcono.SetError(txtIdProducto, "Ingrese Producto");
                    errorIcono.SetError(txtCantidad, "Ingrese cantidad");
                    errorIcono.SetError(txtDescuento, "Ingrese Descuento");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese precio de venta");
                }
                else
                {
                    bool Registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["IdDetalleIngreso"]) == Convert.ToInt32(this.txtIdProducto.Text))
                        {
                            Registrar = false;
                            this.MensajeError("El producto ya se encuentra en el detalle de ingreso");
                        }
                    }

                    if (Registrar && Convert.ToInt32(txtCantidad.Text) <= Convert.ToInt32(txtStockActual.Text))
                    {
                        decimal Subtotal = Convert.ToDecimal(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecioVenta.Text)-Convert.ToDecimal(txtDescuento.Text);
                        TotalPagado = TotalPagado + Subtotal;
                        this.lblTotalPagado.Text = TotalPagado.ToString("#0.00#");
                        //Agregamos el detalle al detallelistadodetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["IdDetalleIngreso"] = Convert.ToInt32(this.txtIdProducto.Text);
                        row["Producto"] = this.txtProducto.Text;
                        row["Cantidad"] = Convert.ToInt32(this.txtCantidad.Text);
                        row["PrecioVenta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["Descuento"] = Convert.ToDecimal(this.txtDescuento.Text);
                        row["Subtotal"] = Subtotal;
                        this.dtDetalle.Rows.Add(row);
                        this.LimpiarDetalle();
                    }
                    else
                    {
                        MensajeError("No hay stock suficiente");
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

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            frmReporteFactura frm = new frmReporteFactura();
            frm.IdVenta = Convert.ToInt32(this.dgvListado.CurrentRow.Cells["IdVenta"].Value);
            frm.ShowDialog();
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

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
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
