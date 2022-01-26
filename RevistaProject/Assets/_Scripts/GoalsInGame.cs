using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalsInGame : MonoBehaviour
{
    [SerializeField] private CanvasBeforePlay _objectivesController;
    [SerializeField] private Transform _barrasInstantiateZone;
    [SerializeField] private Transform _chakrasInstantiateZone;
    [SerializeField] private Text _numberBarrasText;
    
    private int _currentNumberBarras;
    private List<GameObject> _chakrasInScene = new List<GameObject>();
    

    private void Start()
    {
        GameManager.Instance.EventController.CompleteBarraEvent.AddListener(SubtractABarra);
        GameManager.Instance.EventController.OnCompleteCharkaEvent.AddListener(DisableCorrectChakra);
    }

    public void SetObjectives()
    {
        int levelcounter = GameManager.Instance.totalPointsInGame / 10;
        int lenghtBarras = 0;
        bool needBarras = false;

        if (_objectivesController.ModesWithOnlyBarra.Contains(GameManager.colorMode))
        {
            SetBarrasText(levelcounter);
        }
        else
        {
            if (levelcounter > _objectivesController.OnlyChakras.Count)
            {
                lenghtBarras = levelcounter - _objectivesController.OnlyChakras.Count;
                levelcounter = _objectivesController.OnlyChakras.Count;
                needBarras = true;
            }

            for (int i = 0; i < levelcounter; i++)
            {
                _chakrasInScene.Add(Instantiate(_objectivesController.ChakrasListObject[i], _chakrasInstantiateZone));
            }
            if (needBarras)
            {
                SetBarrasNumber(lenghtBarras);
            }
        }
        Instantiate(_objectivesController.BarrasObject, _barrasInstantiateZone);
    }

    private void SetBarrasNumber(int barrasNumber)
    {
        _currentNumberBarras = barrasNumber;
        SetBarrasText(_currentNumberBarras);
    }

    private void SubtractABarra()
    {
        _currentNumberBarras--;
        SetBarrasText(_currentNumberBarras);
    }

    private void SetBarrasText(int number)
    {
        _numberBarrasText.text = number.ToString();
    }

    private void DisableCorrectChakra(GameObject chakra)
    {
        for (int i = 0; i < _chakrasInScene.Count; i++)
        {
            if (_chakrasInScene[i].tag == chakra.tag)
                Destroy(_chakrasInScene[i].gameObject);
        }
    }
}  
