using System;
using System.Collections.Generic;
using nothinbutdotnetprep.utility;
using nothinbutdotnetprep.utility.filtering;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies.one_at_a_time();
        }

        public IEnumerable<Movie> all_movies_matching(Criteria<Movie> criteria)
        {
            return movies.all_items_matching(criteria);
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
            return all_movies_matching(Movie.is_published_by_pixar);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            return all_movies_matching(Movie.is_published_by_pixar_or_disney);
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
            return
                all_movies_matching(
                    new AnonymousCriteria<Movie>(item => item.production_studio != ProductionStudio.Pixar));
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            return all_movies_matching(new AnonymousCriteria<Movie>(item => item.date_published.Year > year));
        }

        public IEnumerable<Movie> all_movies_published_between_years(int starting_year, int endin)
        {
            return all_movies_matching(new AnonymousCriteria<Movie>(item => item.date_published.Year >= starting_year &&
                item.date_published.Year <= endin));
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            return all_movies_matching(new AnonymousCriteria<Movie>(item => item.genre == Genre.kids));
        }

        public IEnumerable<Movie> all_action_movies()
        {
            return all_movies_matching(new AnonymousCriteria<Movie>(item => item.genre == Genre.action));
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
}