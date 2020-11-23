using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    public List<GameObject> chakrasType1;
    public List<GameObject> positions;
    public float initialTime=1, intervaltime=3;

    private int temp, tempPos;
    private GameObject tempGO;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Generator", initialTime,intervaltime);
    }

    void Generator()
    {
        temp = Random.Range(0, chakrasType1.Count);
        tempPos = Random.Range(0, positions.Count);
       
        tempGO = Instantiate(chakrasType1[temp]);
        tempGO.transform.position = positions[tempPos].gameObject.transform.position;
    }


}
