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

    bool musicPlayed = false;
    bool linesWronged = false;


    // Start is called before the first frame update
    void Awake()
    {
        canvasGO.enabled = false;
        canvasWIN.enabled = false;
        GameManager.currentLife = GameManager.life;
    }

    private void Start()
    {
        musicPlayed = false;
        linesWronged = false;
        
        GameManager.linesCompleted = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //print(GameManager.linesCompleted);

        GameManager.SetText(lifeText, GameManager.currentLife);
        GameManager.SetText(currentPointText, GameManager.currentPoints);
        GameManager.SetText(maxPoints, GameManager.Instance.totalPointsInGame);
        
        //convertir todas las barras en TypeWrong
        if((GameManager.linesCompleted >= GameManager.linesToComplete) && linesWronged == false)
        {
            foreach (GameObject hueco in GetAllWrongBars())
            {
                hueco.gameObject.tag = "TypeWrong";
            }
            linesWronged = true;
        }

        if(GameManager.currentPoints >= GameManager.Instance.totalPointsInGame)
        {
            if (!musicPlayed)
            {
                GameManager.audioOst.Stop();
                GameManager.audioCanvas.Stop();
                GameManager.audioCanvas.clip = GameManager.a8win;
                GameManager.audioCanvas.Play();

                musicPlayed = true;
            }

            GameManager.EnableCanvas(canvasWIN);
            GameManager.SetText(currencyText, GameManager.rewardAmount);
            GameManager.SetText(starText, (int)StaticFunctions.CalculateStars());

            if (!GameManager.addedCurrency)
            {
                GameManager.AddCurrencyAndXp();
                GameManager.addedCurrency = true;
            }
        }

        if(GameManager.currentLife <= 0)
        {
            if (!musicPlayed)
            {
                GameManager.audioOst.Stop();
                GameManager.audioCanvas.Stop();
                GameManager.audioCanvas.clip = GameManager.a9gameover;
                GameManager.audioCanvas.Play();

                musicPlayed = true;
            }

            GameManager.EnableCanvas(canvasGO);
        }
    }

    public List<GameObject> GetAllWrongBars()
    {
        List<GameObject> barsList = new List<GameObject>(GameObject.FindGameObjectsWithTag("TypeBlueBar"));
        barsList.AddRange(new List<GameObject>(GameObject.FindGameObjectsWithTag("TypeYellowBar")));
        barsList.AddRange(new List<GameObject>(GameObject.FindGameObjectsWithTag("TypePinkBar")));
        barsList.AddRange(new List<GameObject>(GameObject.FindGameObjectsWithTag("TypeWhiteBar")));

        return barsList;
    }
}
