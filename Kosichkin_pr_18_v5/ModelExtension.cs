using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Kosichkin_pr_18_v5
{
    public partial class Accounting_for_wholesale_salesEntities : DbContext
    {
        private static Accounting_for_wholesale_salesEntities context;
        public static Accounting_for_wholesale_salesEntities GetContext()
        {
            if (context == null) context = new Accounting_for_wholesale_salesEntities();
            return context;
        }
    }
}
