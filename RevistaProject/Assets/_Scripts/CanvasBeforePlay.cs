using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBeforePlay : MonoBehaviour
{
    [SerializeField] private GeneratorScript _generator;
    [SerializeField] private Transform _instantiateZone;
    [SerializeField] private Text _numberBarrasText;

    private List<int> _modesWithOnlyBarra = new List<int> { 2, 3 };
    private List<GameObject> _onlyChakras = new List<GameObject>();
    private List<GameObject> _onlyBarras = new List<GameObject>();

    //ANNA DEL FUTURO
    /* FALTA PROBAR A VER SI FUNCIONA
     * FALTA HACER QUE SALGAN X NUMERO DE BARRAS CUANDO TMBN HAY LOGOS
     * MIRAR MUY BIEN COMO HACER EL MODO 4 QUE PUEDE DAR PROBLEMAS (SI NO CAMBIAR EL ORDEN)
     * PREGUNTAR SI SE PUEDE CAMBIAR EL ORDEN DE LAS BARRAS Y LOS LOGOS
     */

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
        int lenghtChakras = GameManager.Instance.totalPointsInGame / 10;

        if (_modesWithOnlyBarra.Contains(GameManager.colorMode))
        {
            _numberBarrasText.text = lenghtChakras.ToString();
        }
        else
        {
            if (lenghtChakras >= _onlyChakras.Count)
                lenghtChakras = _onlyChakras.Count;
          
            for (int i = 0; i < lenghtChakras; i++)
            {
                Instantiate(_onlyChakras[i], _instantiateZone);
            }
        }
        
    }

    private void DeleteBarrasFromList()
    {
        for (int i = 0; i < _generator.chakrasType1.Count; i++)
        {
            if (_generator.chakrasType1[i].name.Contains("logo"))
            {
                _onlyChakras.Add(_generator.chakrasType1[i]);
            }
        }
    }
    private void DeleteChakrasFromList()
    {
        for (int i = 0; i < _generator.chakrasType1.Count; i++)
        {
            if (_generator.chakrasType1[i].name.Contains("barra"))
            {
                _onlyBarras.Add(_generator.chakrasType1[i]);
            }
        }
    }
}
