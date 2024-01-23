using TaleWorlds.Core;

namespace Cheats.Extensions
{
    public static class CharacterExtensions
    {
        public static bool IsPlayer(this BasicCharacterObject characterObject)
        {
            return characterObject?.IsPlayerCharacter ?? false;
        }

        public static bool IsHero(this BasicCharacterObject characterObject)
        {
            return characterObject?.IsHero ?? false;
        }
    }
}
