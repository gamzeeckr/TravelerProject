using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelerWebProject.Models
{
    public class ViewModel
    {
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Content> Contents { get; set; }
    }
}