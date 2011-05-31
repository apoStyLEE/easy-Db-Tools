using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace easyDbTools
{
    public partial class Execute_Example : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                db.Execute(txtSql.Text,false);
                lblstatus.Text = "Successful.";
            }
            catch (Exception ex)
            {
                lblstatus.Text = "Error.<br />"+ ex.Message;
            }
        }
    }
}