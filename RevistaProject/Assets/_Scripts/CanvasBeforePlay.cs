using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBeforePlay : MonoBehaviour
{
    [SerializeField] private Transform _instantiateZone;
    [SerializeField] private Transform _instantiateBarraZone;
    [SerializeField] private Text _numberBarrasText;
    [SerializeField] private List<GameObject> _chakrasListObjects;
    [SerializeField] private GameObject _barraObject;

    private List<int> _modesWithOnlyBarra = new List<int> { 2, 3 };
    private List<GameObject> _onlyChakras = new List<GameObject>();
    private List<GameObject> _onlyBarras = new List<GameObject>();

    private bool _needBarras = false;
   

    private void Start()
    {
        _onlyChakras.Clear();
        _onlyBarras.Clear();
        DeleteBarrasFromList();
        DeleteChakrasFromList();
        SetObjectives();
    }

    private void SetObjectives()
    {
        int levelcounter = GameManager.Instance.totalPointsInGame / 10;
        int lenghtBarras = 0;

        if (_modesWithOnlyBarra.Contains(GameManager.colorMode))
        {
            SetBarrasText(levelcounter);
        }
        else
        {
            if (levelcounter > _onlyChakras.Count)
            {
                lenghtBarras = levelcounter - _onlyChakras.Count;
                levelcounter = _onlyChakras.Count;
                _needBarras = true;
            }
          
            for (int i = 0; i < levelcounter; i++)
            {
                Instantiate(_chakrasListObjects[i], _instantiateZone);
            }
            if (_needBarras)
            {
                SetBarrasText(lenghtBarras);
            }
        }
        InstantiateBarraObject();
    }

    private void SetBarrasText(int barrasNumber)
    {
        _numberBarrasText.text = barrasNumber.ToString();
    }
    private void InstantiateBarraObject()
    {
        Instantiate(_barraObject, _instantiateBarraZone);
    }

    private void DeleteBarrasFromList()
    {
        for (int i = 0; i < _chakrasListObjects.Count; i++)
        {
            if (_chakrasListObjects[i].name.Contains("logo"))
            {
                _onlyChakras.Add(_chakrasListObjects[i]);
            }
        }
    }
    private void DeleteChakrasFromList()
    {
        for (int i = 0; i < _chakrasListObjects.Count; i++)
        {
            if (_chakrasListObjects[i].name.Contains("barra"))
            {
                _onlyBarras.Add(_chakrasListObjects[i]);
            }
        }
    }
}
