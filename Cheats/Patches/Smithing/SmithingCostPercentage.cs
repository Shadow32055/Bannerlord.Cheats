using System;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;

namespace Cheats.Patches.Smithing
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetSmithingCostsForWeaponDesign))]
    public static class SmithingCostPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetSmithingCostsForWeaponDesign(WeaponDesign weaponDesign, ref int[] __result)
        {
            try
            {
                if (SettingsManager.SmithingCostPercentage.IsChanged)
                {
                    var factor = SettingsManager.SmithingCostPercentage.Value / 100f;

                    for (var i = 0; i < __result.Length; i++)
                    {
                        var newValue = (int)Math.Round(factor * __result[i]);

                        __result[i] = newValue;
                    }
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(SmithingCostPercentage));
            }
        }
    }
}
