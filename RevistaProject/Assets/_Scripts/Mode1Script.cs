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
    public Text lifeText;


    // Start is called before the first frame update
    void Awake()
    {
        canvasGO.enabled = false;
        canvasWIN.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        print(GameManager.addedCurrency);
        GameManager.Instance.SetText(lifeText, GameManager.life);
        if(GameManager.currentPoints >= GameManager.Instance.totalPointsInGame)
        {
            GameManager.EnableCanvas(canvasWIN);

            if (!GameManager.addedCurrency)
            {
                GameManager.AddCurrencyAndXp();
                GameManager.addedCurrency = true;
            }
        }

        if(GameManager.life <= 0)
        {
            GameManager.EnableCanvas(canvasGO);
        }
    }
}
