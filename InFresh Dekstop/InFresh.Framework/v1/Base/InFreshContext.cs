using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using InFresh.Framework.Migrations;
using InFresh.Framework.v1.Models.Masters;
using InFresh.Framework.v1.Models.Systems;

namespace InFresh.Framework.v1.Base
{
    /// <summary>
    /// 
    /// </summary>
    public class InFreshContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public InFreshContext() :
            base("INFRDB")
        {
            Database.SetInitializer<InFreshContext>(new DropCreateDatabaseIfModelChanges<InFreshContext>());

            //Database.SetInitializer<InFreshContext>(new MigrateDatabaseToLatestVersion<InFreshContext, Configuration>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        public InFreshContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer<InFreshContext>(new DropCreateDatabaseIfModelChanges<InFreshContext>());

            //Database.SetInitializer<InFreshContext>(new MigrateDatabaseToLatestVersion<InFreshContext, Configuration>());
        }


        #region DbSet Registration
        //public DbSet<GroupCategory1Dto> GroupCategory1s { get; set; }
        //public DbSet<GroupCategory2Dto> GroupCategory2s { get; set; }

        //public DbSet<GroupCategory2Dto> EmployeeGroups { get; set; }
        //public DbSet<EmplTypeDto> EmployeeTypes { get; set; }

        public DbSet<SubdepoDto> Subdepos { get; set; }
        public DbSet<EmployeeDto> Employees { get; set; }
        public DbSet<SupplierDto> Suppliers { get; set; }
        //public DbSet<OutletDto> Outlets { get; set; }

        //public DbSet<OutletPartDto> OutletParts { get; set; }
        //public DbSet<SupplierOutletPartDto> SupplierOutletParts { get; set; }
        //public DbSet<OutletAccountDto> OutletAccounts { get; set; }
        //public DbSet<OutletContactDto> OutletContacts { get; set; }


        //public DbSet<VariableDto> Variables { get; set; }
        //public DbSet<Definition1Dto> Definition1s { get; set; }

        //public DbSet<CodeFormat1Dto> CodeFormat1s { get; set; }
        public DbSet<Template1Dto> Template1s { get; set; }
        public DbSet<Template2Dto> Template2s { get; set; }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeDto>()
                    .HasOptional(m => m.Subdepo);

            modelBuilder.Entity<EmployeeDto>()
                    .HasOptional(m => m.Boss);

            //modelBuilder.Entity<OutletContactDto>()
            //    .Map<OutletContactDto>(m => m.Requires("OCTYPE").HasValue("OCDT"))
            //    .Map<SuppOutletContactDto>(m => m.Requires("OCTYPE").HasValue("OCSP"));

            //modelBuilder.Entity<OutletPartDto>()
            //    .Map<SubdepoOutletPartDto>(m => m.Requires("HOTYPE").HasValue("SBDP"))
            //    .Map<SupplierOutletPartDto>(m => m.Requires("OPTYPE").HasValue("SPLR"));

            //modelBuilder.Entity<GroupCategory2Dto>()
            //    .Map<GroupCategory2Dto>(m => m.Requires("C2C2C2").HasValue("1"))
            //    .Map<EmplTypeDto>(m => m.Requires("C2C2C2").HasValue("2"))
            //    .Map<OutletTypeDto>(m => m.Requires("C2C2C2").HasValue("3"))
            //    .Map<OutletGroupDto>(m => m.Requires("C2C2C2").HasValue("4"))
            //    .Map<PriceGroupDto>(m => m.Requires("C2C2C2").HasValue("5"))
            //    .Map<DiscountGroupDto>(m => m.Requires("C2C2C2").HasValue("6"))
            //    .Map<PLUGroupDto>(m => m.Requires("C2C2C2").HasValue("7"))
            //    .Map<ConvertGroupDto>(m => m.Requires("C2C2C2").HasValue("8"));

            //modelBuilder.Entity<VariableDto>()
            //    .Map<RecordStatusDto>(m => m.Requires("ZVZVZV").HasValue("1"))
            //    .Map<GenderDto>(m => m.Requires("ZVZVZV").HasValue("2"));
        }
    }
}
