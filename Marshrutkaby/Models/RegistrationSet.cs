namespace Marshrutkaby.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RegistrationSet")]
    public partial class RegistrationSet
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RegistrationSet()
        {
            OrderSet = new HashSet<OrderSet>();
        }

        [Key]
        public int IdRegistration { get; set; }

        [Required(ErrorMessage = "¬ведите »м€")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "¬ведите фамилию")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "¬ведите им€")]
        public string MiddleName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderSet> OrderSet { get; set; }

    }
}
