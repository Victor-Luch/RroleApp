using RroleApp.Areas.GuideArea.Models;
using RroleApp.Areas.ItemArea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RroleApp.Areas.Hero.Models
{
    public class HeroOpt
    {
        public int HeroOptId { get; set; }
        public string Name { get; set; }
        public string RoleInGame { get; set; }


        public virtual ICollection<Guide> GuideH { get; set; }
    }
}