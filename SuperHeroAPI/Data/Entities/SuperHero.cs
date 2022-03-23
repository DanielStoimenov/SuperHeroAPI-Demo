using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI
{
    public class SuperHero
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The name is too long")]
        public string Name { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Place { get; set; } = string.Empty;
    }
}