using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaFinanzauto.DTO
{
    public class StudentDTO
    {
        [Key]
        public int Id { get; set; }
        public int Document { get; set; }
        public string Number { get; set; }
        public string NameStudent { get; set; }
        public string LastName { get; set; }
        public bool State { get; set; }
    }
}
