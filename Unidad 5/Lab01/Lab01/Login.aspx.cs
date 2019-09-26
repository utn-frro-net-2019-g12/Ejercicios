using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void btnIngresar_Click(object sender, EventArgs e) {
        // Valido nombre de Usuario y Contraseña
        if(txtUsuario.Text.ToLower() == "admin" && this.txtClave.Text == "admin") {
            Page.Response.Write("Ingreso OK");
        } else {
            Page.Response.Write("Usuario y/o Contraseña Incorrectos");
        }
    }

    protected void lnkRecordarClave_Click(object sender, EventArgs e) {
        // Redirecciono a otra página que debería existir y para mostrar el mensaje, tener dicho elemento
        Response.Redirect("~/Default.aspx?msj=Es ud. un usuario muy descuidado, haga memoria");
    }
}
