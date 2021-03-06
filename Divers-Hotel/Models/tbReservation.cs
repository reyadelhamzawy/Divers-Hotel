//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Divers_Hotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbReservation
    {
        public int reservationId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string reservationCustomerName { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string reservationCustomerEmail { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string reservationCustomerCountry { get; set; }
        [Required]
        [Display(Name = "Num Of Adults In Room")]
        [Range(0, 2, ErrorMessage = "Please enter valid integer Number between 0..and max number per room is 2")]
        public Nullable<int> reservationAdultNumber { get; set; }
        [Required]
        [Display(Name = "Num Of Child In Room")]
        [Range(0, 2, ErrorMessage = "Please enter valid integer Number between 0..and max number per room is 2")]
        public Nullable<int> reservationChildNumber { get; set; }
        [Required]
        [Display(Name = "Room Type")]
        public Nullable<int> reservationRoomTypeId { get; set; }
        [Required]
        [Display(Name = "Meal Plan")]
        public Nullable<int> reservationMealPlanId { get; set; }
        [Required]
        [Display(Name = "Check In Date")]
        public string reservationCheckInDate { get; set; }
        [Required]
        [Display(Name = "Check Out Date")]
        public string reservationCheckOutDate { get; set; }
        public string reservationTotalPrice { get; set; }
    
        public virtual tbMealPlan tbMealPlan { get; set; }
        public virtual tbRoomType tbRoomType { get; set; }
    }
}
