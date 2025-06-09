using System.ComponentModel.DataAnnotations;

namespace UniStore.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        [Required]
        [MinLength(2), MaxLength(30)]
        public string Name { get; set; }
        [EmailAddress]
        [MinLength(6, ErrorMessage = "Insira um e-mail com mais caracteres")]
        [MaxLength(15, ErrorMessage = "E-mail muito longo")]
        public string Email { get; set; }
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString="{0:F2}")]
        public double Salary { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Display(Name = "Department")]
        public Department Department { get; set; }

        public List<SalesRecord> Sales { get; set; } = 
            new List<SalesRecord>();

        public double TotalSales(DateTime initial, DateTime final) {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final)
                .Sum(sr => sr.Price);
        }
    }
}
