using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mode1ChakrasScirpt : MonoBehaviour
{
    public SpriteRenderer mySprite;

    private bool correctCheck = false;
    private bool wrongCheck = false;

    public int totalPoints; //puntos necesarios por nivel

    public List<GameObject> closeHoleList = new List<GameObject>();
    public float chacDistance;

    public GameObject correctTempHole;
    public GameObject closeTempHole;

    public Camera cam;

    Rigidbody2D myRb;
    public float speed = 1.5f;

    bool canMove = true;

    bool dragPlayed = false;
    bool chacSoundDone = false;

    // Start is called before the first frame update
    void Start()
    {
        chacDistance = 60.0f;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();

        myRb = GetComponent<Rigidbody2D>();

        speed = GameManager.chakraSpeed;

        dragPlayed = false;
        chacSoundDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (closeTempHole != null)
        {
            //print(Input.mousePosition + "   " + cam.WorldToScreenPoint(closeTempHole.transform.position));
            if (Vector3.Distance(cam.WorldToScreenPoint(closeTempHole.transform.position), Input.mousePosition) > chacDistance)
            {
                closeTempHole = null;
            }
        }

        if (FindClosest() != null)
        {
            if ((Vector3.Distance(cam.WorldToScreenPoint(FindClosest().transform.position), Input.mousePosition) <= chacDistance))
            {
                if (!chacSoundDone)
                {
                    GameManager.audio.Stop(); //
                    GameManager.audio.clip = GameManager.a4chac;
                    GameManager.audio.Play();

                    chacSoundDone = true;
                }

                closeTempHole = FindClosest();
            }
        }

        if (canMove)
        {
            Movement();
        }
    }

    public void Movement()
    {
        Vector2 movement = new Vector2(0,-1);
        movement *= speed * Time.deltaTime;

        this.transform.Translate(movement);
    }

    private GameObject FindClosest()
    {
        GameObject closest = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = Input.mousePosition;

        foreach(GameObject potentialClosest in closeHoleList)
        {
            Vector3 directionToTarget = cam.WorldToScreenPoint(potentialClosest.transform.position) - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                closest = potentialClosest;
            }
        }

        return closest;
    }

    void OnMouseDrag()
    {
        canMove = false;

        if (!dragPlayed)
        {
            GameManager.audio.Stop(); //
            GameManager.audio.clip = GameManager.a3grab;
            GameManager.audio.Play();
            dragPlayed = true;
        }

        if (closeTempHole != null)
        {
            transform.position = closeTempHole.transform.position;
        }
        else {
            chacSoundDone = false;

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -1 * (Camera.main.transform.position.z));
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Type"))
        {
            closeHoleList.Add(collision.gameObject);
        }
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

        // print(Vector3.Distance(cam.WorldToScreenPoint(collision.gameObject.transform.position), Input.mousePosition));
        //if (collision.gameObject.tag.Contains("Type") && (Vector3.Distance(cam.WorldToScreenPoint(collision.gameObject.transform.position), Input.mousePosition) <= chacDistance))
        //{
        //    closeTempHole = collision.gameObject;
        //}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Type") && closeHoleList.Contains(collision.gameObject))
        {
            closeHoleList.Remove(collision.gameObject);
        }

        if (collision.gameObject.tag == this.tag) 
        {
            correctCheck = false;
            correctTempHole = null;
        }
        else if (collision.gameObject.tag != this.tag)
        {
            wrongCheck = false;
        }

        //if (collision.gameObject.tag.Contains("Type"))
        //{
        //    closeTempHole = null;
        //}
    }
    private void OnMouseUp()
    {
        canMove = true;

        dragPlayed = false;

        if (correctCheck) //si esta colisionando con una correcta y una incorrecta a la vez, se le da prioridad a la correcta (creo)
        {
            if (!correctTempHole.GetComponent<HuecoScript>().isCompleted)
            {
                //GameManager.Instance.CheckPoints();
                correctTempHole.GetComponent<HuecoScript>().AddProgress();

                if (correctTempHole.GetComponent<HuecoScript>().fullProgress >= 3)
                {
                    //print("COMPLETE");
                    GameManager.audio.Stop();
                    GameManager.audio.clip = GameManager.a6complete;
                    GameManager.audio.Play();
                }
                else
                {
                    //print("NOP");
                    GameManager.audio.Stop();
                    GameManager.audio.clip = GameManager.a5correct;
                    GameManager.audio.Play();
                }

                Destroy(this.gameObject);
            }
            else
            {
                GameManager.audio.Stop(); //
                GameManager.audio.clip = GameManager.a3_2release;
                GameManager.audio.Play();
            }
        }
        else if (wrongCheck)
        {
            GameManager.Instance.CheckLifes();

            GameManager.audio.Stop();
            GameManager.audio.clip = GameManager.a7wrong;
            GameManager.audio.Play();

            Destroy(this.gameObject);
        }
        else
        {
            GameManager.audio.Stop(); //
            GameManager.audio.clip = GameManager.a3_2release;
            GameManager.audio.Play();
        }
    }
}
