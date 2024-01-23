using System;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;

namespace Cheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultDisguiseDetectionModel), nameof(DefaultDisguiseDetectionModel.CalculateDisguiseDetectionProbability))]
    public static class DisguiseAlwaysWorks
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateDisguiseDetectionProbability(Settlement settlement, ref float __result)
        {
            try
            {
                if (SettingsManager.DisguiseAlwaysWorks.IsChanged)
                {
                    __result = 1;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(DisguiseAlwaysWorks));
            }
        }
    }
}
