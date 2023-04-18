using CapstoneGroupProject.Helpers;
using CapstoneGroupProject.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;

namespace CapstoneGroupProject.Models
{
    public class PaymentViewModel
    {
        public PaymentViewModel(Order oder, Payment payment) 
        { 
            Order = oder;
            Payment = payment;
        }

        public PaymentViewModel(){}

        public Order Order { get; set; }
        public Payment Payment { get; set; }

        public IEnumerable<SelectListItem> PaymentType
        {
            get
            {
                var options = new List<SelectListItem>();

                foreach (PaymentType option in Enum.GetValues(typeof(PaymentType)))
                {
                    options.Add(new SelectListItem()
                    {
                        Text = AttributeExtentions.GetDescription(option),
                        Value = option.ToString(),
                    });
                }
                return options;
            }
        }
    }
}
