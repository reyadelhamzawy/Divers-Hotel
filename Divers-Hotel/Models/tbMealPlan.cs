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

    public partial class tbMealPlan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbMealPlan()
        {
            this.tbReservations = new HashSet<tbReservation>();
        }
    
        public int mealPlanId { get; set; }
        [Required]
        [Display(Name = "Meal Plan")]
        public string mealPlanName { get; set; }
        [Required]
        [Display(Name = "Rate Per Person In Low Season")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public string mealPlanPriceInLowSeason { get; set; }
        [Required]
        [Display(Name = "Rate Per Person In High Season")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public string mealPlanPriceinHighSeason { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbReservation> tbReservations { get; set; }
    }
}
