namespace Marshrutkaby.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("CarSet")]
    public partial class CarSet
    {
        [Key]
        public int IdCar { get; set; }

        [Display(Name = "����")]
        [Required]
        public string Color { get; set; }

        [Display(Name = "��������������� �����")]
        [Required]
        public string NumberPlate { get; set; }

        [Display(Name = "���. ������")]
        [Required]
        public string Services { get; set; }

        [Display(Name = "���������� ����")]
        public int NumberOfSeats { get; set; }

        public int IdTransportCompany { get; set; }

        public virtual TransportCompanySet TransportCompanySet { get; set; }
    }
}
