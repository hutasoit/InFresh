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
    [Table("OTCT")]
    public class OutletContactDto
    {
        public OutletContactDto()
        {
            Status = 1;
            DateCreated = DateTime.Now.ToString("yyyyMMddhhmmss");
        }

        [Key]
        [Column("OCOCNO", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }

        [Column("OCOTNO", Order = 1)]
        [Display(Name = "Master Code")]
        [MaxLength(15)]
        public string MasterCode { get; set; }

        [ForeignKey("MasterCode")]
        public virtual OutletDto Outlet { get; set; }

        //[ForeignKey("OutletCode")]
        //public virtual OutletDto Outlet { get; set; }

        [Required]
        [Column("OCCTNM")]
        [Display(Name = "Contact Person")]
        [MaxLength(20)]
        public string Contact { get; set; }

        [Column("OCPHN1")]
        [Display(Name = "Phone1")]
        [MaxLength(15)]
        public string Phone1 { get; set; }

        [Column("OCPHN2")]
        [Display(Name = "Phone2")]
        [MaxLength(15)]
        public string Phone2 { get; set; }

        [Column("OCEMIL")]
        [Display(Name = "Email")]
        [MaxLength(30)]
        public string Email { get; set; }

        [Column("OCSTAT")]
        [Display(Name = "Status")]
        public int Status { get; set; }

        [Column("OCRMRK")]
        public string Remark { get; set; }

        [Column("OCDTCR")]
        [MaxLength(20)]
        public string DateCreated { get; set; }

        [Column("OCLSUP")]
        [MaxLength(20)]
        public string LastUpdated { get; set; }
    }
}
