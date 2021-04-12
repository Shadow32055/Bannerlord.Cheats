﻿using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultTradeItemPriceFactorModel), nameof(DefaultTradeItemPriceFactorModel.GetPrice))]
    public static class SellingPriceMultiplier
    {
        [HarmonyPostfix]
        public static void GetPrice(EquipmentElement itemRosterElement, MobileParty clientParty, PartyBase merchant, bool isSelling, float inStoreValue, float supply, float demand, ref int __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.SellingPriceMultiplier, out var sellingPriceMultiplier)
                && clientParty.IsPlayerParty()
                && isSelling)
            {
                __result = (int) Math.Round(__result * sellingPriceMultiplier);
            }
        }
    }
}
