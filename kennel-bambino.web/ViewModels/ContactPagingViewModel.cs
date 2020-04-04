using kennel_bambino.web.Models;
using System.Collections.Generic;

namespace kennel_bambino.web.ViewModels
{
    public class ContactPagingViewModel
    {
        public List<Contact> Contacts { get; set; }

        public int PageCount { get; set; }

        public int PageNumber { get; set; }
    }
}
