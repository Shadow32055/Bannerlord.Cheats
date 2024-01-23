using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using ArmyObj = TaleWorlds.CampaignSystem.Army;

namespace Cheats.Patches.Army
{
    [HarmonyPatch(typeof(ArmyObj), nameof(ArmyObj.DailyCohesionChange), MethodType.Getter)]
    public static class ArmyCohesionLossPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CohesionChange(ref ArmyObj __instance, ref float __result)
        {
            try
            {
                if (__instance.IsPlayerArmy()
                    && SettingsManager.ArmyCohesionLossPercentage.IsChanged)
                {
                    var factor = SettingsManager.ArmyCohesionLossPercentage.Value / 100f;

                    __result *= factor;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(ArmyCohesionLossPercentage));
            }
        }
    }
}
