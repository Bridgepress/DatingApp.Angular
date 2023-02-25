namespace DatingApp.Domain.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateTime dateOfBirht)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirht.Year;
            if (dateOfBirht.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
