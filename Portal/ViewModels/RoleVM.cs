﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Paul Boyko Feb 2015

namespace Portal.ViewModels
{
    public class RoleVM
    {
        public int RoleID { get; set; }
        public string RoleHexKey { get; set; }
        public string RoleName { get; set; }
        public bool RoleAssigned { get; set; }
        public bool IsPerm { get; set; }
    }
}