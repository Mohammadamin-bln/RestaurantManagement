using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement.Domain.Base;
using RestaurantManagement.Domain.Enum;

namespace RestaurantManagement.Domain.Entity
{
    public class User : BaseEntities
    {

        public string Username { get; set; }
        public string Password { get; set; }


        public MemberShipTypeEnum.MemberShipType Role { get; set; } = MemberShipTypeEnum.MemberShipType.cook;

    }
}
