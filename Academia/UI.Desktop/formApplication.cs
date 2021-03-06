﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop {
    public partial class formApplication : Form {
        public formApplication() {
            InitializeComponent();
        }

        private ModoForm _Modo;

        public ModoForm Modo { get; set; }

        public enum ModoForm {
            Alta,
            Baja,
            Modificacion,
            Consulta
        }

        public virtual void MapearDeDatos() { }
        public virtual void MapearADatos() { }
        public virtual void GuardarCambios() { }
        public virtual bool Validar() { return false; }
        public void Notificar(string titulo, string mensaje, MessageBoxButtons
            botones, MessageBoxIcon icono) {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public void Notificar(string mensaje, MessageBoxButtons botones,
            MessageBoxIcon icono) {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

    }
}
