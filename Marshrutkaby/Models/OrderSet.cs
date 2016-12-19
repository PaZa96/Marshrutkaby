namespace Marshrutkaby.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderSet")]
    public partial class OrderSet
    {
        [Key]
        public int IdOrder { get; set; }

        public DateTime OrderTime { get; set; }

        public int IdDataRoute { get; set; }

        public virtual DataRoutesSet DataRoutesSet { get; set; }

        public int IdRegistration { get; set; }

        public virtual RegistrationSet RegistrationSet { get; set; }
        
        public string IdUser { get; set; }
    }
}
