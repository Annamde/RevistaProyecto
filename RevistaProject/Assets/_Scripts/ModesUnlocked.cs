using System.Collections.Generic;
using UnityEngine;

public class ModesUnlocked : MonoBehaviour
{
    [SerializeField]
    private List<ModeAndType> _modes;

    private void Start()
    {
        UnlockModes();
    }

    public void UnlockModes() 
    {
        for (int i = 0; i < _modes.Count; i++)
        {
            if (PlayerPrefs.GetInt(_modes[i].ModeType.ToString()) == 1)
            {
                _modes[i].UnlockModeObject.SetActive(false);
            }
        }
    }
}
