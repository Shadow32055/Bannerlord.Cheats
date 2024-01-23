using System;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements.Workshops;

namespace Cheats.Patches.Workshops
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), nameof(DefaultWorkshopModel.GetCostForPlayer))]
    public static class WorkshopBuyingCostPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetBuyingCostForPlayer(ref Workshop workshop, ref int __result)
        {
            try
            {
                if (SettingsManager.WorkshopBuyingCostPercentage.IsChanged)
                {
                    var factor = SettingsManager.WorkshopBuyingCostPercentage.Value / 100f;

                    __result = (int) (__result * factor);
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(WorkshopBuyingCostPercentage));
            }
        }
    }
}
