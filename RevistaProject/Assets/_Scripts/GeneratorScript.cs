using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    public List<GameObject> chakrasType1;
    public float initialTime=1, intervaltime=3;

    private int temp;
    private GameObject tempGO;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Generator", initialTime,intervaltime);
    }

    void Generator()
    {
        temp = Random.Range(1, chakrasType1.Count);
       
        tempGO = Instantiate(chakrasType1[temp]);
        tempGO.transform.position = this.gameObject.transform.position; //cambiar
    }


}
