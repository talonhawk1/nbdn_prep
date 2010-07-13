using System;
using nothinbutdotnetprep.utility.filtering;

namespace nothinbutdotnetprep.utility.filtering
{
}

namespace nothinbutdotnetprep.collections
{
    public class Movie  : IEquatable<Movie>
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Movie);
        }

        public bool Equals(Movie other)
        {
            if (other == null) return false;

            return ReferenceEquals(this,other) || is_equal_to_non_null_instance_of(other);
        }

        bool is_equal_to_non_null_instance_of(Movie other)
        {
            return this.title == other.title;
        }

        public override int GetHashCode()
        {
            return title.GetHashCode();
        }

        public static Criteria<Movie> is_published_by_pixar
        {
            get { return new IsPublishedBy(ProductionStudio.Pixar); }
        }

        public static Criteria<Movie> is_published_by_pixar_or_disney
        {
            get
            {
                return Where<Movie>.has_a(x => x.production_studio)
                    .equal_to_any(ProductionStudio.Pixar, ProductionStudio.Disney);
            }
        }


        static Criteria<Movie> is_published_after(int year)
        {
            return new IsPublishedAfter(year);
        }

        public Criteria<Movie> equal_to(ProductionStudio studio)
        {
            return new IsPublishedBy(studio);
        }
    }
}