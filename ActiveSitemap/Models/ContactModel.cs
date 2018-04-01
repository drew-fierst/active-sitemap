using System.ComponentModel.DataAnnotations;

namespace ActiveSitemap.Models
{
    public class ContactModel
    {
		[Required(ErrorMessage = "Your name is required")]
		[Display(Name = "Your name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Your email is required")]
		[Display(Name = "Your Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "You must describe your needs")]
		[DataType(DataType.MultilineText)]
		[Display(Name = "What can we help you with?")]
		public string Question { get; set; }

    }
}
