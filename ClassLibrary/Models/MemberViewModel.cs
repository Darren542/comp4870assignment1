﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClassLibrary;

public class UserRoleViewModel
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public IEnumerable<SelectListItem> Roles { get; set; }
    public string CurrentRole { get; set; }
}

