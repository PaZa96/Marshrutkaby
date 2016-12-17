namespace Marshrutkaby.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WayPointsSet")]
    public partial class WayPointsSet
    {
        [Key]
        public int IdWayPoints { get; set; }

        [Required]
        public string NameWayPoint { get; set; }

        public int IdWayPointsTime { get; set; }

        public int IdRoute { get; set; }

        public virtual RoutesSet RoutesSet { get; set; }

        public virtual WayPointsTimeSet WayPointsTimeSet { get; set; }
    }
}
