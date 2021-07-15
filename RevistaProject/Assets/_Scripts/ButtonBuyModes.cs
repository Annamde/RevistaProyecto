using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonBuyModes : MonoBehaviour
{
    [SerializeField]
    private Text _warningText;

    [SerializeField]
    private GameObject _panel;


    private BuyModes _modeClass;

    private void Start()
    {
        _warningText.enabled = false;
        _relationCurrencies.Clear();
        SetAllCurrency();
    }

    private Dictionary<Enums.RayosType, int> _relationCurrencies = new Dictionary<Enums.RayosType, int>();
 

    private void SetAllCurrency()
    {
        _relationCurrencies.Add(Enums.RayosType.Blue, GameManager.totalBlueCurrency1);
        _relationCurrencies.Add(Enums.RayosType.Yellow, GameManager.totalYellowCurrency2);
        _relationCurrencies.Add(Enums.RayosType.Pink, GameManager.totalPinkCurrency3);
        _relationCurrencies.Add(Enums.RayosType.White, GameManager.totalWhiteCurrency4);
        _relationCurrencies.Add(Enums.RayosType.Purple, GameManager.totalPurpleCurrency7);
        _relationCurrencies.Add(Enums.RayosType.Orange, GameManager.totalOrangeCurrency6);
        _relationCurrencies.Add(Enums.RayosType.Green, GameManager.totalGreenCurrency5);
    }

    public void SetModeClass(BuyModes mode)
    {
        _modeClass = mode;
    }

    public void CheckCanBuyMode()
    {
        _warningText.enabled = false;
        if (_modeClass.CurrencyNecessary <= _relationCurrencies[_modeClass.RayosCurrencyType])
        {
            PlaySound(GameManager.a1button);

            GameManager.UpdateCurrency(_modeClass.RayosCurrencyType, _modeClass.CurrencyNecessary);
            _modeClass.ImageModeUnlocked.enabled = false;
            _panel.SetActive(false);
            PlayerPrefs.SetInt(_modeClass.ButtonModeType.ToString(), 1);
        }
        else
        {
            PlaySound(GameManager.a2lockedButton);

            _warningText.enabled = true;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        GameManager.audio.Stop();
        GameManager.audio.clip = clip;
        GameManager.audio.Play();
    }
}
