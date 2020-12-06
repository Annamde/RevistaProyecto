using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    [Header("Type 1")]
    public List<GameObject> chakrasType1;
    public float initialTime = 0, intervaltime = 3;

    [Header("Other Chakras")]
    public List<GameObject> otherChakras;
    public float initialTimeO = 1, intervaltimeO = 3;

    [Header("Positions")]
    public List<GameObject> positions;
   

    private int temp, tempPos, tempOther, tempPosOther;
    private GameObject tempGO, goOther;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Generator", initialTime,intervaltime);
        InvokeRepeating("GeneratorOthers", initialTimeO,intervaltimeO);
    }

    void Generator()
    {
        temp = Random.Range(0, GameManager.charkrasMode1);
        tempPos = Random.Range(0, positions.Count);
        
       
        tempGO = Instantiate(chakrasType1[temp]);
        tempGO.transform.position = positions[tempPos].gameObject.transform.position;
    }

    void GeneratorOthers()
    {
        tempOther = Random.Range(0, GameManager.otherChakrasMode1);
        tempPosOther = Random.Range(0, positions.Count);

        goOther = Instantiate(otherChakras[tempOther]);
        goOther.transform.position = positions[tempPosOther].gameObject.transform.position;
    }


}
