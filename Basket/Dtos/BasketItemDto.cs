using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Dtos
{
    public class BasketItemDto
    {
        public int Quantity { get; set; }
        public int CourseId { get; set; }
        public int CourseName { get; set; }
        public int Price { get; set; }
    }
}
