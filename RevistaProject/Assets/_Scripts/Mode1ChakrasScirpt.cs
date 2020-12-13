using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mode1ChakrasScirpt : MonoBehaviour
{
    public int speed = 3;
    public SpriteRenderer mySprite;

    private bool correctCheck = false;
    private bool wrongCheck = false;

    public int totalPoints; //puntos necesarios por nivel

    public GameObject correctTempHole;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print("CORRECT: " + correctCheck + "    WRONG: " + wrongCheck);
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -1 * (Camera.main.transform.position.z));
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == this.tag)
        {
            correctCheck = true;
            correctTempHole = collision.gameObject;
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
            correctTempHole = null;
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
            if (!correctTempHole.GetComponent<HuecoScript>().isCompleted)
            {
                GameManager.Instance.CheckPoints();
                correctTempHole.GetComponent<HuecoScript>().AddProgress();
                Destroy(this.gameObject);
            }
        }
        else if (wrongCheck)
        {
            GameManager.Instance.CheckLifes();
            Destroy(this.gameObject);
        }
    }
}
