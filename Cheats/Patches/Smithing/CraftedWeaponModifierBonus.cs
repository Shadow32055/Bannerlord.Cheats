using System;
using System.Drawing;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.Core;
using TaleWorlds.Library;
using static TaleWorlds.Core.Crafting;

namespace Cheats.Patches.Smithing
{
    [HarmonyPatch]
    public static class CraftedWeaponModifierBonus {
        /*[UsedImplicitly]
        [HarmonyPostfix]
        public static void GetModifierChanges(int modifierTier, ref OverrideData __result) {
            try {
                if (SettingsManager.CraftedWeaponHandlingBonus.IsChanged) {
                    __result.Handling += SettingsManager.CraftedWeaponHandlingBonus.Value;
                }

                if (SettingsManager.CraftedWeaponSwingDamageBonus.IsChanged) {
                    __result.SwingDamageOverriden += SettingsManager.CraftedWeaponSwingDamageBonus.Value;
                }

                if (SettingsManager.CraftedWeaponSwingSpeedBonus.IsChanged) {
                    __result.SwingSpeedOverriden += SettingsManager.CraftedWeaponSwingSpeedBonus.Value;
                }

                if (SettingsManager.CraftedWeaponThrustDamageBonus.IsChanged) {
                    __result.ThrustDamageOverriden += SettingsManager.CraftedWeaponThrustDamageBonus.Value;
                }

                if (SettingsManager.CraftedWeaponThrustSpeedBonus.IsChanged) {
                    __result.ThrustSpeedOverriden += SettingsManager.CraftedWeaponThrustSpeedBonus.Value;
                }
            } catch (Exception e) {
                SubModule.LogError(e, typeof(CraftedWeaponModifierBonus));
            }
        }*/

        /*[HarmonyPostfix]
        [HarmonyPatch(typeof(Crafting), nameof(Crafting.GetCurrentCraftedItemObject))]
        public static void Handling(ref ItemObject __result) {
            __result. += SettingsManager.CraftedWeaponHandlingBonus.Value;
        }*/

        [HarmonyPostfix]
        [HarmonyPatch(typeof(WeaponComponentData), "Handling", MethodType.Getter)]
        public static void Handling(ref int __result) {
            __result += SettingsManager.CraftedWeaponHandlingBonus.Value;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(WeaponComponentData), "SwingDamage", MethodType.Getter)]
        public static void SwingDamagePostfix(ref int __result) {
            __result += SettingsManager.CraftedWeaponSwingDamageBonus.Value;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(WeaponComponentData), "SwingSpeed", MethodType.Getter)]
        public static void SwingSpeedPostfix(ref int __result) {
            __result += SettingsManager.CraftedWeaponSwingSpeedBonus.Value;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(WeaponComponentData), "ThrustDamage", MethodType.Getter)]
        public static void ThrustDamagePostfix(ref int __result) {
            __result += SettingsManager.CraftedWeaponThrustDamageBonus.Value;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(WeaponComponentData), "ThrustSpeed", MethodType.Getter)]
        public static void ThrustSpeedPostfix(ref int __result) {
            __result += SettingsManager.CraftedWeaponThrustSpeedBonus.Value;
        }
    }
}
