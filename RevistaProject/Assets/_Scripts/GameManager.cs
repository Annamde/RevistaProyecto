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
        print(currentPoints + "   " + totalPointsInGame);
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

    //public void Mode1Values(int vidas, int valueChakra, int totalPoints)
    //{
    //    life = vidas;
    //    points4Chakra = valueChakra;
    //    totalPointsInGame = totalPoints;
    //}
    public void SetLife(int vidas)
    {
        life = vidas;
    }
    public void SetTotalPoints(int totalPoints)
    {
        totalPointsInGame = totalPoints;
    }
}
