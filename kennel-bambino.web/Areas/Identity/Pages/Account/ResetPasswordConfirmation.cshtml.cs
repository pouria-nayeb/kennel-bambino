﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace kennel_bambino.web.Areas.Identity.Pages.Account
{
    [Authorize]
    public class ResetPasswordConfirmationModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}
