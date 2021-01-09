using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeButtonScript : MonoBehaviour
{
    float counter = 0;
    float helpCounter = 0;
    public Image myPanel;
    public Image myTree;
    public Image temporizador;
    public Image tempTree;
    public Button treeButton;
    // Start is called before the first frame update
    void Start()
    {
        myTree.enabled = false;
        myPanel.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(myTree.isActiveAndEnabled)
        {
            counter += Time.deltaTime;
           //temporizador.fillAmount = (counter * 100 / GameManager.treeCorrectTime) / 100;
            temporizador.fillAmount = (counter/GameManager.treeCorrectTime);
        }
        else if(tempTree.fillAmount < 1)
        {
            helpCounter += Time.deltaTime;
            tempTree.fillAmount = (helpCounter * 100 / GameManager.tempTree) / 100;
            treeButton.enabled = false;
        }
        else
        {
            treeButton.enabled = true;
        }
        if (counter>= GameManager.treeCorrectTime)
        {
            myTree.enabled = false;
            myPanel.enabled = false;
            temporizador.enabled = false;
            temporizador.fillAmount = 1;
            tempTree.fillAmount = 0;
            helpCounter = 0;
            counter = 0;
        }
    }

    public void ResetTemporizador()
    {
        myTree.enabled = false;
        myPanel.enabled = false;
        temporizador.enabled = false;
        temporizador.fillAmount = 1;
        tempTree.fillAmount = 0;
        helpCounter = 0;
        counter = 0;
    }
}
