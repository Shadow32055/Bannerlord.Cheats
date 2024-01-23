using System;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;

namespace Cheats.Patches.Characters
{
    [HarmonyPatch(typeof(DefaultPregnancyModel), nameof(DefaultPregnancyModel.PregnancyDurationInDays), MethodType.Getter)]
    public static class AdjustPregnancyDuration
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void PregnancyDurationInDays(ref float __result)
        {
            try
            {
                if (SettingsManager.AdjustPregnancyDuration.IsChanged)
                {
                    __result = SettingsManager.AdjustPregnancyDuration.Value;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(AdjustPregnancyDuration));
            }
        }
    }
}
