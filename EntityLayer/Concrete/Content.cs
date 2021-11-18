using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Content
    {
        [Key]
        public int ContentId { get; set; }
        [StringLength(1000)]
        public string ContentValue { get; set; } // içeriğin değeri(metin)
        public DateTime ContentDate { get; set; } // içeriğin oluşturulduğu tarih
        public string ContentImage { get; set; }

        // heading sınıfı ile ilişki kuruldu. bir içeriğin bir başlığı olabilir.
        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }

        // traveler sınıfı ile ilişki kuruldu. bir içeriğin bir yazarı olabilir.
        public int? WriterId { get; set; }
        public virtual Writer Writer { get; set; }
        public bool ContentStatus { get; set; }
    }
}
