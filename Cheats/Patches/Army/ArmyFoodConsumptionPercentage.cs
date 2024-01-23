using System;
using Cheats.Settings;
using HarmonyLib;
using Cheats.Extensions;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace Cheats.Patches.Army
{
    [HarmonyPatch(typeof(DefaultMobilePartyFoodConsumptionModel), nameof(DefaultMobilePartyFoodConsumptionModel.CalculateDailyFoodConsumptionf))]
    public static class ArmyFoodConsumptionPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateDailyFoodConsumptionf(
            ref MobileParty party,
            ref ExplainedNumber baseConsumption,
            ref ExplainedNumber __result)
        {
            try
            {
                if (party.IsPlayerArmy()
                    && SettingsManager.ArmyFoodConsumptionPercentage.IsChanged)
                {
                    __result.AddPercentage(SettingsManager.ArmyFoodConsumptionPercentage.Value);
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(ArmyFoodConsumptionPercentage));
            }
        }
    }
}
