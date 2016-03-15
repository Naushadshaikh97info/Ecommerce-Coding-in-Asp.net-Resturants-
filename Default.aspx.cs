using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    DataClassesDataContext linq_obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        fill_hot_offer();
        fill_Featured_Restaurants();
        fill_User_Reviews();
        fill_data();

        if (Session["id1"] != null)
        {
            //lbl_welcome.Visible = true;
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
    private void fill_data()
    {
        //try
        //{
        //    var id = (from a in linq_obj.cms_msts
        //              where a.intglcode == 1
        //              select a).Single();
        //    lbl_aboutus.Text = id.about_us;
        //}
        //catch (Exception)
        //{


        //}
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
    private void fill_hot_offer()
    {
        try
        {
            var id = (from a in linq_obj.promocode_msts
                      where a.status == "Active" && a.showonmailpage == "True"
                      orderby a.intglcode descending
                      select new
                      {
                          code = a.intglcode,
                          image = "./upload/" + a.promoimage
                      }).ToList().Take(10);
            Repeater1.DataSource = id;
            Repeater1.DataBind();
        }
        catch (Exception)
        {

        }
    }
    private void fill_Featured_Restaurants()
    {
        try
        {
            var id = (from a in linq_obj.restaurant_msts
                      where a.status == "Active" && a.Featured_Restaurants == "True"
                      orderby a.intglcode descending
                      select new
                      {
                          code = a.intglcode,
                          tital = a.resturant_name,
                          location = a.location,
                          foodtype = a.food_type,
                          image = a.Featured_image
                      }).ToList().Take(7);
            Repeater2.DataSource = id;
            Repeater2.DataBind();

            foreach (RepeaterItem item in Repeater2.Items)
            {
                Image veg = item.FindControl("veg") as Image;
                Image nonveg = item.FindControl("nonveg") as Image;
                Label lbl_veg = item.FindControl("Label1") as Label;

                if (lbl_veg.Text == "1")
                {
                    nonveg.Visible = false;
                    veg.Visible = true;
                }
                else if (lbl_veg.Text == "2")
                {
                    nonveg.Visible = true;
                    veg.Visible = false;
                }
                else if (lbl_veg.Text == "3")
                {
                    nonveg.Visible = true;
                    veg.Visible = true;
                }
                else if (lbl_veg.Text == "4")
                {
                    nonveg.Visible = false;
                    veg.Visible = true;
                }
            }

        }
        catch (Exception)
        {

        }
    }
    private void fill_User_Reviews()
    {
        try
        {
            var id = (from a in linq_obj.reviews_msts
                      join b in linq_obj.restaurant_msts on a.restaurant_id equals b.intglcode
                      where a.status == "Active"
                      orderby a.intglcode descending
                      select new
                      {
                          code = b.intglcode,
                          tital = b.resturant_name,
                          location = a.review.Substring(0, 140),
                          name = a.name,
                          Rating = b.star
                      }).ToList().Take(8);
            Repeater3.DataSource = id;
            Repeater3.DataBind();
        }
        catch (Exception)
        {

        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton lnk = (ImageButton)sender;
            int code = Convert.ToInt32(lnk.CommandArgument.ToString());
            var id = (from a in linq_obj.promocode_msts
                      where a.intglcode == code
                      select a).ToList();

            TimeZone curTimeZone = TimeZone.CurrentTimeZone;
            DateTime d3 = curTimeZone.ToLocalTime(DateTime.Now);
            string dt11 = d3.ToString("hh:mm:ss tt");

            Session["dilverytime"] = dt11;

            Response.Redirect("restaurant_menu.aspx?id=" + id[0].resto_id, false);
        }
        catch (Exception)
        {

        }
    }
    protected void Rating1_Changed(object sender, AjaxControlToolkit.RatingEventArgs e)
    {

    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_searcharea.Text != "")
            {
                var id = (from a in linq_obj.restaurant_msts
                          join b in linq_obj.location_msts on a.area equals b.intglcode
                          where b.location == txt_searcharea.Text
                          select a).ToList();

                if (id.Count == 0)
                {
                    Page.RegisterStartupScript("onload", "<script language='javascript'>alert('** Result Not Found **')</script>");
                }
                else
                {
                    Response.Redirect("restaurants_list.aspx?id=" + id[0].area);
                }
            }
            else if (txt_search_restaurants.Text != "")
            {
                var id = (from a in linq_obj.restaurant_msts
                          where a.resturant_name == txt_search_restaurants.Text
                          select a).ToList();
                if (id.Count == 0)
                {
                    Page.RegisterStartupScript("onload", "<script language='javascript'>alert('** Result Not Found **')</script>");
                }
                else
                {
                    Response.Redirect("restaurants_list.aspx?id=" + id[0].intglcode);
                }
            }
            else if (txt_search_dish.Text != "")
            {
                var id = (from a in linq_obj.menu_msts
                          where a.item_name == txt_search_dish.Text
                          select a).ToList();

                if (id.Count == 0)
                {
                    Page.RegisterStartupScript("onload", "<script language='javascript'>alert('** Result Not Found **')</script>");
                }
                else
                {
                    Response.Redirect("item_order.aspx?id=" + id[0].item_name);
                }
            }

            else if (txt_searcharea.Text == "" && txt_search_restaurants.Text == "" && txt_search_dish.Text == "")
            {
                Page.RegisterStartupScript("onload", "<script language='javascript'>alert('Please Enter Any One')</script>");
            }


        }
        catch (Exception)
        {

        }
    }
}