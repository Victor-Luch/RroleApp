using RroleApp.Areas.GuideArea.Models;
using RroleApp.Areas.Hero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RroleApp.Areas.ItemArea.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public string ItemDescription { get; set; }
        public string ItemImage { get; set; }


        public virtual ICollection<Guide> GuideI { get; set; }

        public Item()
        {
            GuideI = new List<Guide>();
        }
    }
}