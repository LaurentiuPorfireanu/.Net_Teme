using Movie.Database.Dtos;
using Movie.Database.Entities;
using Movie.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Database.QueryExtensions
{
    public static class FilmQueryExtensions
    {


        public static IQueryable<Film> FilterByTitle(this IQueryable<Film> query, string title)
        {
            if (string.IsNullOrEmpty(title))
                return query;

            return query.Where(f => f.Title.Contains(title));
        }


        public static IQueryable<Film> FilterByYear(this IQueryable<Film> query, int? year)
        {
            if (!year.HasValue)
                return query;

            return query.Where(f => f.Year == year);
        }

        public static IQueryable<Film> FilterByDirectorId(this IQueryable<Film> query, int? directorId)
        {
            if (!directorId.HasValue)
                return query;

            return query.Where(f => f.DirectorId == directorId);
        }

        public static IQueryable<Film> SortBy(this IQueryable<Film> query, FilmSortingDto sortingOption)
        {
            if (sortingOption == null)
                return query;

            switch (sortingOption.Criterion)
            {
                case FilmSortingCriteria.Title:
                    return sortingOption.Order == SortingOrder.Ascending
                        ? query.OrderBy(f => f.Title)
                        : query.OrderByDescending(f => f.Title);
                case FilmSortingCriteria.Year:
                    return sortingOption.Order == SortingOrder.Ascending
                        ? query.OrderBy(f => f.Year)
                        : query.OrderByDescending(f => f.Year);
                case FilmSortingCriteria.DirectorName:
                    return sortingOption.Order == SortingOrder.Ascending
                        ? query.OrderBy(f => f.Director.Name)
                        : query.OrderByDescending(f => f.Director.Name);
                default:
                    return query;
            }
        }
    }
}
