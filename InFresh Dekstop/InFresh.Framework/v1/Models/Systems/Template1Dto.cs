using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace InFresh.Framework.v1.Models.Systems
{
    [Serializable()]
    [Table("ZTP1")]
    public partial class Template1Dto
    {
        public Template1Dto()
        {
            Status = 1;
            DateCreated = DateTime.Now.ToString("yyyyMMddhhmmss");
        }

        [Key]
        [Column("T1T1NO")]
        [MaxLength(30)]
        public string Code { get; set; }

        [Required]
        [Column("T1T1NM")]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [Column("T1T1TP")]
        [MaxLength(30)]
        public string Type { get; set; }

        [Column("T1ENTY")]
        [MaxLength(100)]
        public string Entity { get; set; }

        [Column("T1APFR")]
        [MaxLength(100)]
        public string ApplyFor { get; set; }

        [Column("T1RMRK")]
        public string Remark { get; set; }

        [Column("T1STAT")]
        public int Status { get; set; }

        [Column("T1DTCR")]
        [MaxLength(20)]
        public string DateCreated { get; set; }

        [Column("T1LSUP")]
        [MaxLength(20)]
        public string LastUpdated { get; set; }

        public virtual List<Template2Dto> DetailTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1}", Code, Description);
        }
    }
}
