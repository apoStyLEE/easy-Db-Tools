using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace easyDbTools
{
    public partial class CacheManager_Example : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl.DataSource = onbellek.tumunuListele();
                ddl.DataBind();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            onbellek.Temizle(ddl.SelectedItem.Text);
            Response.Redirect("CacheManager-Example.aspx");
        }

        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            onbellek.tumunuTemizle();
            Response.Redirect("CacheManager-Example.aspx");
        }
    }
}