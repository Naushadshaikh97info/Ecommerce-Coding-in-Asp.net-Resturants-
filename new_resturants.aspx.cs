using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class new_resturants1 : System.Web.UI.Page
{
    DataClassesDataContext linq_obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        fill_image();
    }
    private void fill_image()
    {
        try
        {
            var id2 = (from a in linq_obj.restaurant_msts
                       where a.status == "Active"
                       orderby a.intglcode descending
                       select new
                       {
                           code = a.intglcode,
                           item_name = a.resturant_name,
                           image = a.logo_image
                       }).ToList();
            Repeater1.DataSource = id2;
            Repeater1.DataBind();

            foreach (DataListItem item in Repeater1.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField abc = item.FindControl("HiddenField1") as HiddenField;
                    var id = (from a in linq_obj.restaurant_msts
                              where a.intglcode == Convert.ToInt32(abc.Value)
                              select a).ToList();

                    DateTime d1 = DateTime.Now;
                    DateTime d2 = Convert.ToDateTime(id[0].datetime);

                    TimeSpan t = d1 - d2;
                    double NrOfDays = t.TotalDays;

                    ImageButton image = item.FindControl("ImageButton1") as ImageButton;
                    Panel pnl_resturant = item.FindControl("pnl_resturant") as Panel; 
                    System.Web.UI.HtmlControls.HtmlGenericControl new_item = (System.Web.UI.HtmlControls.HtmlGenericControl)item.FindControl("new_item");

                    if (NrOfDays < 15)
                    {
                        image.Visible = true;
                        new_item.Visible = true;
                        pnl_resturant.Visible = true;
                     
                    }
                    else
                    {
                        image.Visible = false;
                        new_item.Visible = false;
                        pnl_resturant.Visible = false;
                       
                    }
                }
            }
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

            var id = (from a in linq_obj.restaurant_msts
                      where a.intglcode == code
                      select a).Single();

            Response.Redirect("restaurant_menu.aspx?id=" + id.intglcode);
        }
        catch (Exception)
        {


        }
    }

}