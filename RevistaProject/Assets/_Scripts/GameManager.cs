using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }

    public static int life=3;

    static bool created = false;

    public Text lifeText;

    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(gameObject);
            created = true;
            Instance = this;
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetText(lifeText, life);
    }

    public void ResetLifes(int num)
    {
        life = num;
    }

    public void CheckLifes()
    {
        if (life > 0)
        {
            life--;
        }
        else
        {
            //canvas GO
        }
    }

    void SetText(Text temp, int num)
    {
        temp.text = num.ToString();
    }


}
