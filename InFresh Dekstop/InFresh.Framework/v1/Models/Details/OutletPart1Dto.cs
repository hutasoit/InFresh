using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InFresh.Framework.v1.Globals;
using InFresh.Framework.v1.Models.Masters;

namespace InFresh.Framework.v1.Models.Details
{
    /// <summary>
    /// Part for supplier or ditributor
    /// </summary>
    [Serializable()]
    [Table("OTPR")]
    public class OutletPart1Dto
    {
        public OutletPart1Dto()
        {
            OutletSource = GlobalVariables.Distributor;
            ContraBill = 0;
            Status = 1;
            DateCreated = DateTime.Now.ToString("yyyyMMddhhmmss");
        }

        [Key]
        [Column("O1O1NK", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Key { get; set; }

        [Key]
        [Column("O1O1NO", Order = 1)]
        [Display(Name = "Code")]
        [MaxLength(30)]
        public string Code { get; set; }

        [Column("O1O1BC")]
        [Display(Name = "Barcode")]
        [MaxLength(30)]
        public string Barcode { get; set; }

        //[Key]
        [Column("O1OTNO")]
        [Display(Name = "Master Code")]
        [MaxLength(30)]
        public string MasterCode { get; set; }

        [ForeignKey("MasterCode")]
        public virtual OutletDto Outlet { get; set; }

        [Column("O1SDNO")]
        [Display(Name = "Subdepo Code")]
        [MaxLength(15)]
        public string SubdepoCode { get; set; }

        [Column("O1SPNO")]
        [Display(Name = "Supplier Code")]
        [MaxLength(15)]
        public string SupplierCode { get; set; }

        [Column("O1OTSR")]
        [Display(Name = "Outlet Source")]
        [MaxLength(10)]
        public string OutletSource { get; set; }

        #region Territory
        [Column("O1LOCD")]
        [Display(Name = "Location Code")]
        public string LocationCode { get; set; }
        [NotMapped]
        public string LocationName { get; set; }
        [Column("O1DSTD")]
        [Display(Name = "District Code")]
        public string DistrictCode { get; set; }
        [NotMapped]
        public string DistrictName { get; set; }
        [Column("O1BTCD")]
        [Display(Name = "Beat Code")]
        public string BeatCode { get; set; }
        [NotMapped]
        public string BeatName { get; set; }
        [Column("O1SBCD")]
        [Display(Name = "Subbeat Code")]
        public string SubBeatCode { get; set; }
        [NotMapped]
        public string SubBeatName { get; set; }
        [Column("O1CLCD")]
        [Display(Name = "Clasification Code")]
        public string ClasificationCode { get; set; }
        [NotMapped]
        public string ClasificationName { get; set; }
        [Column("O1MKCD")]
        [Display(Name = "Market Code")]
        public string MarketCode { get; set; }
        [NotMapped]
        public string MarketName { get; set; }
        [Column("O1IDCD")]
        [Display(Name = "Industry Code")]
        public string IndustryCode { get; set; }
        [NotMapped]
        public string IndustryName { get; set; }
        #endregion

        #region Transaction
        [Column("O1CTBL")]
        [Display(Name = "Contra Bill")]
        public int ContraBill { get; set; }

        [Column("O1NTO1")]
        [Display(Name = "Term of Payment")]
        [MaxLength(30)]
        public string Top { get; set; }

        [Column("O1PTCD")]
        [Display(Name = "Payment Type Code")]
        public string PayTypeCode { get; set; }
        [NotMapped]
        public string PayTypeName { get; set; }

        [Column("O1CRLT")]
        [Display(Name = "Credit Limit")]
        public decimal CreditLimit { get; set; }
        [Column("O1ISCL")]
        [Display(Name = "Credit Limit")]
        public int IsCreditLimit { get; set; }
        [NotMapped]
        public string CreditLimitType { get; set; }

        [Column("O11TSL")]
        [Display(Name = "First Sales Date")]
        [MaxLength(12)]
        public string FirstSalesDate { get; set; }
        [Column("O1NTSL")]
        [Display(Name = "Last Sales Date")]
        [MaxLength(12)]
        public string LastSalesDate { get; set; }
        [Column("O1WEEK")]
        [Display(Name = "Week")]
        [MaxLength(2)]
        public string Week { get; set; }
        [Column("O1MKSH")]
        [Display(Name = "Market Share")]
        public decimal MarketShare { get; set; }
        #endregion

        #region Groups
        [Column("O1OTYC")]
        [Display(Name = "Outlet Type Code")]
        [MaxLength(100)]
        public string OutTypeCode { get; set; }

        [NotMapped]
        public string OutTypeName { get; set; }

        [Column("O1OGRC")]
        [Display(Name = "Outlet Group Code")]
        [MaxLength(100)]
        public string OutGroupCode { get; set; }

        [NotMapped]
        public string OutGroupName { get; set; }

        [Column("O1PGRC")]
        [Display(Name = "Price Group Code")]
        [MaxLength(100)]
        public string PriceGroupCode { get; set; }

        [NotMapped]
        public string PriceGroupName { get; set; }

        [Column("O1DGRC")]
        [Display(Name = "Discount Group Code")]
        [MaxLength(100)]
        public string DiscGroupCode { get; set; }

        [NotMapped]
        public string DiscGroupName { get; set; }

        [Column("O1PLGC")]
        [Display(Name = "PLU Group Code")]
        [MaxLength(100)]
        public string PLUGroupCode { get; set; }

        [NotMapped]
        public string PLUGroupName { get; set; }

        [Column("O1VGRC")]
        [Display(Name = "Convert Group Code")]
        [MaxLength(100)]
        public string ConvertGroupCode { get; set; }

        [NotMapped]
        public string ConvertGroupName { get; set; }
        #endregion


        [Column("O1RMRK")]
        public string Remark { get; set; }

        [Column("O1STAT")]
        [Display(Name = "Status")]
        public int Status { get; set; }

        [Column("O1DTCR")]
        [MaxLength(20)]
        public string DateCreated { get; set; }

        [Column("O1LSUP")]
        [MaxLength(20)]
        public string LastUpdated { get; set; }

    }
}
