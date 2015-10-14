using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InternetShop.Entities;
using InternetShop.Abstract;
using InternetShop.Concrete;
using System.Data;

namespace InternetShop
{
    public partial class Basket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentOrder"] == null) Session["CurrentOrder"] = new List<Order>();
            List<Order> orders = Session["CurrentOrder"] as List<Order>;

            DataTable dt = new DataTable();
            dt.Columns.Add("Наименование");
            dt.Columns.Add("Количество");
            dt.Columns.Add("Стоимость");

            SqlDataSource2.SelectCommand = "SELECT * FROM GoodsTable ORDER BY id";
            DataView goods = (DataView)SqlDataSource2.Select(new DataSourceSelectArguments());


            foreach (var item in orders)
	        {
		        foreach (DataRowView dr in goods)
                {
                    if (dr["id"].ToString() == item.Id.ToString())
                    {
                        SqlDataSource2.SelectCommand = "SELECT name, cost FROM GoodsTable WHERE id='" + item.Id + "'";
                        DataView row = (DataView)SqlDataSource2.Select(new DataSourceSelectArguments());
                        if (row == null) return;
                        
                        dt.Rows.Add(dt.NewRow());
                        dt.Rows[dt.Rows.Count - 1][0] = row[0][0];
                        dt.Rows[dt.Rows.Count - 1][1] = item.Count;
                        dt.Rows[dt.Rows.Count - 1][2] = String.Format("{0:c}",(int.Parse(row[0][1].ToString()) * item.Count));
                    }
                }
	        }

            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        protected void Buy_Click(object sender, EventArgs e)
        {
            Session["Bought"] = "1";
            Session["CurrentOrder"] = null;
            Response.Redirect("MainForm.aspx");
        }
    }
}