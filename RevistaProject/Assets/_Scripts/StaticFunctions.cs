using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticFunctions : MonoBehaviour
{
    public void ChangeScene(string nameScene)
    {
        Time.timeScale = 1;
        GameManager.currentPoints = 0;
        GameManager.addedCurrency = false;
        SceneManager.LoadScene(nameScene);
    }
    public void SetLife(int vidas)
    {
       GameManager.life = vidas;
    }
    public void SetTotalPoints(int totalPoints)
    {
       GameManager.Instance.totalPointsInGame = totalPoints;
    }
    public void SetMode(int mode)
    {
       GameManager.colorMode = mode;
    }
    public void SetRewardAmount(int reward)
    {
        GameManager.rewardAmount = reward;
    }
    public void SetXpRewardAmount(int xp)
    {
        GameManager.xpReward = xp;
    }
    public void ChakrasMode1Type1(int counterType1) //asigna los chakras para el modo 1 del tipo 1 
    {
        GameManager.charkrasMode1 = counterType1;
    }
    public void OtherChakrasMode1(int counterOther) //asigna los demas chakras para el modo 1 que no son del tipo 1 (el que se tiene que aprender el jugador)
    {
        GameManager.otherChakrasMode1 = counterOther;
    }

    public void CorrectTreeTime(float time) //asigna el valor del tiempo visible del arbol bueno
    {
        GameManager.treeCorrectTime = time;
    }
    public void TempTreeTime(float time) //asigna el valor del tiempo que tarda en cargarse la ayuda del arbol visible
    {
        GameManager.tempTree = time;
    }

    public void RetryLevel()
    {
        ChangeScene(SceneManager.GetActiveScene().name);

        GameManager.currentPoints = 0;
        GameManager.currentLife = GameManager.life;
    }

    public static int CalculateStars()
    {
        float percentage = ((float)GameManager.currentLife / (float)GameManager.life) * 100.0f;

        if (percentage <= 33.0f)
        {
            return 1;
        }
        else if (percentage <= 66.0f)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }

}
