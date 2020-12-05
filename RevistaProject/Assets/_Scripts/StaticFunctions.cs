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

    public void RetryLevel()
    {
        ChangeScene(SceneManager.GetActiveScene().name);

        GameManager.currentPoints = 0;
        GameManager.currentLife = GameManager.life;
    }

}
