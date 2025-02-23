﻿using Cheats.Settings;
using HarmonyLib;
using System;
using Cheats.Extensions;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace Cheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultTradeItemPriceFactorModel), nameof(DefaultTradeItemPriceFactorModel.GetPrice))]
    public static class ItemTradingCostPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetPrice(EquipmentElement itemRosterElement, MobileParty clientParty, PartyBase merchant, bool isSelling, float inStoreValue, float supply, float demand, ref int __result)
        {
            try
            {
                if (clientParty.IsPlayerParty()
                    && !isSelling
                    && SettingsManager.ItemTradingCostPercentage.IsChanged)
                {
                    var factor = SettingsManager.ItemTradingCostPercentage.Value / 100f;

                    var newValue = (int)Math.Round(factor * __result);

                    __result = newValue;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(ItemTradingCostPercentage));
            }
        }
    }
}
