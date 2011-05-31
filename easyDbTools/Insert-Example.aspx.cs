using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace easyDbTools
{
    public partial class Insert_Example : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            testTable tt = new testTable
            {
                name = "random data - " + r.Next(10, 99999),
                email = "mail@mail.com" + r.Next(10, 99999),
                age = 18,
                createDate = DateTime.Now
            };

            db.Insert(tt, true);
        }

        protected void add_Click(object sender, EventArgs e)
        {
            db.Insert(new testTable(),divForm,false);
        }

    }
}