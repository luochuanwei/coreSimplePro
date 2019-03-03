﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthSample.Models
{
    public class LoginViewModel
    {
        [Required]
        public string User { get; set; }

        [Required]
        public string PassWord { get; set; }
    }
}
