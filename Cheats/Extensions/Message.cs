using TaleWorlds.Library;

namespace Cheats.Extensions
{
    public static class Message
    {
        public static void Show(string text, Color? color = null)
        {
            var messageColor = color ?? Color.White;

            InformationManager.DisplayMessage(new InformationMessage(text, messageColor));
        }
    }
}
