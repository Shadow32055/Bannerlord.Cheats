using MCM.Abstractions;
using System;

namespace Cheats.Localization
{
    public sealed class LocalizedSettingPropertyFloatingInteger : LocalizedSettingProperty, IPropertyDefinitionWithMinMax, IPropertyDefinitionWithFormat
    {
        public LocalizedSettingPropertyFloatingInteger(string settingName, float minValue, float maxValue) : base(settingName)
        {
            this.MinValue = Convert.ToDecimal(minValue);
            this.MaxValue = Convert.ToDecimal(maxValue);
        }

        public string ValueFormat { get; } = "0.00";

        public decimal MinValue { get; }

        public decimal MaxValue { get; }
    }
}
