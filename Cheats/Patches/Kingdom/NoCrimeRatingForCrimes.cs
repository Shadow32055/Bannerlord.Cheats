using System;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;

namespace Cheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(ChangeCrimeRatingAction), nameof(ChangeCrimeRatingAction.Apply))]
    public static class NoCrimeRatingForCrimes
    {
        [UsedImplicitly]
        [HarmonyPrefix]
        public static void Apply(
            ref IFaction faction,
            ref float deltaCrimeRating,
            ref bool showNotification)
        {
            try
            {
                if (SettingsManager.NoCrimeRatingForCrimes.IsChanged)
                {
                    deltaCrimeRating = 0f;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(NoCrimeRatingForCrimes));
            }
        }
    }
}
