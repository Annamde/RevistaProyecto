using UnityEngine;
using UnityEngine.UI;

public class GoalsInGame : MonoBehaviour
{
    [SerializeField] private CanvasBeforePlay _objectivesController;
    [SerializeField] private Transform _barrasInstantiateZone;
    [SerializeField] private Transform _chakrasInstantiateZone;
    [SerializeField] private Text _numberBarrasText;
    
    private int _currentNumberBarras;

    //ponerlo bonito en la escena
    //hacer que al completar alguno se elimine
    private void Start()
    {
        GameManager.Instance.EventController.CompleteBarraEvent.AddListener(SubtractABarra);
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
                Instantiate(_objectivesController.ChakrasListObject[i], _chakrasInstantiateZone);
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
}  
