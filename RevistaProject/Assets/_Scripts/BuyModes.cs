using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BuyModes : MonoBehaviour
{
    [SerializeField]
    private int _currencyNecessary;

    [SerializeField]
    private Enums.RayosType _currencyNecessaryType;

    [SerializeField]
    private Enums.RayosType _buttonType;

    [SerializeField]
    private Text _modeText;

    [SerializeField]
    private Text _currencyText;

    [SerializeField]
    private Text _currencyNumberText;

    [SerializeField]
    private string _modeName;

    [SerializeField]
    private Image _imageModeUnlocked;

    public int CurrencyNecessary => _currencyNecessary;
    public Enums.RayosType RayosCurrencyType => _currencyNecessaryType;
    public Enums.RayosType ButtonModeType => _buttonType;
    public Image ImageModeUnlocked => _imageModeUnlocked;

    private Dictionary<Enums.RayosType, string> _currenciesNames = new Dictionary<Enums.RayosType, string>()
    {
        [Enums.RayosType.Blue] = "monedas Rayo Azul",
        [Enums.RayosType.Green] = "monedas Rayo Verde",
        [Enums.RayosType.Orange] = "monedas Rayo Naranja",
        [Enums.RayosType.Pink] = "monedas Rayo Rosa",
        [Enums.RayosType.Yellow] = "monedas Rayo Amarilla",
        [Enums.RayosType.Purple] = "monedas Rayo Violeta",
        [Enums.RayosType.White] = "monedas Rayo Blanca",
    };
 
    public void SetBuyCanvas()
    {
        _modeText.text = _modeName;
        _currencyNumberText.text = _currencyNecessary.ToString();
        _currencyText.text = _currenciesNames[_currencyNecessaryType];
    }

}
