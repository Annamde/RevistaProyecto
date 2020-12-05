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
        blueText1.text = GameManager.totalBlueCurrency1.ToString();
        yellowText2.text = GameManager.totalYellowCurrency2.ToString();
        pinkText3.text = GameManager.totalPinkCurrency3.ToString();
        whiteText4.text = GameManager.totalWhiteCurrency4.ToString();
        greenText5.text = GameManager.totalGreenCurrency5.ToString();
        orangeText6.text = GameManager.totalOrangeCurrency6.ToString();
        purpleText7.text = GameManager.totalPurpleCurrency7.ToString();
    }
    public void UpdateXpText()
    {
        xpText1.text = GameManager.totalXpBlue1.ToString();
        xpText2.text = GameManager.totalXpYellow2.ToString();
        xpText3.text = GameManager.totalXpPink3.ToString();
        xpText4.text = GameManager.totalXpWhite4.ToString();
        xpText5.text = GameManager.totalXpGreen5.ToString();
        xpText6.text = GameManager.totalXpOrange6.ToString();
        xpText7.text = GameManager.totalXpPurple7.ToString();
    }
}
