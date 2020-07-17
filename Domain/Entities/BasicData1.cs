﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class BasicData1
    {
        [Key]
        public int BasicData1Id { get; set; }
        public DeliveryOptions DeliveryOption { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityDocument { get; set; }
        public string NrDocument { get; set; }
        
        public int CartItemId{ get; set; }
        public virtual CartItem CartItem { get; set; }

    }
    public enum DeliveryOptions
    {
        Personal,
        Delivery,
        Delivey_international
    };
}