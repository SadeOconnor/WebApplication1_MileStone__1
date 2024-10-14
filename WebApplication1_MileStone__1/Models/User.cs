using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1_MileStone__1.Models
{
    public class User
    {
        public string Username { get; set; }
        public Cart ShoppingCart { get; set; }

        public User(string username)
        {
            Username = username;
            ShoppingCart = new Cart();
        }
    }
}