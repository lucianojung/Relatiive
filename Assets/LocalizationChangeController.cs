using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocalizationChangeController : MonoBehaviour
{
    public RelativeController relativeController;
    
    public void ChangeSelectedLocale()
    {
        if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
        }
        else
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        }
        relativeController.OnRelativeTapped(relativeController.CurrentRelative);
    }
}
