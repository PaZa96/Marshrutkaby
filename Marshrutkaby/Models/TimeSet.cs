namespace Marshrutkaby.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TimeSet")]
    public partial class TimeSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TimeSet()
        {
            DataRoutesSet = new HashSet<DataRoutesSet>();
        }

        [Key]
        public int IdTime { get; set; }

        [Display(Name = "Время отправления")]
        public TimeSpan DepartureTime { get; set; }

        [Display(Name = "Время прибытия")]
        public TimeSpan ArrivalTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DataRoutesSet> DataRoutesSet { get; set; }
    }
}
