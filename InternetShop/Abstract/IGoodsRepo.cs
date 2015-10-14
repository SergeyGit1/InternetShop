using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShop.Entities;
using System.Web.UI.WebControls;

namespace InternetShop.Abstract
{
    public interface IGoodsRepo
    {
        IList<Good> GetGoods(SqlDataSource sds);
    }
}
