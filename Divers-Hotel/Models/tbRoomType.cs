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

    public partial class tbRoomType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbRoomType()
        {
            this.tbReservations = new HashSet<tbReservation>();
        }

        public int roomTypeId { get; set; }
        [Required]
        [Display(Name ="Room Type")]
        [DataType(DataType.Text)]
        public string roomTypeName { get; set; }
        [Required]
        [Display(Name = "From")]
        public string fromDate { get; set; }
        [Required]
        [Display(Name = "To")]
        public string toDate { get; set; }
        [Required]
        [Display(Name = "Rate Per Room")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public string roomPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbReservation> tbReservations { get; set; }
    }
}
