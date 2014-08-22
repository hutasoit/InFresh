using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace InFresh.Framework.v1.Models.Masters
{
    [Serializable()]
    [Table("EMPL")]
    public class EmployeeDto
    {
        public EmployeeDto()
        {
            Status = 1;
            DateCreated = DateTime.Now.ToString("yyyyMMddhhmmss");
        }

        [Key]
        [Column("EMEMNO", Order = 0)]
        [Display(Name = "Employee Code")]
        [MaxLength(15)]
        public string Code { get; set; }

        [Required]
        [Column("EMEMNM", Order = 1)]
        [Display(Name = "Employee Name")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Column("EMEMON")]
        [Display(Name = "Employee Old Code")]
        [MaxLength(15)]
        public string OldCode { get; set; }

        [Column("EMADD1")]
        [Display(Name = "Address 1")]
        [MaxLength(100)]
        public string Address1 { get; set; }

        [Column("EMADD2")]
        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [Column("EMCITY")]
        [Display(Name = "City")]
        [MaxLength(30)]
        public string City { get; set; }

        [Column("EMZPCD")]
        [Display(Name= "Zip Code")]
        [MaxLength(5)]
        public string ZipCode { get; set; }

        [Column("EMSDNO")]
        [Display(Name = "Subdepo Code")]
        [MaxLength(15)]
        public string SubdepoCode { get; set; }

        [ForeignKey("SubdepoCode")]
        public virtual SubdepoDto Subdepo { get; set; }

        [Column("EMNGEN")]
        [Display(Name = "Gender")]
        [MaxLength(1)]
        public string Gender { get; set; }

        [Column("EMDOBH")]
        [Display(Name = "Birth Date")]
        [MaxLength(12)]
        public string BirthDate { get; set; }

        [Column("EMBKAC")]
        [Display(Name = "Bank Account")]
        [MaxLength(20)]
        public string BankAccount { get; set; }

        [Column("EMEMNH")]
        [Display(Name = "Boss Code")]
        [MaxLength(15)]
        public string BossCode { get; set; }

        [ForeignKey("BossCode")]
        public virtual EmployeeDto Boss { get; set; }

        //[Column("EMEGNO")]
        //[Display(Name = "Position Code")]
        //[MaxLength(7)]
        //public string PositionCode { get; set; }

        //[NotMapped()]
        //public string PositionName { get; set; }

        //[Column("EMSLTP")]
        //[Display(Name = "Saleman Type")]
        //[MaxLength(7)]
        //public string SalesmanTypeCode { get; set; }

        //[NotMapped()]
        //public string SalesmanTypeName { get; set; }

        [Column("EMMAIL")]
        [Display(Name = "Email")]
        [MaxLength(30)]
        public string Email { get; set; }

        [Column("EMPHN1")]
        [Display(Name = "Telephone")]
        [MaxLength(15)]
        public string Phone1 { get; set; }

        [Column("EMPHN2")]
        [Display(Name = "Handphone")]
        [MaxLength(15)]
        public string Phone2 { get; set; }

        [Column("EMJOIN")]
        [MaxLength(12)]
        public string Joined { get; set; }

        //[Column("EMNFAX")]
        //[Display(Name = "Faximile")]
        //public string Fax { get; set; }

        [Column("EMIURL")]
        public string Foto { get; set; }

        [Column("EMRMRK")]
        public string Remark { get; set; }

        [Column("EMSTAT")]
        [Display(Name = "Status")]
        public int Status { get; set; }

        [Column("EMDTCR")]
        [MaxLength(20)]
        public string DateCreated { get; set; }

        [Column("EMLSUP")]
        [MaxLength(20)]
        public string LastUpdated { get; set; }

        public virtual ICollection<EmployeeDto> Subordinates { get; set; }
    }
}
