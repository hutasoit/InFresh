using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using InFresh.Framework.v1.Models.Details;

namespace InFresh.Framework.v1.Models.Masters
{
    [Serializable()]
    [Table("OTLT")]
    public class OutletDto
    {
        /// <summary>
        /// 
        /// </summary>
        public OutletDto()
        {
            Status = 1;
            DateCreated = DateTime.Now.ToString("yyyyMMddhhmmss");
            Longitude = Latitude = 0;

            Part1s = new List<OutletPart1Dto>();
            Accounts = new List<OutletAccountDto>();
            Contacts = new List<OutletContactDto>();
        }

        [Key]
        [Column("OTOTNO", Order = 0)]
        [Display(Name = "Master Code")]
        [MaxLength(15)]
        public string Code { get; set; }

        [Required]
        [Column("OTOTNM")]
        [Display(Name = "Outlet Name")]
        [MaxLength(30)]
        public string Name { get; set; }

        //[Column("OTOTBC")]
        //[Display(Name = "Barcode")]
        //[MaxLength(15)]
        //public string Barcode { get; set; }

        //[Column("OTOTON")]
        //[Display(Name = "Old Code")]
        //[MaxLength(15)]
        //public string OldCode { get; set; }

        #region Geolocation

        [Column("OTGELC")]
        [Display(Name = "Geo Address")]
        public string GeoAddress { get; set; }

        [Column("OTLGTD")]
        [Display(Name = "Longitude")]
        public double Longitude { get; set; }

        [Column("OTLTTD")]
        [Display(Name = "Latitude")]
        public double Latitude { get; set; }

        #endregion

        #region Main Address & Contact

        [Required]
        [Column("OTADD1")]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [Column("OTADD2")]
        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [Column("OTCITY")]
        [Display(Name = "City")]
        [MaxLength(30)]
        public string City { get; set; }

        [Column("OTZPCD")]
        [Display(Name = "Zip Code")]
        [MaxLength(5)]
        public string ZipCode { get; set; }

        [Column("OTPHN1")]
        [Display(Name = "Phone 1")]
        [MaxLength(15)]
        public string Phone1 { get; set; }

        [Column("OTFAX1")]
        [Display(Name = "Fax 1")]
        [MaxLength(15)]
        public string Fax1 { get; set; }

        [Column("OTEMIL")]
        [Display(Name = "Email")]
        [MaxLength(30)]
        public string Email { get; set; }
        #endregion

        #region Outlet Tax

        [Column("OTOXNO")]
        [Display(Name = "Tax Code")]
        [MaxLength(25)]
        public string TaxCode { get; set; }

        [Column("OTOXNM")]
        [Display(Name = "Tax Name")]
        [MaxLength(30)]
        public string TaxName { get; set; }

        [Column("OTXAD1")]
        [Display(Name = "Tax Address 1")]
        //[MaxLength(100)]
        public string TaxAddress1 { get; set; }

        [Column("OTXAD2")]
        [Display(Name = "Tax Address 2")]
        [MaxLength(100)]
        public string TaxAddress2 { get; set; }

        [Column("OTXCTY")]
        [Display(Name = "Tax City")]
        [MaxLength(30)]
        public string TaxCity { get; set; }

        [Column("OTXZPC")]
        [Display(Name = "Tax Zip")]
        [MaxLength(10)]
        public string TaxZip { get; set; }

        [Column("OTRGDT")]
        [Display(Name = "Tax Reg. Date")]
        [MaxLength(10)]
        public string TaxRegDate { get; set; }

        #endregion

        [Column("OTJOIN")]
        [Display(Name = "Join Date")]
        [MaxLength(12)]
        public string JoinDate { get; set; }

        [Column("OTIURL")]
        public string Foto { get; set; }

        [Column("OTRMRK")]
        public string Remark { get; set; }

        [Column("OTSTAT")]
        [Display(Name = "Status")]
        public int Status { get; set; }

        [Column("OTDTCR")]
        [MaxLength(20)]
        public string DateCreated { get; set; }

        [Column("OTLSUP")]
        [MaxLength(20)]
        public string LastUpdated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OutletPart1Dto> Part1s { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OutletAccountDto> Accounts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OutletContactDto> Contacts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1}", Code, Name);
        }
    }
}
