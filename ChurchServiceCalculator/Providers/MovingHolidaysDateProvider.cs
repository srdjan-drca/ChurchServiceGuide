using System;
using System.Collections.Generic;

namespace ChurchServiceCalculator.Providers {

   public static class MovingHolidaysDateProvider {

      private class MonthDay {

         public int Month { get; private set; }

         public int Day { get; private set; }

         public MonthDay(int month, int day) {
            Month = month;
            Day = day;
         }
      }

      private static readonly Dictionary<int, MonthDay> EasterTable = new Dictionary<int, MonthDay> {
         { 1, new MonthDay(3, 22) },
         { 2, new MonthDay(3, 23) },
         { 3, new MonthDay(3, 24) },
         { 4, new MonthDay(3, 25) },
         { 5, new MonthDay(3, 26) },
         { 6, new MonthDay(3, 27) },
         { 7, new MonthDay(3, 28) },
         { 8, new MonthDay(3, 29) },
         { 9, new MonthDay(3, 30) },
         { 10, new MonthDay(3, 31) },
         { 11, new MonthDay(4, 1) },
         { 12, new MonthDay(4, 2) },
         { 13, new MonthDay(4, 3) },
         { 14, new MonthDay(4, 4) },
         { 15, new MonthDay(4, 5) },
         { 16, new MonthDay(4, 6) },
         { 17, new MonthDay(4, 7) },
         { 18, new MonthDay(4, 8) },
         { 19, new MonthDay(4, 9) },
         { 20, new MonthDay(4, 10) },
         { 21, new MonthDay(4, 11) },
         { 22, new MonthDay(4, 12) },
         { 23, new MonthDay(4, 13) },
         { 24, new MonthDay(4, 14) },
         { 25, new MonthDay(4, 15) },
         { 26, new MonthDay(4, 16) },
         { 27, new MonthDay(4, 17) },
         { 28, new MonthDay(4, 18) },
         { 29, new MonthDay(4, 19) },
         { 30, new MonthDay(4, 20) },
         { 31, new MonthDay(4, 21) },
         { 32, new MonthDay(4, 22) },
         { 33, new MonthDay(4, 23) },
         { 34, new MonthDay(4, 24) },
         { 35, new MonthDay(4, 25) }
      };

      public static DateTime Easter(int year) {
         int r1 = year % 19;
         int r2 = year % 4;
         int r3 = year % 7;

         int rA = 19 * r1 + 16;
         int r4 = rA % 30;
         int rB = 2 * r2 + 4 * r3 + 6 * r4;
         int r5 = rB % 7;
         int rC = r4 + r5;

         var monthDay = EasterTable[rC];

         return new DateTime(year, monthDay.Month, monthDay.Day);
      }
   }
}
