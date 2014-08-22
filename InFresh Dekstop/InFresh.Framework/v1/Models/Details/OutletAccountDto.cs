using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using InFresh.Framework.v1.Models.Masters;

namespace InFresh.Framework.v1.Models.Details
{
    [Serializable()]
    [Table("OTAC")]
    public class OutletAccountDto
    {
        /// <summary>
        /// 
        /// </summary>
        public OutletAccountDto()
        {
            Status = 1;
            DateCreated = DateTime.Now.ToString("yyyyMMddhhmmss");
        }

        [Key]
        [Column("OAOANO", Order = 0)]
        [Display(Name = "Account Number")]
        [MaxLength(20)]
        public string Code { get; set; }

        [Column("OAOTNO", Order = 1)]
        [Display(Name = "Master Code")]
        [MaxLength(15)]
        public string MasterCode { get; set; }

        [ForeignKey("MasterCode")]
        public virtual OutletDto Outlet { get; set; }

        [Column("OABKNO")]
        [Display(Name = "Bank Code")]
        [MaxLength(8)]
        public string BankCode { get; set; }

        [Column("OABKNM")]
        [Display(Name = "Bank Name")]
        [MaxLength(30)]
        public string BankName { get; set; }

        [Column("OASTAT")]
        [Display(Name = "Status")]
        public int Status { get; set; }

        [Column("OARMRK")]
        public string Remark { get; set; }

        [Column("OADTCR")]
        [MaxLength(20)]
        public string DateCreated { get; set; }

        [Column("OALSUP")]
        [MaxLength(20)]
        public string LastUpdated { get; set; }
    }
}
