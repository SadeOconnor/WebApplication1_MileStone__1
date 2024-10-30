using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1_MileStone__1.Models
{
    public class User
    {
        public int UserID { get; set; }  // Added to match database
        public string Username { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public User()  // Add parameterless constructor
        {
            ShoppingCart = new ShoppingCart();
        }

        public User(string username)
        {
            Username = username;
            ShoppingCart = new ShoppingCart();
        }
    }
}