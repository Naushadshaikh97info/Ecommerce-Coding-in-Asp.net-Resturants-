using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class profile : System.Web.UI.Page
{
    DataClassesDataContext linq_obj = new DataClassesDataContext();
    static int flag = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
           fill_data();
           fill_google_area();
         
           if (Session["username1"] == null)
           {
               Response.Redirect("Default.aspx");
           }
           else
           {

           }
    }
    private void fill_google_area()
    {
        try
        {
            var id = (from a in linq_obj.googel_are_msts
                      orderby a.nickname ascending
                      select a).ToList();
            ddl_googel_area.DataSource = id;
            ddl_googel_area.DataBind();
            ddl_googel_area.Items.Insert(0, "--- Select your area  ---");
        }
        catch (Exception)
        {

        }
    }
    private void fill_data()
    {
        try
        {
            var id = (from a in linq_obj.registraion_msts
                      where a.intglcode == Convert.ToInt32(Session["id1"].ToString())
                      select new
                      {
                          code = a.intglcode,
                          firstname = a.firstname,
                          lastname = a.lastname,
                          emailid = a.emailid,
                          phoneno = a.phoneno,
                          password =a.password,
                          areaname =a.area_name,
                          landmark=a.landmark,
                          pincode=a.pincode,
                          deals=a.deals_offer_news,
                          adrress=a.adress
                      }).Single();

            txt_firstname.Text = id.firstname;
            txt_lastname.Text = id.lastname;
            txt_emailid.Text = id.emailid;
            txt_phoneno.Text = id.phoneno;
            txt_landmark.Text = id.landmark;
            txt_pincode.Text = id.pincode;
            txt_adrress.Text = id.adrress;

            if (id.deals == "True")
            {
                CheckBox1.Checked = true;
            }
            if (id.deals == "False")
            {
                CheckBox1.Checked = false;
            }

            ddl_googel_area.SelectedValue = id.areaname.ToString();
        }
        catch (Exception)
        {
          
        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            var id = (from a in linq_obj.registraion_msts
                      where a.intglcode == Convert.ToInt32(Session["id1"].ToString())
                      select a).Single();

            id.firstname = txt_firstname.Text;
            id.lastname = txt_lastname.Text;
            id.emailid = txt_emailid.Text;
            id.phoneno = txt_phoneno.Text;
            id.landmark = txt_landmark.Text;
            id.pincode = txt_pincode.Text;
            id.adress = txt_adrress.Text;
            id.area_name = Convert.ToInt32(ddl_googel_area.SelectedValue);
            id.deals_offer_news = CheckBox1.Checked.ToString();

            if (txt_new_password.Text != "" && txt_old_password.Text != "")
            {
                int flag = 0;
                var id2 = (from a in linq_obj.registraion_msts
                           select a).ToList();
                for (int i = 0; i < id2.Count(); i++)
                {
                    if (id2[i].password == txt_old_password.Text)
                    {
                        flag = 1;
                        id2[i].password = txt_new_password.Text;
                        linq_obj.SubmitChanges();
                        //Session.Clear();
                        //Session.Abandon();
                        ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('** Profile Updated Successfully**');window.location='profile.aspx';</script>'");
                        //break;
                    }
                }
                if (flag == 0)
                {
                    Page.RegisterStartupScript("onload", "<script language='javascript'>alert('**Please Enter Correct Old Password**')</script> ");
                }
            }

            linq_obj.SubmitChanges();
            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('** Profile Updated Successfully**');window.location='profile.aspx';</script>'");
        }
        catch (Exception)
        {
            
            
        }
    }
}