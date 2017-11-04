using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace CountWorkingDays
{
    class Program
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            DateTime start = DateTime.ParseExact(startDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime end = DateTime.ParseExact(endDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);


            DateTime[] holidays = new DateTime[]
            {
               DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture),
               DateTime.ParseExact("03-03-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                 DateTime.ParseExact("01-05-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                  DateTime.ParseExact("24-05-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                   DateTime.ParseExact("06-05-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                     DateTime.ParseExact("06-09-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                       DateTime.ParseExact("22-09-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                       DateTime.ParseExact("01-11-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                         DateTime.ParseExact("24-12-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                           DateTime.ParseExact("25-12-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                             DateTime.ParseExact("26-12-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture),

        };

            var countWorkingDays = 0;

            for (DateTime currentDay = start; currentDay <= end; currentDay = currentDay.AddDays(1))
            {
                if ((currentDay.DayOfWeek != DayOfWeek.Sunday && currentDay.DayOfWeek != DayOfWeek.Saturday))
                {
                    bool isHoliday = false;

                    foreach (var holiday in holidays)
                    {
                        if ((holiday.Day == currentDay.Day) && holiday.Month == currentDay.Month)
                        {
                            isHoliday = true;
                            break;
                        }

                    }

                    if (isHoliday == false)
                    {
                        countWorkingDays++;
                    }


                }
               
            }
            Console.WriteLine(countWorkingDays);

        }
    }
}
