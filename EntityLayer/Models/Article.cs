using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string CategoryName { get; set; }
        public string CategoryId { get; set; }
    }
}
