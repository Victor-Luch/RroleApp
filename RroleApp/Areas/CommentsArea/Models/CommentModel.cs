using RroleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RroleApp.Areas.CommentsArea.Models
{
    public class CommentModel
    {
        public int CommentModelId { get; set; }
        public string CommentText { get; set; }
        public ApplicationUser ApplicationUsers { get; set; }
        
    }
}