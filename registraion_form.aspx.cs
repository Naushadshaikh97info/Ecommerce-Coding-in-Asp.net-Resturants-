using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class registraion_form : System.Web.UI.Page
{
    DataClassesDataContext linq_obj = new DataClassesDataContext();
    static int flag = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        fill_google_area();
        fill_city();


    }
    private void fill_city()
    {
        try
        {
            var id = (from a in linq_obj.city_msts
                      select a).ToList();

            ddl_city.DataSource = id;
            ddl_city.DataBind();
            ddl_city.Items.Insert(0, "--- Select ---");
            ddl_city.SelectedIndex = 1;
        }
        catch (Exception)
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
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {

            if (CheckBox1.Checked == true)
            {

                var id2 = (from a in linq_obj.registraion_msts
                           where a.phoneno == txt_phoneno.Text
                           orderby a.intglcode descending
                           select a).ToList();

                if (id2.Count() == 0)
                {
                    linq_obj.insert_registraion(txt_firstname.Text, txt_lastname.Text, txt_emailid.Text, txt_phoneno.Text, txt_password.Text, "Active", Convert.ToDateTime(System.DateTime.Now.ToString()), Convert.ToInt32(ddl_googel_area.SelectedValue), txt_adress.Text, txt_landmark.Text, "", txt_pincode.Text, System.DateTime.Now.ToShortDateString(), CheckBox2.Checked.ToString());
                    linq_obj.SubmitChanges();

                    var id3 = (from a in linq_obj.registraion_msts
                               orderby a.intglcode descending
                               select a).ToList();

                    if (txt_emailid.Text != "")
                    {
                        SmtpClient smtpclient;
                        MailMessage message;
                        string str23 = "<html><head><title>RedJinni</title></head><body><div><center><table><tr><td align='center'><img alt='RedJinni' src='http://demo.redjinni.com/Images/redjinni%20logo.jpg' runat='server'/></td></tr><tr><td>Welcome To RedJinni! <br /> <br /> URL:http://demo.redjinni.com/ <br /><br> Thanks <br />RedJinni</td></tr></table></center></div></form></body></html>";
                        smtpclient = new SmtpClient();
                        message = new MailMessage();
                        try
                        {
                            var id1 = (from a in linq_obj.emails
                                       select a).Single();
                            message.From = new MailAddress(id1.email1);
                            message.To.Add(txt_emailid.Text);  //send email to yahoo
                            message.Subject = "Account Activation";
                            message.IsBodyHtml = true;
                            message.Body = str23;
                            smtpclient.Host = "mail.redjinni.com";
                            smtpclient.EnableSsl = false;
                            smtpclient.UseDefaultCredentials = true;
                            System.Net.NetworkCredential network = new System.Net.NetworkCredential();
                            network.UserName = id1.email1; // email
                            network.Password = id1.password; //password
                            smtpclient.UseDefaultCredentials = true;
                            smtpclient.Credentials = network;
                            smtpclient.Port = 25;
                            smtpclient.Send(message);
                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.Message);
                        }
                    }
                    if (Request.QueryString["shopcart"] != null)
                    {
                        Session["username1"] = txt_phoneno.Text;
                        Session["id1"] = id3[0].intglcode;
                        Response.Redirect("Flower_shoping_cart.aspx?cart=1");
                    }
                    if (Request.QueryString["cart"] != null)
                    {
                        Session["username1"] = txt_phoneno.Text;
                        Session["id1"] = id3[0].intglcode;
                        Response.Redirect("shoping_cart.aspx?cart=1");
                    }
                    else if (Request.QueryString["bakerycart"] != null)
                    {
                        Session["username1"] = txt_phoneno.Text;
                        Session["id1"] = id3[0].intglcode;
                        Response.Redirect("cake_shoping_cart.aspx?cart=1");
                    }
                    else if (Request.QueryString["cartcake"] != null)
                    {
                        Session["username1"] = txt_phoneno.Text;
                        Session["id1"] = id3[0].intglcode;
                        Response.Redirect("cake_discription.aspx?id=" + Request.QueryString["cartcake"].ToString() + "&&" + "restro=" + Request.QueryString["restro"].ToString());
                    }
                    else if (Request.QueryString["cartflower"] != null)
                    {
                        Session["username1"] = txt_phoneno.Text;
                        Session["id1"] = id3[0].intglcode;
                        Response.Redirect("flower_discription.aspx?id=" + Request.QueryString["cartflower"].ToString() + "&&" + "flowershop=" + Request.QueryString["flowershop"].ToString());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('** Welcome to redjinni.com **');window.location='Default.aspx';</script>'");
                    }
                }
                else
                {
                    Page.RegisterStartupScript("onload", "<script language='javascript'>alert('** Mobile No already exists. Please enter different Mobile No **')</script> ");
                }
            }
            else
            {
                Page.RegisterStartupScript("onload", "<script language='javascript'>alert('** Accept our Privacy policy & Terms and conditions **')</script> ");
            }
        }
        catch (Exception)
        {

        }
    }
    protected void btn_login_Click(object sender, EventArgs e)
    {
        try
        {
            var id = (from a in linq_obj.registraion_msts
                      select a).ToList();

            for (int i = 0; i < id.Count; i++)
            {
                if (id[i].phoneno == txt_login_emailid.Text && id[i].password == txt_login_password.Text && id[i].status == "Active")
                {
                    flag = 1;
                    Session["username1"] = id[i].phoneno;
                    Session["id1"] = id[i].intglcode;
                    break;
                }
            }

            if (flag == 1)
            {
                if (Request.QueryString["cart"] != null)
                {
                    Response.Redirect("shoping_cart.aspx?cart=1");
                }
                if (Request.QueryString["bakerycart"] != null)
                {
                    Response.Redirect("cake_shoping_cart.aspx?cart=1");
                }
                if (Request.QueryString["shopcart"] != null)
                {
                    Response.Redirect("Flower_shoping_cart.aspx?cart=1");
                }
                else if (Request.QueryString["cartcake"] != null)
                {
                    Response.Redirect("cake_discription.aspx?id=" + Request.QueryString["cartcake"].ToString() + "&&" + "restro=" + Request.QueryString["restro"].ToString());
                }
                else if (Request.QueryString["cartflower"] != null)
                {
                    Response.Redirect("flower_discription.aspx?id=" + Request.QueryString["cartflower"].ToString() + "&&" + "flowershop=" + Request.QueryString["flowershop"].ToString());
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                Page.RegisterStartupScript("onload", "<script language='javascript'>alert('**  Incorrect mobile no or password **')</script>");
            }
        }
        catch (Exception)
        {

        }
    }
    protected void btn_forgot_submit_Click(object sender, EventArgs e)
    {
        try
        {
            var id = (from a in linq_obj.registraion_msts
                      where a.phoneno == txt_email_id.Text
                      select a).ToList();

            if (id.Count() != 0)
            {
                try
                {

                    string msg = "Username is: " + id[0].phoneno + " and Password is: " + id[0].password;
                    string url = "http://sms.todaybiz.in/SendSMS/sendmsg.php?uname=webcode&pass=webcode&send=RdJnni&dest=91" + id[0].phoneno + "&msg=" + msg;

                    HttpWebRequest myreq = (HttpWebRequest)WebRequest.Create(url);
                    HttpWebResponse myres = (HttpWebResponse)myreq.GetResponse();
                    StreamReader sr = new StreamReader(myres.GetResponseStream());
                    string str = sr.ReadToEnd();
                    sr.Close();
                    myres.Close();

                    Page.RegisterStartupScript("onload", "<script language='javascript'>alert('** Your password has been successfully sent to your mobile no**')</script>");
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                Page.RegisterStartupScript("onload", "<script language='javascript'>alert('** Enter your correct mobile no**')</script>");
            }

        }
        catch (Exception)
        {

        }
    }
    public class PasswordTextBox : TextBox
    {
        public PasswordTextBox()
        {
            TextMode = TextBoxMode.Password;
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;

                Attributes["value"] = value;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            Attributes["value"] = Text;
        }
    }
}