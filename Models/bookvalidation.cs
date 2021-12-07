using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    [MetadataType(typeof(bookMetaData))]
    public partial class book
    {
        public class bookMetaData
        {
            [DisplayName("Book Name")]
            public string book_name { get; set; }

            [DisplayName("Category ID")]
            public Nullable<int> category_id { get; set; }

            [DisplayName("Author ID")]
            public Nullable<int> author_id { get; set; }

            [DisplayName("Publisher ID")]
            public Nullable<int> publisher_id { get; set; }

            [DisplayName("Contents")]
            public string contents { get; set; }

            [DisplayName("Pages")]
            public Nullable<int> pages { get; set; }

            [DisplayName("Edition")]
            public string edition { get; set; }


        }
    }
}