using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCookieAuthSample.ViewModels
{
    public class RegisterViewModel
    {
        //邮箱
        public string Email { get; set; }

        //密码
        public string Password { get; set; }

        //确认密码
        public string ConfirmedPassword { get; set; }

    }
}
