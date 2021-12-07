using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public partial class category
    {
        [MetadataType(typeof(categoryMetaData))]
        public class categoryMetaData
        {
            [DisplayName("Category Name")]

            public string category_name { get; set; }

            [DisplayName("Status")]

            public string status { get; set; }
        }

    }
}