using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinanzauto.Model
{
	public class Student
	{
		[Key]
		public int Id { get; set; }
		public int Document { get; set; }
		public string Number { get; set; }
		public string NameStudent { get; set; }
		public string LastName { get; set; }
        
		public DateTime DateCreate { get; set; }
		public bool State { get; set; }
    }
}
