namespace Marshrutkaby.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("CarSet")]
    public partial class CarSet
    {
        [Key]
        public int IdCar { get; set; }

        [Display(Name = "Цвет")]
        [Required]
        public string Color { get; set; }

        [Display(Name = "Регистрационный номер")]
        [Required]
        public string NumberPlate { get; set; }

        [Display(Name = "Доп. услуги")]
        [Required]
        public string Services { get; set; }

        [Display(Name = "Количество мест")]
        public int NumberOfSeats { get; set; }

        public int IdTransportCompany { get; set; }

        public virtual TransportCompanySet TransportCompanySet { get; set; }
    }
}
