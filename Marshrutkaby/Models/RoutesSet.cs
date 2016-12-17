namespace Marshrutkaby.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoutesSet")]
    public partial class RoutesSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoutesSet()
        {
            DataRoutesSet = new HashSet<DataRoutesSet>();
            WayPointsSet = new HashSet<WayPointsSet>();
        }

        [Key]
        public int IdRoute { get; set; }

        [Required(ErrorMessage = "Введите место отправления")]
        [Display(Name = "Откуда")]
        public string StartingPoint { get; set; }

        [Required(ErrorMessage = "Введите место назначения")]
        [Display(Name = "Куда")]
        public string EndPoint { get; set; }

        public int Distance { get; set; }

        [Required]
        public string Changes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DataRoutesSet> DataRoutesSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WayPointsSet> WayPointsSet { get; set; }

    }
}
