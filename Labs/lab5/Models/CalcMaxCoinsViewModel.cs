using System.ComponentModel.DataAnnotations;

namespace lab5.Models
{
	public class CalcMaxCoinsViewModel
	{
		[Required(ErrorMessage = "Значення N обов'язкове.")]
        [Range(1, 180, ErrorMessage = "Кількість стопок монет (N) повинна бути в діапазоні від 1 до 180.")]
		[Display(Name = "Кількість стопок (N)")]
		public int N { get; set; }

		[Required(ErrorMessage = "Кількість монет у кожній стопці обов'язкова.")]
		[MinLength(1, ErrorMessage = "Мінімум 1 стопка монет повинна бути введена.")]
		[MaxLength(180, ErrorMessage = "Максимальна кількість стопок монет: 180.")]
		[Display(Name = "Монети у стопках")]
        public string CoinsString { get; set; }

        [Required(ErrorMessage = "Значення K обов'язкове.")]
		[Range(1, 80, ErrorMessage = "K повинно бути в діапазоні від 1 до 80.")]
		[Display(Name = "Максимальна кількість стопок, які можна взяти (K)")]
		public int K { get; set; }

		public int? MaxCoins { get; set; }
	}
}
