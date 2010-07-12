namespace nothinbutdotnetprep.collections
{
    public class IsPublishedAfter : MovieCriteria
    {
        int year;

        public IsPublishedAfter(int year)
        {
            this.year = year;
        }

        public bool is_satisfied_by(Movie movie)
        {
            return movie.date_published.Year > year;
        }
    }
}