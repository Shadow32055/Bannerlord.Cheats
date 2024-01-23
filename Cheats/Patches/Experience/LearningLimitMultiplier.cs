using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Localization;

namespace Cheats.Patches.Experience
{
    [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), nameof(DefaultCharacterDevelopmentModel.CalculateLearningLimit))]
    public static class LearningLimitMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateLearningLimit(
            ref int attributeValue,
            ref int focusValue,
            ref TextObject attributeName,
            ref bool includeDescriptions,
            ref ExplainedNumber __result)
        {
            try
            {
                if (SettingsManager.LearningLimitMultiplier.IsChanged)
                {
                    __result.AddMultiplier(SettingsManager.LearningLimitMultiplier.Value);
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(LearningLimitMultiplier));
            }
        }
    }
}
