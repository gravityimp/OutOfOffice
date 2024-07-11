using OutOfOffice.Server.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.Server.Models.Dto.Project
{
    public class ProjectDtoPost
    {
        public int Id { get; } = 0;
        [Required]
        public ProjectStatus Status { get; set; }
        [Required]
        public ProjectType ProjectType { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        [Required]
        public int ProjectManager { get; set; }
        public string? Comment { get; set; }
    }
}
