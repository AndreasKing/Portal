﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.ViewModels
{
    public class NetRollVM
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public bool RoleAssigned { get; set; }
        public bool IsPerm { get; set; }
    }
}