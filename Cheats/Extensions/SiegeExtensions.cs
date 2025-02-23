﻿using System.Linq;
using TaleWorlds.CampaignSystem.Siege;

namespace Cheats.Extensions
{
    public static class SiegeExtensions
    {
        public static bool IsPlayerSide(this ISiegeEventSide side)
        {
            return side?.GetInvolvedPartiesForEventType()?.Any(x => x.IsPlayerParty()) ?? false;
        }
    }
}
