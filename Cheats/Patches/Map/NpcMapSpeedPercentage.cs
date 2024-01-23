using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace Cheats.Patches.Map
{
    [HarmonyPatch(typeof(DefaultPartySpeedCalculatingModel), nameof(DefaultPartySpeedCalculatingModel.CalculateFinalSpeed))]
    public static class NpcMapSpeedPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateFinalSpeed(ref MobileParty mobileParty, ref ExplainedNumber finalSpeed, ref ExplainedNumber __result)
        {
            try
            {
                if (!mobileParty.IsPlayerParty()
                    && SettingsManager.NpcMapSpeedPercentage.IsChanged)
                {
                    __result.AddPercentage(SettingsManager.NpcMapSpeedPercentage.Value);
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(NpcMapSpeedPercentage));
            }
        }
    }
}
