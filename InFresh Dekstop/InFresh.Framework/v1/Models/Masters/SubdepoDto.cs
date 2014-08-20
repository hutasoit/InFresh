using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace InFresh.Framework.v1.Models.Masters
{
    [Serializable()]
    [Table("SBDP")]
    public class SubdepoDto
    {
        public SubdepoDto()
        {
            Status = 1;
            DateCreated = DateTime.Now.ToString("yyyyMMddhhmmss");
        }

        [Key]
        [Column("SDSDNO", Order = 0)]
        [Display(Name = "Subdepo Code")]
        [MaxLength(15)]
        public string Code { get; set; }

        [Required]
        [Column("SDSDNM", Order = 1)]
        [Display(Name = "Subdepo Name")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Column("SDSDON")]
        [Display(Name = "Subdepo Old Code")]
        [MaxLength(15)]
        public string OldCode { get; set; }

        [Required]
        [Column("SDADD1")]
        [Display(Name = "Address 1")]
        [MaxLength(100)]
        public string Address1 { get; set; }

        [Column("SDADD2")]
        [Display(Name = "Address 2")]
        [MaxLength(100)]
        public string Address2 { get; set; }

        [Column("SDCITY")]
        [Display(Name = "City")]
        [MaxLength(30)]
        public string City { get; set; }

        [Column("SDZPCD")]
        [Display(Name = "Zip Code")]
        [MaxLength(5)]
        public string ZipCode { get; set; }

        [Column("SDPHN1")]
        [Display(Name = "Phone 1")]
        [MaxLength(15)]
        public string Phone1 { get; set; }

        [Column("SDFAX1")]
        [Display(Name = "Fax 1")]
        [MaxLength(15)]
        public string Fax1 { get; set; }

        [Column("SDGELC")]
        [Display(Name = "Geo Address")]
        public string GeoAddress { get; set; }

        [Column("SDLGTD")]
        [Display(Name = "Longitude")]
        public double Longitude { get; set; }

        [Column("SDLTTD")]
        [Display(Name = "Latitude")]
        public double Latitude { get; set; }

        //[Column("SDEMNO")]
        //[Display(Name = "Employee Code")]
        //[MaxLength(15)]
        //public string EmployeeCode { get; set; }

        //[NotMapped]
        //[Display(Name = "Employee Name")]
        //public string EmployeeName { get; set; }

        [Column("SDIURL")]
        public string Foto { get; set; }

        [Column("SDRMRK")]
        public string Remark { get; set; }

        [Column("SDSTAT")]
        [Display(Name = "Status")]
        public int Status { get; set; }

        [Column("SDDTCR")]
        [MaxLength(20)]
        public string DateCreated { get; set; }

        [Column("SDLSUP")]
        [MaxLength(20)]
        public string LastUpdated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} - {1}", Code, Name);
        }
    }
}
