﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCookieAuthSample.ViewModels
{
    public class RegisterViewModel
    {
        //邮箱
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //密码
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //确认密码
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }

    }
}
