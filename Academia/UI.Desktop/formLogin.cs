using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop {
    public partial class formLogin : Form {
        public formLogin() {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void btnIngresar_Click(object sender, EventArgs e) {
            //la propiedad Text de los TextBox contiene el texto escrito en ellos
            if (this.txtUsuario.Text == "admin" && this.txtPass.Text == "admin") {
                this.DialogResult = DialogResult.OK;
                // MessageBox.Show("Usted ha ingresado al sistema correctamente", "Login",
                    // MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                MessageBox.Show("Usuario y/o Contraseña incorrectos", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria!", "Olvidé mi Contraseña",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

    }
}
