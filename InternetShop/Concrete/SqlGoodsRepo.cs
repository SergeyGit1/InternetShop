using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InternetShop.Entities;
using InternetShop.Abstract;
using System.Web.UI.WebControls;

namespace InternetShop.Concrete
{
    public class SqlGoodsRepo : IGoodsRepo
    {
        public IList<Good> GetGoods(SqlDataSource sds)
        {
            return null;
        }
    }
}