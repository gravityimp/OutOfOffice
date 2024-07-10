using OutOfOffice.Server.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.Server.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public ProjectStatus Status { get; set; }
        [Required]
        public ProjectType ProjectType { get; set; }
        [Required, DataType(DataType.Date)]
        public DateOnly StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateOnly? EndDate { get; set; }
        public string? Comment { get; set; }

        [Required]
        public int ProjectManager { get; set; }
        [ForeignKey("ProjectManager")]
        public Employee? ProjectManagerRef { get; set; }

        public List<Employee>? Employees { get; set; }
    }
}
