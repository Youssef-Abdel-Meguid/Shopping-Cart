using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.VIewModel
{
    public class SidebarFormViewModel
    {
        public int Id { get; set; }

        [StringLength(int.MaxValue)]
        [AllowHtml]
        [Display(Name = "Sidebar")]
        [Required]
        public string Body { get; set; }

        public SidebarFormViewModel()
        {

        }

        public SidebarFormViewModel(Sidebar sidebar)
        {
            Id = sidebar.Id;
            Body = sidebar.Body;
        }
    }
}