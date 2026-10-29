using System.ComponentModel.DataAnnotations;

namespace LearningActivity.Models
{
    public class Course
    {
        [Required(ErrorMessage = "Course code is required.")]
        public string CourseCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course name is required.")]
        public string CourseName { get; set; } = string.Empty;

        [Required
        (ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty;
    }
}