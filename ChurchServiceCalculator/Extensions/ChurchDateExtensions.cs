using System;
using System.Collections.Generic;
using System.Globalization;
using ChurchServiceCalculator.Enums;
using CommonTools.Extensions;

namespace ChurchServiceCalculator.Extensions {

   public static class ChurchDateExtensions {

      private class CalendarConversionItem {

         public DateTime StartDate { get; }

         public DateTime EndDate { get; }

         public int Difference { get; }

         public CalendarConversionItem(DateTime startDate, DateTime endDate, int difference) {
            StartDate = startDate;
            EndDate = endDate;
            Difference = difference;
         }
      }

      private static readonly DateTime DateOfCreationGregorianCalendar = new DateTime(1582, 10, 15);

      private static readonly DateTime CalendarConversionLastDate = new DateTime(2100, 2, 28);

      private static readonly List<CalendarConversionItem> JulianReferentDates = new List<CalendarConversionItem> {
         new CalendarConversionItem(new DateTime(1582, 10, 05), new DateTime(1700, 02, 19), 10),
         new CalendarConversionItem(new DateTime(1700, 02, 19), new DateTime(1800, 02, 18), 11),
         new CalendarConversionItem(new DateTime(1800, 02, 18), new DateTime(1900, 02, 17), 12),
         new CalendarConversionItem(new DateTime(1900, 02, 17), new DateTime(2100, 02, 16), 13),
         new CalendarConversionItem(new DateTime(2100, 02, 16), new DateTime(2100, 02, 28), 14)
      };

      private static readonly List<CalendarConversionItem> GregorianReferentDates = new List<CalendarConversionItem> {
         new CalendarConversionItem(new DateTime(1582, 10, 15), new DateTime(1700, 03, 01), -10),
         new CalendarConversionItem(new DateTime(1700, 03, 01), new DateTime(1800, 03, 01), -11),
         new CalendarConversionItem(new DateTime(1800, 03, 01), new DateTime(1900, 03, 17), -12),
         new CalendarConversionItem(new DateTime(1900, 03, 01), new DateTime(2100, 03, 16), -13),
         new CalendarConversionItem(new DateTime(2100, 03, 01), new DateTime(2100, 03, 14), -14)
      };

      public static DateTime ToGregorianDate(this DateTime julianDate) {
         DateTime gregorianDate = DateTime.Now;

         if (julianDate < DateOfCreationGregorianCalendar) {
            throw new Exception($"Gregorian calendar didn't exist before {DateOfCreationGregorianCalendar.ToString(CultureInfo.InvariantCulture)}!");
         }

         if (julianDate > CalendarConversionLastDate) {
            throw new Exception("Date not supported for conversion!");
         }

         foreach (var julianDateRange in JulianReferentDates) {
            if (julianDate.IsInRange(julianDateRange.StartDate, julianDateRange.EndDate)) {
               gregorianDate = julianDate.AddDays(julianDateRange.Difference);
               break;
            }
         }

         return gregorianDate;
      }

      public static DateTime ToJulianDate(this DateTime gregorianDate) {
         DateTime julianDate = DateTime.Now;

         if (gregorianDate < DateOfCreationGregorianCalendar) {
            throw new Exception($"Gregorian calendar didn't exist before {DateOfCreationGregorianCalendar.ToString(CultureInfo.InvariantCulture)}!");
         }

         if (gregorianDate > CalendarConversionLastDate) {
            throw new Exception("Date not supported for conversion!");
         }

         foreach (var gregorianConversion in GregorianReferentDates) {
            if (gregorianDate.IsInRange(gregorianConversion.StartDate, gregorianConversion.EndDate)) {
               julianDate = gregorianDate.AddDays(gregorianConversion.Difference);
               break;
            }
         }

         return julianDate;
      }

      public static bool IsChristmasFast(this DateTime date) {
         return
            date.Month == (int)MonthEnum.November && date.Day >= 28 ||
            date.Month == (int)MonthEnum.December ||
            date.Month == (int)MonthEnum.January && date.Day <= 6;
      }

      public static bool IsLastWeekOfChristmasFast(this DateTime date) {
         return
            date.Month == (int)MonthEnum.December && date.Day == 31 ||
            date.Month == (int)MonthEnum.January && (date.Day >= 1 || date.Day <= 6);
      }
   }
}
