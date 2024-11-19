using System.ComponentModel.DataAnnotations;

namespace lab5.Models
{
	public class UtilsViewModel
	{
		[Required(ErrorMessage = "Значення N обов'язкове.")]
		[Range(1, 9, ErrorMessage = "N повинно бути в діапазоні від 1 до 9.")]
		[Display(Name = "Кількість елементів (N)")]
		public int N { get; set; }

		[Required(ErrorMessage = "Значення K обов'язкове.")]
		[Range(0, 9, ErrorMessage = "K повинно бути в діапазоні від 0 до N.")]
		[Display(Name = "Максимальна різниця (K)")]
		public int K { get; set; }

		public int? Count { get; set; }
	}
}
