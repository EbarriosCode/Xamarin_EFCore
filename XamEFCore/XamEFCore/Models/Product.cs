using System;
using System.Collections.Generic;
using System.Text;

namespace XamEFCore.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{ProductId} {Title} {Price}";
        }
    }
}
