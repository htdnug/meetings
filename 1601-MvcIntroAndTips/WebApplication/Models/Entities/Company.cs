using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.Entities
{
    public class Company
    {
        public Company()
        {
            this.IsDeleted = false;
        }
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
