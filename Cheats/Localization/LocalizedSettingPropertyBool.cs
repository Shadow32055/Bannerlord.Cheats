using MCM.Abstractions;

namespace Cheats.Localization
{
    public sealed class LocalizedSettingPropertyBool : LocalizedSettingProperty, IPropertyDefinitionBool
    {
        public LocalizedSettingPropertyBool(string settingName) : base(settingName) { }
    }
}
