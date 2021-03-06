﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//Paul Boyko March 2015

namespace Portal.Models
{
    public class FileSubCat
    {
        [Required]
        public int ID { get; set; }

        [Display(Name = "File Sub-Category Name")]
        [Required(ErrorMessage = "File Category Name is Required")]
        public string FileSubCatName { get; set; }

        [Display(Name = "Related File Category")]
        public int FileCatFK { get; set; }

        public virtual FileCat FlCat { get; set; }

        public virtual ICollection<FileStorage> FileStores { get; set; }
    }
}