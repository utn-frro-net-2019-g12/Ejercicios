﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Read : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        // Validación por si inpuText es null, se le asigna una cadena vacía
        if (Session["inputText"] == null) { Session["inputText"] = ""; }
        Label1.Text = string.Format("inputText en sesión: '{0}'", Session["inputText"].ToString());

    }
}
