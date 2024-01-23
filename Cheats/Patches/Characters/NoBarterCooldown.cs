using System;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.BarterSystem;

namespace Cheats.Patches.Characters
{
    [HarmonyPatch(typeof(BarterManager), nameof(BarterManager.CanPlayerBarterWithHero))]
    public static class NoBarterCooldown
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CanPlayerBarterWithHero(Hero hero, ref bool __result)
        {
            try
            {
                if (SettingsManager.NoBarterCooldown.IsChanged)
                {
                    __result = true;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(NoBarterCooldown));
            }
        }
    }
}
