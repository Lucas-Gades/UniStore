using System.ComponentModel.DataAnnotations;

namespace UniStore.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Display(Name="Department Name")]
        public string Name { get; set; }

        public List<Seller> Sellers { get; set;  } = 
            new List<Seller>();

    }
}
