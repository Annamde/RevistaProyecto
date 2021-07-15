using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }

    public static int life=3; //la vida por nivel
    public static int currentLife=3; //la vida que se va restando cada nivel
    public static int currentPoints = 0; //los puntos del jugador en la partida como tal
    static bool created = false;
    

    public int points4Chakra = 10; //los puntos por chackra correcto 
    public int totalPointsInGame = 100; //los puntos necesarios para pasarse el nivel
    public static int colorMode = 1; //el tipo de modo
    public static int rewardAmount = 10; //la currency que se le da
    public static int xpReward = 3; //la experiencia/estrellitas
    public static int charkrasMode1 = 1; //los chakras del tipo1 para el modo1
    public static int otherChakrasMode1 = 2; //chakras de otro tipo para el modo 1
    public static float treeCorrectTime = 5; //el tiempo para ver el arbol correcto
    public static float tempTree = 15; //el tiempo que tarda en cargarse de nuevo el arbol
    public static float chakraSpeed = 1; //la velocidad a la que cae el chakra

    public static int totalBlueCurrency1 = 0;
    public static int totalYellowCurrency2 = 0;
    public static int totalPinkCurrency3 = 0;
    public static int totalWhiteCurrency4 = 0;
    public static int totalGreenCurrency5 = 0;
    public static int totalOrangeCurrency6 = 0;
    public static int totalPurpleCurrency7 = 0;

    public static int totalXpBlue1 = 0;
    public static int totalXpYellow2 = 0;
    public static int totalXpPink3 = 0;
    public static int totalXpWhite4 = 0;
    public static int totalXpGreen5 = 0;
    public static int totalXpOrange6 = 0;
    public static int totalXpPurple7 = 0;

    public static int xpPointsTotal = 0;

    public static bool addedCurrency = false;

    public bool IsFirtsOpen = true;



    public static AudioSource audio;
    public AudioSource aGeneral;
    public static AudioSource audioChac;
    public AudioSource aChac;
    public static AudioSource audioGrab;
    public AudioSource aGrab;
    public static AudioSource audioCanvas;
    public AudioSource aCanvas;

    public static AudioClip a1button;
    public AudioClip a1;
    public static AudioClip a2lockedButton;
    public AudioClip a2;
    public static AudioClip a3grab;
    public AudioClip a3;
    public static AudioClip a3_2release;
    public AudioClip a3_2;
    public static AudioClip a4chac;
    public AudioClip a4;
    public static AudioClip a5correct;
    public AudioClip a5;
    public static AudioClip a6complete;
    public AudioClip a6;
    public static AudioClip a7wrong;
    public AudioClip a7;
    public static AudioClip a8win;
    public AudioClip a8;
    public static AudioClip a9gameover;
    public AudioClip a9;

    public static AudioSource audioOst;
    public AudioSource aOst;


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

        SetXPandCurrency();

        a1button = a1;
        a2lockedButton = a2;
        a3grab = a3;
        a3_2release = a3_2;
        a4chac = a4;
        a5correct = a5;
        a6complete = a6;
        a7wrong = a7;
        a8win = a8;
        a9gameover = a9;
    }

    // Start is called before the first frame update
    void Start()
    {
        //audioGeneral = GetComponent<AudioSource>();
        audio = aGeneral;
        audioChac = aChac;
        audioGrab = aGrab;
        audioCanvas = aCanvas;

        audioOst = aOst;
    }

    // Update is called once per frame
    void Update()
    {
        audioOst = aOst;
    }

    public void ResetLifes(int num)
    {
        life = num;
    }

    public void CheckLifes()
    {
        if (currentLife > 0)
        {
            currentLife--;
        }
    }

    public void CheckPoints()
    {
        if(currentPoints < totalPointsInGame)
        {
            currentPoints += points4Chakra;
        }

    }

    public static void SetText(Text temp, int num)
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
        switch (colorMode)
        {
            case 1:
                totalBlueCurrency1 += rewardAmount;
                totalXpBlue1 += (int)StaticFunctions.CalculateStars();
                PlayerPrefs.SetInt("totalBlueCurrency1", totalBlueCurrency1);
                PlayerPrefs.SetInt("totalXpBlue1", totalXpBlue1);
                break;
            case 2:
                totalYellowCurrency2 += rewardAmount;
                totalXpYellow2 += (int)StaticFunctions.CalculateStars();
                PlayerPrefs.SetInt("totalYellowCurrency2", totalYellowCurrency2);
                PlayerPrefs.SetInt("totalXpYellow2", totalXpYellow2);
                break;
            case 3:
                totalPinkCurrency3 += rewardAmount;
                totalXpPink3 += (int)StaticFunctions.CalculateStars();
                PlayerPrefs.SetInt("totalPinkCurrency3", totalPinkCurrency3);
                PlayerPrefs.SetInt("totalXpPink3", totalXpPink3);
                break;
            case 4:
                totalWhiteCurrency4 += rewardAmount;
                totalXpWhite4 += (int)StaticFunctions.CalculateStars();
                PlayerPrefs.SetInt("totalWhiteCurrency4", totalWhiteCurrency4);
                PlayerPrefs.SetInt("totalXpWhite4", totalXpWhite4);
                break;
            case 5:
                totalGreenCurrency5 += rewardAmount;
                totalXpGreen5 += (int)StaticFunctions.CalculateStars();
                PlayerPrefs.SetInt("totalGreenCurrency5", totalGreenCurrency5);
                PlayerPrefs.SetInt("totalXpGreen5", totalXpGreen5);
                break;
            case 6:
                totalOrangeCurrency6 += rewardAmount;
                totalXpOrange6 += (int)StaticFunctions.CalculateStars();
                PlayerPrefs.SetInt("totalOrangeCurrency6", totalOrangeCurrency6);
                PlayerPrefs.SetInt("totalXpOrange6", totalXpOrange6);
                break;
            case 7:
                totalPurpleCurrency7 += rewardAmount;
                totalXpPurple7 += (int)StaticFunctions.CalculateStars();
                PlayerPrefs.SetInt("totalPurpleCurrency7", totalPurpleCurrency7);
                PlayerPrefs.SetInt("totalXpPurple7", totalXpPurple7);
                break;
        }
    }

    public static void UpdateCurrency(Enums.RayosType type, int currencyGastada)
    {
        switch (type)
        {
            case Enums.RayosType.Blue:
                totalBlueCurrency1 -= currencyGastada;
                PlayerPrefs.SetInt("totalBlueCurrency1", totalBlueCurrency1);
                PlayerPrefs.SetInt("totalXpBlue1", totalXpBlue1);
                break;
            case Enums.RayosType.Yellow:
                totalYellowCurrency2 -= currencyGastada;
                PlayerPrefs.SetInt("totalYellowCurrency2", totalYellowCurrency2);
                PlayerPrefs.SetInt("totalXpYellow2", totalXpYellow2);
                break;
            case Enums.RayosType.Pink:
                totalPinkCurrency3 -= currencyGastada;
                PlayerPrefs.SetInt("totalPinkCurrency3", totalPinkCurrency3);
                PlayerPrefs.SetInt("totalXpPink3", totalXpPink3);
                break;
            case Enums.RayosType.White:
                totalWhiteCurrency4 -= currencyGastada;
                PlayerPrefs.SetInt("totalWhiteCurrency4", totalWhiteCurrency4);
                PlayerPrefs.SetInt("totalXpWhite4", totalXpWhite4);
                break;
            case Enums.RayosType.Green:
                totalGreenCurrency5 -= currencyGastada;
                PlayerPrefs.SetInt("totalGreenCurrency5", totalGreenCurrency5);
                PlayerPrefs.SetInt("totalXpGreen5", totalXpGreen5);
                break;
            case Enums.RayosType.Orange:
                totalOrangeCurrency6 -= currencyGastada;
                PlayerPrefs.SetInt("totalOrangeCurrency6", totalOrangeCurrency6);
                PlayerPrefs.SetInt("totalXpOrange6", totalXpOrange6);
                break;
            case Enums.RayosType.Purple:
                totalPurpleCurrency7 -= currencyGastada;
                PlayerPrefs.SetInt("totalPurpleCurrency7", totalPurpleCurrency7);
                PlayerPrefs.SetInt("totalXpPurple7", totalXpPurple7);
                break;
        }
    }

    public void SetXPandCurrency()
    {
        totalBlueCurrency1 = PlayerPrefs.GetInt("totalBlueCurrency1");
        totalXpBlue1 = PlayerPrefs.GetInt("totalXpBlue1");

        totalYellowCurrency2 = PlayerPrefs.GetInt("totalYellowCurrency2");
        totalXpYellow2 = PlayerPrefs.GetInt("totalXpYellow2");

        totalPinkCurrency3 = PlayerPrefs.GetInt("totalPinkCurrency3");
        totalXpPink3 = PlayerPrefs.GetInt("totalXpPink3");

        totalWhiteCurrency4 = PlayerPrefs.GetInt("totalWhiteCurrency4");
        totalXpWhite4 = PlayerPrefs.GetInt("totalXpWhite4");

        totalGreenCurrency5 = PlayerPrefs.GetInt("totalGreenCurrency5");
        totalXpGreen5 = PlayerPrefs.GetInt("totalXpGreen5");

        totalOrangeCurrency6 = PlayerPrefs.GetInt("totalOrangeCurrency6");
        totalXpOrange6 = PlayerPrefs.GetInt("totalXpOrange6");

        totalPurpleCurrency7 = PlayerPrefs.GetInt("totalPurpleCurrency7");
        totalXpPurple7 = PlayerPrefs.GetInt("totalXpPurple7");
    }
    
    public void ResetXpCurrency()
    {
        SetValuePlayerPrefs("totalBlueCurrency1", 0);
        SetValuePlayerPrefs("totalXpBlue1", 0);
        SetValuePlayerPrefs("totalYellowCurrency2", 0);
        SetValuePlayerPrefs("totalXpYellow2", 0);
        SetValuePlayerPrefs("totalPinkCurrency3", 0);
        SetValuePlayerPrefs("totalXpPink3", 0);
        SetValuePlayerPrefs("totalWhiteCurrency4", 0);
        SetValuePlayerPrefs("totalXpWhite4", 0);
        SetValuePlayerPrefs("totalGreenCurrency5", 0);
        SetValuePlayerPrefs("totalXpGreen5", 0);
        SetValuePlayerPrefs("totalOrangeCurrency6", 0);
        SetValuePlayerPrefs("totalXpOrange6", 0);
        SetValuePlayerPrefs("totalPurpleCurrency7", 0);
        SetValuePlayerPrefs("totalXpPurple7", 0);

    }

    public void SetValuePlayerPrefs(string name, int num)
    {
        PlayerPrefs.SetInt(name, num);
    }
}
