﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kosichkin_pr_18_v5
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Accounting_for_wholesale_salesEntities : DbContext
    {
        public Accounting_for_wholesale_salesEntities()
            : base("name=Accounting_for_wholesale_salesEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Sales_table> Sales_table { get; set; }
        public virtual DbSet<UserData> UserDatas { get; set; }
    }
}
