﻿using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace Cheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultTradeItemPriceFactorModel), nameof(DefaultTradeItemPriceFactorModel.GetPrice))]
    public static class SellingPriceMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetPrice(EquipmentElement itemRosterElement, MobileParty clientParty, PartyBase merchant, bool isSelling, float inStoreValue, float supply, float demand, ref int __result)
        {
            try
            {
                if (clientParty.IsPlayerParty()
                    && isSelling
                    && SettingsManager.SellingPriceMultiplier.IsChanged)
                {
                    __result = (int) Math.Round(__result * SettingsManager.SellingPriceMultiplier.Value);
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(SellingPriceMultiplier));
            }
        }
    }
}
