using UnityEngine;
using UnityEngine.UI;

public class ButtonChakraTreeController : MonoBehaviour
{
    [SerializeField] private Image _imageContainer;
    [SerializeField] private Sprite _chakraInfoImage;

    public Image chakraSprite;
    public Button chakraButton;

    public int xpNeeded = 0;
    public int starColorNeeded = 1;

    void Update()
    {
        UnlockTreeButtons();
    }

    public void UnlockTreeButtons()
    {
        switch (starColorNeeded)
        {
            case 1:
                if (GameManager.totalXpBlue1 >= xpNeeded)
                {
                    chakraSprite.gameObject.SetActive(true);
                    chakraButton.gameObject.SetActive(true);
                }
                else
                {
                    chakraSprite.gameObject.SetActive(false);
                    chakraButton.gameObject.SetActive(false);
                }
                break;
            case 2:
                if (GameManager.totalXpYellow2 >= xpNeeded)
                {
                    chakraSprite.gameObject.SetActive(true);
                    chakraButton.gameObject.SetActive(true);
                }
                else
                {
                    chakraSprite.gameObject.SetActive(false);
                    chakraButton.gameObject.SetActive(false);
                }
                break;
            case 3:
                if (GameManager.totalXpPink3 >= xpNeeded)
                {
                    chakraSprite.gameObject.SetActive(true);
                    chakraButton.gameObject.SetActive(true);
                }
                else
                {
                    chakraSprite.gameObject.SetActive(false);
                    chakraButton.gameObject.SetActive(false);
                }
                break;
            case 4:
                if (GameManager.totalXpWhite4 >= xpNeeded)
                {
                    chakraSprite.gameObject.SetActive(true);
                    chakraButton.gameObject.SetActive(true);
                }
                else
                {
                    chakraSprite.gameObject.SetActive(false);
                    chakraButton.gameObject.SetActive(false);
                }
                break;
            case 5:
                if (GameManager.totalXpGreen5 >= xpNeeded)
                {
                    chakraSprite.gameObject.SetActive(true);
                    chakraButton.gameObject.SetActive(true);
                }
                else
                {
                    chakraSprite.gameObject.SetActive(false);
                    chakraButton.gameObject.SetActive(false);
                }
                break;
            case 6:
                if (GameManager.totalXpOrange6 >= xpNeeded)
                {
                    chakraSprite.gameObject.SetActive(true);
                    chakraButton.gameObject.SetActive(true);
                }
                else
                {
                    chakraSprite.gameObject.SetActive(false);
                    chakraButton.gameObject.SetActive(false);
                }
                break;
            case 7:
                if (GameManager.totalXpPurple7 >= xpNeeded)
                {
                    chakraSprite.gameObject.SetActive(true);
                    chakraButton.gameObject.SetActive(true);
                }
                else
                {
                    chakraSprite.gameObject.SetActive(false);
                    chakraButton.gameObject.SetActive(false);
                }
                break;
        }
    }

    public void SetUpInfoChakra()
    {
        _imageContainer.sprite = _chakraInfoImage;
        _imageContainer.gameObject.SetActive(true);
    }

    public void CloseInfoChakra()
    {
        _imageContainer.gameObject.SetActive(false);
    }
}
