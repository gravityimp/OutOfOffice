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
        public ProjectType ProjectType { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Required]
        public int ProjectManager { get; set; }
        [ForeignKey("ProjectManagerId")]
        public Employee ProjectManagerRef { get; set; }

        [Required]
        public ProjectStatus Status { get; set; }

        public string Comment { get; set; }
    }
}
