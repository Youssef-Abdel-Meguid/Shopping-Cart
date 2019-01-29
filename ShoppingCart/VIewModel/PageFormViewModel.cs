using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.VIewModel
{
    public class PageFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Slug { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        [AllowHtml]
        public string Body { get; set; }

        public int Sorting { get; set; }

        [Display(Name = "Sidebar")]
        public bool HasSidebar { get; set; }

        public PageFormViewModel()
        {

        }

        public PageFormViewModel(Page page)
        {
            Id = page.Id;
            Title = page.Title;
            Slug = page.Slug;
            Body = page.Body;
            Sorting = page.Sorting;
            HasSidebar = page.HasSidebar;
        }
    }
}