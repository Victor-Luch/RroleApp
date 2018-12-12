using RroleApp.Areas.Hero.Models;
using RroleApp.Areas.ItemArea.Models;
using RroleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RroleApp.Areas.GuideArea.Models
{
    public class Guide
    {
        public int GuideId { get; set; }
        public string GuideName { get; set; }


        public int HeroOptId { get; set; }
        public virtual HeroOpt HeroGuid { get; set; }

        public virtual ICollection<Item> ItemG { get; set; }

        public Guide()
        {
            ItemG = new List<Item>();
        }
    }
}