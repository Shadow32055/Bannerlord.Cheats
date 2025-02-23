﻿using System;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;

namespace Cheats.Patches.Smithing
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetCraftingPartDifficulty))]
    public static class SmithingDifficultyPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetCraftingPartDifficulty(CraftingPiece craftingPiece, ref int __result)
        {
            try
            {
                if (SettingsManager.SmithingDifficultyPercentage.IsChanged)
                {
                    var factor = SettingsManager.SmithingDifficultyPercentage.Value / 100f;

                    var newValue = (int)Math.Round(factor * __result);

                    __result = newValue;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(SmithingDifficultyPercentage));
            }
        }
    }
}
