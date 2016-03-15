using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class restaurant_order_from : System.Web.UI.Page
{
    DataClassesDataContext linq_obj = new DataClassesDataContext();
    static string cuisnes = "";
    static int abc, preordercode;
    static int intCount = 0;
    static DateTime date;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (Request.QueryString["id"] != null)
        {
            int area = Convert.ToInt32(Request.QueryString["id"]);
            FillRestorent(1514, area.ToString(), null, null, 0, 0, 0, 0);
        }
        else
        {
            FillRestorent(1514, null, null, null, 0, 0, 0, 0);
        }

        fill_resturant_location();
        fill_resturant_location1();
        fill_resturant_food_type();
        fill_resturant_food_type1();
    }
    public void FillRestorent(int cityId, string AreaId, string cusionId, string foodtype, int? Rating, int? FreeDelivery, int? MinimumOrderAmount, int? FastdDelevry)
    {
        try
        {
            if (AreaId == "")
            {
                AreaId = null;
            }
            if (cusionId == "")
            {
                cusionId = null;
            }
            if (foodtype == "")
            {
                foodtype = null;
            }


            List<GetFilterResult1Result> _fillData = linq_obj.GetFilterResult1(cityId, AreaId, cusionId, foodtype, Rating, FreeDelivery, MinimumOrderAmount, FastdDelevry).ToList();

            Repeater1.DataSource = _fillData;
            Repeater1.DataBind();

            if (_fillData.Count == 0)
            {
                Page.RegisterStartupScript("onload", "<script language='javascript'>alert('** Result Not Found **')</script>");
            }
        }
        catch (Exception)
        {

        }
    }
    private void fill_resturant_location()
    {
        try
        {
            var id = (from a in linq_obj.location_msts
                      where a.city_id == 1514
                      select a).ToList().Take(10);
            chk_location.DataSource = id;
            chk_location.DataBind();

            if (id.Count() != 10)
            {
                lnk_Seemore.Visible = false;
            }
        }
        catch (Exception)
        {

        }
    }
    private void fill_resturant_location1()
    {
        try
        {
            var id = (from a in linq_obj.location_msts
                      where a.city_id == 1514
                      select a).ToList().Skip(10);
            chk_location1.DataSource = id;
            chk_location1.DataBind();
        }
        catch (Exception)
        {

        }
    }
    private void fill_resturant_food_type()
    {
        try
        {
            var id = (from a in linq_obj.food_category_msts
                      select a).ToList().Take(10);
            chk_food_type.DataSource = id;
            chk_food_type.DataBind();

            if (id.Count() <= 10)
            {
                lnk_Seemore.Visible = false;
            }
        }
        catch (Exception)
        {

        }
    }
    private void fill_resturant_food_type1()
    {
        try
        {
            var id = (from a in linq_obj.food_category_msts
                      select a).ToList().Skip(10);
            chk_food_type1.DataSource = id;
            chk_food_type1.DataBind();
        }
        catch (Exception)
        {

        }
    }
    protected void chk_location_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string locatino = CheakLocationExist();
            string Cusion = checkcusionExist();
            string Foodtype = checkfoodtype();
            FillRestorent(1514, locatino, Cusion, Foodtype, 0, 0, 0, 0);
        }
        catch (Exception)
        {


        }
    }
    protected void chk_cusion_SelectedIndexChanged(object sender, EventArgs e)
    {


        try
        {
            string locatino = CheakLocationExist();
            string Cusion = checkcusionExist();
            string Foodtype = checkfoodtype();
            FillRestorent(1514, locatino, Cusion, Foodtype, 0, 0, 0, 0);
        }
        catch (Exception)
        {

        }


    }
    protected void chk_food_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string locatino = CheakLocationExist();
            string Cusion = checkcusionExist();
            string Foodtype = checkfoodtype();
            FillRestorent(1514, locatino, Cusion, Foodtype, 0, 0, 0, 0);
        }
        catch (Exception)
        {

        }
    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            int flag = 0;
            HiddenField lbl = (HiddenField)e.Item.FindControl("HiddenField1");

            TimeZone curTimeZone = TimeZone.CurrentTimeZone;
            
            Label lbl_foodcuisnie = (Label)e.Item.FindControl("lbl_foodcuisnie");
             Label lbl_Delivery_min_rs = (Label)e.Item.FindControl("lbl_Delivery_min_rs");

            var id = (from a in linq_obj.restaurant_msts
                      where a.intglcode == Convert.ToInt32(lbl.Value)
                      select a).ToList();

            lbl_foodcuisnie.Text = id[0].restro_Cuisines;
            lbl_Delivery_min_rs.Text = id[0].Delivery_min_rs_;
            DateTime dt2 = DateTime.Now;

            int day = dt2.Day;

            String dayName = dt2.DayOfWeek.ToString();
            String todaydate1 = dt2.ToString("ddd");

            Label resturanttime = (Label)e.Item.FindControl("lbl_restuarnts_time");
            Label resturanopentime = (Label)e.Item.FindControl("lbl_opentime");

            Label Afternoonopentime = (Label)e.Item.FindControl("lbl_Afternoonopentime");
            Label Afternoonclosetime = (Label)e.Item.FindControl("lbl_Afternoonclosetime");

            HtmlGenericControl msgDiv = (HtmlGenericControl)e.Item.FindControl("datatime");

            if (todaydate1 == "Mon")
            {
                DateTime dt = curTimeZone.ToLocalTime(DateTime.Now);
                string raj = dt.ToString("hh:mm:ss tt");

                DateTime opentime = Convert.ToDateTime(id[0].mondya_opentime);
                string opentime1 = opentime.ToString("hh:mm:ss tt");
                DateTime clostime = Convert.ToDateTime(id[0].monday_closetime);
                string clostime1 = clostime.ToString("hh:mm:ss tt");
                DateTime raj1 = Convert.ToDateTime(raj);
                string raj2 = raj1.ToString("hh:mm:ss tt");

                HtmlGenericControl gotomenu = (HtmlGenericControl)e.Item.FindControl("goto_menu");
                HtmlGenericControl preorder = (HtmlGenericControl)e.Item.FindControl("preorder");

                if (Convert.ToDateTime(raj2) < Convert.ToDateTime(opentime1))
                {
                    preorder.Visible = true;
                    gotomenu.Visible = false;
                }
                else if (Convert.ToDateTime(raj2) > Convert.ToDateTime(clostime1))
                {
                    preorder.Visible = true;
                    gotomenu.Visible = false;
                }
                else
                {
                    flag = 1;
                    gotomenu.Visible = true;
                    preorder.Visible = false;
                }
                //Aftrnoon Time //
                if (flag == 0)
                {
                    DateTime opentimeA = Convert.ToDateTime(id[0].mondya_Afternoonopentime);
                    string opentime1A = opentimeA.ToString("hh:mm:ss tt");
                    DateTime clostimeA = Convert.ToDateTime(id[0].monday_Afternoonclosetime);
                    string clostime1A = clostimeA.ToString("hh:mm:ss tt");
                    DateTime raj1A = Convert.ToDateTime(raj);
                    string raj2A = raj1A.ToString("hh:mm:ss tt");

                    if (Convert.ToDateTime(raj2A) < Convert.ToDateTime(opentime1A))
                    {
                        preorder.Visible = true;
                        gotomenu.Visible = false;
                    }
                    else if (Convert.ToDateTime(raj2A) > Convert.ToDateTime(clostime1A))
                    {
                        preorder.Visible = true;
                        gotomenu.Visible = false;
                    }
                    else
                    {
                        gotomenu.Visible = true;
                        preorder.Visible = false;
                    }
                }
                //End Aftrnoon Time //

            }
            if (todaydate1 == "Tue")
            {
                HtmlGenericControl gotomenu = (HtmlGenericControl)e.Item.FindControl("goto_menu");
                HtmlGenericControl preorder = (HtmlGenericControl)e.Item.FindControl("preorder");

                Button btn_preorder = (Button)e.Item.FindControl("btn_preorder");
                Button btn_gotomenu = (Button)e.Item.FindControl("btn_gotomenu");

                DateTime dt = curTimeZone.ToLocalTime(DateTime.Now);
                string raj = dt.ToString("hh:mm:ss tt");

                if (id[0].Tuesday_opentime == "")
                {
                    gotomenu.Visible = true;
                    preorder.Visible = false;

                    msgDiv.Visible = false;
                }
                if (id[0].Tuesday_closetime == "")
                {
                    gotomenu.Visible = true;
                    preorder.Visible = false;

                    msgDiv.Visible = false;
                }

                DateTime opentime = Convert.ToDateTime(id[0].Tuesday_opentime);
                string opentime1 = opentime.ToString("hh:mm:ss tt");
                DateTime clostime = Convert.ToDateTime(id[0].Tuesday_closetime);
                string clostime1 = clostime.ToString("hh:mm:ss tt");
                DateTime raj1 = Convert.ToDateTime(raj);
                string raj2 = raj1.ToString("hh:mm:ss tt");

                if (Convert.ToDateTime(raj2) < Convert.ToDateTime(opentime1))
                {
                    preorder.Visible = true;
                    gotomenu.Visible = false;
                }
                else if (Convert.ToDateTime(raj2) > Convert.ToDateTime(clostime1))
                {
                    preorder.Visible = true;
                    gotomenu.Visible = false;
                }
                else
                {
                    flag = 1;
                    gotomenu.Visible = true;
                    preorder.Visible = false;
                }

                //Aftrnoon Time //
                if (flag == 0)
                {
                    DateTime opentimeA = Convert.ToDateTime(id[0].Tuesday_Afternoonopentime);
                    string opentime1A = opentimeA.ToString("hh:mm:ss tt");
                    DateTime clostimeA = Convert.ToDateTime(id[0].Tuesday_Afternoonclosetime);
                    string clostime1A = clostimeA.ToString("hh:mm:ss tt");
                    DateTime raj1A = Convert.ToDateTime(raj);
                    string raj2A = raj1A.ToString("hh:mm:ss tt");

                    if (Convert.ToDateTime(raj2A) < Convert.ToDateTime(opentime1A))
                    {
                        preorder.Visible = true;
                        gotomenu.Visible = false;
                    }
                    else if (Convert.ToDateTime(raj2A) > Convert.ToDateTime(clostime1A))
                    {
                        preorder.Visible = true;
                        gotomenu.Visible = false;
                    }
                    else
                    {
                        gotomenu.Visible = true;
                        preorder.Visible = false;
                    }
                }

                //End Aftrnoon Time //
            }
            if (todaydate1 == "Wed")
            {
                HtmlGenericControl gotomenu = (HtmlGenericControl)e.Item.FindControl("goto_menu");
                HtmlGenericControl preorder = (HtmlGenericControl)e.Item.FindControl("preorder");

                DateTime dt = curTimeZone.ToLocalTime(DateTime.Now);
                string raj = dt.ToString("hh:mm:ss tt");

                if (id[0].Wednesday_opentime == "")
                {
                    gotomenu.Visible = true;
                    preorder.Visible = false;
                    msgDiv.Visible = false;
                }
                if (id[0].Wednesday_closetime == "")
                {
                    gotomenu.Visible = true;
                    preorder.Visible = false;
                    msgDiv.Visible = false;
                }

                DateTime opentime = Convert.ToDateTime(id[0].Wednesday_opentime);
                string opentime1 = opentime.ToString("hh:mm:ss tt");
                DateTime clostime = Convert.ToDateTime(id[0].Wednesday_closetime);
                string clostime1 = clostime.ToString("hh:mm:ss tt");
                DateTime raj1 = Convert.ToDateTime(raj);
                string raj2 = raj1.ToString("hh:mm:ss tt");



                if (Convert.ToDateTime(raj2) < Convert.ToDateTime(opentime1))
                {
                    preorder.Visible = true;
                    gotomenu.Visible = false;
                }
                else if (Convert.ToDateTime(raj2) > Convert.ToDateTime(clostime1))
                {
                    preorder.Visible = true;
                    gotomenu.Visible = false;
                }
                else
                {
                    flag = 1;
                    gotomenu.Visible = true;
                    preorder.Visible = false;
                }

                //Aftrnoon Time //
                if (flag == 0)
                {
                    DateTime opentimeA = Convert.ToDateTime(id[0].Wednesday_Afternoonopentime);
                    string opentime1A = opentimeA.ToString("hh:mm:ss tt");
                    DateTime clostimeA = Convert.ToDateTime(id[0].Wednesday_Afternoonclosetime);
                    string clostime1A = clostimeA.ToString("hh:mm:ss tt");
                    DateTime raj1A = Convert.ToDateTime(raj);
                    string raj2A = raj1A.ToString("hh:mm:ss tt");

                    if (Convert.ToDateTime(raj2A) < Convert.ToDateTime(opentime1A))
                    {
                        preorder.Visible = true;
                        gotomenu.Visible = false;
                    }
                    else if (Convert.ToDateTime(raj2A) > Convert.ToDateTime(clostime1A))
                    {
                        preorder.Visible = true;
                        gotomenu.Visible = false;
                    }
                    else
                    {
                        gotomenu.Visible = true;
                        preorder.Visible = false;
                    }
                }
                //End Aftrnoon Time //
            }
            if (todaydate1 == "Thu")
            {
                HtmlGenericControl gotomenu = (HtmlGenericControl)e.Item.FindControl("goto_menu");
                HtmlGenericControl preorder = (HtmlGenericControl)e.Item.FindControl("preorder");

                DateTime dt = curTimeZone.ToLocalTime(DateTime.Now);
                string raj = dt.ToString("hh:mm:ss tt");

                if (id[0].Thursday_opentime == "")
                {
                    gotomenu.Visible = true;
                    preorder.Visible = false;
                    msgDiv.Visible = false;
                }
                if (id[0].Thursday_closetime == "")
                {
                    gotomenu.Visible = true;
                    preorder.Visible = false;
                    msgDiv.Visible = false;
                }

                DateTime opentime = Convert.ToDateTime(id[0].Thursday_opentime);
                string opentime1 = opentime.ToString("hh:mm:ss tt");
                DateTime clostime = Convert.ToDateTime(id[0].Thursday_closetime);
                string clostime1 = clostime.ToString("hh:mm:ss tt");
                DateTime raj1 = Convert.ToDateTime(raj);
                string raj2 = raj1.ToString("hh:mm:ss tt");



                if (Convert.ToDateTime(raj2) < Convert.ToDateTime(opentime1))
                {
                    preorder.Visible = true;
                    gotomenu.Visible = false;
                }
                else if (Convert.ToDateTime(raj2) > Convert.ToDateTime(clostime1))
                {
                    preorder.Visible = true;
                    gotomenu.Visible = false;
                }
                else
                {
                    flag = 1;
                    gotomenu.Visible = true;
                    preorder.Visible = false;
                }

                //Aftrnoon Time //
                if (flag == 0)
                {
                    DateTime opentimeA = Convert.ToDateTime(id[0].Thursday_Afternoonopentime);
                    string opentime1A = opentimeA.ToString("hh:mm:ss tt");
                    DateTime clostimeA = Convert.ToDateTime(id[0].Thursday_Afternoonclosetime);
                    string clostime1A = clostimeA.ToString("hh:mm:ss tt");
                    DateTime raj1A = Convert.ToDateTime(raj);
                    string raj2A = raj1A.ToString("hh:mm:ss tt");

                    if (Convert.ToDateTime(raj2A) < Convert.ToDateTime(opentime1A))
                    {
                        preorder.Visible = true;
                        gotomenu.Visible = false;
                    }
                    else if (Convert.ToDateTime(raj2A) > Convert.ToDateTime(clostime1A))
                    {
                        preorder.Visible = true;
                        gotomenu.Visible = false;
                    }
                    else
                    {
                        gotomenu.Visible = true;
                        preorder.Visible = false;
                    }
                }
                //End Aftrnoon Time //
            }
            if (todaydate1 == "Fri")
            {
                HtmlGenericControl gotomenu = (HtmlGenericControl)e.Item.FindControl("goto_menu");
                HtmlGenericControl preorder = (HtmlGenericControl)e.Item.FindControl("preorder");

                DateTime dt = curTimeZone.ToLocalTime(DateTime.Now);
                string raj = dt.ToString("hh:mm:ss tt");

                DateTime opentime = Convert.ToDateTime(id[0].Friday_opentime);
                string opentime1 = opentime.ToString("hh:mm:ss tt");
                DateTime clostime = Convert.ToDateTime(id[0].Friday_closetime);
                string clostime1 = clostime.ToString("hh:mm:ss tt");
                DateTime raj1 = Convert.ToDateTime(raj);
                string raj2 = raj1.ToString("hh:mm:ss tt");

                if (id[0].Friday_opentime == "")
                {
                    gotomenu.Visible = true;
                    preorder.Visible = false;
                    msgDiv.Visible = false;
                }
                if (id[0].Friday_closetime == "")
                {
                    gotomenu.Visible = true;
                    preorder.Visible = false;
                    msgDiv.Visible = false;
                }

                if (Convert.ToDateTime(raj2) < Convert.ToDateTime(opentime1))
                {
                    preorder.Visible = true;
                    gotomenu.Visible = false;
                }
                else if (Convert.ToDateTime(raj2) > Convert.ToDateTime(clostime1))
                {
                    preorder.Visible = true;
                    gotomenu.Visible = false;
                }
                else
                {
                    flag = 1;
                    gotomenu.Visible = true;
                    preorder.Visible = false;
                }

                //Aftrnoon Time //
                if (flag == 0)
                {
                    DateTime opentimeA = Convert.ToDateTime(id[0].Friday_Afternoonopentime);
                    string opentime1A = opentimeA.ToString("hh:mm:ss tt");
                    DateTime clostimeA = Convert.ToDateTime(id[0].Friday_Afternoonclosetime);
                    string clostime1A = clostimeA.ToString("hh:mm:ss tt");
                    DateTime raj1A = Convert.ToDateTime(raj);
                    string raj2A = raj1A.ToString("hh:mm:ss tt");

                    if (Convert.ToDateTime(raj2A) < Convert.ToDateTime(opentime1A))
                    {
                        preorder.Visible = true;
                        gotomenu.Visible = false;
                    }
                    else if (Convert.ToDateTime(raj2A) > Convert.ToDateTime(clostime1A))
                    {
                        preorder.Visible = true;
                        gotomenu.Visible = false;
                    }
                    else
                    {
                        gotomenu.Visible = true;
                        preorder.Visible = false;
                    }
                }
                //End Aftrnoon Time //
            }
            if (todaydate1 == "Sat")
            {
                DateTime dt = curTimeZone.ToLocalTime(DateTime.Now);
                string raj = dt.ToString("hh:mm:ss tt");

                DateTime opentime = Convert.ToDateTime(id[0].Saturday_opentime);
                string opentime1 = opentime.ToString("hh:mm:ss tt");
                DateTime clostime = Convert.ToDateTime(id[0].Saturday_closetime);
                string clostime1 = clostime.ToString("hh:mm:ss tt");
                DateTime raj1 = Convert.ToDateTime(raj);
                string raj2 = raj1.ToString("hh:mm:ss tt");

                HtmlGenericControl gotomenu = (HtmlGenericControl)e.Item.FindControl("goto_menu");
                HtmlGenericControl preorder = (HtmlGenericControl)e.Item.FindControl("preorder");

                if (id[0].Saturday_opentime == "")
                {
                    gotomenu.Visible = true;
                    preorder.Visible = false;
                    msgDiv.Visible = false;
                }
                if (id[0].Saturday_closetime == "")
                {
                    gotomenu.Visible = true;
                    preorder.Visible = false;
                    msgDiv.Visible = false;
                }

                if (Convert.ToDateTime(raj2) < Convert.ToDateTime(opentime1))
                {
                    preorder.Visible = true;
                    gotomenu.Visible = false;
                }
                else if (Convert.ToDateTime(raj2) > Convert.ToDateTime(clostime1))
                {
                    preorder.Visible = true;
                    gotomenu.Visible = false;
                }
                else
                {
                    flag = 1;
                    gotomenu.Visible = true;
                    preorder.Visible = false;
                }

                //Aftrnoon Time //
                if (flag == 0)
                {
                    DateTime opentimeA = Convert.ToDateTime(id[0].Saturday_Afternoonopentime);
                    string opentime1A = opentimeA.ToString("hh:mm:ss tt");
                    DateTime clostimeA = Convert.ToDateTime(id[0].Saturday_Afternoonclosetime);
                    string clostime1A = clostimeA.ToString("hh:mm:ss tt");
                    DateTime raj1A = Convert.ToDateTime(raj);
                    string raj2A = raj1A.ToString("hh:mm:ss tt");

                    if (Convert.ToDateTime(raj2A) < Convert.ToDateTime(opentime1A))
                    {
                        preorder.Visible = true;
                        gotomenu.Visible = false;
                    }
                    else if (Convert.ToDateTime(raj2A) > Convert.ToDateTime(clostime1A))
                    {
                        preorder.Visible = true;
                        gotomenu.Visible = false;
                    }
                    else
                    {
                        gotomenu.Visible = true;
                        preorder.Visible = false;
                    }
                }
                //End Aftrnoon Time //
            }
            if (todaydate1 == "Sun")
            {
                DateTime dt = curTimeZone.ToLocalTime(DateTime.Now);
                string raj = dt.ToString("hh:mm:ss tt");

                DateTime opentime = Convert.ToDateTime(id[0].Sunday_opentime);
                string opentime1 = opentime.ToString("hh:mm:ss tt");
                DateTime clostime = Convert.ToDateTime(id[0].Sunday_closetime);
                string clostime1 = clostime.ToString("hh:mm:ss tt");
                DateTime raj1 = Convert.ToDateTime(raj);
                string raj2 = raj1.ToString("hh:mm:ss tt");

                HtmlGenericControl gotomenu = (HtmlGenericControl)e.Item.FindControl("goto_menu");
                HtmlGenericControl preorder = (HtmlGenericControl)e.Item.FindControl("preorder");

                if (id[0].Sunday_opentime == "")
                {
                    gotomenu.Visible = true;
                    preorder.Visible = false;
                    msgDiv.Visible = false;
                }
                if (id[0].Sunday_opentime == "")
                {
                    gotomenu.Visible = true;
                    preorder.Visible = false;
                    msgDiv.Visible = false;
                }

                if (Convert.ToDateTime(raj2) < Convert.ToDateTime(opentime1))
                {
                    preorder.Visible = true;
                    gotomenu.Visible = false;
                }
                else if (Convert.ToDateTime(raj2) > Convert.ToDateTime(clostime1))
                {
                    preorder.Visible = true;
                    gotomenu.Visible = false;
                }
                else
                {
                    flag = 1;
                    gotomenu.Visible = true;
                    preorder.Visible = false;
                }

                //Aftrnoon Time //
                if (flag == 0)
                {
                    DateTime opentimeA = Convert.ToDateTime(id[0].Sunday_Afternoonopentime);
                    string opentime1A = opentimeA.ToString("hh:mm:ss tt");
                    DateTime clostimeA = Convert.ToDateTime(id[0].Sunday_Afternoonclosetime);
                    string clostime1A = clostimeA.ToString("hh:mm:ss tt");
                    DateTime raj1A = Convert.ToDateTime(raj);
                    string raj2A = raj1A.ToString("hh:mm:ss tt");

                    if (Convert.ToDateTime(raj2A) < Convert.ToDateTime(opentime1A))
                    {
                        preorder.Visible = true;
                        gotomenu.Visible = false;
                    }
                    else if (Convert.ToDateTime(raj2A) > Convert.ToDateTime(clostime1A))
                    {
                        preorder.Visible = true;
                        gotomenu.Visible = false;
                    }
                    else
                    {
                        gotomenu.Visible = true;
                        preorder.Visible = false;
                    }
                }
                //End Aftrnoon Time //
            }

            if (todaydate1 == "Mon")
            {
                resturanttime.Text = id[0].mondya_opentime;
                resturanopentime.Text = id[0].monday_closetime;
                Afternoonopentime.Text = id[0].mondya_Afternoonopentime;
                Afternoonclosetime.Text = id[0].monday_Afternoonclosetime;
            }
            if (todaydate1 == "Tue")
            {
                resturanttime.Text = id[0].Tuesday_opentime;
                resturanopentime.Text = id[0].Tuesday_closetime;
                Afternoonopentime.Text = id[0].Tuesday_Afternoonopentime;
                Afternoonclosetime.Text = id[0].Tuesday_Afternoonclosetime;
            }
            if (todaydate1 == "Wed")
            {
                resturanttime.Text = id[0].Wednesday_opentime;
                resturanopentime.Text = id[0].Wednesday_closetime;
                Afternoonopentime.Text = id[0].Wednesday_Afternoonopentime;
                Afternoonclosetime.Text = id[0].Wednesday_Afternoonclosetime;
            }
            if (todaydate1 == "Thu")
            {
                resturanttime.Text = id[0].Thursday_opentime;
                resturanopentime.Text = id[0].Thursday_closetime;
                Afternoonopentime.Text = id[0].Thursday_Afternoonopentime;
                Afternoonclosetime.Text = id[0].Thursday_Afternoonclosetime;
            }
            if (todaydate1 == "Fri")
            {
                resturanttime.Text = id[0].Friday_opentime;
                resturanopentime.Text = id[0].Friday_closetime;
                Afternoonopentime.Text = id[0].Friday_Afternoonopentime;
                Afternoonclosetime.Text = id[0].Friday_Afternoonclosetime;
            }
            if (todaydate1 == "Sat")
            {
                resturanttime.Text = id[0].Saturday_opentime;
                resturanopentime.Text = id[0].Saturday_closetime;
                Afternoonopentime.Text = id[0].Saturday_Afternoonopentime;
                Afternoonclosetime.Text = id[0].Saturday_Afternoonclosetime;
            }
            if (todaydate1 == "Sun")
            {
                resturanttime.Text = id[0].Sunday_opentime;
                resturanopentime.Text = id[0].Sunday_closetime;
                Afternoonopentime.Text = id[0].Sunday_Afternoonopentime;
                Afternoonclosetime.Text = id[0].Sunday_Afternoonclosetime;
            }


            Image veg = (Image)e.Item.FindControl("veg");
            Image nonveg = (Image)e.Item.FindControl("nonveg");
            Label lbl_veg = (Label)e.Item.FindControl("Label2");

            if (id[0].food_type == "1")
            {
                nonveg.Visible = false;
                veg.Visible = true;
            }
            else if (id[0].food_type == "2")
            {
                nonveg.Visible = true;
                veg.Visible = false;
            }
            else if (id[0].food_type == "3")
            {
                nonveg.Visible = true;
                veg.Visible = true;
            }
            else if (id[0].food_type == "4")
            {
                nonveg.Visible = false;
                veg.Visible = true;
            }

            HtmlGenericControl deals = (HtmlGenericControl)e.Item.FindControl("deals");

            if (id[0].Hot_Offers == "True")
            {
                deals.Visible = true;
            }
            if (id[0].Hot_Offers == "False")
            {
                deals.Visible = false;
            }

            HtmlGenericControl freedil = (HtmlGenericControl)e.Item.FindControl("freedilivery");

            if (id[0].free_Delivery_ == "True")
            {
                freedil.Visible = true;
            }

            DateTime d1 = DateTime.Now;
            DateTime d2 = Convert.ToDateTime(id[0].datetime);

            TimeSpan t = d1 - d2;
            double NrOfDays = t.TotalDays;

            if (NrOfDays < 15)
            {
                msgDiv.Visible = true;
            }
            else
            {
                msgDiv.Visible = false;
            }
        }
        catch (Exception)
        {

        }
    }
    protected void lnk_reting_Click(object sender, EventArgs e)
    {
        try
        {
            string locatino = CheakLocationExist();
            string Cusion = checkcusionExist();
            string Foodtype = checkfoodtype();
            FillRestorent(1514, locatino, Cusion, Foodtype, 1, 0, 0, 0);
        }
        catch (Exception)
        {


        }
    }
    protected void lnk_min_order_amt_Click(object sender, EventArgs e)
    {
        try
        {
            string locatino = CheakLocationExist();
            string Cusion = checkcusionExist();
            string Foodtype = checkfoodtype();
            FillRestorent(1514, locatino, Cusion, Foodtype, 0, 0, 1, 0);
        }
        catch (Exception)
        {


        }
    }
    protected void lnk_delivery_free_Click(object sender, EventArgs e)
    {
        try
        {
            string locatino = CheakLocationExist();
            string Cusion = checkcusionExist();
            string Foodtype = checkfoodtype();
            FillRestorent(1514, locatino, Cusion, Foodtype, 0, 1, 0, 0);
        }
        catch (Exception)
        {


        }
    }
    protected void lnk_fast_delivery_Click(object sender, EventArgs e)
    {
        try
        {
            string locatino = CheakLocationExist();
            string Cusion = checkcusionExist();
            string Foodtype = checkfoodtype();
            FillRestorent(1514, locatino, Cusion, Foodtype, 0, 0, 0, 1);
        }
        catch (Exception)
        {

        }
    }

    public string CheakLocationExist()
    {
        string locatino = "";
        for (int i = 0; i < chk_location.Items.Count; i++)
        {
            if (chk_location.Items[i].Selected)
            {
                if (locatino == "")
                {
                    locatino = chk_location.Items[i].Value;
                }
                else
                {
                    locatino += "," + chk_location.Items[i].Value;
                }
            }
        }
        return locatino;
    }
    public string checkcusionExist()
    {
        string cusion = "";
        if (chk_cusion.SelectedIndex == 0)
        {
            if (chk_cusion.SelectedIndex == 1 && chk_cusion.SelectedIndex == 0)
            {
                cusion = "3";
            }
            else if (chk_cusion.SelectedIndex == 0 && chk_cusion.SelectedIndex == 2)
            {
                cusion = "4";
            }
            else
            {
                cusion = "1,3,4";
            }
        }
        else if (chk_cusion.SelectedIndex == 1)
        {
            cusion = "2,3";
        }
        else if (chk_cusion.SelectedIndex == 2)
        {
            cusion = "5,4";
        }
        return cusion;
    }
    public string checkfoodtype()
    {
        string food_type = "";
        for (int i = 0; i < chk_food_type.Items.Count; i++)
        {
            if (chk_food_type.Items[i].Selected)
            {
                if (food_type == "")
                {
                    food_type = chk_food_type.Items[i].Value;
                }
                else
                {
                    food_type += "," + chk_food_type.Items[i].Value;
                }
            }
        }
        for (int i = 0; i < chk_food_type1.Items.Count; i++)
        {
            if (chk_food_type1.Items[i].Selected)
            {
                if (food_type == "")
                {
                    food_type = chk_food_type1.Items[i].Value;
                }
                else
                {
                    food_type += "," + chk_food_type1.Items[i].Value;
                }
            }
        }
        return food_type;
    }
    protected void lnk_Seemore_Click(object sender, EventArgs e)
    {
        try
        {
            chk_location1.Visible = true;
            lnk_Seemore.Visible = false;
            lnk_Close.Visible = true;
        }
        catch (Exception)
        {


        }
    }
    protected void lnk_Close_Click(object sender, EventArgs e)
    {
        try
        {
            chk_location1.Visible = false;
            lnk_Close.Visible = false;
            lnk_Seemore.Visible = true;
        }
        catch (Exception)
        {


        }
    }
    protected void lnk_Close1_Click(object sender, EventArgs e)
    {
        try
        {
            chk_food_type1.Visible = false;
            lnk_Close1.Visible = false;
            lnk_Seemore1.Visible = true;
        }
        catch (Exception)
        {


        }
    }
    protected void lnk_Seemore1_Click(object sender, EventArgs e)
    {
        try
        {
            chk_food_type1.Visible = true;
            lnk_Seemore1.Visible = false;
            lnk_Close1.Visible = true;
        }
        catch (Exception)
        {

        }
    }
    protected void btn_preorder_Click(object sender, EventArgs e)
    {
        try
        {
            rb_list.Items.Clear();
            int flag = 0;
            Button lnk = (Button)sender;
            int code = Convert.ToInt32(lnk.CommandArgument.ToString());
            preordercode = code;

            var id = (from a in linq_obj.restaurant_msts
                      where a.intglcode == code
                      select a).ToList();
            DateTime dt2 = DateTime.Now;

            int day = dt2.Day;

            String dayName = dt2.DayOfWeek.ToString();
            String todaydate1 = dt2.ToString("ddd");

            if (todaydate1 == "Mon")
            {
                //Morning Time//
                TimeZone curTimeZone = TimeZone.CurrentTimeZone;
                DateTime start = Convert.ToDateTime(id[0].mondya_opentime);
                string dt11 = start.ToString("hh:mm:ss tt");

                TimeZone curTimeZone1 = TimeZone.CurrentTimeZone;
                DateTime end = Convert.ToDateTime(id[0].monday_closetime);
                string dt111 = end.ToString("hh:mm:ss tt");
                //End Morning Time//

                //////Aftrnoon Time//
                TimeZone curTimeZoneA = TimeZone.CurrentTimeZone;
                DateTime startA = Convert.ToDateTime(id[0].mondya_Afternoonopentime);
                string dt11A = startA.ToString("hh:mm:ss tt");

                TimeZone curTimeZone1A = TimeZone.CurrentTimeZone;
                DateTime endA = Convert.ToDateTime(id[0].monday_Afternoonclosetime);
                string dt111A = endA.ToString("hh:mm:ss tt");
                //////End Aftrnoon Time//

                double duration = double.Parse(SlotDuration_DDL.SelectedItem.Text);
                string morning = "";
                string afternon = "";
                int i = 0;

                if (dt11 == dt11A && dt111 == dt111A)
                {
                    while (true)
                    {
                        DateTime dtNext = start.AddMinutes(duration);
                        if (start > end || dtNext > end)
                            break;

                        if (start < DateTime.Parse("12:00 AM"))
                        {
                            rb_list.Items.Add(new ListItem(start.ToShortTimeString()));
                            i += 1;
                        }
                        else
                        {
                            rb_list.Items.Add(new ListItem(dtNext.ToShortTimeString()));
                            i += 1;
                        }

                        start = dtNext;
                        flag = 1;
                    }
                }
                if (flag == 0) 
                {

                    while (true)
                    {
                        DateTime dtNext = start.AddMinutes(duration);
                        if (start > end || dtNext > end)
                            break;

                        if (start < DateTime.Parse("12:00 AM"))
                        {
                            rb_list.Items.Add(new ListItem(start.ToShortTimeString()));
                            i += 1;
                        }
                        else
                        {
                            rb_list.Items.Add(new ListItem(dtNext.ToShortTimeString()));
                            i += 1;
                        }

                        start = dtNext;
                       
                    }

                    while (true)
                    {
                        DateTime dtNextA = startA.AddMinutes(duration);
                        if (startA > endA || dtNextA > endA)
                            break;

                        if (startA < DateTime.Parse("12:00 AM"))
                        {
                            rb_list.Items.Add(new ListItem(startA.ToShortTimeString()));
                            i += 1;
                        }
                        else
                        {
                            rb_list.Items.Add(new ListItem(dtNextA.ToShortTimeString()));
                            i += 1;
                        }

                        startA = dtNextA;
                    }
                }

                if (morning.Length > 0)
                    morning = "" + morning;
                if (afternon.Length > 0)
                    afternon = "" + afternon;

                mp1.Show();
            }
            if (todaydate1 == "Tue")
            {
                TimeZone curTimeZone = TimeZone.CurrentTimeZone;
                DateTime start = Convert.ToDateTime(id[0].Tuesday_opentime);
                string dt11 = start.ToString("hh:mm:ss tt");

                TimeZone curTimeZone1 = TimeZone.CurrentTimeZone;
                DateTime end = Convert.ToDateTime(id[0].Thursday_closetime);
                string dt111 = end.ToString("hh:mm:ss tt");
                double duration = double.Parse(SlotDuration_DDL.SelectedItem.Text);


                //////Aftrnoon Time//
                TimeZone curTimeZoneA = TimeZone.CurrentTimeZone;
                DateTime startA = Convert.ToDateTime(id[0].Tuesday_Afternoonopentime);
                string dt11A = startA.ToString("hh:mm:ss tt");

                TimeZone curTimeZone1A = TimeZone.CurrentTimeZone;
                DateTime endA = Convert.ToDateTime(id[0].Tuesday_Afternoonclosetime);
                string dt111A = endA.ToString("hh:mm:ss tt");
                //////End Aftrnoon Time//
                string morning = "";
                string afternon = "";
                int i = 0;

                if (dt11 == dt11A && dt111 == dt111A)
                {
                    while (true)
                    {
                        DateTime dtNext = start.AddMinutes(duration);
                        if (start > end || dtNext > end)
                            break;

                        if (start < DateTime.Parse("12:00 AM"))
                        {
                            rb_list.Items.Add(new ListItem(start.ToShortTimeString()));
                            i += 1;
                        }
                        else
                        {
                            rb_list.Items.Add(new ListItem(dtNext.ToShortTimeString()));
                            i += 1;
                        }

                        start = dtNext;
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    while (true)
                    {
                        DateTime dtNext = start.AddMinutes(duration);
                        if (start > end || dtNext > end)
                            break;

                        if (start < DateTime.Parse("12:00 AM"))
                        {
                            rb_list.Items.Add(new ListItem(start.ToShortTimeString()));
                            i += 1;
                        }
                        else
                        {
                            rb_list.Items.Add(new ListItem(dtNext.ToShortTimeString()));
                            i += 1;
                        }

                        start = dtNext;
                    }
                    while (true)
                    {
                        DateTime dtNextA = startA.AddMinutes(duration);
                        if (startA > endA || dtNextA > endA)
                            break;

                        if (startA < DateTime.Parse("12:00 AM"))
                        {
                            rb_list.Items.Add(new ListItem(startA.ToShortTimeString()));
                            i += 1;
                        }
                        else
                        {
                            rb_list.Items.Add(new ListItem(dtNextA.ToShortTimeString()));
                            i += 1;
                        }

                        startA = dtNextA;
                    }
                }
                if (morning.Length > 0)
                    morning = "" + morning;
                if (afternon.Length > 0)
                    afternon = "" + afternon;

                mp1.Show();
            }
            if (todaydate1 == "Wed")
            {
                TimeZone curTimeZone = TimeZone.CurrentTimeZone;
                DateTime start = Convert.ToDateTime(id[0].Wednesday_opentime);
                string dt11 = start.ToString("hh:mm:ss tt");

                TimeZone curTimeZone1 = TimeZone.CurrentTimeZone;
                DateTime end = Convert.ToDateTime(id[0].Wednesday_closetime);
                string dt111 = end.ToString("hh:mm:ss tt");

                //////Aftrnoon Time//
                TimeZone curTimeZoneA = TimeZone.CurrentTimeZone;
                DateTime startA = Convert.ToDateTime(id[0].Wednesday_Afternoonopentime);
                string dt11A = startA.ToString("hh:mm:ss tt");

                TimeZone curTimeZone1A = TimeZone.CurrentTimeZone;
                DateTime endA = Convert.ToDateTime(id[0].Wednesday_Afternoonclosetime);
                string dt111A = endA.ToString("hh:mm:ss tt");
                //////End Aftrnoon Time//


                double duration = double.Parse(SlotDuration_DDL.SelectedItem.Text);
                string morning = "";
                string afternon = "";
                int i = 0;

                if (dt11 == dt11A && dt111 == dt111A)
                {
                    while (true)
                    {
                        DateTime dtNext = start.AddMinutes(duration);
                        if (start > end || dtNext > end)
                            break;

                        if (start < DateTime.Parse("12:00 AM"))
                        {
                            rb_list.Items.Add(new ListItem(start.ToShortTimeString()));
                            i += 1;
                        }
                        else
                        {
                            rb_list.Items.Add(new ListItem(dtNext.ToShortTimeString()));
                            i += 1;
                        }

                        start = dtNext;
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    while (true)
                    {
                        DateTime dtNext = start.AddMinutes(duration);
                        if (start > end || dtNext > end)
                            break;

                        if (start < DateTime.Parse("12:00 AM"))
                        {
                            rb_list.Items.Add(new ListItem(start.ToShortTimeString()));
                            i += 1;
                        }
                        else
                        {
                            rb_list.Items.Add(new ListItem(dtNext.ToShortTimeString()));
                            i += 1;
                        }

                        start = dtNext;

                    }

                    while (true)
                    {
                        DateTime dtNextA = startA.AddMinutes(duration);
                        if (startA > endA || dtNextA > endA)
                            break;

                        if (startA < DateTime.Parse("12:00 AM"))
                        {
                            rb_list.Items.Add(new ListItem(startA.ToShortTimeString()));
                            i += 1;
                        }
                        else
                        {
                            rb_list.Items.Add(new ListItem(dtNextA.ToShortTimeString()));
                            i += 1;
                        }

                        startA = dtNextA;
                    }
                }
                if (morning.Length > 0)
                    morning = "" + morning;
                if (afternon.Length > 0)
                    afternon = "" + afternon;

                mp1.Show();
            }
            if (todaydate1 == "Thu")
            {
                TimeZone curTimeZone = TimeZone.CurrentTimeZone;
                DateTime start = Convert.ToDateTime(id[0].Thursday_opentime);
                string dt11 = start.ToString("hh:mm:ss tt");

                TimeZone curTimeZone1 = TimeZone.CurrentTimeZone;
                DateTime end = Convert.ToDateTime(id[0].Thursday_closetime);
                string dt111 = end.ToString("hh:mm:ss tt");


                //////Aftrnoon Time//
                TimeZone curTimeZoneA = TimeZone.CurrentTimeZone;
                DateTime startA = Convert.ToDateTime(id[0].Thursday_Afternoonopentime);
                string dt11A = startA.ToString("hh:mm:ss tt");

                TimeZone curTimeZone1A = TimeZone.CurrentTimeZone;
                DateTime endA = Convert.ToDateTime(id[0].Thursday_Afternoonclosetime);
                string dt111A = endA.ToString("hh:mm:ss tt");
                //////End Aftrnoon Time//


                double duration = double.Parse(SlotDuration_DDL.SelectedItem.Text);
                string morning = "";
                string afternon = "";
                int i = 0;

                if (dt11 == dt11A && dt111 == dt111A)
                {
                    while (true)
                    {
                        DateTime dtNext = start.AddMinutes(duration);
                        if (start > end || dtNext > end)
                            break;

                        if (start < DateTime.Parse("12:00 AM"))
                        {
                            rb_list.Items.Add(new ListItem(start.ToShortTimeString()));
                            i += 1;
                        }
                        else
                        {
                            rb_list.Items.Add(new ListItem(dtNext.ToShortTimeString()));
                            i += 1;
                        }

                        start = dtNext;
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    while (true)
                    {
                        DateTime dtNextA = startA.AddMinutes(duration);
                        if (startA > endA || dtNextA > endA)
                            break;

                        if (startA < DateTime.Parse("12:00 AM"))
                        {
                            rb_list.Items.Add(new ListItem(startA.ToShortTimeString()));
                            i += 1;
                        }
                        else
                        {
                            rb_list.Items.Add(new ListItem(dtNextA.ToShortTimeString()));
                            i += 1;
                        }

                        startA = dtNextA;
                    }
                }
                if (morning.Length > 0)
                    morning = "" + morning;
                if (afternon.Length > 0)
                    afternon = "" + afternon;

                mp1.Show();
            }
            if (todaydate1 == "Fri")
            {
                TimeZone curTimeZone = TimeZone.CurrentTimeZone;
                DateTime start = Convert.ToDateTime(id[0].Friday_opentime);
                string dt11 = start.ToString("hh:mm:ss tt");

                TimeZone curTimeZone1 = TimeZone.CurrentTimeZone;
                DateTime end = Convert.ToDateTime(id[0].Friday_closetime);
                string dt111 = end.ToString("hh:mm:ss tt");

                //////Aftrnoon Time//
                TimeZone curTimeZoneA = TimeZone.CurrentTimeZone;
                DateTime startA = Convert.ToDateTime(id[0].Friday_Afternoonopentime);
                string dt11A = startA.ToString("hh:mm:ss tt");

                TimeZone curTimeZone1A = TimeZone.CurrentTimeZone;
                DateTime endA = Convert.ToDateTime(id[0].Friday_Afternoonclosetime);
                string dt111A = endA.ToString("hh:mm:ss tt");
                //////End Aftrnoon Time//

                double duration = double.Parse(SlotDuration_DDL.SelectedItem.Text);
                string morning = "";
                string afternon = "";
                int i = 0;
                if (dt11 == dt11A && dt111 == dt111A)
                {
                    while (true)
                    {
                        DateTime dtNext = start.AddMinutes(duration);
                        if (start > end || dtNext > end)
                            break;

                        if (start < DateTime.Parse("12:00 AM"))
                        {
                            rb_list.Items.Add(new ListItem(start.ToShortTimeString()));
                            i += 1;
                        }
                        else
                        {
                            rb_list.Items.Add(new ListItem(dtNext.ToShortTimeString()));
                            i += 1;
                        }

                        start = dtNext;
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    while (true)
                    {
                        DateTime dtNextA = startA.AddMinutes(duration);
                        if (startA > endA || dtNextA > endA)
                            break;

                        if (startA < DateTime.Parse("12:00 AM"))
                        {
                            rb_list.Items.Add(new ListItem(startA.ToShortTimeString()));
                            i += 1;
                        }
                        else
                        {
                            rb_list.Items.Add(new ListItem(dtNextA.ToShortTimeString()));
                            i += 1;
                        }

                        startA = dtNextA;
                    }
                }
                if (morning.Length > 0)
                    morning = "" + morning;
                if (afternon.Length > 0)
                    afternon = "" + afternon;

                mp1.Show();
            }
            if (todaydate1 == "Sat")
            {
                TimeZone curTimeZone = TimeZone.CurrentTimeZone;
                DateTime start = Convert.ToDateTime(id[0].Saturday_opentime);
                string dt11 = start.ToString("hh:mm:ss tt");

                TimeZone curTimeZone1 = TimeZone.CurrentTimeZone;
                DateTime end = Convert.ToDateTime(id[0].Saturday_closetime);
                string dt111 = end.ToString("hh:mm:ss tt");

                //////Aftrnoon Time//
                TimeZone curTimeZoneA = TimeZone.CurrentTimeZone;
                DateTime startA = Convert.ToDateTime(id[0].Saturday_Afternoonopentime);
                string dt11A = startA.ToString("hh:mm:ss tt");

                TimeZone curTimeZone1A = TimeZone.CurrentTimeZone;
                DateTime endA = Convert.ToDateTime(id[0].Saturday_Afternoonclosetime);
                string dt111A = endA.ToString("hh:mm:ss tt");
                //////End Aftrnoon Time//

                double duration = double.Parse(SlotDuration_DDL.SelectedItem.Text);
                string morning = "";
                string afternon = "";
                int i = 0;

                if (dt11 == dt11A && dt111 == dt111A)
                {
                    while (true)
                    {
                        DateTime dtNext = start.AddMinutes(duration);
                        if (start > end || dtNext > end)
                            break;

                        if (start < DateTime.Parse("12:00 AM"))
                        {
                            rb_list.Items.Add(new ListItem(start.ToShortTimeString()));
                            i += 1;
                        }
                        else
                        {
                            rb_list.Items.Add(new ListItem(dtNext.ToShortTimeString()));
                            i += 1;
                        }

                        start = dtNext;
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    while (true)
                    {
                        DateTime dtNextA = startA.AddMinutes(duration);
                        if (startA > endA || dtNextA > endA)
                            break;

                        if (startA < DateTime.Parse("12:00 AM"))
                        {
                            rb_list.Items.Add(new ListItem(startA.ToShortTimeString()));
                            i += 1;
                        }
                        else
                        {
                            rb_list.Items.Add(new ListItem(dtNextA.ToShortTimeString()));
                            i += 1;
                        }

                        startA = dtNextA;
                    }
                }
                if (morning.Length > 0)
                    morning = "" + morning;
                if (afternon.Length > 0)
                    afternon = "" + afternon;

                mp1.Show();
            }
            if (todaydate1 == "Sun")
            {
                TimeZone curTimeZone = TimeZone.CurrentTimeZone;
                DateTime start = Convert.ToDateTime(id[0].Sunday_opentime);
                string dt11 = start.ToString("hh:mm:ss tt");

                TimeZone curTimeZone1 = TimeZone.CurrentTimeZone;
                DateTime end = Convert.ToDateTime(id[0].Sunday_closetime);
                string dt111 = end.ToString("hh:mm:ss tt");

                //////Aftrnoon Time//
                TimeZone curTimeZoneA = TimeZone.CurrentTimeZone;
                DateTime startA = Convert.ToDateTime(id[0].Sunday_Afternoonopentime);
                string dt11A = startA.ToString("hh:mm:ss tt");

                TimeZone curTimeZone1A = TimeZone.CurrentTimeZone;
                DateTime endA = Convert.ToDateTime(id[0].Sunday_Afternoonclosetime);
                string dt111A = endA.ToString("hh:mm:ss tt");
                //////End Aftrnoon Time//
                double duration = double.Parse(SlotDuration_DDL.SelectedItem.Text);
                string morning = "";
                string afternon = "";
                int i = 0;

                if (dt11 == dt11A && dt111 == dt111A)
                {
                    while (true)
                    {
                        DateTime dtNext = start.AddMinutes(duration);
                        if (start > end || dtNext > end)
                            break;

                        if (start < DateTime.Parse("12:00 AM"))
                        {
                            rb_list.Items.Add(new ListItem(start.ToShortTimeString()));
                            i += 1;
                        }
                        else
                        {
                            rb_list.Items.Add(new ListItem(dtNext.ToShortTimeString()));
                            i += 1;
                        }

                        start = dtNext;
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    while (true)
                    {
                        DateTime dtNextA = startA.AddMinutes(duration);
                        if (startA > endA || dtNextA > endA)
                            break;

                        if (startA < DateTime.Parse("12:00 AM"))
                        {
                            rb_list.Items.Add(new ListItem(startA.ToShortTimeString()));
                            i += 1;
                        }
                        else
                        {
                            rb_list.Items.Add(new ListItem(dtNextA.ToShortTimeString()));
                            i += 1;
                        }

                        startA = dtNextA;
                    }
                }
                if (morning.Length > 0)
                    morning = "" + morning;
                if (afternon.Length > 0)
                    afternon = "" + afternon;

                mp1.Show();
            }
        }
        catch (Exception)
        {

        }
    }
    protected void btn_send_Click(object sender, EventArgs e)
    {
        try
        {
            //   Button lnk = (Button)sender;
            //  int code = Convert.ToInt32(lnk.CommandArgument.ToString());
            var id = (from a in linq_obj.restaurant_msts
                      where a.intglcode == preordercode
                      select a).ToList();

            Session["dilverytimePreordorder"] = "Date " + ddl_day.SelectedItem.Text + "," + rb_list.SelectedItem.Text;

            Response.Redirect("restaurant_menu.aspx?id=" + id[0].intglcode, false);
        }
        catch (Exception)
        {

        }
    }
    protected void btn_gotomenu_Click(object sender, EventArgs e)
    {
        try
        {
            Button lnk = (Button)sender;
            int code = Convert.ToInt32(lnk.CommandArgument.ToString());
            var id = (from a in linq_obj.restaurant_msts
                      where a.intglcode == code
                      select a).ToList();

            TimeZone curTimeZone = TimeZone.CurrentTimeZone;
            DateTime d3 = curTimeZone.ToLocalTime(DateTime.Now);
            string dt11 = d3.ToString("hh:mm:ss tt");
            dt11 = "";
            Session["dilverytimePreordorder"] = dt11;

            Response.Redirect("restaurant_menu.aspx?id=" + id[0].intglcode, false);
        }
        catch (Exception)
        {

        }
    }
    protected void SlotDuration_DDL_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Rating1_Changed(object sender, RatingEventArgs e)
    {

    }
    protected void btn_review_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        int code = Convert.ToInt32(lnk.CommandArgument.ToString());
        var id = (from a in linq_obj.restaurant_msts
                  where a.intglcode == code
                  select a).ToList();

        Response.Redirect("restaurant_menu.aspx?id=" + id[0].intglcode);
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("restaurants_list.aspx");
    }
}