using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenWithCode : MonoBehaviour
{
    [SerializeField]
    private Canvas _canvasCode;

    [SerializeField]
    private TMP_InputField _inputField;

    [SerializeField]
    private GameObject _warningText;

    private WWW w;

    public void Awake()
    {
        _warningText.SetActive(false);
    }

    public void CheckCode()
    {
        StartCoroutine(Check());
    }
    public void DecideIfOpenApp()
    {
        _warningText.SetActive(false);

        if (_inputField.text == "")
        {
            _warningText.SetActive(true);
            ForceCanvas();
        }
        else if (w.text.Contains(_inputField.text))
        {
            DisableCanvas();
        }
        else
        {
            _warningText.SetActive(true);
            ForceCanvas();
        }
        _inputField.text = "";
    }

    private IEnumerator Check()
    {
        w = new WWW("https://docs.google.com/document/d/10WH7W5YBWqR1MkjvXna_7LPnzYovMWH2gG7OvfYRa5M/edit?usp=sharing");
        yield return w;
        DecideIfOpenApp();
    }

    private void ForceCanvas()
    {
        _canvasCode.enabled = true;
    }

    private void DisableCanvas()
    {
        _canvasCode.enabled = false;
    }
}
