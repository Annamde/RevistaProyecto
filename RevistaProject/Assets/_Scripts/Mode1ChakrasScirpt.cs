using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode1ChakrasScirpt : MonoBehaviour
{
    public int speed = 3;
    public SpriteRenderer mySprite;

    private bool correctCheck = false;
    private bool wrongCheck = false;

    public int totalPoints; //puntos necesarios por nivel

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == this.tag)
        {
            correctCheck = true;
        }
        else if (collision.gameObject.tag == "End")
        {
            Destroy(this.gameObject);
        }
        else
        {
            wrongCheck = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == this.tag) 
        {
            correctCheck = false;
        }
        else if (collision.gameObject.tag != this.tag)
        {
            wrongCheck = false;
        }
    }
    private void OnMouseUp()
    {
        if (correctCheck) //si esta colisionando con una correcta y una incorrecta a la vez, se le da prioridad a la correcta (creo)
        {
            GameManager.Instance.CheckPoints();
            Destroy(this.gameObject);
        }
        else if (wrongCheck)
        {
            GameManager.Instance.CheckLifes();
            Destroy(this.gameObject);
        }
    }
}
