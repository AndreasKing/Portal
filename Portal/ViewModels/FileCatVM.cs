using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.ViewModels
{
    public class FileCatVM
    {
     
            public int ID { get; set; }

            public string FileCatName { get; set; }

            public ICollection<FileSubCat> FileSubCats { get; set; }
    }
}