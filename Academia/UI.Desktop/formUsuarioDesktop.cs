using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop {
    public partial class formUsuarioDesktop : formApplication {
        public formUsuarioDesktop() {
            InitializeComponent();
        }

        // Altas
        public formUsuarioDesktop(ModoForm modo) : this() { }

        // Recuperar (Modificaciones y Bajas)
        public formUsuarioDesktop(int ID, ModoForm modo) : this() {
            this.Modo = modo;
            this.UsuarioActual = new UsuarioLogic().GetOne(ID);
            this.MapearDeDatos();
        }

        private Business.Entities.Usuario _UsuarioActual;

        public Business.Entities.Usuario UsuarioActual { get; set; }

        public virtual void MapearDeDatos() {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
            switch (this.Modo) {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";  break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";  break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";  break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar"; break;
                default:
                    this.btnAceptar.Text = "Aceptar"; break;
            }
            this.btnCancelar.Text = "Cancelar";
        }

        public virtual void MapearADatos() {
            if (this.Modo == ModoForm.Alta) {
                this.UsuarioActual = new Usuario(); // ID ?
            }
            this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
            this.UsuarioActual.Nombre = this.txtNombre.Text;
            this.UsuarioActual.Apellido = this.txtApellido.Text;
            this.UsuarioActual.Email = this.txtEmail.Text;
            this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
            this.UsuarioActual.Clave = this.txtClave.Text;
            if (this.Modo == ModoForm.Alta) {
                this.UsuarioActual.State = BusinessEntity.States.New;
            } else if (this.Modo == ModoForm.Modificacion) {
                this.UsuarioActual.State = BusinessEntity.States.Modified;
            } else if (this.Modo == ModoForm.Baja) {
                this.UsuarioActual.State = BusinessEntity.States.Deleted;
            }
        }

        public virtual void GuardarCambios() {
            this.MapearADatos();
            if (this.UsuarioActual.State == BusinessEntity.States.Modified || this.UsuarioActual.State == BusinessEntity.States.New) {
                new UsuarioLogic().Save(UsuarioActual);
            } else if (this.UsuarioActual.State == BusinessEntity.States.Deleted) { new UsuarioLogic().Delete(UsuarioActual.ID); }
        }

        public virtual bool Validar() {
            if (this.txtNombre.Text != "" && this.txtApellido.Text != "" &&
                this.txtEmail.Text != "" && this.txtUsuario.Text != "" &&
                this.txtClave.Text != "" && this.txtConfirmarClave.Text != "") {
                if (this.txtClave.Text == this.txtConfirmarClave.Text) {
                    if(this.txtClave.Text.Length >= 8) {
                        if (new EmailAddressAttribute().IsValid(this.txtEmail.Text)) {
                            return true;
                        } else { this.Notificar("Validación Fallida", "El Email es Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    } else { this.Notificar("Validación Fallida", "La Contraseña debe tener 8 caracteres de largo mínimo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                } else { this.Notificar("Validación Fallida", "La Contraseña y la Confimación no coinciden", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            } else { this.Notificar("Validación Fallida", "No dejar ningún campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return false;
        }

        private void btnAceptar_Click(object sender, EventArgs e) {
            if (this.Modo != ModoForm.Baja) {
                if (this.Validar()) {
                    this.GuardarCambios();
                    this.Close();
                }
            } else {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
