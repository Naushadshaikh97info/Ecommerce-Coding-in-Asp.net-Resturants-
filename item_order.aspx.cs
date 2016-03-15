using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class item_order : System.Web.UI.Page
{
    DataClassesDataContext linq_obj = new DataClassesDataContext();
    static DataTable dt;
    static int count = 0, code = 0;
    static int totalvalue;
    static int abc;
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
        if (IsPostBack)
            return;
     

        if (Request.QueryString["id"] != null)
        {
            fill_item();
            fill_resturants();
        }
    }
    private void fill_item()
    {
        try
        {
            var id = (from a in linq_obj.menu_msts
                      where a.item_name == (Request.QueryString["id"].ToString())
                      select new
                      {
                          code = a.intglcode,
                          image = "./upload/" + a.item_image,
                          name =a.item_name
                      }).ToList().Take(1);
            Repeater1.DataSource = id;
            Repeater1.DataBind();
        }
        catch (Exception)
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
    private void fill_resturants()
    {
        try
        {
            var id = (from a in linq_obj.restaurant_msts
                      join b in linq_obj.menu_msts on a.intglcode equals b.restaurant
                      where b.item_name == (Request.QueryString["id"].ToString())
                      select new
                      {
                          intglcode = a.intglcode,
                          resturant_name = a.resturant_name + "&nbsp;&nbsp;&nbsp;Rs.&nbsp;" + b.item_price
                      }).ToList();
            rb_resturants.DataSource = id;
            rb_resturants.DataBind();
        }
        catch (Exception)
        {
            
        }
    }
    protected void btn_orderthisitem_Click(object sender, EventArgs e)
    {
        try
        {
            if (rb_resturants.SelectedIndex != -1)
            {
                var id = (from a in linq_obj.menu_msts
                          where a.item_name == (Request.QueryString["id"].ToString()) && a.restaurant == Convert.ToInt32(rb_resturants.SelectedValue)
                          select a).Single();

                string path = "~/upload/";
                decimal total = Convert.ToDecimal(id.item_price) * Convert.ToDecimal(ddl_quantity.SelectedValue);
                int total_qty = Convert.ToInt32(ddl_quantity.SelectedValue);
                int flag = 0;

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
                if (rb_resturants.SelectedIndex != -1)
                {
                    //HiddenField abc = item.FindControl("HiddenField4") as HiddenField;

                    var id1 = (from a in linq_obj.restaurant_msts
                               //join b in linq_obj.restaurant_msts on a.restaurant_name equals b.intglcode
                               where a.intglcode == Convert.ToInt32(rb_resturants.SelectedValue)
                               select new
                               {
                                   intglcode = a.intglcode,
                                   //extra_item_name = a.extra_item_name,
                                   //price = a.price,
                                   restaurant_name = a.resturant_name
                                   
                               }).ToList();

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
                        dt.Rows.Add(total_qty, id.item_name, id.item_price, total, id.intglcode, id1[0].restaurant_name,id.package_charge);
                    }

                    Session["addcart"] = dt;

                    //if (Session["login"] == "yes")
                    //{

                    Response.Redirect("restaurant_menu.aspx?id=" + id1[0].intglcode, false);

                    //}
                    //else
                    //{
                    //    Response.Redirect("user_login.aspx?id=1");
                    //}
                }
            }
            else
            {
                Page.RegisterStartupScript("onload", "<script language='javascript'>alert('**  Please Select Restaurant **')</script>");
            }
        }
        catch (Exception)
        {

        }
     }
}