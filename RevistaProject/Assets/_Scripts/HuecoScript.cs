using UnityEngine;
using UnityEngine.UI;

public class HuecoScript : MonoBehaviour
{
    public float fullProgress = 0;
    public bool isLine = false;

    public bool isCompleted = false;
    public bool pointsAdded = false;

    public Image filler;
    public Image completedImage; //imagen con el chakra o la barra

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private Sprite _spriteCorrectType;
    
    void Start()
    {
        isCompleted = false;

        if (this.tag != "TypeWrong")
        {
            _spriteRenderer.sprite = _spriteCorrectType;
        }
    }
    
    void Update()
    {
        if (this.tag != "TypeWrong")
        {
            UpdateFiller();

            if (CheckCompleted())
            {
                if (!pointsAdded)
                {
                    if (isLine)
                    {
                        GameManager.linesCompleted++;
                    }

                    GameManager.Instance.CheckPoints();
                    pointsAdded = true;
                }
                isCompleted = true;
            }
        }
    }

    public void UpdateFiller()
    {
        filler.fillAmount = fullProgress / 3.0f;
    }

    public void AddProgress()
    {
        fullProgress++;
    }

    public bool CheckCompleted()
    {
        if (fullProgress >= 3)
        {
            return true;
        }
        else return false;
    }
}
