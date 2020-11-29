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

    public Text lifeText;

    public int points4ChakraMode1 = 10; //los puntos por chackra correcto en el modo 1 (supongo que seran los mismos en los demás, pero por ahora vamo asi)
    public Canvas canvasWIN, canvasGO;

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
        if (SceneManager.GetActiveScene().name != "MenuScene")
        {
            canvasGO.enabled = false;
            canvasWIN.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "MenuScene")
        {
            SetText(lifeText, life);
        }
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
        else
        {
            canvasGO.enabled = true;
        }
    }

    public void CheckPoints(int totalPoints)
    {
        if(currentPoints < totalPoints)
        {
            currentPoints += points4ChakraMode1;
        }
        else
        {
            canvasWIN.enabled = true;
        }

    }

    void SetText(Text temp, int num)
    {
        temp.text = num.ToString();
    }

    public static void DisableCanvas(Canvas canvas)
    {
        canvas.enabled = false;
    }

    public static void EnableCanvas(Canvas canvas)
    {
        canvas.enabled = true;
    }

    public void ChangeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
