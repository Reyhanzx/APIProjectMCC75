﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models
{
  
    public class Account
    {
     
        public string Employee_Id { get; set; }
        
        public string Password { get; set; }

      
    }
}
