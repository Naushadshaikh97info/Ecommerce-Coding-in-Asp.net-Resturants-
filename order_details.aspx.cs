using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class order_details : System.Web.UI.Page
{
    DataClassesDataContext linq_obj = new DataClassesDataContext();
    static int flag = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        fillgrid();

        if (Session["username1"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {

        }
    }
    protected void fillgrid()
    {
        try
        {
            var id = (from a in linq_obj.order_details
                      orderby a.intglcode descending
                      join b in linq_obj.registraion_msts on a.fk_memberid equals b.intglcode
                      where a.fk_memberid == Convert.ToInt32(Session["id1"].ToString()) && a.status != "DELIVERED"
                      select new
                      {
                          code = a.intglcode,
                          code1 = b.intglcode,
                          order_no = a.ord_no,
                          name = b.firstname + " " + b.lastname,
                          city = a.city,
                          pincode = a.pincode,
                          mobile = a.mobileno,
                          email = a.email,
                          date = a.email,
                          quantity = a.total_qty,
                          amount = a.total_amt,
                          status = a.status,
                          pay = a.pincode
                      }).ToList();
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
    protected void LinkButton12_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        int code = Convert.ToInt32(lnk.CommandArgument.ToString());

        var id = (from a in linq_obj.order_details
                  where a.intglcode == code
                  select a).ToList();
        if (id[0].status == "PENDING")
        {
            id[0].status = "CANCEL";
            linq_obj.SubmitChanges();
            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('** Order Successfulyy Canceled **');window.location='order_details.aspx';</script>'");
        }
        else
        {
            Response.Write("<script laguage='javascript'>alert('** You cant cancel this order **')</Script>");
        }
    }
}