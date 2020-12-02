using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManagerScript : MonoBehaviour
{
    public Text blueText1;
    public Text yellowText2;
    public Text pinkText3;
    public Text whiteText4;
    public Text greenText5;
    public Text orangeText6;
    public Text purpleText7;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCurrencyText();
    }

    public void UpdateCurrencyText()
    {
        blueText1.text = GameManager.totalBlueCurrency1.ToString();
        yellowText2.text = GameManager.totalYellowCurrency2.ToString();
        pinkText3.text = GameManager.totalPinkCurrency3.ToString();
        whiteText4.text = GameManager.totalWhiteCurrency4.ToString();
        greenText5.text = GameManager.totalGreenCurrency5.ToString();
        orangeText6.text = GameManager.totalOrangeCurrency6.ToString();
        purpleText7.text = GameManager.totalPurpleCurrency7.ToString();
    }
}
