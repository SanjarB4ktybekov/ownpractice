using System.Collections.Generic;

namespace practice
{
    public class MovieViewModel
    {
        public List<Movie> Movies { get; set; } // Список фильмов на текущей странице
        public int CurrentPage { get; set; } // Номер текущей страницы
        public int TotalPages { get; set; } // Общее количество страниц
        public int ItemsPerPage { get; set; } // Количество элементов на странице
    }
}