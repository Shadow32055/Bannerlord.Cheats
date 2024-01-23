using System;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements.Workshops;
using TaleWorlds.Core;

namespace Cheats.Patches.Workshops
{
    [HarmonyPatch]
    //[HarmonyPatch(typeof(DefaultWorkshopModel), nameof(DefaultWorkshopModel.GetDailyExpense))]
    public static class WorkshopDailyExpensePercentage {
        /*[UsedImplicitly]
        [HarmonyPostfix]
        public static void GetDailyExpense(ref int level, ref int __result)
        {
            try
            {
                if (SettingsManager.WorkshopDailyExpensePercentage.IsChanged)
                {
                    var factor = SettingsManager.WorkshopDailyExpensePercentage.Value / 100f;

                    __result = (int) (__result * factor);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(WorkshopDailyExpensePercentage));
            }
        }
    }*/
        [HarmonyPostfix]
        [HarmonyPatch(typeof(Workshop), "Expense", MethodType.Getter)]
        public static void ExpensePostfix(ref int __result, ref Workshop __instance) {
            if (SettingsManager.WorkshopDailyExpensePercentage.IsChanged)
                if (__instance.Owner == Campaign.Current.MainParty.Owner)
                    __result = (int)(__result * SettingsManager.WorkshopDailyExpensePercentage.Value / 100f);
        }
    }
}
