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
    public partial class formMain : Form {
        public formMain() {
            this.LogState = false;
            InitializeComponent();
        }

        public formMain(bool LogState) {
            this.LogState = LogState;
            InitializeComponent();
        }

        private bool _LogState;

        public bool LogState { get; set; }

        private void mnuSalir_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        private void mnuUsuarios_Click(object sender, EventArgs e) {
            formUsuarios appUsuarios = new formUsuarios();
            appUsuarios.ShowDialog();
            this.Close();
        }

        private void formMain_Shown(object sender, EventArgs e) {
            formLogin appLogin = new formLogin();
            if (!LogState) {
                if (appLogin.ShowDialog() != DialogResult.OK) {
                    // Dispose = Close() + SQLConnection Close
                    this.Dispose();
                }
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e) {
            // WTF
        }
    }
}
