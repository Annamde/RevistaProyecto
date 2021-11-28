using UnityEngine;
using UnityEngine.UI;

public class ButtonChakraTreeController : MonoBehaviour
{
    [SerializeField] private Image _imageContainer;
    [SerializeField] private Sprite _chakraInfoImage;

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
