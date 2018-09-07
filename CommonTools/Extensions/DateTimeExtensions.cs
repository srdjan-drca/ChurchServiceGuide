using System;

namespace CommonTools.Extensions {

   public static class DateTimeExtensions {

      public static bool IsInRange(this DateTime date, DateTime startDate, DateTime endDate) {
         return date >= startDate && date < endDate;
      }

      public static bool IsWorkday(this DateTime date) {
         return date.DayOfWeek == DayOfWeek.Monday
            || date.DayOfWeek == DayOfWeek.Tuesday
            || date.DayOfWeek == DayOfWeek.Wednesday
            || date.DayOfWeek == DayOfWeek.Thursday
            || date.DayOfWeek == DayOfWeek.Friday;
      }

      public static bool IsMonday(this DateTime date) {
         return date.DayOfWeek == DayOfWeek.Monday;
      }

      public static bool IsTuesday(this DateTime date) {
         return date.DayOfWeek == DayOfWeek.Tuesday;
      }

      public static bool IsWednesday(this DateTime date) {
         return date.DayOfWeek == DayOfWeek.Wednesday;
      }

      public static bool IsThursday(this DateTime date) {
         return date.DayOfWeek == DayOfWeek.Thursday;
      }

      public static bool IsFriday(this DateTime date) {
         return date.DayOfWeek == DayOfWeek.Friday;
      }
   }
}
