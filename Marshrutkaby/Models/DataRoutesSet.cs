namespace Marshrutkaby.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DataRoutesSet")]
    public partial class DataRoutesSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DataRoutesSet()
        {
            OrderSet = new HashSet<OrderSet>();
            
        }

        [Key]
        public int IdDataRoute { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата отправления")]
        public DateTime Date { get; set; }

        
        public string Information { get; set; }

        public int IdTransportCompany { get; set; }

        public int IdRoute { get; set; }

        public int IdTime { get; set; }

        [Display(Name = "Цена")]
        public int Price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderSet> OrderSet { get; set; }

        public virtual TransportCompanySet TransportCompanySet { get; set; }

        public virtual RoutesSet RoutesSet { get; set; }

        public virtual TimeSet TimeSet { get; set; }

    }
}
