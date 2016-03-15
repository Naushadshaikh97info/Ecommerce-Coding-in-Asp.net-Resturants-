using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    DataClassesDataContext linq_obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (Session["id1"] != null)
        {
           // lbl_welcome.Visible = true;
            lbl_login.Visible = false;
            lbl_signup.Visible = false;
            lbl_logout.Visible = true;
            pnl_profile.Visible = true;

            var id = (from a in linq_obj.registraion_msts
                      where a.intglcode == Convert.ToInt32(Session["id1"])
                      select new
                      {
                          code = a.intglcode,
                          name = "&nbsp;&nbsp;" + "Welcome" + "&nbsp;" + a.firstname
                      }).Single();

            lbl_name.Text = id.name;
        }
        else
        {
            lbl_name.Visible = false;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        {

            Session["username1"] = "";
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
    protected void link_read_more_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("about_us.aspx");
        }
        catch (Exception ex)
        {

        }
    }

}
