﻿using System;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;

namespace Cheats.Patches.Party
{
    [HarmonyPatch(typeof(EndCaptivityAction), nameof(EndCaptivityAction.ApplyByEscape))]
    public static class NoPrisonerEscape
    {
        [UsedImplicitly]
        [HarmonyPrefix]
        public static bool ApplyByEscape(Hero character, Hero facilitator)
        {
            try
            {
                if (character.IsPrisoner
                    && character.PartyBelongedToAsPrisoner != null
                    && character.PartyBelongedToAsPrisoner.MapFaction == Hero.MainHero.MapFaction
                    && SettingsManager.NoPrisonerEscape.IsChanged)
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(NoPrisonerEscape));

                return true;
            }
        }
    }
}
