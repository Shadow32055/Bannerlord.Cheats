using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Party;

namespace Cheats.Patches.Map
{
    [HarmonyPatch(typeof(MobileParty), nameof(MobileParty.ShouldBeIgnored), MethodType.Getter)]
    public static class CaravansInvisibleOnMap
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void ShouldBeIgnored(ref MobileParty __instance, ref bool __result)
        {
            try
            {
                if (__instance.IsCaravan
                    && __instance.Owner.IsPlayer()
                    && SettingsManager.CaravansInvisibleOnMap.Value)
                {
                    __result = true;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(CaravansInvisibleOnMap));
            }
        }
    }
}