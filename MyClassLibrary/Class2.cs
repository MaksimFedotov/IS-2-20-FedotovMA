using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public static class DateParser
    {


        public static string GetMonth(string month)
        {

            switch (month)
            {
                case "01":
                    return "Января";
                case "02":
                    return "Февраля";
                case "03":
                    return "Марта";
                case "04":
                    return "Апреля";
                case "05":
                    return "Мая";
                case "06":
                    return "Июня";
                case "07":
                    return "Июля";
                case "08":
                    return "Августа";
                case "09":
                    return "Сентября";
                case "10":
                    return "Октября";
                case "11":
                    return "Ноября";
                case "12":
                    return "Декабря";
                default: throw new Exception("Неверный формат месяца!");

            }
        }
        public static string Parse(string s)
        {
            string[] dateParts = s.Substring(0, 10).Split('.');


            string day = dateParts[0];
            string month = GetMonth(dateParts[1]);
            string year = dateParts[2];

            return $"{day} {month} {year} г.";
        }
    }
    
}
