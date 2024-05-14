﻿
namespace Student_edu.Core.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int? age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public string? Nationality { get; set; }
    }
}
