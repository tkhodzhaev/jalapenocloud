using System;
using System.Collections.Generic;

namespace JalapenoCloud.Common.Helpers
{
    public static class CalendarHelper
    {
        public static readonly DateTime MinDate = new DateTime(1900, 1, 1);

        public static Dictionary<int, string> Months()
        {
            var response = new Dictionary<int, string>();

            string[] months = new string[]
            {
                "Январь", "Февраль", "Март",
                "Апрель", "Май", "Июнь",
                "Июль", "Август", "Сентябрь",
                "Октябрь", "Ноябрь", "Декабрь"
            };

            for (int i = 0; i <= months.Length - 1; i++)
                response.Add(i + 1, months[i]);

            return response;
        }

        public static Dictionary<int, string> Years()
        {
            var response = new Dictionary<int, string>();

            for (int i = CalendarHelper.MinDate.Year; i <= DateTime.Today.Year; i++)
                response.Add(i, i.ToString());

            return response;
        }
    }
}