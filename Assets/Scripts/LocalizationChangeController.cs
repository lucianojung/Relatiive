using System;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LocalizationChangeController : MonoBehaviour
{
    public RelativeController relativeController;
    public Sprite germanFlag;
    public Sprite usaFlag;
    
    private Image _image;
    

    private void Start()
    {
        _image = GetComponent<Image>();
        ChangeSelectedLocale();
        ChangeSelectedLocale();
    }

    public void ChangeSelectedLocale()
    {
        if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
            _image.sprite = usaFlag;
        }
        else
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
            _image.sprite = germanFlag;
        }
        relativeController.OnRelativeTapped(relativeController.CurrentRelative);
    }
}
