using System;
using ChurchServiceCalculator.Enums;
using ChurchServiceCalculator.Extensions;
using CommonTools.Extensions;

namespace ChurchServiceCalculator.Providers {

   public static class FastRule {

      public static FastRuleEnum Get(DateTime date) {
         FastRuleEnum fastRule = FastRuleEnum.AnimalFat;

         if (date.IsChristmasFast()) {
            fastRule = TheChristmasFastRule(date);
         }

         if (date.IsGreatFast()) {
            fastRule = TheGreatFastRule(date);
         }

         if (date.IsApostlesFast()) {
            fastRule = TheApostlesFastRule(date);
         }

         if (date.IsDormitionFast()) {
            fastRule = TheDormitionFastRule(date);
         }

         return fastRule;
      }

      #region Private methods

      private static FastRuleEnum TheChristmasFastRule(DateTime date) {
         FastRuleEnum fastRule;

         if (date.IsMonday() || date.IsWednesday() || date.IsFriday()) {
            fastRule = FastRuleEnum.Water;
         }
         else if (date.IsTuesday() || date.IsThursday()) {
            fastRule = FastRuleEnum.OilAndWine;
         }
         else {
            fastRule = date.IsLastWeekOfChristmasFast()
               ? FastRuleEnum.OilAndWine
               : FastRuleEnum.Fish;
         }

         return fastRule;
      }

      private static FastRuleEnum TheDormitionFastRule(DateTime date) {
         FastRuleEnum fastRule = date.IsWorkday()
            ? FastRuleEnum.Water
            : FastRuleEnum.OilAndWine;

         return fastRule;
      }

      private static FastRuleEnum TheGreatFastRule(DateTime date) {
         FastRuleEnum fastRule = date.IsWorkday()
            ? FastRuleEnum.Water
            : FastRuleEnum.OilAndWine;

         return fastRule;
      }

      private static FastRuleEnum TheApostlesFastRule(DateTime date) {
         FastRuleEnum fastRule;

         if (date.IsMonday() || date.IsWednesday() || date.IsFriday()) {
            fastRule = FastRuleEnum.Water;
         }
         else if (date.IsTuesday() || date.IsThursday()) {
            fastRule = FastRuleEnum.OilAndWine;
         }
         else {
            fastRule = FastRuleEnum.Fish;
         }

         return fastRule;
      }

      #endregion
   }
}
