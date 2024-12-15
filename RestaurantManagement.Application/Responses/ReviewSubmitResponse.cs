﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Responses
{
    public class ReviewSubmitResponse
    {
        public int ReviewId { get; set; }
        public int FoodId { get; set; }
        public int UserId { get; set; }

        public string Comment { get; set; }

        public int Rate { get; set; }
    }
}
