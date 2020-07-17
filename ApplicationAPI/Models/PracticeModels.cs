using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationAPI.Models
{
    public class PracticeModels
    {

        public Nullable<int> Id { get; set; }
        public string OrderDate { get; set; }
        public Nullable<int> OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public Nullable<int> TotalAmount { get; set; }
    }
}