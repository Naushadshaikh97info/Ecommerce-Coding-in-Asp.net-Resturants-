using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class new_item : System.Web.UI.Page
{
    DataClassesDataContext linq_obj = new DataClassesDataContext();
    static DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        fill_item_new();
    }
    private void createtable()
    {
        try
        {
            if (dt == null)
            {
                dt = new DataTable();
                dt.Columns.Add("code");
                dt.Columns.Add("item_name");
                dt.Columns.Add("image");
                dt.Columns.Add("count");
            }
        }
        catch (Exception ex)
        {

        }
    }
    private void fill_item_new()
    {
        try
        {
            var id3 = (from buildinguser in linq_obj.GetTable<shopingcart>()
                       join building in linq_obj.GetTable<menu_mst>()
                       on buildinguser.fk_productcode equals building.intglcode
                       group building by building.item_name into grpBuilding
                       select new
                       {
                           building = grpBuilding.Key,
                           users = grpBuilding.Count(),

                       }).ToList();
            createtable();
            for (int i = 0; i < id3.Count(); i++)
            {
                var id2 = (from a in linq_obj.menu_msts
                           where a.item_name == id3[i].building 
                           select a).ToList();
                if (50 < Convert.ToInt32(id2[0].item_price))
                {
                    dt.Rows.Add(id2[0].intglcode, id2[0].item_name, "./upload/" + id2[0].item_image, id3[i].users);
                }
            }

            DataTable dtMarks1 = dt.Clone();

            foreach (DataRow dr in dt.Rows)
            {
                dtMarks1.ImportRow(dr);
            }
            dt.Clear();
            dtMarks1.AcceptChanges();


            DataView dv = dtMarks1.DefaultView;
            dv.Sort = "count DESC";

            for (int k = 0; k < dv.Count; k++)
            {
                if (k != 17)
                {
                    dt.Rows.Add(dv[k].Row[0].ToString(), dv[k].Row[1].ToString(), dv[k].Row[2].ToString(), dv[k].Row[3].ToString());
                }
            }


            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            dt.Clear();
        }
        catch (Exception)
        {

        }
    }
    protected void btn_orderthisitem_Click(object sender, EventArgs e)
    {
        try
        {
            Button lnk = (Button)sender;
            int code = Convert.ToInt32(lnk.CommandArgument.ToString());

            var id = (from a in linq_obj.menu_msts
                      where a.intglcode == code
                      select a).ToList();

            Response.Redirect("item_order.aspx?id=" + id[0].item_name);
        }
        catch (Exception)
        {

        }
    }
}