using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class City
    {
        [Key]
        public int CityId { get; set; }
        [StringLength(50)]
        public string CityName { get; set; }
        [StringLength(200)]
        public string CityDescription { get; set; }
        public bool CityStatus { get; set; }

        // heading sınıfı ile ilişki kuruldu. bir kategorinin birden fazla başlığı olabilir
        public ICollection<Heading> Headings { get; set; }

        
    }
}
