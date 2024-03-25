using System.ComponentModel.DataAnnotations;

namespace Crud_Back.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Emri është i detyrueshëm.")]
        [MaxLength(50, ErrorMessage = "Emri nuk mund të jetë më i gjatë se 50 karaktere.")]
        [MinLength(2, ErrorMessage = "Emri nuk mund të jetë më i shkurt se 2 karaktere.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Mbiemri është i detyrueshëm.")]
        [MaxLength(50, ErrorMessage = "Mbiermi nuk mund të jetë më i gjatë se 50 karaktere.")]
        [MinLength(2, ErrorMessage = "Mbiemri nuk mund të jetë më i shkurt se 2 karaktere.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Data e lindjes është e detyrueshëm.")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Gjinia është e detyrueshëm.")]
        public bool Gender { get; set; }
    }
}
