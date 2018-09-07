using System;
using ChurchServiceCalculator.Extensions;
using ChurchServiceCalculator.Providers;
using Xunit;
using Xunit.Abstractions;

namespace ChurchServiceCalculator.Test.MovingHolidays {

   public class MovingHolidaysProviderShould {

      private readonly ITestOutputHelper _output;

      public MovingHolidaysProviderShould(ITestOutputHelper output) {
         _output = output;
      }

      [Fact]
      public void CalculateEasterForYear2018ByJulianCalendar() {

         DateTime julianEasterDate = MovingHolidaysDateProvider.Easter(2018);

         Assert.Equal(new DateTime(2018,3,26), julianEasterDate);
      }

      [Fact]
      public void CalculateAllEasterDatesFrom1981Till2020() {

         for (int year = 1981; year <= 2020; year++) {
            DateTime easterDate = MovingHolidaysDateProvider.Easter(year).ToGregorianDate();
            _output.WriteLine($"{year} - Easter: {easterDate:D}");
         }
      }
   }
}
