﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portal.Models
{
    public class RoleList
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Role name is required")]
        [StringLength(50, ErrorMessage = "Role name can not exceed 50 characters")]
        public string RoleName { get; set; }

        public bool IsPerm { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }

        public virtual ICollection<FileStorage> FileStores { get; set; }

        public virtual ICollection<Meeting> Meetings { get; set; }



    }
}