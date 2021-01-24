using System;
using System.ComponentModel.DataAnnotations;
namespace BACWebsite.ViewModels
{
    public class BookNowViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Date, ErrorMessage = "Must Enter Date")]
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Too Long")]
        public string Description { get; set; }
    }
}
