using UnityEngine;

[System.Serializable]
public class ModeAndType 
{
    [SerializeField]
    private GameObject _unlockModeObject;

    [SerializeField]
    private Enums.RayosType _modeType;

    public GameObject UnlockModeObject => _unlockModeObject;

    public Enums.RayosType ModeType => _modeType;
}
