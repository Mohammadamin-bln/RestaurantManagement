using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement.Domain.Base;

namespace RestaurantManagement.Domain.Entity
{
    public class Review : BaseEntities
    {
        public int UserId { get; set; }
        public int FoodId {  get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public Food Food { get; set; }
        public User User { get; set; }
    }
}
