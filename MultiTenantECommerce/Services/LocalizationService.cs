using Microsoft.Extensions.Localization;
using System.Globalization;

namespace LuvCremicaArt.Shop.Services
{
    public class LocalizationService
    {
        private readonly IStringLocalizer _localizer;

        public LocalizationService(IStringLocalizerFactory localizerFactory)
        {
            var type = typeof(LocalizationService); 
            _localizer = localizerFactory.Create(type);
        }

        public string GetLocalizedValue(string key)
        {
            return _localizer[key];
        }
    }
}
