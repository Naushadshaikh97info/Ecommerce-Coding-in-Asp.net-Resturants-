using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Data;
using System.Net.Mail;
using System.Xml;
using System.Net;

public partial class shoping_cart : System.Web.UI.Page
{
    DataClassesDataContext linq_obj = new DataClassesDataContext();
    static DataTable dt, chargedt;
    static int count = 0, code = 0;
    static int totalvalue;
    static int abc;
    static string dt1;
    static int restroid2 = 0;
    static int noofselection = 0;
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
        if (Request.QueryString["id"] != null)
        {
            gridfill();
        }
      
        if (IsPostBack)
            return;
        gridfill();
        fill_city();
        fill_google_area();
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
        var id = (from a in linq_obj.googel_are_msts
                  orderby a.nickname ascending
                  select a).ToList();
        ddl_googel_area.DataSource = id;
        ddl_googel_area.DataBind();
        ddl_googel_area.Items.Insert(0, "--- Select your location ---");
    }
    private void gridfill()
    {
        try
        {
            string restroid1 = "";
            if (Request.QueryString["id"] != null)
            {
                var id = (from a in linq_obj.shopingcarts
                          join c in linq_obj.restaurant_msts on a.resturants_id equals c.intglcode
                          join d in linq_obj.menu_msts on a.fk_productcode equals d.intglcode
                          where a.fk_order == Convert.ToInt32(Request.QueryString["id"])
                          orderby a.resturants_id descending
                          select new
                          {
                              code = a.intglcode,
                              productcode = a.intglcode,
                              productname = d.item_name,
                              drpquantity = a.quantity,
                              restro_id = c.resturant_name,
                              actualprice = d.item_price,
                              totalprice = a.total_price
                          }).ToList();
                grd_shoping.DataSource = id;
                grd_shoping.DataBind();

                lbl_subtotle.Text = id[0].totalprice;
                lbltotal_amt.Text = id[0].totalprice;

                if (Session["idea"] == "1")
                {
                    decimal fianl = totalvalue;
                    lbltotal_amt.Text = fianl.ToString();
                }
                else
                {
                    Label2.Visible = false;
                    lbltotal_amt.Text = id[0].totalprice;
                }

                decimal a1 = Convert.ToDecimal(Convert.ToDecimal(lbltotal_amt.Text) * 14 / Convert.ToDecimal(100));
                decimal g1 = Convert.ToDecimal(Convert.ToDecimal(lbltotal_amt.Text));

                lbl_grand_total.Text = g1.ToString("0.00");
                //   lbl_service_tex.Text = a1.ToString();

                Session["total_qty"] = id[0].drpquantity;
                Session["total_amount"] = id[0].totalprice;

                decimal km_price = Convert.ToDecimal(Session["kmprice"]);
                lbl_delivery_fee.Text = km_price.ToString(); 

                decimal total = Convert.ToDecimal(lbl_subtotle.Text) + Convert.ToDecimal(lbl_service_tex.Text) + km_price + Convert.ToDecimal(lbl_packing.Text);
                lbl_grand_total.Text = total.ToString("0.00");
            }
            else
            {
                //  createtable();
                count = 0;
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

                    grd_shopingcart.DataSource = dv;
                    grd_shopingcart.DataBind();

                    int total_quantity = 0;
                    decimal total_amt = 0;
                    int miltirestro = 0, restroid = 0;
                    int restro_total = 0;
                    int mark = 0;
                    for (int i = 0; i < grd_shoping.Rows.Count; i++)
                    {
                        var raj = (from a in linq_obj.restaurant_msts
                                   where a.resturant_name == dv[i].Row[5].ToString()
                                   select a).ToList();
                      


                        if (raj.Count != 0)
                        {
                            if (restroid == 0)
                            {
                                restro_total += Convert.ToInt32(dv[i].Row[3].ToString());
                                if (i + 1 == grd_shoping.Rows.Count)
                                {

                                    var tax1 = (from a in linq_obj.restaurant_msts
                                                where a.resturant_name == dv[i].Row[5].ToString()
                                                select a).ToList();
                                    int restropaching = 0;
                                    for (int k = 0; k < dt.Rows.Count; k++)
                                    {
                                        if (dt.Rows[k][5].ToString() == dv[i].Row[5].ToString())
                                        {

                                            restropaching += Convert.ToInt32(dt.Rows[k][6].ToString());
                                        }
                                    }

                                    decimal per1 = Convert.ToDecimal(tax1[0].Vat) + Convert.ToDecimal(tax1[0].Service_tax_);
                                    decimal stax1 = ((restro_total + restropaching) * per1 / 100);
                                    decimal finaltax = Convert.ToDecimal(lbl_service_tex.Text) + stax1;
                                    lbl_service_tex.Text = finaltax.ToString();
                                }

                                miltirestro = miltirestro + 10;
                                //  Label2.Text = (miltirestro - 10).ToString();
                                restroid = raj[0].intglcode;
                            }
                            else if (restroid == raj[0].intglcode)
                            {
                                restro_total += Convert.ToInt32(dv[i].Row[3].ToString());
                                if (i + 1 == grd_shoping.Rows.Count)
                                {

                                    var tax1 = (from a in linq_obj.restaurant_msts
                                                where a.resturant_name == dv[i].Row[5].ToString()
                                                select a).ToList();

                                    int restropaching = 0;
                                    for (int k = 0; k < dt.Rows.Count; k++)
                                    {
                                        if (dt.Rows[k][5].ToString() == dv[i].Row[5].ToString())
                                        {

                                            restropaching += Convert.ToInt32(dt.Rows[k][6].ToString());
                                        }
                                    }

                                    decimal per1 = Convert.ToDecimal(tax1[0].Vat) + Convert.ToDecimal(tax1[0].Service_tax_);
                                    decimal stax1 = ((restro_total + restropaching) * per1 / 100);
                                    decimal finaltax = Convert.ToDecimal(lbl_service_tex.Text) + stax1;
                                    lbl_service_tex.Text = finaltax.ToString();
                                }
                            }
                            else
                            {
                                var tax = (from a in linq_obj.restaurant_msts
                                           where a.resturant_name == dv[i - 1].Row[5].ToString()
                                           select a).ToList();

                                int restropaching = 0;
                                for (int k = 0; k < dt.Rows.Count; k++)
                                {
                                    if (dt.Rows[k][5].ToString() == dv[i].Row[5].ToString())
                                    {

                                        restropaching += Convert.ToInt32(dt.Rows[k][6].ToString());
                                    }
                                }

                                decimal per = Convert.ToDecimal(tax[0].Vat) + Convert.ToDecimal(tax[0].Service_tax_);
                                decimal stax = ((restro_total + restropaching) * per / 100);
                                decimal finaltax1 = Convert.ToDecimal(lbl_service_tex.Text) + stax;
                                lbl_service_tex.Text = finaltax1.ToString();
                                restro_total = 0;

                                if (i + 1 == grd_shoping.Rows.Count)
                                {
                                    restro_total += Convert.ToInt32(dv[i].Row[3].ToString());

                                    var tax1 = (from a in linq_obj.restaurant_msts
                                                where a.resturant_name == dv[i].Row[5].ToString()
                                                select a).ToList();


                                    for (int k = 0; k < dt.Rows.Count; k++)
                                    {
                                        if (dt.Rows[k][5].ToString() == dv[i].Row[5].ToString())
                                        {

                                            restropaching += Convert.ToInt32(dt.Rows[k][6].ToString());
                                        }
                                    }

                                    decimal per1 = Convert.ToDecimal(tax1[0].Vat) + Convert.ToDecimal(tax1[0].Service_tax_);
                                    decimal stax1 = ((restro_total + restropaching) * per1 / 100);
                                    decimal finaltax = Convert.ToDecimal(lbl_service_tex.Text) + stax1;
                                    lbl_service_tex.Text = finaltax.ToString();
                                }
                                else
                                {
                                    restro_total += Convert.ToInt32(dv[i].Row[3].ToString());
                                }
                                miltirestro = miltirestro + 10;
                                // Label2.Text = (miltirestro - 10).ToString();
                                restroid = raj[0].intglcode;
                            }
                        }
                        else
                        {
                            Label2.Text = "0";
                        }

                    }
                    int delivry = 0;
                    for (int i = 0; i < grd_shoping.Rows.Count; i++)
                    {
                        DropDownList drp = (DropDownList)grd_shoping.Rows[i].FindControl("drpquantity");
                        Label lbl_restroid = (Label)grd_shoping.Rows[i].FindControl("Label3");
                        if (lbl_restroid.Text != restroid1)
                        {

                            lbl_restroid.Text = dv[i].Row[5].ToString();
                            restroid1 = dv[i].Row[5].ToString();
                        }
                        else
                        {

                            lbl_restroid.Text = null;
                        }
                        total_quantity += Convert.ToInt32(drp.SelectedValue.ToString());
                        total_amt = total_amt + Convert.ToDecimal(dt.Rows[i][3].ToString());
                        //lbltotal_qty.Text = total_quantity.ToString();

                        lbl_subtotle.Text = total_amt.ToString();
                        totalvalue = Convert.ToInt32(total_amt);
                        delivry += Convert.ToInt32(dt.Rows[i][6].ToString());
                    }
                    lbl_packing.Text = delivry.ToString();
                    if (Session["idea"] == "1")
                    {
                        decimal fianl = (total_amt);
                        lbltotal_amt.Text = fianl.ToString();
                    }
                    else
                    {
                        Label2.Visible = false;
                        lbltotal_amt.Text = total_amt.ToString();
                    }

                    decimal km_price = 0;
                    int chargeflag = 0;
                    for (int i = 0; i < chargedt.Rows.Count; i++)
                    {
                        for (int j = 0; j < grd_shoping.Rows.Count; j++)
                        {
                            if (chargedt.Rows[i][0].ToString() == dv[j].Row[5].ToString())
                            {

                                chargeflag = 1;
                            }
                           
                        }
                        if (chargeflag == 0)
                        {
                            chargedt.Rows[i].Delete();
                            Session["delicharge"] = chargedt;
                        }
                        else
                        {
                            km_price += Convert.ToDecimal(chargedt.Rows[i][1].ToString());
                            chargeflag = 0;
                        }
                    }

                    //decimal a = Convert.ToDecimal(Convert.ToDecimal(lbltotal_amt.Text) * 14 / Convert.ToDecimal(100));
                    decimal g = Convert.ToDecimal(Convert.ToDecimal(lbltotal_amt.Text)) + km_price + Convert.ToDecimal(lbl_service_tex.Text) + Convert.ToDecimal(lbl_packing.Text);
                    lbl_delivery_fee.Text = km_price.ToString();
                    lbl_grand_total.Text = g.ToString("0.00");
                    //   lbl_service_tex.Text = a.ToString();

                    Session["total_qty"] = total_quantity;
                    Session["total_amount"] = total_amt;
                    pnl_menu_cart.Visible = true;
                    pnl_cart.Visible = false;

                    dt1 = Session["dilverytimePreordorder"].ToString();
                    Session["dilverytime"] = dt1;

                    if (Session["dilverytime"] == null)
                    {
                        TimeZone curTimeZone = TimeZone.CurrentTimeZone;
                        DateTime d3 = curTimeZone.ToLocalTime(DateTime.Now);
                        string dt11 = d3.ToString("hh:mm:ss tt");
                        dt1 = dt11;
                    }
                    if (Session["dilverytime"] != null)
                    {
                        Session["dilverytime"] = dt1;
                    }
                    Session["dilverytime"] = dt1;
                    //  Label3.Text = dt1;

                }
                else
                {
                    grd_shoping.Visible = false;
                    pnl_menu_cart.Visible = false;
                }
            }
        }
        catch (Exception ex)
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
            if (dt == null)
            {
                dt = new DataTable();
                dt.Columns.Add("drpquantity");
                dt.Columns.Add("productname");
                dt.Columns.Add("actualprice");
                dt.Columns.Add("totalprice");
                dt.Columns.Add("productcode");
                dt.Columns.Add("restro_id");
                dt.Columns.Add("bakery_id");
                dt.Columns.Add("flower_shop_id");
                dt = (DataTable)Session["addcart"];
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void drpquantity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            for (int i = 0; i < grd_shoping.Rows.Count; i++)
            {
                DropDownList drp = (DropDownList)grd_shoping.Rows[i].FindControl("drpquantity");
                int drp_t = Convert.ToInt32(drp.Text.ToString());
                decimal actual_price = Convert.ToDecimal(dt.Rows[i][3].ToString()) / Convert.ToDecimal(dt.Rows[i][0].ToString());
                decimal actual_packing_price = Convert.ToDecimal(dt.Rows[i][6].ToString()) / Convert.ToDecimal(dt.Rows[i][0].ToString());
                decimal total = Convert.ToDecimal(actual_price) * Convert.ToInt32(drp_t);
                decimal packing_total = Convert.ToDecimal(actual_packing_price) * Convert.ToInt32(drp_t);
                total = Math.Round(total, 2);
                dt.Rows[i][3] = total.ToString();
                dt.Rows[i][0] = drp.Text.ToString();
                dt.Rows[i][6] = packing_total.ToString();
            }

            count = 0;
            gridfill();


            decimal totaladd = 0;
            decimal dilivery_total_amt = 0;

            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            int rowIndex = row.RowIndex;

            int code = Convert.ToInt32(grd_shoping.DataKeys[rowIndex].Value.ToString());

            var id = (from a in linq_obj.restaurant_msts
                      join b in linq_obj.menu_msts on a.intglcode equals b.restaurant
                      where b.intglcode == code
                      select a).ToList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i][5].ToString() == id[0].resturant_name.ToString())
                {
                    totaladd = Convert.ToDecimal(id[0].Delivery_min_rs_);
                    dilivery_total_amt = dilivery_total_amt + Convert.ToDecimal(dt.Rows[i][3].ToString());
                }
            }
            if (Convert.ToInt32(dilivery_total_amt) < Convert.ToInt32(totaladd))
            {
                decimal msgamt = totaladd - dilivery_total_amt;
                string strMsg = "Add Rs." + msgamt + " to reach Rs." + totaladd + ", the minimum amount for delivery in " + id[0].resturant_name + " Restaurant ";
                Response.Write("<script>alert('" + strMsg + "')</script>");
                btn_chekout.Enabled = false;
            }
            else
            {
                btn_chekout.Enabled = true;
            }
            decimal km_price = 0;
            for (int i = 0; i < chargedt.Rows.Count; i++)
            {
                if (chargedt.Rows[i][0].ToString() == id[0].resturant_name)
                {
                    if (id[0].Delivery_Type == "Pure delivery")
                    {
                        if (dilivery_total_amt < 200)
                        {
                            km_price = Convert.ToDecimal(Convert.ToDecimal(chargedt.Rows[i][4].ToString()) * 12);

                            if (km_price < 50)
                            {
                                chargedt.Rows[i][0] = id[0].resturant_name;
                                chargedt.Rows[i][1] = "50";
                                chargedt.Rows[i][2] = id[0].google_location;
                                chargedt.Rows[i][3] = Session["deliveryarea"].ToString();
                                chargedt.Rows[i][4] = chargedt.Rows[i][4].ToString();
                            }
                            else
                            {
                                chargedt.Rows[i][0] = id[0].resturant_name;
                                chargedt.Rows[i][1] = km_price;
                                chargedt.Rows[i][2] = id[0].google_location;
                                chargedt.Rows[i][3] = Session["deliveryarea"].ToString();
                                chargedt.Rows[i][4] = chargedt.Rows[i][4].ToString();
                            }

                        }
                        else
                        {
                            km_price = Convert.ToDecimal(Convert.ToDecimal(chargedt.Rows[i][4].ToString()) * 6);

                            if (km_price < 25)
                            {
                                chargedt.Rows[i][0] = id[0].resturant_name;
                                chargedt.Rows[i][1] = "25";
                                chargedt.Rows[i][2] = id[0].google_location;
                                chargedt.Rows[i][3] = Session["deliveryarea"].ToString();
                                chargedt.Rows[i][4] = chargedt.Rows[i][4].ToString();
                            }
                            else
                            {
                                chargedt.Rows[i][0] = id[0].resturant_name;
                                chargedt.Rows[i][1] = km_price;
                                chargedt.Rows[i][2] = id[0].google_location;
                                chargedt.Rows[i][3] = Session["deliveryarea"].ToString();
                                chargedt.Rows[i][4] = chargedt.Rows[i][4].ToString();
                            }

                        }
                    }
                    else if (id[0].Delivery_Type == "Mixed")
                    {
                        decimal totalkm = Convert.ToDecimal(chargedt.Rows[i][4].ToString());
                        if (totalkm >= Convert.ToDecimal(id[0].Delivery_Distance_))
                        {
                            if (dilivery_total_amt < 200)
                            {
                                km_price = Convert.ToDecimal(Convert.ToDecimal(chargedt.Rows[i][4].ToString()) * 12);

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
                                km_price = Convert.ToDecimal(Convert.ToDecimal(chargedt.Rows[i][4].ToString()) * 6);

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
                }
            }
            Session["delicharge"] = chargedt;
            gridfill();
            // Response.Redirect("shoping_cart.aspx");
        }
        catch (Exception ex)
        {

        }
    }
    protected void grd_shoping_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList drp = (DropDownList)e.Row.FindControl("drpquantity");

                drp.SelectedValue = dt.Rows[count][0].ToString();
                count++;
                // e.Row.Cells[6].Attributes.Add("onclientclick", "Are You Sure You Want to Delete This Record");

            }




        }
        catch (Exception ex)
        {

        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            var id = (from a in linq_obj.restaurant_msts
                      where a.resturant_name == dt.Rows[0][5].ToString()
                      select a).ToList();

            Response.Redirect("restaurant_menu.aspx?id=" + id[0].intglcode);
        }
        catch (Exception)
        {

        }
    }
    private void fill_adrress_list()
    {
        var id = (from a in linq_obj.order_details
                  where a.fk_memberid == Convert.ToInt32(Session["id1"])
                  select a).GroupBy(x => x.address).Select(z => z.OrderBy(i => i.intglcode).First()).ToList();
        rb_adrress_list.DataSource = id;
        rb_adrress_list.DataBind();
    }
    protected void btn_chekout_Click(object sender, EventArgs e)
    {
        if (Session["username1"] != null)
        {
            fill_adrress_list();
            var id = (from a in linq_obj.registraion_msts
                      where a.intglcode == Convert.ToInt32(Session["id1"].ToString())
                      join b in linq_obj.googel_are_msts on a.area_name equals b.intglcode
                      orderby a.intglcode descending
                      select new
                      {
                          code = a.intglcode,
                          firstname = a.firstname,
                          area_name = a.area_name,
                          adress = a.adress,
                          emailid = a.emailid,
                          phoneno = a.phoneno,
                          pincode = a.pincode,
                          lastname = a.lastname,
                          landmark = a.landmark
                      }).Single();

            txt_yourname.Text = id.firstname;
            txt_last_name.Text = id.lastname;
            txt_emailid.Text = id.emailid;
            txt_mobileno.Text = id.phoneno;
            txt_pincode.Text = id.pincode;
            txt_adrress.Text = id.adress;
            txt_last_name.Text = id.lastname;
            txt_landmark.Text = id.landmark;
            fill_google_area();

            ddl_googel_area.SelectedValue = Session["deliveryareavalue"].ToString();


            Session["dilverytimePreordorder"] = dt1;
            
            if (Session["dilverytimePreordorder"] != null)
            {
                RadioButton1.Visible = false;
                RadioButton2.Visible = false;
                txt_calender.Visible = false;
                ddl_time.Visible = false;
                ddl_category.Visible = false;
            }
          

            if (Session["dilverytimePreordorder"] == "")
            {
                RadioButton1.Visible = true;
                RadioButton2.Visible = true;
            }
           
            mp1.Show();
        }
        else
        {
            Response.Redirect("registraion_form.aspx?cart=1");
        }
    }
    protected void grd_shoping_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void btn_delete_item_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton btn = (ImageButton)sender;

            GridViewRow row = (GridViewRow)btn.NamingContainer;

            int code = Convert.ToInt32(btn.CommandArgument.ToString());

            if (dt.Rows.Count != 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][4].ToString() == code.ToString())
                    {
                        dt.Rows[i].Delete();
                        dt.AcceptChanges();
                    }
                }

                //dt.Rows.RemoveAt(row.RowIndex);
                Session["addcart"] = dt;

                //if (dt.Rows.Count == 0)
                //{
                //    // panMain.Visible = false;
                //    Session["total_qty"] = 0;
                //    Session["total_amount"] = 0;
                //    Response.Redirect("restaurants_list.aspx", false);
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

            linq_obj.delete_shoping(code);
            linq_obj.SubmitChanges();

            DataTable dtMarks1 = dt.Clone();


            foreach (DataRow dr in dt.Rows)
            {
                dtMarks1.ImportRow(dr);
            }
            dtMarks1.AcceptChanges();


            DataView dv = dtMarks1.DefaultView;
            dv.Sort = "restro_id DESC";
            decimal totaladd = 0;
            decimal dilivery_total_amt = 0;
            var naushad = (from a in linq_obj.restaurant_msts
                           join b in linq_obj.menu_msts on a.intglcode equals b.restaurant
                           where b.intglcode == code
                           select a).ToList();

            for (int i = 0; i < grd_shoping.Rows.Count; i++)
            {
                if (dv[i].Row[5].ToString() == naushad[0].resturant_name)
                {
                    totaladd = Convert.ToDecimal(naushad[0].Delivery_min_rs_);
                    dilivery_total_amt = dilivery_total_amt + Convert.ToDecimal(dv[i].Row[3].ToString());
                }
            }
            if (Convert.ToInt32(dilivery_total_amt) < Convert.ToInt32(totaladd))
            {
                decimal msgamt = totaladd - dilivery_total_amt;
                string strMsg = "Add Rs." + msgamt + " to reach Rs." + totaladd + ", the minimum amount for delivery in " + naushad[0].resturant_name + " Restaurant ";
                Response.Write("<script>alert('" + strMsg + "')</script>");
                btn_chekout.Enabled = false;
            }
            else
            {
                btn_chekout.Enabled = true;
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        var delfree = (from a in linq_obj.order_details
                       where a.fk_memberid == Convert.ToInt32(Session["id1"])
                       select a).ToList();

        if (delfree.Count() == 0)
        {
            lbl_delivery_fee.Text = "0";
        }




        decimal km_price = 0;
        for (int i = 0; i < chargedt.Rows.Count; i++)
        {
            km_price += Convert.ToDecimal(chargedt.Rows[i][1].ToString());
        }


        if (lbl_delivery_fee.Text != "0")
        {

            decimal total = Convert.ToDecimal(lbltotal_amt.Text);
            lbl_grand_total.Text = (total + Convert.ToDecimal(lbl_delivery_fee.Text) + Convert.ToDecimal(lbl_service_tex.Text) + Convert.ToDecimal(lbl_packing.Text)).ToString("0.00");
            
        }
        else
        {
            decimal total = Convert.ToDecimal(lbltotal_amt.Text);
            lbl_grand_total.Text = (total + Convert.ToDecimal(lbl_service_tex.Text) + Convert.ToDecimal(lbl_packing.Text)).ToString("0.00");
            
        }



        //   Session["km_price"] = km_price;

        //  lbl_delivery_fee.Text = dilveryfee.ToString();

        Session["dilverytimePreordorder"] = dt1;
        if (Session["dilverytimePreordorder"] == null)
        {
            TimeZone curTimeZone = TimeZone.CurrentTimeZone;
            DateTime d3 = curTimeZone.ToLocalTime(DateTime.Now);
            string dt11 = d3.ToString("hh:mm:ss tt");
            dt1 = dt11;
            Session["dilverytimePreordorder"] = dt1;
        }
        if (Session["dilverytimePreordorder"] == "")
        {
            TimeZone curTimeZone = TimeZone.CurrentTimeZone;
            DateTime d3 = curTimeZone.ToLocalTime(DateTime.Now);
            string dt11 = d3.ToString("hh:mm:ss tt");
            dt1 = dt11;
            Session["dilverytimePreordorder"] = dt1;
        }
        if (Session["dilverytimePreordorder"] != null)
        {
            Session["dilverytimePreordorder"] = dt1;
        }
        if (RadioButton2.Checked == true)
        {
            if (lbl_calender.Text != null)
            {
                dt1 = txt_calender.Text + "," + ddl_time.SelectedItem.Text + ":00" + "," + ddl_category.SelectedItem.Text;
                Session["dilverytimePreordorder"] = dt1;
            }
        }

        Session["dilverytimePreordorder"] = dt1;
        pnl_shiping_adrress_fill.Visible = true;
        lbl_firstname.Text = txt_yourname.Text + "&nbsp;" +  txt_last_name.Text;
        lbl_adrress.Text = txt_adrress.Text;
        lbl_landmark.Text = txt_landmark.Text;
        lbl_pincode.Text = txt_pincode.Text;
        lbl_emailid.Text = txt_emailid.Text;
        lbl_phoneon.Text = txt_mobileno.Text;
        lbl_calender.Text = dt1;
        //pnl_shiping_adrress.Visible = false;
        btn_chekout.Visible = false;
        btn_order.Visible = true;
    }
    protected void btn_apply_Click(object sender, EventArgs e)
    {
        try
        {
            // extra variavle
            string freedilivery = "true";
            string ontotal = "true";
            int miniordamt = 0;
            string itemvalue = "true";
            string flatamt = "true";
            string modifycart = "false";
            int retro_total = 0;
            //end extra variable

            var id = (from a in linq_obj.promocode_msts
                      where a.promocode == txt_promocode.Text
                      select a).ToList();

            if (id.Count() != 0)
            {

                if (id[0].enddate != DateTime.Now.ToString("MM-dd-yyyy") && Convert.ToDateTime(DateTime.Now.ToString("MM-dd-yyyy")) > Convert.ToDateTime(id[0].startdate))
                {

                    if (Convert.ToDateTime(System.DateTime.Now.ToString("hh:mm:ss tt")) > Convert.ToDateTime(id[0].start_time) && Convert.ToDateTime(System.DateTime.Now.ToString("hh:mm:ss tt")) < Convert.ToDateTime(id[0].end_time))
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            decimal discount_price = 0;
                            int flag = 0;

                            var id2 = (from c in linq_obj.promocode_msts
                                       join b in linq_obj.restaurant_msts on c.resto_id equals b.intglcode
                                       //join d in linq_obj.menu_msts on c.resto_id equals d.restaurant
                                       where c.resto_id == id[0].resto_id && c.promocode == txt_promocode.Text
                                       select new
                                       {
                                           promoid = c.intglcode,
                                           specific_day = c.specific_day,
                                           //item_id = d.item_name,
                                           maxdisc = c.minimum_amount,
                                           itemitem = c.item_id,
                                           //itemprice = d.item_price,
                                           minordamt = c.ord_min_amt,
                                           disaplonsubtot = c.dis_apply_on_subtotal,
                                           flatoff = c.flat_disc,
                                           onseconditem = c.on_second_item_discount,
                                           modify = c.modify_cart,
                                           restroname = b.resturant_name
                                       }).ToList();

                            for (int r = 0; r < dt.Rows.Count; r++)
                            {
                                if (id2.Count != 0)
                                {
                                    miniordamt = Convert.ToInt32(id2[0].minordamt);
                                    freedilivery = id2[0].disaplonsubtot;
                                    flatamt = id2[0].flatoff;
                                    ontotal = id2[0].disaplonsubtot;
                                    itemvalue = id2[0].onseconditem;
                                    modifycart = id2[0].modify;
                                    if (dt.Rows[r][5].ToString() == id2[0].restroname && id[0].resto_id == 23)
                                    {
                                        retro_total += Convert.ToInt32(dt.Rows[r][3].ToString());
                                    }
                                    if (id2[0].specific_day != null)
                                    {
                                        flag = 1;
                                    }
                                }
                                else
                                {
                                    miniordamt = Convert.ToInt32(id[0].ord_min_amt);
                                    freedilivery = id[0].dis_apply_on_subtotal;
                                    flatamt = id[0].flat_disc;
                                    ontotal = id[0].dis_apply_on_subtotal;
                                    //   itemvalue = id2[0].onseconditem;
                                    //  modifycart = id2[0].modify;
                                }
                            }
                            if (id2[0].specific_day == DateTime.Now.DayOfWeek.ToString())
                            {
                                // dilivery free
                                if (freedilivery == "False")
                                {
                                    if ((miniordamt <= Convert.ToInt32(retro_total)) || (id[0].resto_id == 23))
                                    {
                                        Panel2.Visible = false;
                                        Panel3.Visible = true;
                                        int finaldel = (Convert.ToInt32(lbl_delivery_fee.Text)- 25);
                                        if (finaldel > 0)
                                        {
                                            lbl_delivery_fee.Text = finaldel.ToString();
                                        }
                                        else
                                        {
                                            lbl_delivery_fee.Text = "";
                                        }
                                        lbl_pro_amt.Text = "Delivery 25 rupees free";
                                        discount_price = 1;
                                        // Response.Write("<script laguage='javascript'>alert('** Promo code applied successfully**')</Script>");
                                    }
                                    else
                                    {
                                        // pass message order amout less
                                    }
                                }
                                else if (flatamt == "True")
                                {
                                    if ((miniordamt <= Convert.ToInt32(retro_total)) || (id[0].resto_id == 23))
                                    {

                                        lbl_pro_amt.Text = id[0].percentage.ToString();
                                        Panel2.Visible = false;
                                        Panel3.Visible = true;
                                        decimal totamamt = Convert.ToDecimal(Convert.ToDecimal(lbl_subtotle.Text) - Convert.ToDecimal(id[0].percentage));
                                        lbltotal_amt.Text = totamamt.ToString();


                                        decimal g = Convert.ToDecimal(Convert.ToDecimal(totamamt));

                                        lbl_grand_total.Text = (g + Convert.ToDecimal(lbl_delivery_fee.Text) + Convert.ToDecimal(lbl_service_tex.Text)).ToString() + Convert.ToDecimal(lbl_packing.Text);
                                        //      lbl_service_tex.Text = a.ToString();
                                        Response.Write("<script laguage='javascript'>alert('** Promo code applied successfully**')</Script>");
                                        break;
                                    }
                                    else
                                    {
                                        // pass message order amout less
                                    }
                                }
                                else if ((ontotal == "True" && itemvalue != "True") || (id[0].resto_id == 23))
                                {
                                    if (miniordamt <= Convert.ToInt32(retro_total))
                                    {
                                        discount_price = Convert.ToDecimal(retro_total) * Convert.ToDecimal(id[0].percentage) / 100;
                                        if (discount_price > id2[0].maxdisc)
                                        {
                                            if (id2[0].maxdisc != 0)
                                            {
                                                discount_price = Convert.ToDecimal(id2[0].maxdisc);
                                            }

                                        }
                                        lbl_pro_amt.Text = discount_price.ToString();
                                        Panel2.Visible = false;
                                        Panel3.Visible = true;
                                        decimal totamamt = Convert.ToDecimal(Convert.ToDecimal(lbltotal_amt.Text) - discount_price);
                                        lbltotal_amt.Text = totamamt.ToString();


                                        decimal g = Convert.ToDecimal(Convert.ToDecimal(totamamt));

                                        lbl_grand_total.Text = (g + Convert.ToDecimal(lbl_delivery_fee.Text) + Convert.ToDecimal(lbl_service_tex.Text)).ToString() + Convert.ToDecimal(lbl_packing.Text);
                                        //      lbl_service_tex.Text = a.ToString();
                                        Response.Write("<script laguage='javascript'>alert('** Promo code applied successfully**')</Script>");
                                        break;
                                    }
                                    else if (miniordamt <= Convert.ToInt32(lbl_subtotle.Text))
                                    {
                                        discount_price = Convert.ToDecimal(lbl_subtotle.Text) * Convert.ToDecimal(id[0].percentage) / 100;
                                        if (discount_price > id2[0].maxdisc)
                                        {
                                            if (id2[0].maxdisc != 0)
                                            {
                                                discount_price = Convert.ToDecimal(id2[0].maxdisc);
                                            }

                                        }
                                        lbl_pro_amt.Text = discount_price.ToString();
                                        Panel2.Visible = false;
                                        Panel3.Visible = true;
                                        decimal totamamt = Convert.ToDecimal(Convert.ToDecimal(lbltotal_amt.Text) - discount_price);
                                        lbltotal_amt.Text = totamamt.ToString();


                                        decimal g = Convert.ToDecimal(Convert.ToDecimal(totamamt));

                                        lbl_grand_total.Text = (g + Convert.ToDecimal(lbl_delivery_fee.Text) + Convert.ToDecimal(lbl_service_tex.Text)).ToString() + Convert.ToDecimal(lbl_packing.Text);
                                        //      lbl_service_tex.Text = a.ToString();
                                        Response.Write("<script laguage='javascript'>alert('** Promo code applied successfully**')</Script>");
                                        break;
                                    }
                                    else
                                    {
                                        // pass message order amout less
                                    }
                                }
                                else if (itemvalue == "True")
                                {
                                    if (miniordamt > 0)
                                    {
                                        if (Convert.ToInt32(lbl_subtotle.Text) >= miniordamt)
                                        {
                                            if (modifycart == "True")
                                            {
                                                // poop  cart
                                                int noofset = 0;
                                                int remainqty = 0;
                                                decimal disc = 0;
                                                var rajesh = (from a in linq_obj.list1s
                                                              join c in linq_obj.promocode_msts on a.promo_id equals c.intglcode
                                                              join b in linq_obj.menu_msts on a.list11 equals b.intglcode
                                                              where a.promo_id == id[0].intglcode
                                                              select new
                                                              {
                                                                  list11 = a.list11,
                                                                  set_size = a.set_size,
                                                                  chipitemamt = b.item_price,
                                                                  disc = c.percentage
                                                              }).ToList();
                                                var sagar = (from a in linq_obj.list2s
                                                             join c in linq_obj.promocode_msts on a.promo_id equals c.intglcode
                                                             join b in linq_obj.menu_msts on a.list21 equals b.intglcode
                                                             where a.promo_id == id[0].intglcode
                                                             select new
                                                             {
                                                                 list22 = a.list21,
                                                                 set_size = a.set_size,
                                                                 chipitemamt = b.item_price,
                                                                 disc = c.percentage
                                                             }).ToList();

                                                int setcounter = 0;
                                                int setcounter1 = 0;
                                                if (rajesh.Count != 0)
                                                {
                                                    setcounter = Convert.ToInt32(rajesh[0].set_size);
                                                }
                                                setcounter1 = Convert.ToInt32(sagar[0].set_size);
                                                DataTable dtMarks1 = dt.Clone();
                                                dtMarks1.Columns["actualprice"].DataType = Type.GetType("System.Int32");

                                                foreach (DataRow dr in dt.Rows)
                                                {
                                                    dtMarks1.ImportRow(dr);
                                                }
                                                dtMarks1.AcceptChanges();


                                                DataView dv = dtMarks1.DefaultView;
                                                if (rajesh.Count != 0)
                                                {
                                                    if (noofselection == 0)
                                                    {
                                                        for (int s = 0; s < dv.Count; s++)
                                                        {
                                                            for (int r = 0; r < rajesh.Count(); r++)
                                                            {
                                                                if (rajesh[r].list11 == Convert.ToInt32(dv[s].Row[4].ToString()))
                                                                {
                                                                    noofselection += Convert.ToInt32(dv[s].Row[0].ToString());
                                                                }
                                                            }
                                                        }
                                                        noofselection = noofselection / setcounter;
                                                        noofselection = noofselection * setcounter1;
                                                    }
                                                }


                                                var combo = (from a in linq_obj.menu_msts
                                                             join b in linq_obj.list2s on a.intglcode equals b.list21
                                                             where b.promo_id == id[0].intglcode
                                                             select a).ToList();
                                                CheckBoxList1.DataSource = combo;
                                                CheckBoxList1.DataBind();
                                                ModalPopupExtender1.Show();
                                                if (noofselection > 0)
                                                {
                                                    HiddenField1.Value = noofselection.ToString();
                                                    i = dt.Rows.Count;
                                                }
                                                else
                                                {
                                                    HiddenField1.Value = sagar[0].set_size.ToString();
                                                    noofselection = Convert.ToInt32(sagar[0].set_size);
                                                    i = dt.Rows.Count;
                                                }


                                            }
                                            else
                                            {

                                                var rajesh = (from a in linq_obj.list2s
                                                              join c in linq_obj.promocode_msts on a.promo_id equals c.intglcode
                                                              join b in linq_obj.menu_msts on a.list21 equals b.intglcode
                                                              where a.promo_id == id[0].intglcode
                                                              select new
                                                              {
                                                                  list21 = a.list21,
                                                                  set_size = a.set_size,
                                                                  chipitemamt = b.item_price,
                                                                  disc = c.percentage
                                                              }).ToList();
                                                int setcounter = Convert.ToInt32(rajesh[0].set_size);
                                                int chipitemamt = 0;
                                                int perstage = 100;
                                                decimal totaldisc = 0;
                                                decimal subtotal = Convert.ToDecimal(lbl_subtotle.Text);
                                                for (int r = 0; r < rajesh.Count(); r++)
                                                {
                                                    for (int s = 0; s < grd_shoping.Rows.Count; s++)
                                                    {
                                                        if (rajesh[r].list21 == Convert.ToInt32(dt.Rows[s][4].ToString()))
                                                        {
                                                            if (setcounter != 0)
                                                            {
                                                                chipitemamt = Convert.ToInt32(rajesh[r].chipitemamt);
                                                                perstage = Convert.ToInt32(rajesh[r].disc);
                                                                setcounter = setcounter - 1;

                                                                Panel2.Visible = false;
                                                                Panel3.Visible = true;

                                                                totaldisc = totaldisc + (chipitemamt * perstage / 100);
                                                                lbl_pro_amt.Text = totaldisc.ToString();
                                                                decimal totamamt = Convert.ToDecimal(Convert.ToDecimal(subtotal) - (chipitemamt * perstage / 100));
                                                                lbltotal_amt.Text = totamamt.ToString();
                                                                subtotal = (totamamt);

                                                                decimal g = Convert.ToDecimal(Convert.ToDecimal(totamamt) + Convert.ToDecimal(lbl_delivery_fee.Text) + Convert.ToDecimal(lbl_service_tex.Text) + Convert.ToDecimal(lbl_packing.Text));

                                                                lbl_grand_total.Text = g.ToString("0.00");
                                                            }
                                                            else
                                                            {
                                                                i = dt.Rows.Count;
                                                                Response.Write("<script laguage='javascript'>alert('** Promo code applied successfully**')</Script>");

                                                                break;

                                                            }

                                                        }

                                                    }

                                                }
                                            }
                                        }
                                        else
                                        {
                                            // ord amont is less thhen 400
                                        }
                                    }
                                    else
                                    {
                                        // this else is on both list
                                        int noofset = 0;
                                        int remainqty = 0;
                                        decimal disc = 0;
                                        var rajesh = (from a in linq_obj.list1s
                                                      join c in linq_obj.promocode_msts on a.promo_id equals c.intglcode
                                                      join b in linq_obj.menu_msts on a.list11 equals b.intglcode
                                                      where a.promo_id == id[0].intglcode
                                                      select new
                                                      {
                                                          list11 = a.list11,
                                                          set_size = a.set_size,
                                                          chipitemamt = b.item_price,
                                                          disc = c.percentage
                                                      }).ToList();
                                        var sagar = (from a in linq_obj.list2s
                                                     join c in linq_obj.promocode_msts on a.promo_id equals c.intglcode
                                                     join b in linq_obj.menu_msts on a.list21 equals b.intglcode
                                                     where a.promo_id == id[0].intglcode
                                                     select new
                                                     {
                                                         list22 = a.list21,
                                                         set_size = a.set_size,
                                                         chipitemamt = b.item_price,
                                                         disc = c.percentage
                                                     }).ToList();
                                        int setcounter = Convert.ToInt32(rajesh[0].set_size);
                                        int setcounter1 = Convert.ToInt32(sagar[0].set_size);
                                        DataTable dtMarks1 = dt.Clone();
                                        dtMarks1.Columns["actualprice"].DataType = Type.GetType("System.Int32");

                                        foreach (DataRow dr in dt.Rows)
                                        {
                                            dtMarks1.ImportRow(dr);
                                        }
                                        dtMarks1.AcceptChanges();


                                        DataView dv = dtMarks1.DefaultView;
                                        dv.Sort = "actualprice DESC";
                                        for (int s = 0; s < dv.Count; s++)
                                        {
                                            for (int r = 0; r < rajesh.Count(); r++)
                                            {
                                                if (rajesh[r].list11 == Convert.ToInt32(dv[s].Row[4].ToString()))
                                                {
                                                    if (((Convert.ToInt32(dv[s].Row[0].ToString())) + remainqty) >= (setcounter + setcounter1))
                                                    {
                                                        noofset = (Convert.ToInt32(dv[s].Row[0].ToString()) + remainqty) / (setcounter + setcounter1);
                                                        disc += noofset * (Convert.ToInt32(dv[s].Row[2].ToString()) * Convert.ToInt32(rajesh[0].disc) / 100);
                                                        remainqty += Convert.ToInt32(dv[s].Row[0].ToString()) - (noofset * (setcounter + setcounter1));
                                                    }
                                                    else
                                                    {
                                                        remainqty += Convert.ToInt32(dv[s].Row[0].ToString());
                                                    }

                                                }
                                            }

                                        }

                                        decimal totamamt = Convert.ToDecimal(Convert.ToDecimal(lbl_subtotle.Text) - disc);
                                        lbltotal_amt.Text = totamamt.ToString();
                                        lbl_pro_amt.Text = disc.ToString();
                                        Panel2.Visible = false;
                                        Panel3.Visible = true;
                                        discount_price = disc;
                                        decimal g = Convert.ToDecimal(Convert.ToDecimal(totamamt) + Convert.ToDecimal(lbl_delivery_fee.Text) + Convert.ToDecimal(lbl_service_tex.Text) + Convert.ToDecimal(lbl_packing.Text));

                                        lbl_grand_total.Text = g.ToString("0.00");

                                    }



                                }




                            }
                            else if (flag == 0)
                            {

                                // dilivery free
                                if (freedilivery == "False")
                                {
                                    if ((miniordamt <= Convert.ToInt32(retro_total)) || (id[0].resto_id == 23))
                                    {
                                        int finaldel = (Convert.ToInt32(lbl_delivery_fee.Text) - 25);
                                        if (finaldel > 0)
                                        {
                                            lbl_delivery_fee.Text = finaldel.ToString();
                                        }
                                        else
                                        {
                                            lbl_delivery_fee.Text = "";
                                        }
                                        lbl_pro_amt.Text = "Delivery 25 rupees free";
                                        discount_price = 1;
                                      
                                        Panel2.Visible = false;
                                        Panel3.Visible = true;
                                        // Response.Write("<script laguage='javascript'>alert('** Promo code applied successfully**')</Script>");
                                    }
                                    else
                                    {
                                        // pass message order amout less
                                    }
                                }
                                else if (flatamt == "True")
                                {
                                    if ((miniordamt <= Convert.ToInt32(retro_total)) || (id[0].resto_id == 23))
                                    {

                                        lbl_pro_amt.Text = id[0].percentage.ToString();
                                        Panel2.Visible = false;
                                        Panel3.Visible = true;
                                        decimal totamamt = Convert.ToDecimal(Convert.ToDecimal(lbl_subtotle.Text) - Convert.ToDecimal(id[0].percentage));
                                        lbltotal_amt.Text = totamamt.ToString();


                                        decimal g = Convert.ToDecimal(Convert.ToDecimal(totamamt));

                                        lbl_grand_total.Text = (g + Convert.ToDecimal(lbl_delivery_fee.Text) + Convert.ToDecimal(lbl_service_tex.Text)).ToString() + Convert.ToDecimal(lbl_packing.Text);
                                        //      lbl_service_tex.Text = a.ToString();
                                        Response.Write("<script laguage='javascript'>alert('** Promo code applied successfully**')</Script>");
                                        break;
                                    }
                                    else
                                    {
                                        // pass message order amout less
                                    }
                                }
                                else if ((ontotal == "True" && itemvalue != "True") || (id[2].resto_id == 23))
                                {
                                    if (miniordamt <= Convert.ToInt32(retro_total))
                                    {
                                        discount_price = Convert.ToDecimal(retro_total) * Convert.ToDecimal(id[0].percentage) / 100;
                                        if (discount_price > id2[0].maxdisc)
                                        {
                                            if (id2[0].maxdisc != 0)
                                            {
                                                discount_price = Convert.ToDecimal(id2[0].maxdisc);
                                            }

                                        }
                                        lbl_pro_amt.Text = discount_price.ToString();
                                        Panel2.Visible = false;
                                        Panel3.Visible = true;
                                        decimal totamamt = Convert.ToDecimal(Convert.ToDecimal(lbltotal_amt.Text) - discount_price);
                                        lbltotal_amt.Text = totamamt.ToString();


                                        decimal g = Convert.ToDecimal(Convert.ToDecimal(totamamt));

                                        lbl_grand_total.Text = (g + Convert.ToDecimal(lbl_delivery_fee.Text) + Convert.ToDecimal(lbl_service_tex.Text)).ToString() + Convert.ToDecimal(lbl_packing.Text);
                                        //      lbl_service_tex.Text = a.ToString();
                                        Response.Write("<script laguage='javascript'>alert('** Promo code applied successfully**')</Script>");
                                        break;
                                    }
                                    else if (miniordamt <= Convert.ToInt32(lbl_subtotle.Text))
                                    {
                                        discount_price = Convert.ToDecimal(lbl_subtotle.Text) * Convert.ToDecimal(id[0].percentage) / 100;
                                        if (discount_price > id2[0].maxdisc)
                                        {
                                            if (id2[0].maxdisc != 0)
                                            {
                                                discount_price = Convert.ToDecimal(id2[0].maxdisc);
                                            }

                                        }
                                        lbl_pro_amt.Text = discount_price.ToString();
                                        Panel2.Visible = false;
                                        Panel3.Visible = true;
                                        decimal totamamt = Convert.ToDecimal(Convert.ToDecimal(lbltotal_amt.Text) - discount_price);
                                        lbltotal_amt.Text = totamamt.ToString();


                                        decimal g = Convert.ToDecimal(Convert.ToDecimal(totamamt));

                                        lbl_grand_total.Text = (g + Convert.ToDecimal(lbl_delivery_fee.Text) + Convert.ToDecimal(lbl_service_tex.Text)).ToString() + Convert.ToDecimal(lbl_packing.Text);
                                        //      lbl_service_tex.Text = a.ToString();
                                        Response.Write("<script laguage='javascript'>alert('** Promo code applied successfully**')</Script>");
                                        break;
                                    }
                                    else
                                    {
                                        // pass message order amout less
                                    }
                                }
                                else if (itemvalue == "True")
                                {

                                    if (miniordamt > 0)
                                    {
                                        if (Convert.ToInt32(lbl_subtotle.Text) >= miniordamt)
                                        {
                                            if (modifycart == "True")
                                            {
                                                // poop  cart
                                                int noofset = 0;
                                                int remainqty = 0;
                                                decimal disc = 0;
                                                var rajesh = (from a in linq_obj.list1s
                                                              join c in linq_obj.promocode_msts on a.promo_id equals c.intglcode
                                                              join b in linq_obj.menu_msts on a.list11 equals b.intglcode
                                                              where a.promo_id == id[0].intglcode
                                                              select new
                                                              {
                                                                  list11 = a.list11,
                                                                  set_size = a.set_size,
                                                                  chipitemamt = b.item_price,
                                                                  disc = c.percentage
                                                              }).ToList();
                                                var sagar = (from a in linq_obj.list2s
                                                             join c in linq_obj.promocode_msts on a.promo_id equals c.intglcode
                                                             join b in linq_obj.menu_msts on a.list21 equals b.intglcode
                                                             where a.promo_id == id[0].intglcode
                                                             select new
                                                             {
                                                                 list22 = a.list21,
                                                                 set_size = a.set_size,
                                                                 chipitemamt = b.item_price,
                                                                 disc = c.percentage
                                                             }).ToList();

                                                int setcounter = 0;
                                                int setcounter1 = 0;
                                                if (rajesh.Count != 0)
                                                {
                                                    setcounter = Convert.ToInt32(rajesh[0].set_size);
                                                }
                                                setcounter1 = Convert.ToInt32(sagar[0].set_size);
                                                DataTable dtMarks1 = dt.Clone();
                                                dtMarks1.Columns["actualprice"].DataType = Type.GetType("System.Int32");

                                                foreach (DataRow dr in dt.Rows)
                                                {
                                                    dtMarks1.ImportRow(dr);
                                                }
                                                dtMarks1.AcceptChanges();


                                                DataView dv = dtMarks1.DefaultView;
                                                if (rajesh.Count != 0)
                                                {
                                                    if (noofselection == 0)
                                                    {
                                                        for (int s = 0; s < dv.Count; s++)
                                                        {
                                                            for (int r = 0; r < rajesh.Count(); r++)
                                                            {
                                                                if (rajesh[r].list11 == Convert.ToInt32(dv[s].Row[4].ToString()))
                                                                {
                                                                    noofselection += Convert.ToInt32(dv[s].Row[0].ToString());
                                                                }
                                                            }
                                                        }
                                                        noofselection = noofselection / setcounter;
                                                        noofselection = noofselection * setcounter1;
                                                    }
                                                }


                                                var combo = (from a in linq_obj.menu_msts
                                                             join b in linq_obj.list2s on a.intglcode equals b.list21
                                                             where b.promo_id == id[0].intglcode
                                                             select a).ToList();
                                                CheckBoxList1.DataSource = combo;
                                                CheckBoxList1.DataBind();
                                                ModalPopupExtender1.Show();
                                                if (noofselection > 0)
                                                {
                                                    HiddenField1.Value = noofselection.ToString();
                                                    i = dt.Rows.Count;
                                                }
                                                else
                                                {
                                                    HiddenField1.Value = sagar[0].set_size.ToString();
                                                    noofselection = Convert.ToInt32(sagar[0].set_size);
                                                    i = dt.Rows.Count;
                                                }


                                            }
                                            else
                                            {

                                                var rajesh = (from a in linq_obj.list2s
                                                              join c in linq_obj.promocode_msts on a.promo_id equals c.intglcode
                                                              join b in linq_obj.menu_msts on a.list21 equals b.intglcode
                                                              where a.promo_id == id[0].intglcode
                                                              select new
                                                              {
                                                                  list21 = a.list21,
                                                                  set_size = a.set_size,
                                                                  chipitemamt = b.item_price,
                                                                  disc = c.percentage
                                                              }).ToList();
                                                int setcounter = Convert.ToInt32(rajesh[0].set_size);
                                                int chipitemamt = 0;
                                                int perstage = 100;
                                                decimal totaldisc = 0;
                                                decimal subtotal = Convert.ToDecimal(lbl_subtotle.Text);
                                                for (int r = 0; r < rajesh.Count(); r++)
                                                {
                                                    for (int s = 0; s < grd_shoping.Rows.Count; s++)
                                                    {
                                                        if (rajesh[r].list21 == Convert.ToInt32(dt.Rows[s][4].ToString()))
                                                        {
                                                            if (setcounter != 0)
                                                            {
                                                                chipitemamt = Convert.ToInt32(rajesh[r].chipitemamt);
                                                                perstage = Convert.ToInt32(rajesh[r].disc);
                                                                setcounter = setcounter - 1;

                                                                Panel2.Visible = false;
                                                                Panel3.Visible = true;

                                                                totaldisc = totaldisc + (chipitemamt * perstage / 100);
                                                                lbl_pro_amt.Text = totaldisc.ToString();
                                                                decimal totamamt = Convert.ToDecimal(Convert.ToDecimal(subtotal) - (chipitemamt * perstage / 100));
                                                                lbltotal_amt.Text = totamamt.ToString();
                                                                subtotal = (totamamt);

                                                                decimal g = Convert.ToDecimal(Convert.ToDecimal(totamamt) + Convert.ToDecimal(lbl_delivery_fee.Text) + Convert.ToDecimal(lbl_service_tex.Text) + Convert.ToDecimal(lbl_packing.Text));

                                                                lbl_grand_total.Text = g.ToString("0.00");
                                                            }
                                                            else
                                                            {
                                                                i = dt.Rows.Count;
                                                                Response.Write("<script laguage='javascript'>alert('** Promo code applied successfully**')</Script>");

                                                                break;

                                                            }

                                                        }

                                                    }

                                                }
                                            }
                                        }
                                        else
                                        {
                                            // ord amont is less thhen 400
                                        }
                                    }
                                    else
                                    {
                                        // this else is on both list
                                        int noofset = 0;
                                        int remainqty = 0;
                                        decimal disc = 0;
                                        var rajesh = (from a in linq_obj.list1s
                                                      join c in linq_obj.promocode_msts on a.promo_id equals c.intglcode
                                                      join b in linq_obj.menu_msts on a.list11 equals b.intglcode
                                                      where a.promo_id == id[0].intglcode
                                                      select new
                                                      {
                                                          list11 = a.list11,
                                                          set_size = a.set_size,
                                                          chipitemamt = b.item_price,
                                                          disc = c.percentage
                                                      }).ToList();
                                        var sagar = (from a in linq_obj.list2s
                                                     join c in linq_obj.promocode_msts on a.promo_id equals c.intglcode
                                                     join b in linq_obj.menu_msts on a.list21 equals b.intglcode
                                                     where a.promo_id == id[0].intglcode
                                                     select new
                                                     {
                                                         list22 = a.list21,
                                                         set_size = a.set_size,
                                                         chipitemamt = b.item_price,
                                                         disc = c.percentage
                                                     }).ToList();
                                        int setcounter = Convert.ToInt32(rajesh[0].set_size);
                                        int setcounter1 = Convert.ToInt32(sagar[0].set_size);
                                        DataTable dtMarks1 = dt.Clone();
                                        dtMarks1.Columns["actualprice"].DataType = Type.GetType("System.Int32");

                                        foreach (DataRow dr in dt.Rows)
                                        {
                                            dtMarks1.ImportRow(dr);
                                        }
                                        dtMarks1.AcceptChanges();


                                        DataView dv = dtMarks1.DefaultView;
                                        dv.Sort = "actualprice DESC";
                                        for (int s = 0; s < dv.Count; s++)
                                        {
                                            for (int r = 0; r < rajesh.Count(); r++)
                                            {
                                                if (rajesh[r].list11 == Convert.ToInt32(dv[s].Row[4].ToString()))
                                                {
                                                    if (((Convert.ToInt32(dv[s].Row[0].ToString())) + remainqty) >= (setcounter + setcounter1))
                                                    {
                                                        noofset = (Convert.ToInt32(dv[s].Row[0].ToString()) + remainqty) / (setcounter + setcounter1);
                                                        disc += noofset * (Convert.ToInt32(dv[s].Row[2].ToString()) * Convert.ToInt32(rajesh[0].disc) / 100);
                                                        remainqty += Convert.ToInt32(dv[s].Row[0].ToString()) - (noofset * (setcounter + setcounter1));
                                                    }
                                                    else
                                                    {
                                                        remainqty += Convert.ToInt32(dv[s].Row[0].ToString());
                                                    }

                                                }
                                            }

                                        }

                                        decimal totamamt = Convert.ToDecimal(Convert.ToDecimal(lbl_subtotle.Text) - disc);
                                        lbltotal_amt.Text = totamamt.ToString();
                                        lbl_pro_amt.Text = disc.ToString();
                                        Panel2.Visible = false;
                                        Panel3.Visible = true;
                                        discount_price = disc;
                                        decimal g = Convert.ToDecimal(Convert.ToDecimal(totamamt) + Convert.ToDecimal(lbl_delivery_fee.Text) + Convert.ToDecimal(lbl_service_tex.Text) + Convert.ToDecimal(lbl_packing.Text));

                                        lbl_grand_total.Text = g.ToString("0.00");

                                    }
                                }

                            }
                            else
                            {
                                Response.Write("<script laguage='javascript'>alert('** Promocode  expire **')</Script>");
                            }
                            if (discount_price > 0)
                            {
                                Response.Write("<script laguage='javascript'>alert('** Promo code applied successfully**')</Script>");
                                i = dt.Rows.Count;
                                break;
                            }

                        }
                        int restroid = 0, restro_total = 0;
                        DataTable dtMarks11 = dt.Clone();
                        dtMarks11.Columns["actualprice"].DataType = Type.GetType("System.Int32");

                        foreach (DataRow dr in dt.Rows)
                        {
                            dtMarks11.ImportRow(dr);
                        }
                        dtMarks11.AcceptChanges();


                        DataView dv1 = dtMarks11.DefaultView;
                        dv1.Sort = "actualprice DESC";
                        lbl_service_tex.Text = "0";
                        for (int i = 0; i < grd_shoping.Rows.Count; i++)
                        {
                            ImageButton lbl_restroid = (ImageButton)grd_shoping.Rows[i].FindControl("btn_delete_item");
                            DropDownList drp = (DropDownList)grd_shoping.Rows[i].FindControl("drpquantity");
                            drp.Enabled = false;
                            lbl_restroid.Enabled = false;

                            var raj = (from a in linq_obj.restaurant_msts
                                       where a.resturant_name == dv1[i].Row[5].ToString()
                                       select a).ToList();
                            if (raj.Count != 0)
                            {
                                if (restroid == 0)
                                {
                                    restro_total += Convert.ToInt32(dv1[i].Row[3].ToString());
                                    if (i + 1 == grd_shoping.Rows.Count)
                                    {


                                        var tax1 = (from a in linq_obj.restaurant_msts
                                                    where a.resturant_name == dv1[i].Row[5].ToString()
                                                    select a).ToList();

                                        if (tax1[0].intglcode == id[0].resto_id)
                                        {

                                            decimal per1 = Convert.ToDecimal(tax1[0].Vat) + Convert.ToDecimal(tax1[0].Service_tax_);
                                            decimal stax1 = ((restro_total - Convert.ToDecimal(lbl_pro_amt.Text)) * per1 / 100);
                                            decimal finaltax = Convert.ToDecimal(lbl_service_tex.Text) + stax1;
                                            lbl_service_tex.Text = finaltax.ToString();
                                            decimal g = Convert.ToDecimal(Convert.ToDecimal(lbltotal_amt.Text) + Convert.ToDecimal(lbl_delivery_fee.Text) + Convert.ToDecimal(lbl_service_tex.Text) + Convert.ToDecimal(lbl_packing.Text));
                                            lbl_grand_total.Text = g.ToString("0.00");
                                        }
                                        else
                                        {

                                            decimal per1 = Convert.ToDecimal(tax1[0].Vat) + Convert.ToDecimal(tax1[0].Service_tax_);
                                            decimal stax1 = (restro_total * per1 / 100);
                                            decimal finaltax = Convert.ToDecimal(lbl_service_tex.Text) + stax1;
                                            lbl_service_tex.Text = finaltax.ToString();
                                            decimal g = Convert.ToDecimal(Convert.ToDecimal(lbltotal_amt.Text) + Convert.ToDecimal(lbl_delivery_fee.Text) + Convert.ToDecimal(lbl_service_tex.Text) + Convert.ToDecimal(lbl_packing.Text));
                                            lbl_grand_total.Text = g.ToString("0.00");
                                        }
                                    }





                                    restroid = raj[0].intglcode;
                                }
                                else if (restroid == raj[0].intglcode)
                                {
                                    restro_total += Convert.ToInt32(dv1[i].Row[3].ToString());
                                    if (i + 1 == grd_shoping.Rows.Count)
                                    {
                                        var tax1 = (from a in linq_obj.restaurant_msts
                                                    where a.resturant_name == dv1[i].Row[5].ToString()
                                                    select a).ToList();
                                        if (tax1[0].intglcode == id[0].resto_id)
                                        {

                                            decimal per1 = Convert.ToDecimal(tax1[0].Vat) + Convert.ToDecimal(tax1[0].Service_tax_);
                                            decimal stax1 = ((restro_total - Convert.ToDecimal(lbl_pro_amt.Text)) * per1 / 100);
                                            decimal finaltax = Convert.ToDecimal(lbl_service_tex.Text) + stax1;
                                            lbl_service_tex.Text = finaltax.ToString();
                                            decimal g = Convert.ToDecimal(Convert.ToDecimal(lbltotal_amt.Text) + Convert.ToDecimal(lbl_delivery_fee.Text) + Convert.ToDecimal(lbl_service_tex.Text) + Convert.ToDecimal(lbl_packing.Text));
                                            lbl_grand_total.Text = g.ToString("0.00");
                                        }
                                        else
                                        {
                                            decimal per1 = Convert.ToDecimal(tax1[0].Vat) + Convert.ToDecimal(tax1[0].Service_tax_);
                                            decimal stax1 = (restro_total * per1 / 100);
                                            decimal finaltax = Convert.ToDecimal(lbl_service_tex.Text) + stax1;
                                            lbl_service_tex.Text = finaltax.ToString();
                                            decimal g = Convert.ToDecimal(Convert.ToDecimal(lbltotal_amt.Text) + Convert.ToDecimal(lbl_delivery_fee.Text) + Convert.ToDecimal(lbl_service_tex.Text) + Convert.ToDecimal(lbl_packing.Text));
                                            lbl_grand_total.Text = g.ToString("0.00");
                                        }
                                    }
                                }
                                else
                                {
                                    var tax = (from a in linq_obj.restaurant_msts
                                               where a.resturant_name == dv1[i - 1].Row[5].ToString()
                                               select a).ToList();
                                    if (tax[0].intglcode == id[0].resto_id)
                                    {

                                        decimal per = Convert.ToDecimal(tax[0].Vat) + Convert.ToDecimal(tax[0].Service_tax_);
                                        decimal stax = ((restro_total - Convert.ToDecimal(lbl_pro_amt.Text)) * per / 100);
                                        decimal finaltax1 = Convert.ToDecimal(lbl_service_tex.Text) + stax;
                                        lbl_service_tex.Text = finaltax1.ToString();
                                        restro_total = 0;
                                        decimal g = Convert.ToDecimal(Convert.ToDecimal(lbltotal_amt.Text) + Convert.ToDecimal(lbl_delivery_fee.Text) + Convert.ToDecimal(lbl_service_tex.Text) + Convert.ToDecimal(lbl_packing.Text));
                                        lbl_grand_total.Text = g.ToString("0.00");
                                    }
                                    else
                                    {

                                        decimal per = Convert.ToDecimal(tax[0].Vat) + Convert.ToDecimal(tax[0].Service_tax_);
                                        decimal stax = (restro_total * per / 100);
                                        decimal finaltax1 = Convert.ToDecimal(lbl_service_tex.Text) + stax;
                                        lbl_service_tex.Text = finaltax1.ToString();
                                        restro_total = 0;
                                        decimal g = Convert.ToDecimal(Convert.ToDecimal(lbltotal_amt.Text) + Convert.ToDecimal(lbl_delivery_fee.Text) + Convert.ToDecimal(lbl_service_tex.Text) + Convert.ToDecimal(lbl_packing.Text));
                                        lbl_grand_total.Text = g.ToString("0.00");
                                    }

                                    if (i + 1 == grd_shoping.Rows.Count)
                                    {
                                        restro_total += Convert.ToInt32(dv1[i].Row[3].ToString());

                                        var tax1 = (from a in linq_obj.restaurant_msts
                                                    where a.resturant_name == dv1[i].Row[5].ToString()
                                                    select a).ToList();
                                        if (tax1[0].intglcode == id[0].resto_id)
                                        {

                                            decimal per1 = Convert.ToDecimal(tax1[0].Vat) + Convert.ToDecimal(tax1[0].Service_tax_);
                                            decimal stax1 = ((restro_total - Convert.ToDecimal(lbl_pro_amt.Text)) * per1 / 100);
                                            decimal finaltax = Convert.ToDecimal(lbl_service_tex.Text) + stax1;
                                            lbl_service_tex.Text = finaltax.ToString();
                                            decimal g = Convert.ToDecimal(Convert.ToDecimal(lbltotal_amt.Text) + Convert.ToDecimal(lbl_delivery_fee.Text) + Convert.ToDecimal(lbl_service_tex.Text) + Convert.ToDecimal(lbl_packing.Text));
                                            lbl_grand_total.Text = g.ToString("0.00");
                                        }
                                        else
                                        {

                                            decimal per1 = Convert.ToDecimal(tax1[0].Vat) + Convert.ToDecimal(tax1[0].Service_tax_);
                                            decimal stax1 = (restro_total * per1 / 100);
                                            decimal finaltax = Convert.ToDecimal(lbl_service_tex.Text) + stax1;
                                            lbl_service_tex.Text = finaltax.ToString();
                                            decimal g = Convert.ToDecimal(Convert.ToDecimal(lbltotal_amt.Text) + Convert.ToDecimal(lbl_delivery_fee.Text) + Convert.ToDecimal(lbl_service_tex.Text) + Convert.ToDecimal(lbl_packing.Text));
                                            lbl_grand_total.Text = g.ToString("0.00");
                                        }
                                    }
                                    else
                                    {
                                        restro_total += Convert.ToInt32(dv1[i].Row[3].ToString());
                                    }

                                    restroid = raj[0].intglcode;
                                }
                            }
                            else
                            {
                                Label2.Text = "0";
                            }



                        }


                    }
                    else
                    {
                        Response.Write("<script laguage='javascript'>alert('** Promo code not valid at this time **')</Script>");
                    }
                }

                else
                {
                    Response.Write("<script laguage='javascript'>alert('** Promo code has expired **')</Script>");
                }
            }
            else
            {
                Response.Write("<script laguage='javascript'>alert('** Promo code is incorrect. Please recheck **')</Script>");
            }

            txt_promocode.Text = "";
            //pnl_shiping_adrress.Visible = false;
        }
        catch (Exception ex)
        {

        }
    }
    protected void btn_order_Click1(object sender, EventArgs e)
    {
        try
        {
            if (dt.Rows.Count != 0)
            {
                int total_quantity = 0;
                decimal total_amt = 0;
                decimal prototal2 = 0;
                decimal grandtotal2 = 0;
                string dilverytime = "";

                for (int i = 0; i < grd_shoping.Rows.Count; i++)
                {
                    total_quantity = total_quantity + Convert.ToInt32(dt.Rows[i][0].ToString());
                    total_amt = Convert.ToDecimal(lbl_grand_total.Text);
                    ViewState["total_amt"] = total_amt;
                }

                Session["grand_total"] = total_amt;
                Session["dilverytimePreordorder"] = dt1;

                //Label3.Text = dt1;

                var id5 = (from a in linq_obj.registraion_msts
                           where a.phoneno == Session["username1"].ToString()
                           select a).ToList();

                Random rnd = new Random();
                int startNumber = rnd.Next(1, 9000);

                //dilverytime = Convert.ToString(txt_calender.Text + "," + ddl_time.SelectedItem.Text + ":00" + "," + ddl_category.SelectedItem.Text);

                string rndno = "redjinni" + startNumber.ToString();
                int y = linq_obj.Insert_order_detail(txt_yourname.Text, txt_last_name.Text, txt_adrress.Text, ddl_city.SelectedItem.Text, txt_pincode.Text, txt_mobileno.Text, txt_emailid.Text, Convert.ToString(dt1), total_quantity.ToString(), total_amt.ToString("0.00"), "PENDING", Convert.ToInt32(id5[0].intglcode), rndno, Convert.ToInt32(ddl_googel_area.SelectedValue), "", lbl_delivery_fee.Text, txt_comment.Text, System.DateTime.Now.ToShortDateString(), Convert.ToInt32(lbl_packing.Text), Convert.ToDateTime(System.DateTime.Now.ToString()), txt_landmark.Text, lbl_service_tex.Text);
                linq_obj.SubmitChanges();

                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    var estro = (from a in linq_obj.restaurant_msts
                                 where a.resturant_name == (dt.Rows[k][5].ToString())
                                 select a).ToList();

                    linq_obj.Insert_shoping(Convert.ToInt32(dt.Rows[k][4].ToString()), dt.Rows[k][0].ToString(), dt.Rows[k][3].ToString(), Convert.ToInt32(y), Convert.ToInt32(estro[0].intglcode), dt.Rows[k][1].ToString());
                    linq_obj.SubmitChanges();
                }

                for (int i = 0; i < chargedt.Rows.Count; i++)
                {
                    linq_obj.insert_deliverycgarge(chargedt.Rows[i][0].ToString(), chargedt.Rows[i][1].ToString(), chargedt.Rows[i][2].ToString(), chargedt.Rows[i][3].ToString(), chargedt.Rows[i][4].ToString(), Convert.ToInt32(y));
                    linq_obj.SubmitChanges();
                }


                prototal2 = Convert.ToDecimal(lbltotal_amt.Text) + Convert.ToDecimal(lbl_packing.Text) + Convert.ToDecimal(lbl_service_tex.Text);
                grandtotal2 = Convert.ToDecimal(lbltotal_amt.Text) + Convert.ToDecimal(lbl_packing.Text) + Convert.ToDecimal(lbl_service_tex.Text) + Convert.ToDecimal(lbl_delivery_fee.Text);
                // send msg //

                string msg = "Dear " + txt_yourname.Text + ", Thanks for ordering from Redjinni. Your Order Id is " + rndno + " Order Detail - " + dt.Rows[0][5].ToString() + "(" + prototal2 + ") Sub-Total: Rs ." + lbl_subtotle.Text + " Packing Charges (Restaurant): Rs. " + lbl_packing.Text + " Taxes (Restaurant): Rs. " + lbl_service_tex.Text + " Delivery Fee: Rs. " + lbl_delivery_fee.Text + " Total: Rs. " + grandtotal2 + " Further assistance: 9228028000";
                string url = "http://sms.todaybiz.in/SendSMS/sendmsg.php?uname=webcode&pass=webcode&send=RdJnni&dest=91" + txt_mobileno.Text + ",919327555100,919930454989" + "&msg=" + msg;


                HttpWebRequest myreq = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse myres = (HttpWebResponse)myreq.GetResponse();
                StreamReader sr = new StreamReader(myres.GetResponseStream());
                string str = sr.ReadToEnd();
                sr.Close();
                myres.Close();

                Session["deliveryarea"] = null;
                Session["addcart"] = null;
                Session["dilverytime"] = null;
                Session["delicharge"] = null;
                Session["dilverytimePreordorder"] = null;

                dt.Clear();
                chargedt.Clear();
                if (txt_emailid.Text != "")
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {
                            var id1 = (from a in linq_obj.emails
                                       select a).Single();
                            string str1 = "<div><center><table><tr><td colspan=2 align='center'><img alt='RedJinni' src='http://redjinni.com/Images/redjinnilogo.png' runat='server'/><hr /> <br/><font size=\"3\">ORDER " + "PENDING" + "</font></td></tr><br/><tr><td width=50%>Hi " + txt_yourname.Text + "<br />your order no. : " + rndno + "</td><td width=50%>Delivery Address <br>" + txt_adrress.Text + "</td></tr></table></center></div>";
                            grd_shopingcart.RenderControl(hw);
                            StringReader sr1 = new StringReader(sw.ToString());
                            MailMessage mm = new MailMessage(id1.email1, txt_emailid.Text);
                            mm.Subject = "Your Redjinni Order: " + rndno;
                            mm.Body = str1 + "ORDER DETAILS:<hr />" + sw.ToString() + "<hr />" + "<div align='right' ><font size=\"3\">Total Amount (Include Service tax and Delivery charge) : " + lbl_grand_total.Text + "</font></div><br /><hr /><div>Thank you for shopping with <a href='http://redjinni.com/'>Redjinni.com</a><br />Redjinni Team <br />For any query or assistance, feel free to <a href='http://redjinni.com/Contact.aspx'>Contact Us</a></div>";
                            mm.IsBodyHtml = true;
                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "mail.redjinni.com";
                            smtp.EnableSsl = false;
                            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                            NetworkCred.UserName = id1.email1;
                            NetworkCred.Password = id1.password;
                            smtp.UseDefaultCredentials = true;
                            smtp.Credentials = NetworkCred;
                            smtp.Port = 25;
                            smtp.Send(mm);
                        }
                    }
                }

                ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('**  Your Order has been Placed Successfully  **');window.location='default.aspx';</script>'");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('**  An error has occurred while trying plece order please try again  **');window.location='default.aspx';</script>'");
            }
        }
        catch (Exception)
        {

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void rb_adrress_list_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            mp1.Show();
            txt_adrress.Text = rb_adrress_list.SelectedItem.Text;
        }
        catch (Exception)
        {

        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //foreach (ListItem li in CheckBoxList1.Items)
        //{
        int total_qty = 0, flag = 0;
        decimal total, discount_price = 0;
        for (int j = 0; j < lstRight.Items.Count; j++)
        {
            var id = (from a in linq_obj.menu_msts
                      where a.intglcode == Convert.ToInt32(lstRight.Items[j].Value)
                      select a).ToList();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (id[0].intglcode == Convert.ToInt32(dt.Rows[i][4].ToString()))
                {
                    total_qty = Convert.ToInt32(1) + Convert.ToInt32(dt.Rows[i][0].ToString());
                    total = Convert.ToDecimal(id[0].item_price) * Convert.ToDecimal(total_qty);
                    dt.Rows[i][0] = total_qty.ToString();
                    dt.Rows[i][3] = total.ToString();
                    flag = 1;
                    discount_price += Convert.ToInt32(id[0].item_price);
                }
            }
            if (flag == 0)
            {
                dt.Rows.Add(1, lstRight.Items[j].Text, id[0].item_price, id[0].item_price, id[0].intglcode, "", "");
                discount_price += Convert.ToInt32(id[0].item_price);
            }


            count123 = 0;
        }
        Session["addcart"] = dt;
        dt = (DataTable)Session["addcart"];
        gridfill();

        decimal totamamt = Convert.ToDecimal(lbltotal_amt.Text) - discount_price;
        lbltotal_amt.Text = totamamt.ToString();
        Panel2.Visible = false;
        Panel3.Visible = true;

        decimal g = Convert.ToDecimal(Convert.ToDecimal(totamamt));
        lbl_pro_amt.Text = discount_price.ToString();
        lbl_grand_total.Text = g.ToString("0.00");
        ModalPopupExtender1.Hide();
    }
    static int count123 = 0;
    protected void Button4_Click(object sender, EventArgs e)
    {
        if (count123 < noofselection)
        {
            foreach (ListItem itm in CheckBoxList1.Items)
            {
                if (itm.Selected)
                    lstRight.Items.Add(itm);
            }
            count123 += 1;
        }

        else
        {
            count123 = 0;
            noofselection = 0;
            Label4.Text = "Your free item limit is over.";
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        foreach (ListItem itm in CheckBoxList1.Items)
        {
            if (itm.Selected)
                lstRight.Items.Remove(itm);
        }
        count123 -= 1;
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        txt_calender.Visible = true;
        ddl_time.Visible = true;
        ddl_time.Visible = true;
        ddl_category.Visible = true;
        RadioButton1.Checked = false;
        mp1.Show();
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        txt_calender.Visible = false;
        ddl_time.Visible = false;
        ddl_time.Visible = false;
        ddl_category.Visible = false;
        RadioButton2.Checked = false;
        mp1.Show();
    }
    protected void ddl_googel_area_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_googel_area.SelectedValue == Session["deliveryareavalue"].ToString())
        {
            Literal1.Text = "";
            //ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('**  You are not change your location at this time. if you change your locatin create new cart  **');window.location='default.aspx';</script>'");
            Button2.Visible = true;
            Button2.Enabled = true;
        }
        else
        {
            Literal1.Text = "You are not allow to change your location at this time. if you want to change your location please create new cart";
            //ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('**  You are not change your location at this time. if you change your locatin create new cart  **');window.location='default.aspx';</script>'");
            Button2.Enabled = false;
        }
    }
}