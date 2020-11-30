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
    public Text lifeText;


    // Start is called before the first frame update
    void Awake()
    {
        canvasGO.enabled = false;
        canvasWIN.enabled = false;
        GameManager.Instance.canvasGO = canvasGO;
        GameManager.Instance.canvasWIN = canvasWIN;
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.SetText(lifeText, GameManager.life);
    }



}
