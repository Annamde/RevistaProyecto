using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HuecoScript : MonoBehaviour
{
    public float fullProgress = 0;
    public bool isLine = false;

    public bool isCompleted = false;
    public bool pointsAdded = false;

    public Image filler;
    public Image completedImage; //imagen con el chakra o la barra
    
    void Start()
    {
        isCompleted = false;
    }
    
    void Update()
    {
        if (this.tag != "TypeWrong")
        {
            UpdateFiller();

            if (CheckCompleted())
            {
                if (!pointsAdded)
                {
                    GameManager.Instance.CheckPoints();
                    pointsAdded = true;
                }
                isCompleted = true;
            }
        }
    }

    public void UpdateFiller()
    {
        filler.fillAmount = fullProgress / 3.0f;
    }

    public void AddProgress()
    {
        fullProgress++;
    }

    public bool CheckCompleted()
    {
        if (fullProgress >= 3)
        {
            return true;
        }
        else return false;
    }
}
