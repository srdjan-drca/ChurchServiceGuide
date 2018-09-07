using System;
using System.Collections.Generic;
using ChurchServiceCalculator.Enums;
using Xunit;

namespace ChurchServiceCalculator.Test.FastRule {

   public class DormitionFastRuleShould {

      // Julian calendar: 1 August - 14 August
      // Gregorian calendar: 14 August - 27 August
      private readonly List<DateTime> _workdaysInDormitionFast;

      private readonly List<DateTime> _weekendsInDormitionFast;

      public DormitionFastRuleShould() {
         _workdaysInDormitionFast = new List<DateTime> {
            new DateTime(2018, 8, 1).AddDays(13),
            new DateTime(2018, 8, 2).AddDays(13),
            new DateTime(2018, 8, 3).AddDays(13),
            new DateTime(2018, 8, 4).AddDays(13),
            new DateTime(2018, 8, 7).AddDays(13),
            new DateTime(2018, 8, 8).AddDays(13),
            new DateTime(2018, 8, 9).AddDays(13),
            new DateTime(2018, 8, 10).AddDays(13),
            new DateTime(2018, 8, 11).AddDays(13),
            new DateTime(2018, 8, 14).AddDays(13)
         };

         _weekendsInDormitionFast = new List<DateTime> {
            new DateTime(2018, 8, 5).AddDays(13),
            new DateTime(2018, 8, 6).AddDays(13),
            new DateTime(2018, 8, 12).AddDays(13),
            new DateTime(2018, 8, 13).AddDays(13)
         };
      }

      // General:Water
      [Fact]
      public void ReturnFastTypeWater_IfWorkdaysFromAugust14TillAugust27() {

         foreach (DateTime workday in _workdaysInDormitionFast) {
            FastRuleEnum fastRule = Providers.FastRule.Get(workday);
            Assert.Equal(FastRuleEnum.Water, fastRule);
         }
      }

      // General:OilAndWine
      [Fact]
      public void ReturnFastTypeOilAndWine_IfWeekendsFromAugust14TillAugust27() {

         foreach (DateTime weekend in _weekendsInDormitionFast) {
            FastRuleEnum fastRule = Providers.FastRule.Get(weekend);
            Assert.Equal(FastRuleEnum.OilAndWine, fastRule);
         }
      }
   }
}
