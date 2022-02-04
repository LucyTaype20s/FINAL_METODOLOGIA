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
    public partial class frmProveedor : Form
    {

        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmProveedor()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtRazonSocial, "Ingrese Razon Social del Proveedor");
            this.ttMensaje.SetToolTip(this.txtNumDocumento, "Ingrese Número de Documento del Proveedor");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese Dirección del Proveedor");
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


        //Limpiar los controles del formulario
        private void Limpiar()
        {
            this.txtRazonSocial.Text = string.Empty;
            this.txtNumDocumento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtPaginaWeb.Text = string.Empty;
            this.txtIdProveedor.Text = string.Empty;
        }


        //Habilitar los controls del formulario
        private void Habilitar(bool valor)
        {
            this.txtRazonSocial.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.cbSectorComercial.Enabled = valor;
            this.cbTipoDocumento.Enabled = valor;
            this.txtNumDocumento.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtPaginaWeb.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtIdProveedor.ReadOnly = !valor;
        }


        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
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

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            //El formulario se mostratara
            //arriba
            this.Top = 0;
            //izquiera
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
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
                            //capturamos el codigo proveedor
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Respuesta = NProveedor.Eliminar(Convert.ToInt32(Codigo));

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Registro eliminado correctamente");
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtRazonSocial.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Respuesta = "";
                if (this.txtRazonSocial.Text == string.Empty || this.txtNumDocumento.Text == string.Empty ||
                    this.txtDireccion.Text == string.Empty)
                {
                    MensajeError("Ingrese todos los datos");
                    errorIcono.SetError(txtRazonSocial, "Ingrese Razon Social");
                    errorIcono.SetError(txtNumDocumento, "Ingrese Numero de Documento");
                    errorIcono.SetError(txtDireccion, "Ingrese Direccion");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        Respuesta = NProveedor.Insertar(this.txtRazonSocial.Text.Trim().ToUpper(),
                                                        this.cbSectorComercial.Text,
                                                        this.cbTipoDocumento.Text,
                                                        this.txtNumDocumento.Text,
                                                        this.txtDireccion.Text,
                                                        this.txtTelefono.Text,
                                                        this.txtEmail.Text,
                                                        this.txtPaginaWeb.Text);
                    }
                    else
                    {
                        Respuesta = NProveedor.Editar(Convert.ToInt32(this.txtIdProveedor.Text),
                                                        this.txtRazonSocial.Text.Trim().ToUpper(),
                                                        this.cbSectorComercial.Text,
                                                        this.cbTipoDocumento.Text,
                                                        this.txtNumDocumento.Text,
                                                        this.txtDireccion.Text,
                                                        this.txtTelefono.Text,
                                                        this.txtEmail.Text,
                                                        this.txtPaginaWeb.Text);
                    }

                    if (Respuesta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se inserto el registro correctamente ");
                        }
                        else
                        {
                            this.MensajeOk("Se actualizo el registro correctamente ");
                        }
                    }

                    else
                    {
                        this.MensajeError(Respuesta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdProveedor.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Seleccione un registro que desea moficiar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.txtIdProveedor.Text = string.Empty;
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdProveedor.Text = Convert.ToString(dgvListado.CurrentRow.Cells["IdProveedor"].Value);
            this.txtRazonSocial.Text = Convert.ToString(dgvListado.CurrentRow.Cells["RazonSocial"].Value);
            this.cbSectorComercial.Text = Convert.ToString(dgvListado.CurrentRow.Cells["SectorComercial"].Value);
            this.cbTipoDocumento.Text = Convert.ToString(dgvListado.CurrentRow.Cells["TipoDocumento"].Value);
            this.txtNumDocumento.Text = Convert.ToString(dgvListado.CurrentRow.Cells["NumDocumento"].Value);
            this.txtDireccion.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Telefono"].Value);
            this.txtEmail.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Email"].Value);
            this.txtPaginaWeb.Text = Convert.ToString(dgvListado.CurrentRow.Cells["PaginaWeb"].Value);

            this.tabControl1.SelectedIndex = 1;
        }
    }
}
