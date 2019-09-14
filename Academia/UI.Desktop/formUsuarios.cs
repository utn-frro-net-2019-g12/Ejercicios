using System;
using System.Collections.Generic;
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
    public partial class formUsuarios : Form {
        public formUsuarios() {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
        }

        private void mnuSalir_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        private void formUsuarios_Shown(object sender, EventArgs e) {

        }

        private void mnuInicio_Click(object sender, EventArgs e) {
            formMain appMain = new formMain(true);
            appMain.ShowDialog();
            this.Close();
        }

        public void Listar() {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.DataSource = ul.GetAll();
        }

        private void formUsuarios_Load(object sender, EventArgs e) {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e) {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e) {
            formUsuarioDesktop appUsuarioDesktop = new formUsuarioDesktop(formApplication.ModoForm.Alta);
            appUsuarioDesktop.ShowDialog();
            this.Listar();
        }

        private void tbsEditar_Click(object sender, EventArgs e) {
            if(this.dgvUsuarios.SelectedRows.Count > 0) {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                formUsuarioDesktop appUsuarioDesktop = new formUsuarioDesktop(ID, formApplication.ModoForm.Modificacion);
                appUsuarioDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void tbsEliminar_Click(object sender, EventArgs e) {
            if (this.dgvUsuarios.SelectedRows.Count > 0) {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                formUsuarioDesktop appUsuarioDesktop = new formUsuarioDesktop(ID, formApplication.ModoForm.Baja);
                appUsuarioDesktop.ShowDialog();
                this.Listar();
            }
        }
    }
}
