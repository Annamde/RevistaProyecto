using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticFunctions : MonoBehaviour
{
    public void ChangeScene(string nameScene)
    {
        Time.timeScale = 1;
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
    
}
