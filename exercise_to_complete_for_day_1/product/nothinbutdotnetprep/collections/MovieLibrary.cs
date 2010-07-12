using System;
using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetprep.utility;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;
        private readonly ISpecification<Movie> published_by_pixar = new PublishedByPixar();

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies.one_at_a_time();
        }

        public IEnumerable<Movie> all_movies(ISpecification<Movie> specification)
        {
            foreach (var movie in all_movies())
            {
                if (specification.IsSatisfiedBy(movie))
                {
                    yield return movie;
                }
            }
        }

        public void add(Movie movie)
        {
            if (already_contains(movie)) return;

            this.movies.Add(movie);
        }

        bool already_contains(Movie movie)
        {
            return movies.Contains(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                var temp = new Movie[this.movies.Count];
                this.movies.CopyTo(temp, 0);
                for (var i = 0; i < temp.Length; i++)
                {
                    for (var j = i; j < temp.Length; j++)
                    {
                        if (temp[i].title.CompareTo(temp[j].title) < 0)
                        {
                            var t = temp[i];
                            temp[i] = temp[j];
                            temp[j] = t;
                        }
                    }
                }
                return temp;
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return all_movies(published_by_pixar);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            return all_movies(new PublishedByPixarOrDisney());
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get
            {
                var temp = new Movie[this.movies.Count];
                this.movies.CopyTo(temp, 0);
                for (var i = 0; i < temp.Length; i++)
                {
                    for (var j = i; j < temp.Length; j++)
                    {
                        if (temp[i].title.CompareTo(temp[j].title) > 0)
                        {
                            var t = temp[i];
                            temp[i] = temp[j];
                            temp[j] = t;
                        }
                    }
                }
                return temp;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            var temp = new Movie[this.movies.Count];
            this.movies.CopyTo(temp, 0);
            for (var i = 0; i < temp.Length; i++)
            {
                for (var j = i; j < temp.Length; j++)
                {
                    if (temp[i].rating < temp[j].rating)
                    {
                        var t = temp[i];
                        temp[i] = temp[j];
                        temp[j] = t;
                    }
                }
            }

            for (var i = 0; i < this.movies.Count - 1; i++)
            {
                for (var j = i + 1; j < this.movies.Count; j++)
                {
                    if (temp[i].rating == temp[j].rating)
                    {
                        if (temp[i].date_published.Year > temp[j].date_published.Year)
                        {
                            var t = temp[i];
                            temp[i] = temp[j];
                            temp[j] = t;
                        }
                    }
                }
            }
            return temp;
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            return all_movies(new NotPublishedByPixar());
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            return all_movies(new PublishedAfter(year));
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            return all_movies(new PublishedBetweenYears(startingYear, endingYear));
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            return all_movies(new InGenre(Genre.kids));
        }

        public IEnumerable<Movie> all_action_movies()
        {
            return all_movies(new InGenre(Genre.action));
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            var temp = new Movie[this.movies.Count];
            this.movies.CopyTo(temp, 0);
            for (var i = 0; i < temp.Length; i++)
            {
                for (var j = i; j < temp.Length; j++)
                {
                    if (temp[i].date_published < temp[j].date_published)
                    {
                        var t = temp[i];
                        temp[i] = temp[j];
                        temp[j] = t;
                    }
                }
            }

            return temp;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            var temp = new Movie[this.movies.Count];
            this.movies.CopyTo(temp, 0);
            for (var i = 0; i < temp.Length; i++)
            {
                for (var j = i; j < temp.Length; j++)
                {
                    if (temp[i].date_published > temp[j].date_published)
                    {
                        var t = temp[i];
                        temp[i] = temp[j];
                        temp[j] = t;
                    }
                }
            }

            return temp;
        }
    }

    public class InGenre : ISpecification<Movie>
    {
        private readonly Genre genre;

        public InGenre(Genre genre)
        {
            this.genre = genre;
        }

        public bool IsSatisfiedBy(Movie item)
        {
            return item.genre == genre;
        }
    }

    public class PublishedBetweenYears : ISpecification<Movie>
    {
        private readonly int startingYear;
        private readonly int endingYear;

        public PublishedBetweenYears(int startingYear, int endingYear)
        {
            this.startingYear = startingYear;
            this.endingYear = endingYear;
        }

        public bool IsSatisfiedBy(Movie item)
        {
            return item.date_published.Year >= startingYear && item.date_published.Year <= endingYear;
        }
    }

    public class PublishedAfter : ISpecification<Movie>
    {
        private readonly int year;

        public PublishedAfter(int year)
        {
            this.year = year;
        }

        public bool IsSatisfiedBy(Movie item)
        {
            return item.date_published.Year > year;
        }
    }

    public class PublishedByPixar : ISpecification<Movie>
    {
        public bool IsSatisfiedBy(Movie item)
        {
            return item.production_studio == ProductionStudio.Pixar;
        }
    }

    public class NotPublishedByPixar : ISpecification<Movie>
    {
        public bool IsSatisfiedBy(Movie item)
        {
            return item.production_studio != ProductionStudio.Pixar;
        }
    }

    public class PublishedByPixarOrDisney : ISpecification<Movie>
    {
        public bool IsSatisfiedBy(Movie item)
        {
            return item.production_studio == ProductionStudio.Pixar
                || item.production_studio == ProductionStudio.Disney;
        }
    }

    public class ReadOnlySetOf<T> : IEnumerable<T>
    {
        IList<T> items;

        public ReadOnlySetOf(IList<T> items)
        {
            this.items = items;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}