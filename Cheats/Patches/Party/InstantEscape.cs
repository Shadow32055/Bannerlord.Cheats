using System;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;

namespace Cheats.Patches.Party
{
    [HarmonyPatch(typeof(PlayerCaptivityCampaignBehavior), nameof(PlayerCaptivityCampaignBehavior.CheckCaptivityChange))]
    public static class InstantEscape
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CheckCaptivityChange(float dt)
        {
            try
            {
                if (SettingsManager.InstantEscape.IsChanged)
                {
                    PlayerCaptivity.EndCaptivity();
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(InstantEscape));
            }
        }
    }
}
