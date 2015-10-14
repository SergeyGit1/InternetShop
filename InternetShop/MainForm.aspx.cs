using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InternetShop.Entities;
using InternetShop.Abstract;
using InternetShop.Concrete;

namespace InternetShop
{
    public partial class MainForm : System.Web.UI.Page
    {
        private void refreshGrid()
        {
            if (Session["CurrentOrder"] == null) Session["CurrentOrder"] = new List<Order>();


            SqlDataSource1.SelectCommand = "SELECT * FROM GoodsTable";
            SqlDataSource1.Select(new DataSourceSelectArguments());
            GridView1.DataBind();
            GridView1.Visible = true;

            foreach (GridViewRow item in GridView1.Rows)
            {
                bool b = false;
                foreach (var order in Session["CurrentOrder"] as List<Order>)
                {
                    if (order.Id.ToString() == item.Cells[0].Text)
                    {
                        (item.Cells[4].Controls[0] as Button).Text = "ok (" + order.Count + ")";
                        b = true;
                        break;
                    }                    
                }
                if (!b) (item.Cells[4].Controls[0] as Button).Text = "+";
            }
           
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Bought"] != null)
            {
                Label_message.Text = "Goods are bought! Success! Maybe something else?";
                Session["Bought"] = null;
            }
            else Label_message.Text = "Choose goods for you!";
            refreshGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = (sender as GridView).SelectedIndex;
            if (index == -1) return;

            if (Session["CurrentOrder"] == null) 
                Session["CurrentOrder"] = new List<Order>();
            List<Order> orders = Session["CurrentOrder"] as List<Order>;

            GridView1.DataBind();
            GridView1.Visible = true;
            addToOrders(orders, int.Parse(GridView1.Rows[index].Cells[0].Text));
            refreshGrid();
        }

        private void addToOrders(List<Order> orders, int id)
        {
            bool b = false;
            foreach (var item in orders)
            {
                if (item.Id == id)
                {
                    item.Count++;
                    b = true;
                    break;
                }
            }

            if (!b) orders.Add(new Order() { Id = id, Count = 1 });
        }

        protected void btn_basket_Click(object sender, EventArgs e)
        {
            Response.Redirect("Basket.aspx");
        }
    }
}