﻿using System;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.BarterSystem;
using TaleWorlds.CampaignSystem.Party;

namespace Cheats.Patches.Characters
{
    [HarmonyPatch(typeof(BarterManager), nameof(BarterManager.IsOfferAcceptable), new[] { typeof(BarterData), typeof(Hero), typeof(PartyBase) })]
    public static class BarterOfferAlwaysAccepted
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void IsOfferAcceptable(BarterData args, Hero hero, PartyBase party, ref BarterManager __instance, ref bool __result)
        {
            try
            {
                if (SettingsManager.BarterOfferAlwaysAccepted.IsChanged)
                {
                    __result = true;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(BarterOfferAlwaysAccepted));
            }
        }
    }
}
