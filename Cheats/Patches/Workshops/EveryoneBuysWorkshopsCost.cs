using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Settlements.Workshops;

namespace Cheats.Patches.Workshops {
    [HarmonyPatch(typeof(ChangeOwnerOfWorkshopAction), nameof(ChangeOwnerOfWorkshopAction.ApplyByPlayerSelling))]
    public static class EveryoneBuysWorkshopsCost {
        [UsedImplicitly]
        [HarmonyPrefix]
        public static void ApplyByTrade(ref Workshop workshop, ref Hero newOwner, ref WorkshopType workshopType) {
            try {
                int costForNotable = Campaign.Current.Models.WorkshopModel.GetCostForNotable(workshop);
                if (SettingsManager.EveryoneBuysWorkshops.IsChanged
                    && workshop.Owner.IsPlayer()
                    && costForNotable > newOwner.Gold) {
                    newOwner.Gold = costForNotable;
                }
            } catch (Exception e) {
                Cheats.LogError(e, typeof(EveryoneBuysWorkshopsCost));
            }
        }
    }
}
