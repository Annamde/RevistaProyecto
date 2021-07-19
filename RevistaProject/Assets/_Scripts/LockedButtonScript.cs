using UnityEngine;
using UnityEngine.UI;

public class LockedButtonScript : MonoBehaviour
{
    public int xpNeeded = 0;
    public Text buttonText;
    public int starColorNeeded = 1;

    // Update is called once per frame
    void Update()
    {
        UpdateUnlocks();
        UpdateRemainingStars();
    }

    public void UpdateUnlocks()
    {
        switch (starColorNeeded)
        {
            case 1:
                if(GameManager.totalXpBlue1 >= xpNeeded)
                {
                    this.gameObject.SetActive(false);
                }
                break;
            case 2:
                if (GameManager.totalXpYellow2 >= xpNeeded)
                {
                    this.gameObject.SetActive(false);
                }
                break;
            case 3:
                if (GameManager.totalXpPink3 >= xpNeeded)
                {
                    this.gameObject.SetActive(false);
                }
                break;
            case 4:
                if (GameManager.totalXpWhite4 >= xpNeeded)
                {
                    this.gameObject.SetActive(false);
                }
                break;
            case 5:
                if (GameManager.totalXpGreen5 >= xpNeeded)
                {
                    this.gameObject.SetActive(false);
                }
                break;
            case 6:
                if (GameManager.totalXpOrange6 >= xpNeeded)
                {
                    this.gameObject.SetActive(false);
                }
                break;
            case 7:
                if (GameManager.totalXpPurple7 >= xpNeeded)
                {
                    this.gameObject.SetActive(false);
                }
                break;
        }
    }
    public void UpdateRemainingStars()
    {
        switch (starColorNeeded)
        {
            case 1:
                GameManager.SetText(buttonText, xpNeeded - GameManager.totalXpBlue1);
                break;
            case 2:
                buttonText.text = (xpNeeded - GameManager.totalXpYellow2).ToString();
                break;
            case 3:
                buttonText.text = (xpNeeded - GameManager.totalXpPink3).ToString();
                break;
            case 4:
                buttonText.text = (xpNeeded - GameManager.totalXpWhite4).ToString();
                break;
            case 5:
                buttonText.text = (xpNeeded - GameManager.totalXpGreen5).ToString();
                break;
            case 6:
                buttonText.text = (xpNeeded - GameManager.totalXpOrange6).ToString();
                break;
            case 7:
                buttonText.text = (xpNeeded - GameManager.totalXpPurple7).ToString();
                break;
        }
    }
}
