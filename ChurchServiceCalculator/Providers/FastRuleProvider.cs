using System;
using ChurchServiceCalculator.Enums;
using ChurchServiceCalculator.Extensions;
using CommonTools.Extensions;

namespace ChurchServiceCalculator.Providers {

   public static class FastRuleProvider {

      public static FastRuleEnum Get(DateTime date) {
         FastRuleEnum fastRule = FastRuleEnum.NoEating;

         if (date.IsChristmasFast()) {
            fastRule = TheChristmasFastRule(date);
         }

         return fastRule;
      }

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
         FastRuleEnum fastRule = FastRuleEnum.Water;

         return fastRule;
      }

      private static FastRuleEnum TheGreatFastRule(DateTime date) {
         FastRuleEnum fastRule = FastRuleEnum.Water;

         return fastRule;
      }

      private static FastRuleEnum TheFastOfTheApostlesRule(DateTime date) {
         FastRuleEnum fastRule = FastRuleEnum.Water;

         return fastRule;
      }
   }
}
