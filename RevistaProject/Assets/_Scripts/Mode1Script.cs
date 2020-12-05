using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mode1Script : MonoBehaviour
{
    [Header("Canvas")]
    public Canvas canvasWIN;
    public Canvas canvasGO;

    [Header("Text")]
    public Text lifeText; //las vidas generales
    public Text currencyText; //canvas win
    public Text starText; //canvas win
    public Text currentPointText; //escena normal
    public Text maxPoints; // escena normal


    // Start is called before the first frame update
    void Awake()
    {
        canvasGO.enabled = false;
        canvasWIN.enabled = false;
        GameManager.currentLife = GameManager.life;
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.SetText(lifeText, GameManager.currentLife);
        GameManager.Instance.SetText(currentPointText, GameManager.currentPoints);
        GameManager.Instance.SetText(maxPoints, GameManager.Instance.totalPointsInGame);
        
        if(GameManager.currentPoints >= GameManager.Instance.totalPointsInGame)
        {
            GameManager.EnableCanvas(canvasWIN);
            GameManager.Instance.SetText(currencyText, GameManager.rewardAmount);
            GameManager.Instance.SetText(starText, StaticFunctions.CalculateStars());

            if (!GameManager.addedCurrency)
            {
                GameManager.AddCurrencyAndXp();
                GameManager.addedCurrency = true;
            }
        }

        if(GameManager.currentLife <= 0)
        {
            GameManager.EnableCanvas(canvasGO);
        }
    }
}
