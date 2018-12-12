using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RroleApp.Areas.GuideArea.Models
{
    public class GuideViewModel
    {
        public List<int> ItemId { get; set; }
        public int GuideId { get; set; }
        public string GuideName { get; set; }

        public int HeroOptId { get; set; }

    }
}