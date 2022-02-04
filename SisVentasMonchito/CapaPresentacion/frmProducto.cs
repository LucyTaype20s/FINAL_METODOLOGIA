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
    public partial class frmProducto : Form
    {

        private bool IsNuevo = false;
        private bool IsEditar = false;


        //Metodo para enviar parametros de un formulario al otro
        private static frmProducto _Instancia;
        public static frmProducto GetInstancia()
        {
            if (_Instancia==null)
            {
                _Instancia = new frmProducto();
            }
            return _Instancia;
        }

        //Metodo para enviar los valores a la caja de texto txtidcategoria
        public void setCategoria(string idcategoria, string nombre)
        {
            this.txtIdCategoria.Text = idcategoria;
            this.txtCategoria.Text = nombre;
        }


        public frmProducto()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Producto");
            this.ttMensaje.SetToolTip(this.pxImagen, "Ingrese imagen del Producto");
            this.ttMensaje.SetToolTip(this.txtCategoria, "Seleccione la categoria del Producto");
            this.ttMensaje.SetToolTip(this.cbIdPresentacion, "Seleccione la presentacion del Producto");

            this.txtIdCategoria.Visible = false;
            this.txtIdCategoria.ReadOnly = true;
            this.LlenarComboPresentacion();
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
            this.txtCodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtIdCategoria.Text = string.Empty;
            this.txtCategoria.Text = string.Empty;
            this.txtIdProducto.Text = string.Empty;
            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.ImgTransparente;
        }


        //Habilitar los controls del formulario
        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.btnBuscarCategoria.Enabled = valor;
            this.cbIdPresentacion.Enabled = valor;
            this.btnCargar.Enabled = valor;
            this.btnLimpiar.Enabled = valor;
            this.txtIdProducto.ReadOnly = !valor;
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
            this.dgvListado.Columns[6].Visible = false;
            this.dgvListado.Columns[8].Visible = false;
        }


        //Metodo Mostrar
        private void Mostrar()
        {
            this.dgvListado.DataSource = NProducto.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }


        //Buscar por nombre
        private void BuscarNombre()
        {
            this.dgvListado.DataSource = NProducto.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }

        //Metodo para llenar el combo con las presentaciones de la base de datos
        private void LlenarComboPresentacion()
        {
            cbIdPresentacion.DataSource = NPresentacion.Mostrar();
            cbIdPresentacion.ValueMember = "IdPresentacion";
            cbIdPresentacion.DisplayMember = "Nombre";
        }



        private void frmProducto_Load(object sender, EventArgs e)
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

        private void btnCargar_Click(object sender, EventArgs e)
        {
            //Creamos el cuadro de dialogo
            OpenFileDialog Dialogo = new OpenFileDialog();

            //variable para almacenar el resultado
            DialogResult Resultado = Dialogo.ShowDialog();

            //Si el usuario selecciona una imagen
            if (Resultado == DialogResult.OK)
            {
                //Coloca la imagen al mismo tamaño de pximagen
                this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxImagen.Image = Image.FromFile(Dialogo.FileName);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.ImgTransparente;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
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
                if (this.txtNombre.Text == string.Empty || this.txtIdCategoria.Text == string.Empty ||
                    this.txtCodigo.Text == string.Empty)
                {
                    MensajeError("Ingrese todos los datos");
                    errorIcono.SetError(txtCodigo, "Ingrese codigo");
                    errorIcono.SetError(txtNombre, "Ingrese nombre");
                    errorIcono.SetError(txtCategoria, "Ingrese categoria");
                }
                else
                {
                    //Guardamos la imagen
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    byte[] imagen = ms.GetBuffer();


                    if (this.IsNuevo)
                    {
                        Respuesta = NProducto.Insertar(this.txtCodigo.Text,
                                                        this.txtNombre.Text.Trim().ToUpper(),
                                                        this.txtDescripcion.Text.Trim(),
                                                        imagen, 
                                                        Convert.ToInt32(this.txtIdCategoria.Text),
                                                        Convert.ToInt32(this.cbIdPresentacion.SelectedValue));
                    }
                    else
                    {
                        Respuesta = NProducto.Editar(Convert.ToInt32(this.txtIdProducto.Text),
                                                        this.txtCodigo.Text,
                                                        this.txtNombre.Text.Trim().ToUpper(),
                                                        this.txtDescripcion.Text.Trim(),
                                                        imagen,
                                                        Convert.ToInt32(this.txtIdCategoria.Text),
                                                        Convert.ToInt32(this.cbIdPresentacion.SelectedValue));
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
            if (!this.txtIdProducto.Text.Equals(""))
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
            this.Habilitar(false);
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
            this.txtIdProducto.Text = Convert.ToString(dgvListado.CurrentRow.Cells["IdProducto"].Value);
            this.txtCodigo.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Codigo"].Value);
            this.txtNombre.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Descripcion"].Value);

            //Mostramos la imagen
            byte[] imagenBuffer = (byte[])this.dgvListado.CurrentRow.Cells["Imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
            this.pxImagen.Image = Image.FromStream(ms);
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;


            this.txtIdCategoria.Text = Convert.ToString(dgvListado.CurrentRow.Cells["IdCategoria"].Value);
            this.txtCategoria.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Categoria"].Value);
            this.cbIdPresentacion.SelectedValue = Convert.ToString(this.dgvListado.CurrentRow.Cells["IdPresentacion"].Value);

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
                            Respuesta = NProducto.Eliminar(Convert.ToInt32(Codigo));

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

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            frmVistaCategoria_Producto form = new frmVistaCategoria_Producto();
            form.ShowDialog();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporteProductos frm = new frmReporteProductos();
            frm.ShowDialog();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCategoria_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
