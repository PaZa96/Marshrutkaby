namespace Marshrutkaby.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("CarSet")]
    public partial class CarSet
    {
        [Key]
        public int IdCar { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string NumberPlate { get; set; }

        [Required]
        public string Services { get; set; }

        public int NumberOfSeats { get; set; }

        public int IdTransportCompany { get; set; }

        public virtual TransportCompanySet TransportCompanySet { get; set; }
    }
}
