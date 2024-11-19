using System.ComponentModel.DataAnnotations;

namespace lab5.Models
{
	public class RegViewModel
	{
		[Required]
		[StringLength(50, ErrorMessage = "Ім'я користувача не може перевищувати 50 символів.")]
		public string Username { get; set; }

		[Required]
		[StringLength(500, ErrorMessage = "Повне ім'я не може перевищувати 500 символів.")]
		public string FullName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(16, MinimumLength = 8, ErrorMessage = "Пароль повинен містити від 8 до 16 символів.")]
		[RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$",
			ErrorMessage = "Пароль повинен містити хоча б одну велику літеру, одну цифру та один спеціальний символ.")]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Паролі не співпадають.")]
		public string ConfirmPassword { get; set; }

		[Required]
		[Phone]
		[RegularExpression(@"^\+380\d{9}$", ErrorMessage = "Телефонний номер повинен бути у форматі +380XXXXXXXXX.")]
		public string Phone { get; set; }

		[Required]
		[EmailAddress(ErrorMessage = "Некоректна електронна адреса.")]
		public string Email { get; set; }
	}
}
