using System;

namespace C_
{
    class Program
    {
        static void Main(string[] args)
        {
            string birthday;
            Console.WriteLine("Please type your birthday in MM/DD/YYYY form.");
            birthday = Console.ReadLine();

            try
            {
                DateTime birthDateTime = DateTime.Parse(birthday);

                DateTime now = DateTime.Today;
                //DateTime now = new DateTime(2019,9,9);
                DateTime CalenderOrigin = new DateTime(1, 1, 0001); //Start of the Calender, allows for the calculation to account for varying month lengths and leap years
                TimeSpan diff = now.Subtract(birthDateTime);

                //Calculating the TimeSpan in Years, Months, and Days
                int Years = (CalenderOrigin + diff).Year - 1;
                int Months = (CalenderOrigin + diff).Month - 1;
                int Days = (CalenderOrigin + diff).Day - 1; //Excluding the End Date

                Console.WriteLine("You are approximatly {0} Year(s), {1} Month(s), and {2} day(s) old.", Years, Months, Days);

                //Find the next Birthday
                int BDayMonth = birthDateTime.Month;
                int BDayDay = birthDateTime.Day;
                int BDayYear = now.Year;
                DateTime nextBDay = new DateTime(BDayYear, BDayMonth, BDayDay);
                if (now > nextBDay)
                { //If the Birthday has already passed this year, calculate for next year.
                    nextBDay = nextBDay.AddYears(1);
                }

                //Calculate TimeSpan until next Birthday
                TimeSpan untilBDay = nextBDay.Subtract(now);
                Double DaysUntilBDay = Convert.ToDouble(untilBDay.Days);
                Double MonthsUntilBDay = Math.Round(DaysUntilBDay / 30);

                Console.WriteLine("Your next birthday is in approximatly {0} Month(s).", MonthsUntilBDay);
                //comment
                Double WeeksUntilBDay = 0;

                if (now.DayOfWeek == DayOfWeek.Tuesday)
                {                    //Rounds to the nearest Sunday, then counts the weeks. Subtract a week if it is currently the weekend already
                    WeeksUntilBDay = Math.Ceiling((DaysUntilBDay - 5) / 7);
                }
                else if (now.DayOfWeek == DayOfWeek.Wednesday)
                {
                    WeeksUntilBDay = Math.Ceiling((DaysUntilBDay - 4) / 7);
                }
                else if (now.DayOfWeek == DayOfWeek.Thursday)
                {
                    WeeksUntilBDay = Math.Ceiling((DaysUntilBDay - 3) / 7);
                }
                else if (now.DayOfWeek == DayOfWeek.Friday)
                {
                    WeeksUntilBDay = Math.Ceiling((DaysUntilBDay - 2) / 7);
                }
                else if (now.DayOfWeek == DayOfWeek.Saturday)
                {
                    WeeksUntilBDay = Math.Ceiling((DaysUntilBDay - 1) / 7) - 1;
                }
                else if (now.DayOfWeek == DayOfWeek.Sunday)
                {
                    WeeksUntilBDay = Math.Ceiling((DaysUntilBDay) / 7) - 1;
                }
                else
                {
                    WeeksUntilBDay = (DaysUntilBDay) / 7;
                }

                Console.WriteLine("That's approximatly {0} weekends from now.", (int)WeeksUntilBDay);

            }
            catch
            {
                Console.WriteLine("This is either not the correct format or an invalid date.");
            }

        }
    }
}
