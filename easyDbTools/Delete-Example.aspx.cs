using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace easyDbTools
{
    public partial class Delete_Example : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            if (!string.IsNullOrEmpty(id))
            {
                db.Delete("testTable","where id = "+ id);
                Response.Redirect("Delete-Example.aspx");
            }

            DataTable dt = db.DTGetir("Select * from testTable");
            gv.DataSource = dt;
            gv.DataBind();
        }
    }
}