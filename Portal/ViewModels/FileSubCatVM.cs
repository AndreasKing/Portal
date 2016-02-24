using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.ViewModels
{
    public class FileSubCatVM
    {
       
        public int ID { get; set; }
      
        public string FileSubCatName { get; set; }       

        public bool FileSubCatAssigned { get; set; }

        public int FileCatFK { get; set; }

        public virtual FileCat FlCat { get; set; }
    }
}