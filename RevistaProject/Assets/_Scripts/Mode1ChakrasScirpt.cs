using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode1ChakrasScirpt : MonoBehaviour
{
    public int speed = 3;
    public SpriteRenderer mySprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -1 * (Camera.main.transform.position.z));
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
}
