using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace Catstagram.Models
{
	public class CatPost
	{
		

		[Key]
		public int Id { get; set; }

		[Required]
		public string? Image { get; set; }

		[Required]
		public string AuthorName { get; set; }

        [MaxLength(320, ErrorMessage = "Email address is too long")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
		public string Email { get; set; }

        public string Comment { get; set; }

		[Required]
		public DateTime Date { get; set; } = DateTime.Now;
    }
}

