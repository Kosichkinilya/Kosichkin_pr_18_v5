using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Kosichkin_pr_18_v5
{
    public partial class DB_Students_18Entities : DbContext
    {
        private static DB_Students_18Entities context;
        public static DB_Students_18Entities GetContext()
        {
            if (context == null) context = new DB_Students_18Entities();
            return context;
        }
    }
}
