using System;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core;

namespace Cheats.Patches.Experience
{
    [HarmonyPatch(typeof(HeroDeveloper), nameof(HeroDeveloper.GetRequiredFocusPointsToAddFocus))]
    public static class FreeFocusPointAssignment
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetRequiredFocusPointsToAddFocus(ref SkillObject skill, ref int __result)
        {
            try
            {
                if (SettingsManager.FreeFocusPointAssignment.IsChanged)
                {
                    __result = 0;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(FreeFocusPointAssignment));
            }
        }
    }
}
