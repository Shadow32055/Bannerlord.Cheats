using Cheats.Settings;
using HarmonyLib;
using System;
using Cheats.Extensions;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;

namespace Cheats.Patches.Smithing
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetEnergyCostForSmithing))]
    public static class SmithingEnergyCostPercentageSmithing
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetEnergyCostForSmithing(ItemObject item, Hero hero, ref int __result)
        {
            try
            {
                if (hero.PartyBelongedTo.IsPlayerParty()
                    && SettingsManager.SmithingEnergyCostPercentage.IsChanged)
                {
                    var factor = SettingsManager.SmithingEnergyCostPercentage.Value / 100f;

                    var newValue = (int)Math.Round(factor * __result);

                    __result = newValue;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(SmithingEnergyCostPercentageSmithing));
            }
        }
    }
}
