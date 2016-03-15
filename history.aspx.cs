using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class history : System.Web.UI.Page
{
    DataClassesDataContext linq_obj = new DataClassesDataContext();
    static int order_no;
    static DataTable dt, chargedt;
    static int count = 0, code = 0;
    static int totalvalue;
    static int abc;
    static string dt1;
    int error_flag = 0;
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

        if (Session["deliveryarea"] == null)
        {
            Session["deliveryarea"] = null;
            Session["delicharge"] = null;
        }
        else
        {
            Session["deliveryarea"] = null;
            Session["delicharge"] = null;
        }

        fillgrid();

        if (Session["username1"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
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
    protected void fillgrid()
    {
       try
         {
             var id = (from a in linq_obj.order_details
                       join b in linq_obj.registraion_msts on a.fk_memberid equals b.intglcode
                       join c in linq_obj.shopingcarts on a.intglcode equals c.fk_order
                       join d in linq_obj.restaurant_msts on c.resturants_id equals d.intglcode
                       where a.fk_memberid == Convert.ToInt32(Session["id1"].ToString()) && a.status == "DELIVERED"
                       orderby a.intglcode descending
                       select new
                       {
                           code = a.intglcode,
                           order_no = a.ord_no,
                           DateTime = a.distance,
                           Restaurants =d.resturant_name,
                           amount = a.total_amt,
                           status = a.status
                       }).GroupBy(x => x.order_no).Select(z => z.OrderBy(i => i.code).First()).ToList();
             grd_order.DataSource = id;
             grd_order.DataBind();
         } 
         catch (Exception)
         {
            
         }
    }  
    protected void onclick_order(object sender, EventArgs e)
    {
        try
        {
            Panel2.Visible = false;
            Panel1.Visible = true;
            LinkButton lnk = (LinkButton)sender;
            int code = Convert.ToInt32(lnk.CommandArgument.ToString());
            //  order_no = Convert.ToInt32(lnk.CommandArgument.ToString());

            var id = (from a in linq_obj.shopingcarts
                      join b in linq_obj.menu_msts on a.fk_productcode equals b.intglcode
                      join c in linq_obj.restaurant_msts on a.resturants_id equals c.intglcode
                      where a.fk_order == code
                      select new
                      {
                          code = a.intglcode,
                          productcode = b.item_name,
                          ResturantName = c.resturant_name,
                          qty = a.quantity,
                          price = a.total_price,
                          img = "~/upload/" + b.item_image

                      }).ToList();
            grd_shopingcart.DataSource = id;
            grd_shopingcart.DataBind();
        }
        catch (Exception)
        {

        }
    }
    protected void grd_order_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //grd_order.PageIndex = e.NewPageIndex;
        //if (ddl_type.SelectedIndex == 0)
        //{
        //    fillgrid();
        //}
        //else
        //{
        //    fill_search();
        //}
    }
    protected void lnl_reorder_Click(object sender, EventArgs e)
    {
        try
        {   
            Button lnk = (Button)sender;
            int code = Convert.ToInt32(lnk.CommandArgument.ToString());
            order_no = Convert.ToInt32(lnk.CommandArgument.ToString());

            var id = (from a in linq_obj.order_details
                      join b in linq_obj.shopingcarts on a.intglcode equals b.fk_order
                      join c in linq_obj.restaurant_msts on b.resturants_id equals c.intglcode
                      where a.intglcode == code
                      select new
                      {
                          intglcode = a.intglcode,
                          item_price = b.total_price,
                          item_name = b.product_name,
                          restro_id = c.resturant_name,
                          packing = a.packag_charg,
                          deliverycharge=a.dilivery_charge,
                          qty = b.quantity,
                          totle =b.total_price
                      }).ToList();

         //   decimal total = Convert.ToDecimal(id.item_price);
           // int total_qty = 1;
            int flag = 0;

            for (int i = 0; i < id.Count(); i++)
            {
                if (i == 0)
                {
                    dt.Rows.Add(id[i].qty, id[i].item_name, id[i].item_price, id[i].totle, id[i].intglcode, id[i].restro_id, id[i].packing);
                }
                else
                {
                    dt.Rows.Add(id[i].qty, id[i].item_name, id[i].item_price, id[i].totle, id[i].intglcode, id[i].restro_id, "0");
                }
                //if (id.intglcode == Convert.ToInt32(dt.Rows[i][4].ToString()))
                //{
                //    total_qty = 1 + Convert.ToInt32(dt.Rows[i][0].ToString());
                //    total = Convert.ToDecimal(id.item_price) * Convert.ToDecimal(total_qty);
                //    dt.Rows[i][0] = total_qty.ToString();
                //    dt.Rows[i][3] = total.ToString();
                //    flag = 1;
                //    break;
                //}
            }

            var id1 = (from a in linq_obj.deliverycharge_msts
                       join b in linq_obj.order_details on a.fkorder equals b.intglcode
                       where a.fkorder == code
                       select a).ToList();

            var nickname = (from a in linq_obj.googel_are_msts
                            where a.area_name == id1[0].cust_locati
                            select a).ToList();




            for (int k = 0; k < id1.Count(); k++)
            {
                chargedt.Rows.Add(id1[k].restroname, id1[k].deli_charge, id1[k].restro_locati, id1[k].cust_locati, id1[k].toatal_km);
            }

            Session["addcart"] = dt;
            Session["delicharge"] = chargedt;
            Session["deliveryarea"] = id1[0].cust_locati;
            Session["deliveryareavalue"] = nickname[0].intglcode;
            Response.Redirect("shoping_cart.aspx", false);
        }
        catch (Exception)
        {

        }
    }
}