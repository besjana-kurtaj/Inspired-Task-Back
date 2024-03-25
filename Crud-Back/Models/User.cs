using System.ComponentModel.DataAnnotations;

namespace Crud_Back.Models
{
    public class User
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Emri është i detyrueshëm.")]
        //[MaxLength(50, ErrorMessage = "Emri nuk mund të jetë më i gjatë se 50 karaktere.")]
        //[MinLength(2, ErrorMessage = "Emri nuk mund të jetë më i shkurt se 2 karaktere.")]
        public string? FirstName { get; set; }
        //[Required(ErrorMessage = "Mbiemri është i detyrueshëm.")]
        //[MaxLength(50, ErrorMessage = "Mbiemri nuk mund të jetë më i gjatë se 50 karaktere.")]
        //[MinLength(2, ErrorMessage = "Mbiemri nuk mund të jetë më i shkurt se 2 karaktere.")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Username është i detyrueshëm.")]
        [MaxLength(50, ErrorMessage = "Username nuk mund të jetë më i gjatë se 50 karaktere.")]
        [MinLength(2, ErrorMessage = "Username nuk mund të jetë më i shkurt se 2 karaktere.")]
        public string UserName { get; set; }

        public DateTime CreationDate { get; set; }= DateTime.Now;
        [Required(ErrorMessage = "Passwordi është i detyrueshëm.")]
        public string Password { get; set; }
       
      
    }
}
