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

    public Text xpText1;
    public Text xpText2;
    public Text xpText3;
    public Text xpText4;
    public Text xpText5;
    public Text xpText6;
    public Text xpText7;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCurrencyText();
        UpdateXpText();
    }

    public void UpdateCurrencyText()
    {
        GameManager.SetText(blueText1, GameManager.totalBlueCurrency1);
        GameManager.SetText(yellowText2, GameManager.totalYellowCurrency2);
        GameManager.SetText(pinkText3, GameManager.totalPinkCurrency3);
        GameManager.SetText(whiteText4, GameManager.totalWhiteCurrency4);
        GameManager.SetText(greenText5, GameManager.totalGreenCurrency5);
        GameManager.SetText(orangeText6, GameManager.totalOrangeCurrency6);
        GameManager.SetText(purpleText7, GameManager.totalPurpleCurrency7);
    }
    public void UpdateXpText()
    {
        GameManager.SetText(xpText1, GameManager.totalXpBlue1);
        GameManager.SetText(xpText2, GameManager.totalXpYellow2);
        GameManager.SetText(xpText3, GameManager.totalXpPink3);
        GameManager.SetText(xpText4, GameManager.totalXpWhite4);
        GameManager.SetText(xpText5, GameManager.totalXpGreen5);
        GameManager.SetText(xpText6, GameManager.totalXpOrange6);
        GameManager.SetText(xpText7, GameManager.totalXpPurple7);
    }
}
