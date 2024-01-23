using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;

namespace Cheats.Patches.Characters
{
    [HarmonyPatch(typeof(DefaultRomanceModel), nameof(DefaultRomanceModel.GetAttractionValuePercentage))]
    public static class PerfectAttraction
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAttractionValuePercentage(
            ref Hero potentiallyInterestedCharacter,
            ref Hero heroOfInterest,
            ref int __result)
        {
            try
            {
                if (SettingsManager.PerfectAttraction.IsChanged
                    && heroOfInterest.IsPlayer())
                {
                    __result = 100;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(PerfectAttraction));
            }
        }
    }
}
