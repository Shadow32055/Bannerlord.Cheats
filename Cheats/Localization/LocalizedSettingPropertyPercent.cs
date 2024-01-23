using MCM.Abstractions;

namespace Cheats.Localization
{
    public sealed class LocalizedSettingPropertyPercent : LocalizedSettingProperty, IPropertyDefinitionWithMinMax, IPropertyDefinitionWithFormat
    {
        public LocalizedSettingPropertyPercent(string settingName) : base(settingName) { }

        public string ValueFormat { get; } = "0.00\\%";

        public decimal MinValue { get; } = 0;

        public decimal MaxValue { get; } = 100;
    }
}
