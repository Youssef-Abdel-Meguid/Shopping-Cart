﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCart.Dtos
{
    public class SidebarDto
    {
        public int Id { get; set; }

        [StringLength(int.MaxValue)]
        public string Body { get; set; }
    }
}