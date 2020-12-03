using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }

    public static int life=3;
    public static int currentPoints = 0; //los puntos del jugador en la partida como tal
    static bool created = false;
    

    public int points4Chakra = 10; //los puntos por chackra correcto 
    public int totalPointsInGame = 100;
    public static int colorMode = 1;
    public static int rewardAmount = 10;
    public static int xpReward = 100;

    public static int totalBlueCurrency1 = 0;
    public static int totalYellowCurrency2 = 0;
    public static int totalPinkCurrency3 = 0;
    public static int totalWhiteCurrency4 = 0;
    public static int totalGreenCurrency5 = 0;
    public static int totalOrangeCurrency6 = 0;
    public static int totalPurpleCurrency7 = 0;

    public static int xpPointsTotal = 0;

    public static bool addedCurrency = false;

    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(gameObject);
            created = true;
            Instance = this;
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(currentPoints + "   " + totalPointsInGame);
        print(totalBlueCurrency1 + " " + totalYellowCurrency2 + " " + totalPinkCurrency3 + " " + totalWhiteCurrency4 + " " + totalGreenCurrency5 + " " + totalOrangeCurrency6 + " " + totalPurpleCurrency7);
    }

    public void ResetLifes(int num)
    {
        life = num;
    }

    public void CheckLifes()
    {
        if (life > 0)
        {
            life--;
        }
    }

    public void CheckPoints()
    {
        if(currentPoints < totalPointsInGame)
        {
            currentPoints += points4Chakra;
        }

    }

    public void SetText(Text temp, int num)
    {
        temp.text = num.ToString();
    }

    public static void DisableCanvas(Canvas canvas)
    {
        Time.timeScale = 1;
        canvas.enabled = false;
    }

    public static void EnableCanvas(Canvas canvas)
    {
        Time.timeScale = 0;
        canvas.enabled = true;
    }

    public void ChangeScene(string nameScene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(nameScene);
    }
    
    public static void AddCurrencyAndXp()
    {
        xpPointsTotal += xpReward;

        switch (colorMode)
        {
            case 1:
                totalBlueCurrency1 += rewardAmount;
                break;
            case 2:
                totalYellowCurrency2 += rewardAmount;
                break;
            case 3:
                totalPinkCurrency3 += rewardAmount;
                break;
            case 4:
                totalWhiteCurrency4 += rewardAmount;
                break;
            case 5:
                totalGreenCurrency5 += rewardAmount;
                break;
            case 6:
                totalOrangeCurrency6 += rewardAmount;
                break;
            case 7:
                totalPurpleCurrency7 += rewardAmount;
                break;
        }
    }
}
