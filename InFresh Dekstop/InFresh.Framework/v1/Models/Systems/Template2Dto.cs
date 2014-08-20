using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace InFresh.Framework.v1.Models.Systems
{
    [Serializable()]
    [Table("ZTP2")]
    public partial class Template2Dto
    {
        public Template2Dto()
        {
            Status = 1;
            DateCreated = DateTime.Now.ToString("yyyyMMddhhmmss");
        }

        [Key]
        [Column("T2T2NO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Key { get; set; }

        [Required]
        [Column("T2T1NO")]
        [MaxLength(30)]
        public string Code { get; set; }

        [ForeignKey("Code")]
        public virtual Template1Dto Template { get; set; }

        [Required()]
        [Column("T2SQCE")]
        public int Sequence { get; set; }

        [Column("T2SRCE")]
        [MaxLength(100)]
        public string Source { get; set; }

        [Column("T2DSTN")]
        [MaxLength(100)]
        public string Destination { get; set; }

        [Column("T2NMED")]
        [MaxLength(100)]
        public string Named { get; set; }

        [Column("T2RMRK")]
        public string Remark { get; set; }

        [Column("T2STAT")]
        public int Status { get; set; }

        [Column("T2DTCR")]
        [MaxLength(20)]
        public string DateCreated { get; set; }

        [Column("T2LSUP")]
        [MaxLength(20)]
        public string LastUpdated { get; set; }
    }
}
