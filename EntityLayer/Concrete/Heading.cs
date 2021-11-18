using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Heading
    {
        [Key]
        public int HeadingId { get; set; }
        [StringLength(50)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; } // başlığın oluşturulma tarihi

        // category sınıfı ile ilişki kuruldu. bir başlığın bir kategorisi olabilir.
        public int CityId { get; set; }
        public virtual City City { get; set; }

        // writer sınıfı ile ilişki kuruldu. bir başlığın bir yazarı olur.
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }
        public bool HeadingStatus { get; set; }
        public string HeadingDescription { get; set; }
        public string HeadingImage { get; set; }

        // content sınıfı ile ilişki kuruldu. bir başlığın birden fazla içeriği olabilir.
        public ICollection<Content> Contents { get; set; }
    }
}
