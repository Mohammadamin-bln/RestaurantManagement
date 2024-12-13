using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement.Domain.Base;

namespace RestaurantManagement.Domain.Entity
{
    public class Food : BaseEntities
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; }

        public bool IsAvailable { get; set; } = true;

        public int CategoryId { get; set; }

        public Category Category { get; set; }


    }
}
