using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class Page
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Slug { get; set; }

        [StringLength(int.MaxValue)]
        public string Body { get; set; }

        public int Sorting { get; set; }

        public bool HasSidebar { get; set; }
    }
}