using System.ComponentModel.DataAnnotations;

namespace lab5.Models
{
	public class FindShortPathViewModel
	{
        [Required(ErrorMessage = "Кількість правих поворотів (K) є обов'язковою.")]
        [Range(0, 5, ErrorMessage = "K повинно бути в межах від 0 до 5.")]
        [Display(Name = "Максимальна кількість правих поворотів (K)")]
        public int K { get; set; }

        [Required(ErrorMessage = "Кількість рядків у лабіринті (N) є обов'язковою.")]
        [Range(1, 20, ErrorMessage = "N повинно бути в межах від 1 до 20.")]
        [Display(Name = "Кількість рядків (N)")]
        public int N { get; set; }

        [Required(ErrorMessage = "Кількість стовпців у лабіринті (M) є обов'язковою.")]
        [Range(1, 20, ErrorMessage = "M повинно бути в межах від 1 до 20.")]
        [Display(Name = "Кількість стовпців (M)")]
        public int M { get; set; }

        [Required(ErrorMessage = "Мазу повинен містити стартову (2) і кінцеву (3) точки.")]
        [Display(Name = "Лабіринт")]
        public string MazeString { get; set; }   // Строка для представления лабиринта

        [Required(ErrorMessage = "Координати стартової точки є обов'язковими.")]
        [Range(0, 20, ErrorMessage = "X координата повинна бути в межах від 0 до 20.")]
        [Display(Name = "X координата стартової точки")]
        public int StartX { get; set; }

        [Required(ErrorMessage = "Координати стартової точки є обов'язковими.")]
        [Range(0, 20, ErrorMessage = "Y координата повинна бути в межах від 0 до 20.")]
        [Display(Name = "Y координата стартової точки")]
        public int StartY { get; set; }

        [Required(ErrorMessage = "Координати кінцевої точки є обов'язковими.")]
        [Range(0, 20, ErrorMessage = "X координата повинна бути в межах від 0 до 20.")]
        [Display(Name = "X координата кінцевої точки")]
        public int EndX { get; set; }

        [Required(ErrorMessage = "Координати кінцевої точки є обов'язковими.")]
        [Range(0, 20, ErrorMessage = "Y координата повинна бути в межах від 0 до 20.")]
        [Display(Name = "Y координата кінцевої точки")]
        public int EndY { get; set; }

        public int? ShortestPathDistance { get; set; }
    }
}
