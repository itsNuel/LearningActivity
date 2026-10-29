using System.Collections.Generic;

namespace LearningActivity.Models
{
    public class Student
    {
        public string Name { get; set; } = string.Empty;
        public string Program { get; set; } = string.Empty;
        public string Background { get; set; } = string.Empty;
        public string Interests { get; set; } = string.Empty;
        public string CareerGoals { get; set; } = string.Empty;
        public List<Course> CurrentCourses { get; set; } = new();
    }
}
