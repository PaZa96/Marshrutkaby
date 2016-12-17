namespace Marshrutkaby.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TransportCompanySet")]
    public partial class TransportCompanySet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TransportCompanySet()
        {
            CarSet = new HashSet<CarSet>();
            DataRoutesSet = new HashSet<DataRoutesSet>();
            DriversSet = new HashSet<DriversSet>();
        }

        [Key]
        public int IdTransportCompany { get; set; }

        [Required]
        [Display(Name = "Перевозчик")]
        public string Name { get; set; }

        [Required]
        public string NumberPhone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Raiting { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarSet> CarSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DataRoutesSet> DataRoutesSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DriversSet> DriversSet { get; set; }
    }
}
