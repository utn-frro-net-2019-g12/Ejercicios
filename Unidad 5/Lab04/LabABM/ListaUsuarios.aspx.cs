using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class ListaUsuarios : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!Page.IsPostBack) {
            cargarDiasCalendario();
        }

        PaginaEnEstadoEdicion();

    }

    private bool PaginaEnEstadoEdicion() {
        if (Request.QueryString["id"] != null) {
            return true;
        } else {
            return false;
        }
    }


    private void cargarDiasCalendario() {
        DropDownList numbers = (DropDownList)FindControl("ddlDiaFechaNacimiento");
        if (numbers != null) {
            for (int i = 1; i <= 31; i++) {
                numbers.Items.Add(new ListItem(i.ToString()));;
            }
        }
    }

    /*
    // Modificar la etiqueta lblAccion con el texto “Editar Usuario <idUsuario>”, donde el idUsuario es el valor de la variable de QueryString id

    •	Alta (cuando la variable de QueryString id NO tiene valor): modificar la etiqueta lblAccion con el texto “Agregar Nuevo Usuario”
    4)	Programar el botón “Guardar”: en el evento btnGuardar_Click crear un objeto Usuario y asignarle los valores de los controles del formulario de la tabla de edición. Si el estado de la página es Edición, llamar al método ActualizarUsuario de ManagerUsuario. Si es Alta, llamar a AgregarUsuario.
    5)	Programar el botón “Cancelar”: en el evento btnCancelar_Click redireccionar a la misma página para borrar el estado en que y cargar el estado de la página por default.
    6)	Seteamos el Formulario ListaUsuarios.aspx como página de inicio. Para esto en el Explorador de Soluciones, clickeamos el botón derecho del mouse sobre el formulario y seleccionamos la opción “Establecer como página de inicio”.
    7)	Ejecutamos la aplicación y probamos. 
    */

}
