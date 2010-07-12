using System;
using System.Collections.Generic;
using System.Diagnostics;

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
            return movies;
        }

        public void add(Movie movie)
        {
        	var found = false;
			for(var i = 0; i<this.movies.Count; i++)
			{
				found = movie.title == this.movies[i].title;
			}
			if (!found)
				this.movies.Add(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
            	var temp = new Movie[this.movies.Count];
				this.movies.CopyTo(temp, 0);
				for (var i=0; i < temp.Length; i++)
				{
					for (var j=i; j<temp.Length; j++)
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
        	var returnVal = new List<Movie>();
        	for (var i=0; i<this.movies.Count; i++)
        	{
        		if (this.movies[i].production_studio == ProductionStudio.Pixar)
        			returnVal.Add(this.movies[i]);
        	}
        	return returnVal;
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
			var returnVal = new List<Movie>();
			for (var i = 0; i < this.movies.Count; i++)
			{
				if (this.movies[i].production_studio == ProductionStudio.Pixar || this.movies[i].production_studio == ProductionStudio.Disney)
					returnVal.Add(this.movies[i]);
			}
			return returnVal;
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

        	for (var i=0; i < this.movies.Count - 1; i++)
        	{
        		for (var j=i+1; j<this.movies.Count; j++)
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
			var returnVal = new List<Movie>();
			for (var i = 0; i < this.movies.Count; i++)
			{
				if (this.movies[i].production_studio != ProductionStudio.Pixar)
					returnVal.Add(this.movies[i]);
			}
			return returnVal;
		}

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
			var returnVal = new List<Movie>();
			for (var i = 0; i < this.movies.Count; i++)
			{
				if (this.movies[i].date_published.Year > year)
					returnVal.Add(this.movies[i]);
			}
			return returnVal;
		}

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
			var returnVal = new List<Movie>();
			for (var i = 0; i < this.movies.Count; i++)
			{
				if (startingYear <= this.movies[i].date_published.Year &&
					this.movies[i].date_published.Year <= endingYear)
					returnVal.Add(this.movies[i]);
			}
			return returnVal;
		}

        public IEnumerable<Movie> all_kid_movies()
        {
			var returnVal = new List<Movie>();
			for (var i = 0; i < this.movies.Count; i++)
			{
				if (this.movies[i].genre == Genre.kids)
					returnVal.Add(this.movies[i]);
			}
			return returnVal;
		}

        public IEnumerable<Movie> all_action_movies()
        {
			var returnVal = new List<Movie>();
			for (var i = 0; i < this.movies.Count; i++)
			{
				if (this.movies[i].genre == Genre.action)
					returnVal.Add(this.movies[i]);
			}
			return returnVal;
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