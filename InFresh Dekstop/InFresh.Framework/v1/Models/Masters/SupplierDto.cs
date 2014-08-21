using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace InFresh.Framework.v1.Models.Masters
{
    [Serializable()]
    [Table("SPLR")]
    public class SupplierDto
    {
        public SupplierDto()
        {
            Status = 1;
            DateCreated =  DateTime.Now.ToString("yyyyMMddhhmmss");
        }

        [Key]
        [Column("SPSPNO", Order = 0)]
        [Display(Name = "Supplier Code")]
        [MaxLength(15)]
        public string Code { get; set; }

        [Column("SPSPON")]
        [Display(Name = "Supplier Old Code")]
        [MaxLength(15)]
        public string OldCode { get; set; }

        [Required]
        [Column("SPSPNM", Order = 1)]
        [Display(Name = "Supplier Name")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Column("SPADD1")]
        [Display(Name = "Address 1")]
        [MaxLength(100)]
        public string Address1 { get; set; }

        [Column("SPADD2")]
        [Display(Name = "Address 2")]
        [MaxLength(100)]
        public string Address2 { get; set; }

        [Column("SPCITY")]
        [Display(Name = "City")]
        [MaxLength(30)]
        public string City { get; set; }

        [Column("SPZPCD")]
        [Display(Name = "Zip Code")]
        [MaxLength(5)]
        public string ZipCode { get; set; }

        [Column("SPCTNM")]
        [Display(Name = "Contact Person")]
        [MaxLength(30)]
        public string Contact { get; set; }

        [Column("SPPHN1")]
        [Display(Name = "Phone 1")]
        [MaxLength(15)]
        public string Phone1 { get; set; }

        [Column("SPFAX1")]
        [Display(Name = "Fax 1")]
        [MaxLength(15)]
        public string Fax1 { get; set; }

        [Column("SPEMIL")]
        [Display(Name = "Email")]
        [MaxLength(30)]
        public string Email { get; set; }

        //[Column("SDGELC")]
        //[Display(Name = "Geo Address")]
        //public string GeoAddress { get; set; }

        //[Column("SDLGTD")]
        //[Display(Name = "Longitude")]
        //public double Longitude { get; set; }

        //[Column("SDLTTD")]
        //[Display(Name = "Latitude")]
        //public double Latitude { get; set; }

        [Column("SDRMRK")]
        public string Remark { get; set; }

        [Column("SPSTAT")]
        [Display(Name = "Status")]
        public int Status { get; set; }

        [Column("SPDTCR")]
        [MaxLength(20)]
        public string DateCreated { get; set; }

        [Column("SPLSUP")]
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
