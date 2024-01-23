using System;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements.Workshops;

namespace Cheats.Patches.Workshops
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), nameof(DefaultWorkshopModel.GetCostForPlayer))]
    public static class WorkshopSellingCostMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetSellingCost(ref Workshop workshop, ref int __result)
        {
            try
            {
                if (SettingsManager.WorkshopSellingCostMultiplier.IsChanged)
                {
                    __result = (int) (__result * SettingsManager.WorkshopSellingCostMultiplier.Value);
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(WorkshopSellingCostMultiplier));
            }
        }
    }
}
