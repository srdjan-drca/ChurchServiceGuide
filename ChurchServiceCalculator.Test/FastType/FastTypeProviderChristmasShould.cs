using System;
using System.Collections.Generic;
using ChurchServiceCalculator.Enums;
using ChurchServiceCalculator.Providers;
using Xunit;

namespace ChurchServiceCalculator.Test.FastType {

   public class FastTypeProviderChristmasShould {

      // Julian calendar: 15 November - 24 December
      // Gregorian calendar: 28 November - 06 January
      private readonly List<DateTime> _mondaysInChristmasFast;
      private readonly List<DateTime> _tuesdaysInChristmasFast;
      private readonly List<DateTime> _wednesdaysInChristmasFast;
      private readonly List<DateTime> _thursdaysInChristmasFast;
      private readonly List<DateTime> _fridaysInChristmasFast;
      private readonly List<DateTime> _saturdaysInChristmasFastExceptLastWeek;
      private readonly List<DateTime> _sundaysInChristmasFastExceptLastWeek;

      public FastTypeProviderChristmasShould() {
         _mondaysInChristmasFast = new List<DateTime> {
            new DateTime(2018, 11, 20).AddDays(13),
            new DateTime(2018, 11, 27).AddDays(13),
            new DateTime(2018, 12, 04).AddDays(13),
            new DateTime(2018, 12, 11).AddDays(13),
            new DateTime(2018, 12, 18).AddDays(13)
         };

         _tuesdaysInChristmasFast = new List<DateTime> {
            new DateTime(2018, 11, 21).AddDays(13),
            new DateTime(2018, 11, 28).AddDays(13),
            new DateTime(2018, 12, 05).AddDays(13),
            new DateTime(2018, 12, 12).AddDays(13),
            new DateTime(2018, 12, 19).AddDays(13)
         };

         _wednesdaysInChristmasFast = new List<DateTime> {
            new DateTime(2018, 11, 15).AddDays(13),
            new DateTime(2018, 11, 22).AddDays(13),
            new DateTime(2018, 11, 29).AddDays(13),
            new DateTime(2018, 12, 06).AddDays(13),
            new DateTime(2018, 12, 13).AddDays(13),
            new DateTime(2018, 12, 20).AddDays(13)
         };

         _thursdaysInChristmasFast = new List<DateTime> {
            new DateTime(2018, 11, 16).AddDays(13),
            new DateTime(2018, 11, 23).AddDays(13),
            new DateTime(2018, 11, 30).AddDays(13),
            new DateTime(2018, 12, 07).AddDays(13),
            new DateTime(2018, 12, 14).AddDays(13),
            new DateTime(2018, 12, 21).AddDays(13)
         };

         _fridaysInChristmasFast = new List<DateTime> {
            new DateTime(2018, 11, 17).AddDays(13),
            new DateTime(2018, 11, 24).AddDays(13),
            new DateTime(2018, 12, 01).AddDays(13),
            new DateTime(2018, 12, 08).AddDays(13),
            new DateTime(2018, 12, 15).AddDays(13),
            new DateTime(2018, 12, 22).AddDays(13)
         };

         _saturdaysInChristmasFastExceptLastWeek = new List<DateTime> {
            new DateTime(2018, 11, 18).AddDays(13),
            new DateTime(2018, 11, 25).AddDays(13),
            new DateTime(2018, 12, 02).AddDays(13),
            new DateTime(2018, 12, 09).AddDays(13),
            new DateTime(2018, 12, 16).AddDays(13)
         };

         _sundaysInChristmasFastExceptLastWeek = new List<DateTime> {
            new DateTime(2018, 11, 19).AddDays(13),
            new DateTime(2018, 11, 26).AddDays(13),
            new DateTime(2018, 12, 03).AddDays(13),
            new DateTime(2018, 12, 10).AddDays(13),
            new DateTime(2018, 12, 17).AddDays(13)
         };
      }

      // General:Water
      [Fact]
      public void ReturnFastTypeWater_IfMondayFromNovember28TillJanuary6() {

         foreach (DateTime monday in _mondaysInChristmasFast) {
            FastRuleEnum fastRule = FastRuleProvider.Get(monday);
            Assert.Equal(FastRuleEnum.Water, fastRule);
         }
      }

      [Fact]
      public void ReturnFastTypeWater_IfWednesdayFromNovember28TillJanuary6() {

         foreach (DateTime wednesday in _wednesdaysInChristmasFast) {
            FastRuleEnum fastRule = FastRuleProvider.Get(wednesday);
            Assert.Equal(FastRuleEnum.Water, fastRule);
         }
      }

      [Fact]
      public void ReturnFastTypeWater_IfFridayFromNovember28TillJanuary6() {

         foreach (DateTime friday in _fridaysInChristmasFast) {
            FastRuleEnum fastRule = FastRuleProvider.Get(friday);
            Assert.Equal(FastRuleEnum.Water, fastRule);
         }
      }

      // General:OilAndWine
      [Fact]
      public void ReturnFastTypeOilAndWine_IfTuesdayFromNovember28TillJanuary6() {

         foreach (DateTime tuesday in _tuesdaysInChristmasFast) {
            FastRuleEnum fastRule = FastRuleProvider.Get(tuesday);
            Assert.Equal(FastRuleEnum.OilAndWine, fastRule);
         }
      }

      [Fact]
      public void ReturnFastTypeOilAndWine_IfThursdayFromNovember28TillJanuary6() {

         foreach (DateTime thursday in _thursdaysInChristmasFast) {
            FastRuleEnum fastRule = FastRuleProvider.Get(thursday);
            Assert.Equal(FastRuleEnum.OilAndWine, fastRule);
         }
      }

      [Fact]
      public void ReturnFastTypeOilAndWine_IfSaturdayFromDecember31TillJanuary6() {

         DateTime saturday = new DateTime(2018, 12, 23).AddDays(13);
         FastRuleEnum fastRule = FastRuleProvider.Get(saturday);
         Assert.Equal(FastRuleEnum.OilAndWine, fastRule);
      }

      [Fact]
      public void ReturnFastTypeOilAndWine_IfSundayFromDecember31TillJanuary6() {

         DateTime sunday = new DateTime(2018, 12, 24).AddDays(13);
         FastRuleEnum fastRule = FastRuleProvider.Get(sunday);
         Assert.Equal(FastRuleEnum.OilAndWine, fastRule);
      }

      // General:Fish
      [Fact]
      public void ReturnFastTypeFish_IfSaturdayFromNovember28TillDecember30() {

         foreach (DateTime saturday in _saturdaysInChristmasFastExceptLastWeek) {
            FastRuleEnum fastRule = FastRuleProvider.Get(saturday);
            Assert.Equal(FastRuleEnum.Fish, fastRule);
         }
      }

      [Fact]
      public void ReturnFastTypeFish_IfSundayFromNovember28TillDecember30() {

         foreach (DateTime sunday in _sundaysInChristmasFastExceptLastWeek) {
            FastRuleEnum fastRule = FastRuleProvider.Get(sunday);
            Assert.Equal(FastRuleEnum.Fish, fastRule);
         }
      }
   }
}
