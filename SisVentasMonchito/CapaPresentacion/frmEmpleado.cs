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
    public partial class frmEmpleado : Form
    {

        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmEmpleado()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese Nombre del Empleado");
            this.ttMensaje.SetToolTip(this.txtApellidos, "Ingrese Apellidos del Empleado");
            this.ttMensaje.SetToolTip(this.txtUsuario, "Ingrese usuario del Empleado");
            this.ttMensaje.SetToolTip(this.txtContraseña, "Ingrese contraseña del Empleado");
            this.ttMensaje.SetToolTip(this.cbAcceso, "Seleccione acceso de trabajador");
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
            this.txtNombre.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtNumDocumento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtIdEmpleado.Text = string.Empty;
            this.txtUsuario.Text = string.Empty;
            this.txtContraseña.Text = string.Empty;
        }


        //Habilitar los controls del formulario
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtApellidos.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.cbSexo.Enabled = valor;
            this.txtNumDocumento.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.cbAcceso.Enabled = valor;
            this.txtUsuario.ReadOnly = !valor;
            this.txtContraseña.ReadOnly = !valor;
            this.txtIdEmpleado.ReadOnly = !valor;
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
            this.dgvListado.DataSource = NEmpleado.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }


        //Buscar por Apellidos
        private void BuscarApellidos()
        {
            this.dgvListado.DataSource = NEmpleado.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }

        //Buscar por NumDocumento
        private void BuscarNumDocumento()
        {
            this.dgvListado.DataSource = NEmpleado.BuscarNumDocumento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }

        private void frmEmpleado_Load(object sender, EventArgs e)
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
            if (cbBuscar.Text.Equals("Apellidos"))
            {
                this.BuscarApellidos();
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
                            //capturamos el codigo empleado
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Respuesta = NEmpleado.Eliminar(Convert.ToInt32(Codigo));

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
            this.txtIdEmpleado.Text = Convert.ToString(dgvListado.CurrentRow.Cells["IdEmpleado"].Value);
            this.txtNombre.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
            this.txtApellidos.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Apellidos"].Value);
            this.cbSexo.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Sexo"].Value);
            this.dtFechaNacimiento.Value = Convert.ToDateTime(this.dgvListado.CurrentRow.Cells["FechaNacimiento"].Value);
            this.txtNumDocumento.Text = Convert.ToString(dgvListado.CurrentRow.Cells["NumDocumento"].Value);
            this.txtDireccion.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Telefono"].Value);
            this.txtEmail.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Email"].Value);
            this.cbAcceso.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Acceso"].Value);
            this.txtUsuario.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Usuario"].Value);
            this.txtContraseña.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Contraseña"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Respuesta = "";
                if (this.txtNombre.Text == string.Empty || this.txtApellidos.Text == string.Empty ||
                    this.txtNumDocumento.Text == string.Empty ||
                    this.txtDireccion.Text == string.Empty || this.txtUsuario.Text == string.Empty || this.txtContraseña.Text == string.Empty)
                {
                    MensajeError("Ingrese todos los datos");
                    errorIcono.SetError(txtNombre, "Ingrese Nombre");
                    errorIcono.SetError(txtApellidos, "Ingrese Apellidos");
                    errorIcono.SetError(txtNumDocumento, "Ingrese Numero de Documento");
                    errorIcono.SetError(txtDireccion, "Ingrese Direccion");
                    errorIcono.SetError(txtUsuario, "Ingrese Usuario");
                    errorIcono.SetError(txtContraseña, "Ingrese Contraseña");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        Respuesta = NEmpleado.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                                                        this.txtApellidos.Text.Trim().ToUpper(),
                                                        this.cbSexo.Text,
                                                        this.dtFechaNacimiento.Value,
                                                        this.txtNumDocumento.Text,
                                                        this.txtDireccion.Text,
                                                        this.txtTelefono.Text,
                                                        this.txtEmail.Text,
                                                        this.cbAcceso.Text,
                                                        this.txtUsuario.Text,
                                                        this.txtContraseña.Text);
                    }
                    else
                    {
                        Respuesta = NEmpleado.Editar(Convert.ToInt32(this.txtIdEmpleado.Text),
                                                        this.txtNombre.Text.Trim().ToUpper(),
                                                        this.txtApellidos.Text.Trim().ToUpper(),
                                                        this.cbSexo.Text,
                                                        this.dtFechaNacimiento.Value,
                                                        this.txtNumDocumento.Text,
                                                        this.txtDireccion.Text,
                                                        this.txtTelefono.Text,
                                                        this.txtEmail.Text,
                                                        this.cbAcceso.Text,
                                                        this.txtUsuario.Text,
                                                        this.txtContraseña.Text);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Habilitar(false);
            this.Limpiar();
            this.txtIdEmpleado.Text = string.Empty;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdEmpleado.Text.Equals(""))
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

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNumDocumento_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
