using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Xml;
using System.Data;
using System.IO;
using System.Xml.XPath;
using System.Web.UI.HtmlControls;


public partial class restaurant_menu : System.Web.UI.Page
{
    static DataTable dt, chargedt;
    static int count = 0, code = 0;
    static int totalvalue;
    static int abc;
    static string dt1;
    int error_flag = 0;
    DataClassesDataContext linq_obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["addcart"] == null)
        {
            createtable();
        }
        else
        {
            dt = (DataTable)Session["addcart"];
        }

        if (Session["delicharge"] == null)
        {
            createtable1();
        }
        else
        {
            chargedt = (DataTable)Session["delicharge"];
        }

        if (IsPostBack)
            return;
        if(Session["deliveryarea"] == null)
        {
            mp_google_area.Show();
        lbl_resturantsname.Visible = false;
        Button2.Visible = false;
        }
        else
        {
            string strValue = Session["deliveryarea"].ToString();
            string[] strArray = strValue.Split(',');

            lbl_location.Text = strArray[0].ToString();
            fill_calcudeliverycgarge();
            lbl_resturantsname.Visible = true;
            Button2.Visible = true;
        }
        gridfill();
        fill_rating();
        fill_review();
        fill_main_list();
        fill_info();
        fill_hot_offer();
        fill_google_area();

       


        if (Request.QueryString["id2"] != null)
        {
            pnl_menu.Visible = false;
            pnl_review.Visible = true;
        }

        try
        {
            if (Session["restro_multi"] == null)
            {
                Session["restro_multi"] = Request.QueryString["id"].ToString();
            }
            else
            {
                var id = (from a in linq_obj.restaurant_msts
                          where a.intglcode == Convert.ToInt32(Session["restro_multi"].ToString())
                          select a).ToList();
                if (id.Count() != 0)
                {
                    Session["idea"] = "1";
                }
            }

            if (Request.QueryString["id"] != null)
            {
                fill_menu_item();
                fill_data();
                fill_repeater_item();
                fill_location();
                fill_Delivery();
            }
        }
        catch (Exception)
        {

        }
    }
    private void fill_google_area()
    {
        var id = (from a in linq_obj.googel_are_msts
                  orderby a.nickname ascending
                  select a).ToList();
        ddl_googel_area.DataSource = id;
        ddl_googel_area.DataBind();
        ddl_googel_area.Items.Insert(0, "Select your location");
    }
    private void fill_hot_offer()
    {
        try
        {
            var id = (from a in linq_obj.promocode_msts
                      where a.resto_id == Convert.ToInt32(Request.QueryString["id"].ToString())
                      where a.status == "Active"
                      orderby a.intglcode descending
                      select new
                      {
                          code = a.intglcode,
                          image = "./upload/" + a.promoimage
                      }).ToList().Take(10);
            Repeater9.DataSource = id;
            Repeater9.DataBind();
        }
        catch (Exception)
        {

        }
    }
    private void fill_info()
    {
        try
        {
            var id = (from a in linq_obj.restaurant_msts
                      where a.intglcode == Convert.ToInt32(Request.QueryString["id"].ToString())
                      select a).Single();

            lbl_resturants_name.Text = id.resturant_name;
            lbl_monday_opentime.Text = id.mondya_opentime;
            lbl_monday_closetime.Text = id.monday_closetime;
            lbl_mondaya_aftrnoon_open.Text = id.mondya_Afternoonopentime;
            lbl_mondaya_aftrnoon_close.Text = id.monday_Afternoonclosetime;
            Tuesday_opentime.Text = id.Thursday_opentime;
            Tuesday_closetime.Text = id.Thursday_closetime;
            TuesdayAfternoonopentime.Text = id.Tuesday_Afternoonopentime;
            TuesdayAfternoonclosetime.Text = id.Tuesday_Afternoonclosetime;
            Wednesday_opentime.Text = id.Wednesday_opentime;
            Wednesday_closetime.Text = id.Wednesday_closetime;
            WednesdayAfternoonopentime.Text = id.Wednesday_Afternoonopentime;
            WednesdayAfternoonclosetime.Text = id.Wednesday_Afternoonclosetime;
            Thursday_opentime.Text = id.Thursday_opentime;
            Thursday_closetime.Text = id.Thursday_closetime;
            Thursday_Afternoonopentime.Text = id.Thursday_Afternoonopentime;
            Thursday_Afternoonclosetime.Text = id.Thursday_Afternoonclosetime;
            friday_opentime.Text = id.Friday_opentime;
            friday_closetime.Text = id.Friday_closetime;
            FridayAfternoonopentime.Text = id.Friday_Afternoonopentime;
            FridayAfternoonclosetime.Text = id.Friday_Afternoonclosetime;
            Saturday_opentime.Text = id.Saturday_opentime;
            Saturday_closetime.Text = id.Saturday_closetime;
            SaturdayAfternoonopentime.Text = id.Saturday_Afternoonopentime;
            SaturdayAfternoonclosetime.Text = id.Saturday_Afternoonclosetime;
            Sunday_opentime.Text = id.Sunday_opentime;
            Sunday_closetime.Text = id.Sunday_closetime;
            SundayAfternoonopentime.Text = id.Sunday_Afternoonopentime;
            SundayAfternoonclosetime.Text = id.Sunday_Afternoonclosetime;
            lbl_deliveryfee.Text = id.Delivery_min_rs_;
            lbl_delivery_time.Text = id.Delivery_time;
            lbl_adress.Text = id.location;
        }
        catch (Exception)
        {

        }
    }
    private void fill_rating()
    {
        try
        {
            var id = (from a in linq_obj.star_msts
                      select a).ToList();
            rb_rating.DataSource = id;
            rb_rating.DataBind();
        }
        catch (Exception)
        {

        }
    }
    private void fill_main_list()
    {
        try
        {
            var id = (from a in linq_obj.food_category_msts
                      join b in linq_obj.menu_msts on a.intglcode equals b.food_category
                      where b.restaurant == Convert.ToInt32(Request.QueryString["id"].ToString())
                      select new
                      {
                          name = a.food_category
                      }).ToList().Distinct();
            Repeater8.DataSource = id;
            Repeater8.DataBind();
        }
        catch (Exception)
        {

        }
    }
    private void fill_review()
    {
        try
        {
            var id = (from a in linq_obj.reviews_msts
                      where a.restaurant_id == Convert.ToInt32(Request.QueryString["id"].ToString()) && a.status == "Active"
                      select new
                      {
                          code = a.intglcode,
                          name = a.name,
                          review = a.review,
                          Rating = a.rating_id,
                          date = a.datatime.ToString()
                      }).ToList();
            Repeater7.DataSource = id;
            Repeater7.DataBind();
        }
        catch (Exception)
        {

        }
    }
    private void createtable1()
    {
        try
        {
            chargedt = new DataTable();
            chargedt.Columns.Add("restro_id");
            chargedt.Columns.Add("deli_charge");
            chargedt.Columns.Add("restro_loca"); 
            chargedt.Columns.Add("custo_loca");
            chargedt.Columns.Add("total_km");
        }
        catch (Exception ex)
        {

        }
    }
    private void createtable()
    {
        try
        {
            dt = new DataTable();
            dt.Columns.Add("drpquantity");
            dt.Columns.Add("productname");
            dt.Columns.Add("actualprice");
            dt.Columns.Add("totalprice");
            dt.Columns.Add("productcode");
            dt.Columns.Add("restro_id");
            dt.Columns.Add("extraitem");
        }
        catch (Exception ex)
        {

        }
    }
    protected void drpquantity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dtMarks1 = dt.Clone();

            foreach (DataRow dr in dt.Rows)
            {
                dtMarks1.ImportRow(dr);
            }
            dtMarks1.AcceptChanges();


            DataView dv = dtMarks1.DefaultView;
            dv.Sort = "restro_id DESC";

            for (int i = 0; i < grd_shoping.Rows.Count; i++)
            {
                DropDownList drp = (DropDownList)grd_shoping.Rows[i].FindControl("drpquantity");
              
                int drp_t = Convert.ToInt32(drp.Text.ToString());

                decimal actual_price = Convert.ToDecimal(dv[i].Row[3].ToString()) / Convert.ToDecimal(dv[i].Row[0].ToString());
                decimal actual_packing_price = Convert.ToDecimal(dv[i].Row[6].ToString()) / Convert.ToDecimal(dv[i].Row[0].ToString());
                    decimal total = Convert.ToDecimal(actual_price) * Convert.ToInt32(drp_t);
                    decimal packing_total = Convert.ToDecimal(actual_packing_price) * Convert.ToInt32(drp_t);
                    total = Math.Round(total, 2);
                    dv[i].Row[3] = total.ToString();
                    dv[i].Row[0] = drp.Text.ToString();
                    dv[i].Row[6] = packing_total.ToString();
                
            }
            dt = dv.ToTable();
            count = 0;
            Session["addcart"] = dt;
            gridfill();

            // Response.Redirect("shoping_cart.aspx");
        }
        catch (Exception ex)
        {

        }
    }
    private void gridfill()
    {
        try
        {
            //   createtable();
            count = 0;
            string restroid1 = "";
            if (dt.Rows.Count != 0)
            {
                grd_shoping.Visible = true;

                DataTable dtMarks1 = dt.Clone();

                foreach (DataRow dr in dt.Rows)
                {
                    dtMarks1.ImportRow(dr);
                }
                dtMarks1.AcceptChanges();


                DataView dv = dtMarks1.DefaultView;
                dv.Sort = "restro_id DESC";

                grd_shoping.DataSource = dv;
                grd_shoping.DataBind();
                int total_quantity = 0;
                decimal total_amt = 0;


                string restroid = dv[0].Row[5].ToString();
                int restro_min_amt = 0;

                int rest_amt = Convert.ToInt32(dv[0].Row[3].ToString());

                for (int i = 0; i < grd_shoping.Rows.Count; i++)
                {
                    var id2 = (from a in linq_obj.restaurant_msts
                               where a.resturant_name == dv[i].Row[5].ToString()
                               select a).ToList();
                    restro_min_amt = Convert.ToInt32(id2[0].Delivery_min_rs_);
                    Label lbl_restroid = (Label)grd_shoping.Rows[i].FindControl("Label4");

                    if (grd_shoping.Rows.Count == 1)
                    {
                        if (rest_amt < restro_min_amt)
                        {
                            lbl_add_to_total.Text = (restro_min_amt - Convert.ToInt32(dv[i].Row[3].ToString())).ToString();
                            lbl_delivery_in1.Text = restro_min_amt.ToString();
                            lbl_restro_name.Text = dv[i].Row[5].ToString();
                            error_flag = 1;
                            pnl_add_total.Visible = true;
                            lnl_chekout1.Visible = true;
                            lnk_process_to_checkout.Visible = false;
                        }
                        else
                        {
                            if (error_flag == 0)
                            {
                                pnl_add_total.Visible = false;
                                lnl_chekout1.Visible = false;
                                lnk_process_to_checkout.Visible = true;
                                pnl_delicuios.Visible = false;
                            }
                        }

                    }
                    else
                    {
                        if ((i + 1) < grd_shoping.Rows.Count)
                        {
                            if (dv[i].Row[5].ToString() == dv[i + 1].Row[5].ToString())
                            {
                                if (error_flag == 0)
                                {
                                    rest_amt += Convert.ToInt32(dv[i + 1].Row[3].ToString());

                                }
                            }
                            else
                            {
                                if (rest_amt < restro_min_amt)
                                {
                                    if (error_flag == 0)
                                    {
                                        lbl_add_to_total.Text = (restro_min_amt - rest_amt).ToString();
                                        lbl_delivery_in1.Text = restro_min_amt.ToString();
                                        lbl_restro_name.Text = dv[i].Row[5].ToString();
                                        error_flag = 1;
                                        pnl_add_total.Visible = true;
                                        lnl_chekout1.Visible = true;
                                        lnk_process_to_checkout.Visible = false;
                                    }
                                }
                                else
                                {
                                    rest_amt = Convert.ToInt32(dv[i + 1].Row[3].ToString());

                                }

                            }
                        }
                        else
                        {
                            //this is last record check for all errors
                            if (rest_amt < restro_min_amt)
                            {
                                if (error_flag == 0)
                                {
                                    lbl_add_to_total.Text = (restro_min_amt - rest_amt).ToString();
                                    lbl_delivery_in1.Text = restro_min_amt.ToString(); ;
                                    lbl_restro_name.Text = dv[i].Row[5].ToString();
                                    error_flag = 1;
                                    pnl_add_total.Visible = true;
                                    lnl_chekout1.Visible = true;
                                    lnk_process_to_checkout.Visible = false;
                                }
                            }
                            else
                            {
                                if (error_flag == 0)
                                {
                                    pnl_add_total.Visible = false;
                                    lnl_chekout1.Visible = false;
                                    lnk_process_to_checkout.Visible = true;
                                    pnl_delicuios.Visible = false;
                                }
                            }
                        }
                    }

                    DropDownList drp = (DropDownList)grd_shoping.Rows[i].FindControl("drpquantity");
                    total_quantity += Convert.ToInt32(drp.SelectedValue.ToString());
                    total_amt = total_amt + Convert.ToDecimal(dt.Rows[i][3].ToString());

                    // lbltotal_qty.Text = total_quantity.ToString();

                    lbl_sub_totle.Text = total_amt.ToString();
                    totalvalue = Convert.ToInt32(total_amt);
                    if ((i + 1) == grd_shoping.Rows.Count)
                    {
                        error_flag = 0;
                    }


                    if (lbl_restroid.Text != restroid1)
                    {

                        lbl_restroid.Text = dv[i].Row[5].ToString();
                        restroid1 = dv[i].Row[5].ToString();
                    }
                    else
                    {

                        lbl_restroid.Text = null;
                    }

                }

                if (Session["idea"] == "1")
                {
                    decimal fianl = (total_amt);
                    lbl_total.Text = fianl.ToString();
                }
                else
                {
                    lbl_total.Text = total_amt.ToString();
                }

                lbl_total_amount.Text = total_amt.ToString();

                var id = (from a in linq_obj.restaurant_msts
                          where a.intglcode == Convert.ToInt32(Request.QueryString["id"].ToString())
                          orderby a.intglcode descending
                          select a).Single();

                //   lbl_delivery_in1.Text = id.Delivery_min_rs_;

                decimal totaladd = Convert.ToInt32(lbl_delivery_in1.Text);
                decimal dilivery_total_amt = 0;
                for (int i = 0; i < grd_shoping.Rows.Count; i++)
                {
                    
                    var naushad = (from a in linq_obj.restaurant_msts
                                   where a.intglcode == Convert.ToInt32(Request.QueryString["id"].ToString())
                                   select a).ToList();

                    if (dv[i].Row[5].ToString() == naushad[0].resturant_name)
                    {
                        dilivery_total_amt = dilivery_total_amt + Convert.ToDecimal(dv[i].Row[3].ToString());
                    }

                }
              

                pnl_menu_cart.Visible = true;
                pnl_delicuios.Visible = false;

                Session["totaladd"] = totaladd;
                dt1 = Session["dilverytimePreordorder"].ToString();
                pnl_menu1.Visible = true;
                pnl_menu2.Visible = false;
                //Label6.Text = dt1;
            }
            else
            {
                lnk_process_to_checkout.Visible = false;
                grd_shoping.Visible = false;
                pnl_menu_cart.Visible = false;
                pnl_menu1.Visible = false;
                pnl_menu2.Visible = true;
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton link = (ImageButton)sender;
            code = Convert.ToInt32(link.CommandArgument.ToString());
            
            var id1 = (from a in linq_obj.Add_New_Extra_Item_msts
                       where a.item_name == code
                       select new
                       {
                           code = a.intglcode,
                           Minimum = a.Minimum,
                           Maximum = a.Maximum,
                           Category = a.Category
                       }).ToList();
            Repeater5.DataSource = id1;
            Repeater5.DataBind();

            for (int i = 0; i < id1.Count(); i++)
            {
                Repeater data1 = (Repeater)Repeater5.Items[i].FindControl("Repeater6");

                var id11 = (from a in linq_obj.product_choices_msts
                            where a.category == id1[i].code
                            select new
                            {
                                code = a.intglcode,
                                item_name = a.extra_item_name,
                                item_price = a.price + ".00"
                            }).ToList();
                data1.DataSource = id11;
                data1.DataBind();
            }

            var id = (from a in linq_obj.menu_msts
                      join b in linq_obj.restaurant_msts on a.restaurant equals b.intglcode
                      where a.intglcode == code
                      select new
                      {
                          intglcode = a.intglcode,
                          item_price = a.item_price,
                          item_name = a.item_name,
                          restro_id = b.resturant_name,
                          packing = a.package_charge
                      }).Single();

            decimal total = Convert.ToDecimal(id.item_price);
            int total_qty = 1;
            int flag = 0;

            if (id1.Count() == 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (id.intglcode == Convert.ToInt32(dt.Rows[i][4].ToString()))
                    {
                        total_qty = 1 + Convert.ToInt32(dt.Rows[i][0].ToString());
                        total = Convert.ToDecimal(id.item_price) * Convert.ToDecimal(total_qty);
                        dt.Rows[i][0] = total_qty.ToString();
                        dt.Rows[i][3] = total.ToString();
                        flag = 1;
                        break;
                    }
                }

                if (flag == 0)
                {
                    dt.Rows.Add(total_qty, id.item_name, id.item_price, total, id.intglcode, id.restro_id,id.packing);
                }
                Session["addcart"] = dt;
                gridfill();
            }
            else
            {
                mp1.Show();
            }
            pnl_menu2.Visible = false;
            pnl_menu1.Visible = true;
        }
        catch (Exception)
        {

        }
    }
    private void fill_Delivery()
    {
        try
        {
            var id = (from a in linq_obj.restaurant_msts
                      where a.intglcode == Convert.ToInt32(Request.QueryString["id"].ToString())
                      select new
                      {
                          code = a.intglcode,
                          Deliverym = a.Delivery_time,
                          Deliverymin = a.Delivery_min_rs_,
                          Rating = a.star,
                          review = a.review,
                          OnlinePayment_Available = a.online_payment
                      }).ToList();
            Repeater6.DataSource = id;
            Repeater6.DataBind();

            foreach (RepeaterItem item in Repeater6.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    System.Web.UI.WebControls.Label lbl_OnlinePayment_Available = (System.Web.UI.WebControls.Label)item.FindControl("lbl_OnlinePayment_Available");
                    System.Web.UI.WebControls.Image Image = (System.Web.UI.WebControls.Image)item.FindControl("Image1");
                    System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label)item.FindControl("Label1");
                    System.Web.UI.HtmlControls.HtmlContainerControl OnlinePayment_Available = (System.Web.UI.HtmlControls.HtmlContainerControl)item.FindControl("OnlinePayment_Available");

                    if (lbl.Text == "True")
                    {
                        lbl_OnlinePayment_Available.Visible = true;
                        Image.Visible = true;
                        OnlinePayment_Available.Visible = true;
                    }
                    else if (lbl.Text == "False")
                    {
                        lbl_OnlinePayment_Available.Visible = false;
                        Image.Visible = false;
                        OnlinePayment_Available.Visible = false;
                    }
                    else
                    {
                        lbl_OnlinePayment_Available.Visible = false;
                        Image.Visible = false;
                        OnlinePayment_Available.Visible = false;
                    }
                }
            }
        }
        catch (Exception)
        {

        }
    }
    private void fill_repeater_item()
    {
        try
        {
            var id = (from a in linq_obj.restaurant_msts
                      where a.intglcode == Convert.ToInt32(Request.QueryString["id"].ToString())
                      select new
                      {
                          code = a.intglcode,
                          foodtype = a.food_type,
                          foodtype1 = a.food_type
                      }).ToList();
            Repeater1.DataSource = id;
            Repeater1.DataBind();

            foreach (RepeaterItem item in Repeater1.Items)
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
    private void fill_location()
    {
        try
        {
            var id = (from a in linq_obj.restaurant_msts
                      where a.intglcode == Convert.ToInt32(Request.QueryString["id"].ToString())
                      select new
                      {
                          code = a.intglcode,
                          location = a.location,
                          title = a.resturant_name,
                          googlelocation = a.google_location
                      }).Single();
            location.Text = id.location;
            menu_title.InnerText = id.title;

        }
        catch (Exception)
        {

        }
    }
    private void fill_menu_item()
    {
        try
        {
            var id = (from a in linq_obj.restaurant_msts
                      where a.intglcode == Convert.ToInt32(Request.QueryString["id"].ToString())
                      select new
                      {
                          code = a.intglcode,
                          image = a.image
                      }).ToList();
            Repeater4.DataSource = id;
            Repeater4.DataBind();
        }
        catch (Exception)
        {

        }
    }
    private void fill_data()
    {
        try
        {
            var id2 = (from a in linq_obj.menu_msts
                       join b in linq_obj.food_category_msts on a.food_category equals b.intglcode
                       where a.restaurant == Convert.ToInt32(Request.QueryString["id"].ToString()) 
                       select new
                       {
                           code = a.intglcode,
                           Title = b.food_category
                       }).GroupBy(x => x.Title).Select(z => z.OrderBy(i => i.code).First()).ToList();

            Repeater2.DataSource = id2;
            Repeater2.DataBind();

            for (int i = 0; i < id2.Count(); i++)
            {
                Repeater data1 = (Repeater)Repeater2.Items[i].FindControl("Repeater3");
                var id3 = (from a in linq_obj.menu_msts
                           join b in linq_obj.food_type_msts on a.food_type equals b.intglcode
                           join c in linq_obj.food_category_msts on a.food_category equals c.intglcode
                           where c.food_category == id2[i].Title && a.restaurant == Convert.ToInt32(Request.QueryString["id"].ToString()) && a.status == "Active"
                           select new
                           {
                               code = a.intglcode,
                               discription = a.discription,
                               List = a.item_name,
                               RS = a.item_price,
                               foodtype = b.food_type
                           }).ToList();
                data1.DataSource = id3;
                data1.DataBind();

                foreach (RepeaterItem item in data1.Items)
                {
                    Image veg = item.FindControl("veg") as Image;
                    Image nonveg = item.FindControl("nonveg") as Image;
                    Label lbl_veg = item.FindControl("Label1") as Label;

                    if (lbl_veg.Text == "Non Veg")
                    {
                        nonveg.Visible = true;
                        veg.Visible = false;
                    }
                    else
                    {
                        veg.Visible = true;
                        nonveg.Visible = false;
                    }

                    Image new_image = item.FindControl("new_image") as Image;
                    HiddenField abc = item.FindControl("HiddenField1") as HiddenField;

                    var id = (from a in linq_obj.menu_msts
                              where a.intglcode == Convert.ToInt32(abc.Value)
                              select a).ToList();

                    DateTime d1 = DateTime.Now;
                    DateTime d2 = Convert.ToDateTime(id[0].datetime);

                    TimeSpan t = d1 - d2;
                    double NrOfDays = t.TotalDays;

                    if (NrOfDays < 15)
                    {
                        new_image.Visible = true;
                    }
                    else
                    {
                        new_image.Visible = false;
                    }
                }
            }
        }
        catch (Exception)
        {

        }
    }
    protected void Repeater4_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            HiddenField lbl = (HiddenField)e.Item.FindControl("HiddenField1");
           
            var id = (from a in linq_obj.restaurant_msts
                      where a.intglcode == Convert.ToInt32(lbl.Value)
                      select a).ToList();

            DateTime d1 = DateTime.Now;
            DateTime d2 = Convert.ToDateTime(id[0].datetime);

            TimeSpan t = d1 - d2;
            double NrOfDays = t.TotalDays;

            HtmlGenericControl msgDiv = (HtmlGenericControl)e.Item.FindControl("datatime");

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


    protected void grd_shoping_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DataTable dtMarks1 = dt.Clone();

                foreach (DataRow dr in dt.Rows)
                {
                     dtMarks1.ImportRow(dr);
                }
                dtMarks1.AcceptChanges();


                DataView dv = dtMarks1.DefaultView;
                dv.Sort = "restro_id DESC";

                DropDownList drp = (DropDownList)e.Row.FindControl("drpquantity");

                drp.SelectedValue = dv[count].Row[0].ToString();
                if (count == 0)
                {

                }
                count++;

                // e.Row.Cells[6].Attributes.Add("onclientclick", "Are You Sure You Want to Delete This Record");
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void btn_send_Click(object sender, EventArgs e)
    {
        try
        {
            int flag = 0;
            decimal total = 0;
            int erroreflag = 0;

            var id11 = (from a in linq_obj.Add_New_Extra_Item_msts
                        where a.item_name == code
                        select new
                        {
                            code = a.intglcode,
                            Minimum = a.Minimum,
                            Maximum = a.Maximum,
                            Category = a.Category
                        }).ToList();

            for (int k = 0; k < id11.Count(); k++)
            {
                Repeater data1 = (Repeater)Repeater5.Items[k].FindControl("Repeater6");
                Label lblmessage = (Label)Repeater5.Items[k].FindControl("Label10");
                 int count = 0;
               
                foreach (RepeaterItem item in data1.Items)
                {
                  // int qty =  Convert.ToInt32(data1.Items.Count);
                    CheckBox veg = item.FindControl("chek_item") as CheckBox;
                   
                    if (veg.Checked == true)
                    {
                        count += 1;
                       
                    }
                }

                if (count > Convert.ToInt32(id11[k].Maximum) || count < Convert.ToInt32(id11[k].Minimum))
                {
                    lblmessage.Text = "You must select at least" + id11[k].Minimum + " choice.";
                    erroreflag = 1;
                }
                else if(erroreflag != 1)
                {
                    erroreflag = 0;
                }
            }
            if (erroreflag == 1)
            {
                mp1.Show();

            }
            else
            {
                //////
                string exteaitems = "";
                decimal extraitemtotal = 0;
                for (int k = 0; k < id11.Count(); k++)
                {
                    Repeater data1 = (Repeater)Repeater5.Items[k].FindControl("Repeater6");
                    
                    foreach (RepeaterItem item in data1.Items)
                    {
                        // int qty =  Convert.ToInt32(data1.Items.Count);
                        CheckBox veg = item.FindControl("chek_item") as CheckBox;
                      
                        if (veg.Checked == true)
                        {
                            count += 1;
                            HiddenField abc = item.FindControl("HiddenField4") as HiddenField;

                            var id1 = (from a in linq_obj.product_choices_msts
                                       join b in linq_obj.restaurant_msts on a.restaurant_name equals b.intglcode
                                       join c in linq_obj.menu_msts on a.item_name equals c.intglcode
                                       where a.intglcode == Convert.ToInt32(abc.Value)
                                       select new
                                       {
                                           intglcode = a.item_name,
                                           extra_item_name = a.extra_item_name,
                                           price = a.price,
                                           restaurant_name = b.resturant_name,
                                           menuitemname = c.item_name,
                                           memuitemprice = c.item_price,
                                           menuitemintglcode = c.intglcode,
                                           packing = c.package_charge
                                       }).ToList();
                            
                            int extraitemflag = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (id1[0].intglcode == Convert.ToInt32(dt.Rows[i][4].ToString()))
                                {

                                    extraitemtotal = extraitemtotal + Convert.ToInt32(id1[0].price);

                                    //  dt.Rows[i][3] = total.ToString();
                                    exteaitems = exteaitems + "," + id1[0].extra_item_name;
                                    //dt.Rows[i][1] = dt.Rows[i][1] + "," + id1[0].extra_item_name;
                                    flag = 1;

                                    if (item.ItemIndex == (data1.Items.Count - 1) && k + 1 == id11.Count())
                                    {

                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                                if (item.ItemIndex == (data1.Items.Count - 1) && k+1 == id11.Count() )
                                {
                                    exteaitems = id1[0].menuitemname + "," + exteaitems;
                                    extraitemtotal = (Convert.ToDecimal(id1[0].memuitemprice) + extraitemtotal);
                                    for (int sagar = 0; sagar < dt.Rows.Count; sagar++)
                                    {
                                        if (dt.Rows[sagar][1].ToString() == exteaitems)
                                        {

                                            dt.Rows[sagar][0] = Convert.ToInt32(dt.Rows[sagar][0]) + 1;
                                            dt.Rows[sagar][3] = Convert.ToInt32(dt.Rows[sagar][0].ToString()) * extraitemtotal;
                                            extraitemflag = 1;
                                            flag = 1;
                                            break;
                                        }
                                    }
                                    if (extraitemflag == 0)
                                    {
                                        dt.Rows.Add(1, exteaitems, id1[0].memuitemprice, extraitemtotal, dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][6].ToString());  
                                        exteaitems = "";
                                        extraitemtotal = 0;
                                        flag = 1;
                                        break;
                                    }
                                }
                            }
                            if (flag == 0)
                            {
                                extraitemtotal = extraitemtotal + Convert.ToInt32(id1[0].price);
                                exteaitems = exteaitems + "," + id1[0].extra_item_name;
                                if ( k + 1 == id11.Count())
                                {
                                    exteaitems = id1[0].menuitemname + "," + exteaitems;
                                    extraitemtotal = (Convert.ToDecimal(id1[0].memuitemprice) + extraitemtotal);
                                    for (int sagar = 0; sagar < dt.Rows.Count; sagar++)
                                    {
                                      
                                        if (dt.Rows[sagar][1].ToString() == exteaitems)
                                        {

                                            dt.Rows[sagar][0] = Convert.ToInt32(dt.Rows[sagar][0]) + 1;
                                            dt.Rows[sagar][3] = Convert.ToInt32(dt.Rows[sagar][0].ToString()) * extraitemtotal;
                                            extraitemflag = 1;
                                            flag = 1;
                                            break;
                                        }
                                    }

                                    if (extraitemflag == 0)
                                    {


                                        dt.Rows.Add(1, exteaitems, id1[0].memuitemprice, extraitemtotal, id1[0].menuitemintglcode, id1[0].restaurant_name, id1[0].packing);
                                        exteaitems = "";
                                        extraitemtotal = 0;
                                        break;
                                    }
                                }
                                
                            }
                           
                           
                        }
                    }

                   
                }
                Session["addcart"] = dt;
                gridfill();
                /////
            }
            
        }
        catch (Exception)
        {

        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            linq_obj.insert_reviews(Convert.ToInt16(rb_rating.SelectedValue), txt_Reviews.Text, txt_name.Text, 0, Convert.ToInt32(Request.QueryString["id"].ToString()), Convert.ToDateTime(System.DateTime.Now.ToShortDateString()), "Deactive");
            linq_obj.SubmitChanges();

            var id = (from a in linq_obj.reviews_msts
                      where a.restaurant_id == Convert.ToInt32(Request.QueryString["id"].ToString())
                      select a).ToList();

            int raj = 0;

            for (int i = 0; i < id.Count(); i++)
            {
                raj = raj + Convert.ToInt32(id[i].rating_id);
            }

            int padu = raj / id.Count();

            var id2 = (from a in linq_obj.restaurant_msts
                       where a.intglcode == Convert.ToInt32(Request.QueryString["id"].ToString())
                       select a).ToList();

            id2[0].review = id.Count();
            id2[0].star = padu;
            linq_obj.SubmitChanges();

            Page.RegisterStartupScript("onload", "<script language='javascript'>alert('** Submitted Successfully**')</script>");
            txt_name.Text = "";
            txt_Reviews.Text = "";
            rb_rating.SelectedIndex = -1;
            fill_review();
        }
        catch (Exception)
        {

        }
    }
    protected void Rating1_Changed(object sender, AjaxControlToolkit.RatingEventArgs e)
    {

    }
    protected void btn_review_Click(object sender, EventArgs e)
    {

        try
        {
            var id = (from a in linq_obj.restaurant_msts
                      where a.intglcode == Convert.ToInt32(Request.QueryString["id"])
                      select a).Single();


            Response.Redirect("restaurant_menu.aspx?id=" + id.intglcode + "#reviews");
        }
        catch (Exception)
        {

        }
    }
    protected void lnk_process_to_checkout_Click(object sender, EventArgs e)
     {
        try
        {
            decimal total_amt = 0;
            decimal totaladd = 0;

            Session["addcart"] = dt;
            
            //dt1 = Session["dilverytimePreordorder"].ToString();
            Session["dilverytimePreordorder"] = dt1;
            total_amt = Convert.ToInt32(Session["total_amount"]);
            totaladd = Convert.ToInt32(Session["totaladd"]);

            var id = (from a in linq_obj.restaurant_msts
                      where a.intglcode == Convert.ToInt32(Request.QueryString["id"].ToString())
                      orderby a.intglcode descending
                      select a).Single();

            //lbl_delivery_in.Text = id.Delivery_min_rs_;


            if (Convert.ToInt32(lbl_total.Text) >= Convert.ToInt32(id.Delivery_min_rs_))
            {
                fill_calcudeliverycgarge();
                Response.Redirect("shoping_cart.aspx", false);
            }
            if (Convert.ToInt32(totaladd) == 0)
            {
                fill_calcudeliverycgarge();
                Response.Redirect("shoping_cart.aspx", false);
            }

        }
        catch (Exception)
        {

        }
    }
    protected void grd_shoping_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (dt.Rows.Count != 0)
            {

                int code = int.Parse(grd_shoping.DataKeys[e.RowIndex].Value.ToString());

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][4].ToString() == code.ToString())
                    {
                        dt.Rows[i].Delete();
                        dt.AcceptChanges();
                        break;
                    }
                }
                //dt.Rows.RemoveAt(e.RowIndex);
                Session["addcart"] = dt;

                //if (dt.Rows.Count == 0)
                //{
                //    // panMain.Visible = false;
                //    Session["total_qty"] = 0;
                //    Session["total_amount"] = 0;

                //}
                //else
                //{
                //    string URL = HttpContext.Current.Request.Url.AbsoluteUri;
                //    System.Uri uri = new System.Uri(URL);
                //    gridfill();
                //}

            }
            if (dt.Rows.Count == 0)
            {
                createtable();
                grd_shoping.Visible = false;
                Response.Redirect("restaurants_list.aspx", false);
            }
            else
            {
                gridfill();
                grd_shoping.Visible = true;
            }

            linq_obj.delete_shoping(Convert.ToInt32(grd_shoping.DataKeys[e.RowIndex].Value.ToString()));
            linq_obj.SubmitChanges();

        }
        catch (Exception ex)
        {

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //var id = (from a in linq_obj.restaurant_msts
        //          where a.google_location == Convert.ToInt32(searchTextField.Text)
        //          select a).ToList();

        //if (id.Count() == 0)
        //{
        //    Page.RegisterStartupScript("onload", "<script language='javascript'>alert('** Please enter Your City Name **')</script>");
        //    mdlpopup.Show();
        //}
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            var id = (from a in linq_obj.restaurant_msts
                      where a.intglcode == Convert.ToInt32(Request.QueryString["id"])
                      select a).Single();

            Response.Redirect("restaurant_menu.aspx?id=" + id.intglcode);
        }
        catch (Exception)
        {

        }
    }
    protected void btn_submit_google_Click(object sender, EventArgs e)
    {
        var id = (from a in linq_obj.restaurant_msts
                  where a.intglcode == Convert.ToInt32(Request.QueryString["id"].ToString())
                  select a).ToList();
        var nickname = (from a in linq_obj.googel_are_msts
                        where a.nickname == ddl_googel_area.SelectedItem.Text
                        select a).ToList();

        //Declare variable to store XML result
        string xmlResult = null;

       

        //Pass request to google api with orgin and destination details
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + id[0].google_location + "&destinations=" + nickname[0].area_name + "&mode=Car&language=us-en&sensor=false");

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        //Get response as stream from httpwebresponse
        StreamReader resStream = new StreamReader(response.GetResponseStream());

        //Create instance for xml document
        XmlDocument doc = new XmlDocument();

        //Load response stream in to xml result
        xmlResult = resStream.ReadToEnd();

        //Load xmlResult variable value into xml documnet
        doc.LoadXml(xmlResult);

        string output = "";

        //Get specified element value using select single node method and verify it return OK (success ) or failed
        if (doc.DocumentElement.SelectSingleNode("/DistanceMatrixResponse/row/element/status").InnerText.ToString().ToUpper() != "OK")
        {
            //lblResult.Text = "Invalid City Name please try again";
            return;
        }

        //Get DistanceMatrixResponse element and its values
        XmlNodeList xnList = doc.SelectNodes("/DistanceMatrixResponse");
        foreach (XmlNode xn in xnList)
        {
            if (xn["status"].InnerText.ToString() == "OK")
            {
                //Form a table and bind it orgin, destination place and return distance value, approximate duration
                output = "<table align='center' width='600' cellpadding='0' cellspacing='0'>";
                output += "<tr><td height='40' align='left'>Distance</td><td align='left'>" + doc.DocumentElement.SelectSingleNode("/DistanceMatrixResponse/row/element/distance/text").InnerText + "</td></tr>";
                output += "</table>";

                //finally bind it in the result label control
                // lblResult.Text = "(" + doc.DocumentElement.SelectSingleNode("/DistanceMatrixResponse/row/element/distance/text").InnerText + ")";
                string abc = doc.DocumentElement.SelectSingleNode("/DistanceMatrixResponse/row/element/distance/text").InnerText;
                string[] test12 = abc.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                decimal km_price = Convert.ToDecimal(Convert.ToDecimal(test12[0].ToString()) * 6);
                decimal totalkm = Convert.ToDecimal(test12[0].ToString());
                int flag = 0;
                for (int i = 0; i < chargedt.Rows.Count; i++)
                {
                    if (chargedt.Rows[i][0].ToString() == id[0].resturant_name)
                    {
                    
                        if (chargedt.Rows[i][0].ToString() == id[0].resturant_name && chargedt.Rows[i][3].ToString() == nickname[0].area_name)
                        {
                            flag = 1;
                        }
                        else
                        {
                            if (id[0].Delivery_Type == "Pure Aggregator")
                            {
                                if (totalkm >= Convert.ToDecimal(id[0].Delivery_Distance_))
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('** This restaurant will not be able to deliver at your area. Please select another restaurant **');window.location='restaurants_list.aspx';</script>'");
                                }
                                else
                                {
                                  
                                    chargedt.Rows[i][0] =id[0].resturant_name;
                                    chargedt.Rows[i][1] =0;
                                    chargedt.Rows[i][2] =id[0].google_location;
                                    chargedt.Rows[i][3] =nickname[0].area_name;
                                    chargedt.Rows[i][4] =totalkm;
                                }
                            }
                            else if (id[0].Delivery_Type == "Pure delivery")
                            {
                                if (totalkm >= Convert.ToDecimal(id[0].Delivery_Distance_))
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('** This restaurant will not be able to deliver at your area. Please select another restaurant **');window.location='restaurants_list.aspx';</script>'");
                                }
                                else
                                {
                                    if (km_price < 25)
                                    {
                                       // chargedt.Rows.Add(id[0].resturant_name, 25, id[0].google_location, ddl_googel_area.SelectedItem.Text, totalkm);
                                        chargedt.Rows[i][0] = id[0].resturant_name;
                                        chargedt.Rows[i][1] = 25;
                                        chargedt.Rows[i][2] = id[0].google_location;
                                        chargedt.Rows[i][3] = nickname[0].area_name;
                                        chargedt.Rows[i][4] = totalkm;
                                    }
                                    else
                                    {
                                      //  chargedt.Rows.Add(id[0].resturant_name, km_price, id[0].google_location, ddl_googel_area.SelectedItem.Text, totalkm);
                                        chargedt.Rows[i][0] = id[0].resturant_name;
                                        chargedt.Rows[i][1] = km_price;
                                        chargedt.Rows[i][2] = id[0].google_location;
                                        chargedt.Rows[i][3] = nickname[0].area_name;
                                        chargedt.Rows[i][4] = totalkm;
                                    }
                                }
                            }
                            else if (id[0].Delivery_Type == "Mixed")
                            {
                                if (totalkm >= Convert.ToDecimal(id[0].Delivery_Distance_))
                                {
                                  //  chargedt.Rows.Add(id[0].resturant_name, km_price, id[0].google_location, ddl_googel_area.SelectedItem.Text, totalkm);
                                    chargedt.Rows[i][0] = id[0].resturant_name;
                                    chargedt.Rows[i][1] = km_price;
                                    chargedt.Rows[i][2] = id[0].google_location;
                                    chargedt.Rows[i][3] = nickname[0].area_name;
                                    chargedt.Rows[i][4] = totalkm;
                                }
                                else
                                {
                                   // chargedt.Rows.Add(id[0].resturant_name, 0, id[0].google_location, ddl_googel_area.SelectedItem.Text, totalkm);
                                    chargedt.Rows[i][0] = id[0].resturant_name;
                                    chargedt.Rows[i][1] = 0;
                                    chargedt.Rows[i][2] = id[0].google_location;
                                    chargedt.Rows[i][3] = nickname[0].area_name;
                                    chargedt.Rows[i][4] = totalkm;
                                }
                            }
                            flag = 1;
                        }
                    }
                }
                if (flag == 0)
                {
                    if (id[0].Delivery_Type == "Pure Aggregator")
                    {
                        if (totalkm >= Convert.ToDecimal(id[0].Delivery_Distance_))
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('** This restaurant will not be able to deliver at your area. Please select another restaurant **');window.location='restaurants_list.aspx';</script>'");
                        }
                        else
                        {
                            chargedt.Rows.Add(id[0].resturant_name, 0, id[0].google_location, nickname[0].area_name, totalkm);
                        }
                    }
                    else if (id[0].Delivery_Type == "Pure delivery")
                    {
                        if (totalkm >= Convert.ToDecimal(id[0].Delivery_Distance_))
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('** This restaurant will not be able to deliver at your area. Please select another restaurant **');window.location='restaurants_list.aspx';</script>'");
                        }
                        else
                        {
                            if (km_price < 25)
                            {
                                chargedt.Rows.Add(id[0].resturant_name, 25, id[0].google_location, nickname[0].area_name, totalkm);
                            }
                            else
                            {
                                chargedt.Rows.Add(id[0].resturant_name, km_price, id[0].google_location, nickname[0].area_name, totalkm);
                            }
                        }
                    }
                    else if (id[0].Delivery_Type == "Mixed")
                    {
                        if (totalkm >= Convert.ToDecimal(id[0].Delivery_Distance_))
                        {
                            chargedt.Rows.Add(id[0].resturant_name, km_price, id[0].google_location, nickname[0].area_name, totalkm);
                        }
                        else
                        {
                            chargedt.Rows.Add(id[0].resturant_name, 0, id[0].google_location, nickname[0].area_name, totalkm);
                        }
                    }
                }
                Session["delicharge"] = chargedt;
                Session["deliveryarea"] = nickname[0].area_name;
                Session["deliveryareavalue"] = nickname[0].intglcode;
            
                //string strValue= Session["deliveryarea"].ToString();
                //string[] strArray = strValue.Split(',');

                lbl_location.Text = ddl_googel_area.SelectedItem.Text;
                lbl_resturantsname.Visible = true;
                Button2.Visible = true;
            }
        }
    }
    private void fill_calcudeliverycgarge()
    {
        var id = (from a in linq_obj.restaurant_msts
                  where a.intglcode == Convert.ToInt32(Request.QueryString["id"].ToString())
                  select a).ToList();

     
        //Declare variable to store XML result
        string xmlResult = null;

        //Pass request to google api with orgin and destination details
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + id[0].google_location + "&destinations=" + Session["deliveryarea"].ToString() + "&mode=Car&language=us-en&sensor=false");

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        //Get response as stream from httpwebresponse
        StreamReader resStream = new StreamReader(response.GetResponseStream());

        //Create instance for xml document
        XmlDocument doc = new XmlDocument();

        //Load response stream in to xml result
        xmlResult = resStream.ReadToEnd();

        //Load xmlResult variable value into xml documnet
        doc.LoadXml(xmlResult);

        string output = "";

        //Get specified element value using select single node method and verify it return OK (success ) or failed
        if (doc.DocumentElement.SelectSingleNode("/DistanceMatrixResponse/row/element/status").InnerText.ToString().ToUpper() != "OK")
        {
            //lblResult.Text = "Invalid City Name please try again";
            return;
        }

        //Get DistanceMatrixResponse element and its values
        XmlNodeList xnList = doc.SelectNodes("/DistanceMatrixResponse");
        foreach (XmlNode xn in xnList)
        {
            if (xn["status"].InnerText.ToString() == "OK")
            {
                //Form a table and bind it orgin, destination place and return distance value, approximate duration
                output = "<table align='center' width='600' cellpadding='0' cellspacing='0'>";
                output += "<tr><td height='40' align='left'>Distance</td><td align='left'>" + doc.DocumentElement.SelectSingleNode("/DistanceMatrixResponse/row/element/distance/text").InnerText + "</td></tr>";
                output += "</table>";

                //finally bind it in the result label control
                // lblResult.Text = "(" + doc.DocumentElement.SelectSingleNode("/DistanceMatrixResponse/row/element/distance/text").InnerText + ")";
                string abc = doc.DocumentElement.SelectSingleNode("/DistanceMatrixResponse/row/element/distance/text").InnerText;
                string[] test12 = abc.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                decimal km_price = Convert.ToDecimal(Convert.ToDecimal(test12[0].ToString()) * 6);
                decimal totalkm = Convert.ToDecimal(test12[0].ToString());
                int flag = 0;
                int restrototal = 0;
                var id5 = (from a in linq_obj.restaurant_msts
                          where a.intglcode == Convert.ToInt32(Request.QueryString["id"].ToString())
                          select a).ToList();


                for (int i = 0; i < chargedt.Rows.Count; i++)
                {
                    if (chargedt.Rows[i][0].ToString() == id[0].resturant_name && chargedt.Rows[i][3].ToString() == Session["deliveryarea"].ToString())
                    {

                        for (int k = 0; k < dt.Rows.Count; k++)
                        {
                            if (dt.Rows[k][5].ToString() == id5[0].resturant_name)
                            {
                                restrototal += Convert.ToInt32(dt.Rows[k][3].ToString());
                            }
                        }
                        if (id[0].Delivery_Type == "Pure delivery")
                        {
                            if (restrototal < 200)
                            {
                                km_price = Convert.ToDecimal(Convert.ToDecimal(test12[0].ToString()) * 12);

                                if (km_price < 50)
                                {
                                    chargedt.Rows[i][0] = id[0].resturant_name;
                                    chargedt.Rows[i][1] = "50";
                                    chargedt.Rows[i][2] = id[0].google_location;
                                    chargedt.Rows[i][3] = Session["deliveryarea"].ToString();
                                    chargedt.Rows[i][4] =totalkm;
                                }
                                else
                                {
                                    chargedt.Rows[i][0] = id[0].resturant_name;
                                    chargedt.Rows[i][1] = km_price;
                                    chargedt.Rows[i][2] = id[0].google_location;
                                    chargedt.Rows[i][3] = Session["deliveryarea"].ToString();
                                    chargedt.Rows[i][4] = totalkm;
                                }

                            }
                            else
                            {
                                km_price = Convert.ToDecimal(Convert.ToDecimal(test12[0].ToString()) * 6);

                                if (km_price < 25)
                                {
                                    chargedt.Rows[i][0] = id[0].resturant_name;
                                    chargedt.Rows[i][1] = "25";
                                    chargedt.Rows[i][2] = id[0].google_location;
                                    chargedt.Rows[i][3] = Session["deliveryarea"].ToString();
                                    chargedt.Rows[i][4] = totalkm;
                                }
                                else
                                {
                                    chargedt.Rows[i][0] = id[0].resturant_name;
                                    chargedt.Rows[i][1] = km_price;
                                    chargedt.Rows[i][2] = id[0].google_location;
                                    chargedt.Rows[i][3] = Session["deliveryarea"].ToString();
                                    chargedt.Rows[i][4] = totalkm;
                                }

                            }
                        }
                        else if (id[0].Delivery_Type == "Mixed")
                        {
                            if (totalkm >= Convert.ToDecimal(id[0].Delivery_Distance_))
                            {
                                if (restrototal < 200)
                                {
                                    km_price = Convert.ToDecimal(Convert.ToDecimal(test12[0].ToString()) * 12);

                                    if (km_price < 50)
                                    {
                                        chargedt.Rows[i][0] = id[0].resturant_name;
                                        chargedt.Rows[i][1] = "50";
                                        chargedt.Rows[i][2] = id[0].google_location;
                                        chargedt.Rows[i][3] = Session["deliveryarea"].ToString();
                                        chargedt.Rows[i][4] = totalkm;
                                    }
                                    else
                                    {
                                        chargedt.Rows[i][0] = id[0].resturant_name;
                                        chargedt.Rows[i][1] = km_price;
                                        chargedt.Rows[i][2] = id[0].google_location;
                                        chargedt.Rows[i][3] = Session["deliveryarea"].ToString();
                                        chargedt.Rows[i][4] = totalkm;
                                    }

                                }
                                else
                                {
                                    km_price = Convert.ToDecimal(Convert.ToDecimal(test12[0].ToString()) * 6);

                                    if (km_price < 25)
                                    {
                                        chargedt.Rows[i][0] = id[0].resturant_name;
                                        chargedt.Rows[i][1] = "25";
                                        chargedt.Rows[i][2] = id[0].google_location;
                                        chargedt.Rows[i][3] = Session["deliveryarea"].ToString();
                                        chargedt.Rows[i][4] = totalkm;
                                    }
                                    else
                                    {
                                        chargedt.Rows[i][0] = id[0].resturant_name;
                                        chargedt.Rows[i][1] = km_price;
                                        chargedt.Rows[i][2] = id[0].google_location;
                                        chargedt.Rows[i][3] = Session["deliveryarea"].ToString();
                                        chargedt.Rows[i][4] = totalkm;
                                    }

                                }

                            }
                        }
                        Session["delicharge"] = chargedt;
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    if (id[0].Delivery_Type == "Pure Aggregator")
                    {
                        if (totalkm >= Convert.ToDecimal(id[0].Delivery_Distance_))
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('** This restaurant will not be able to deliver at your area. Please select another restaurant **');window.location='restaurants_list.aspx';</script>'");
                        }
                        else
                        {
                            chargedt.Rows.Add(id[0].resturant_name, 0, id[0].google_location, Session["deliveryarea"].ToString(), totalkm);
                        }
                    }
                    else if (id[0].Delivery_Type == "Pure delivery")
                    {
                        if (totalkm >= Convert.ToDecimal(id[0].Delivery_Distance_))
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('** This restaurant will not be able to deliver at your area. Please select another restaurant **');window.location='restaurants_list.aspx';</script>'");
                        }
                        else
                        {
                            if (km_price < 25)
                            {
                                chargedt.Rows.Add(id[0].resturant_name, 25, id[0].google_location, Session["deliveryarea"].ToString(), totalkm);
                            }
                            else
                            {
                                chargedt.Rows.Add(id[0].resturant_name, km_price, id[0].google_location, Session["deliveryarea"].ToString(), totalkm);
                            }
                        }
                    }
                    else if (id[0].Delivery_Type == "Mixed")
                    {
                        if (totalkm >= Convert.ToDecimal(id[0].Delivery_Distance_))
                        {
                            chargedt.Rows.Add(id[0].resturant_name, km_price, id[0].google_location, Session["deliveryarea"].ToString(), totalkm);
                        }
                        else
                        {
                            chargedt.Rows.Add(id[0].resturant_name, 0, id[0].google_location, Session["deliveryarea"].ToString(), totalkm);
                        }
                    }
                }
                Session["delicharge"] = chargedt;
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Button2.Visible = false;
        lbl_resturantsname.Visible = false;
        lbl_location.Text = "";
        mp_google_area.Show();
    }
    protected void link_itemname_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton link = (LinkButton)sender;
            code = Convert.ToInt32(link.CommandArgument.ToString());

            var id1 = (from a in linq_obj.Add_New_Extra_Item_msts

                       where a.item_name == code
                       select new
                       {
                           code = a.intglcode,

                           Minimum = a.Minimum,
                           Maximum = a.Maximum,
                           Category = a.Category
                       }).ToList();
            Repeater5.DataSource = id1;
            Repeater5.DataBind();

            for (int i = 0; i < id1.Count(); i++)
            {
                Repeater data1 = (Repeater)Repeater5.Items[i].FindControl("Repeater6");

                var id11 = (from a in linq_obj.product_choices_msts
                            where a.category == id1[i].code
                            select new
                            {
                                code = a.intglcode,
                                item_name = a.extra_item_name,
                                item_price = a.price + ".00"
                            }).ToList();
                data1.DataSource = id11;
                data1.DataBind();
            }

            var id = (from a in linq_obj.menu_msts
                      join b in linq_obj.restaurant_msts on a.restaurant equals b.intglcode
                      where a.intglcode == code
                      select new
                      {
                          intglcode = a.intglcode,
                          item_price = a.item_price,
                          item_name = a.item_name,
                          restro_id = b.resturant_name,
                          packing = a.package_charge
                      }).Single();

            decimal total = Convert.ToDecimal(id.item_price);
            int total_qty = 1;
            int flag = 0;

            if (id1.Count() == 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (id.intglcode == Convert.ToInt32(dt.Rows[i][4].ToString()))
                    {
                        total_qty = 1 + Convert.ToInt32(dt.Rows[i][0].ToString());
                        total = Convert.ToDecimal(id.item_price) * Convert.ToDecimal(total_qty);
                        dt.Rows[i][0] = total_qty.ToString();
                        dt.Rows[i][3] = total.ToString();
                        flag = 1;
                        break;
                    }
                }

                if (flag == 0)
                {
                    dt.Rows.Add(total_qty, id.item_name, id.item_price, total, id.intglcode, id.restro_id, id.packing);
                }
                Session["addcart"] = dt;
                gridfill();
            }
            else
            {

                mp1.Show();


            }
            pnl_menu2.Visible = false;
            pnl_menu1.Visible = true;
        }
        catch (Exception)
        {

        }
    }
}
