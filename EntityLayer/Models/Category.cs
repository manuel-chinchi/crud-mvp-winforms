using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Browsable(false)]
        public DateTime DateCreated { get; set; }
        public int ArticlesRelated { get; set; }
    }
}
