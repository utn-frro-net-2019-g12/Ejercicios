﻿using System;
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
    }
}
