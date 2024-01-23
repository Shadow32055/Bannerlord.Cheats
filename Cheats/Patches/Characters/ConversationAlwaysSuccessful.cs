using System;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Conversation.Persuasion;
using TaleWorlds.CampaignSystem.GameComponents;

namespace Cheats.Patches.Characters
{
    [HarmonyPatch(typeof(DefaultPersuasionModel), nameof(DefaultPersuasionModel.GetChances))]
    public static class ConversationAlwaysSuccessful
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetChances(PersuasionOptionArgs optionArgs, ref float successChance, ref float critSuccessChance, ref float critFailChance, ref float failChance, float difficultyMultiplier)
        {
            try
            {
                if (SettingsManager.ConversationAlwaysSuccessful.IsChanged)
                {
                    successChance = 1;
                    critSuccessChance = 1;
                    failChance = 0;
                    critFailChance = 0;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(ConversationAlwaysSuccessful));
            }
        }
    }
}
