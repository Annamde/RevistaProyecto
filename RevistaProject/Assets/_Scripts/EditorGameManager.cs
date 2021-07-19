using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class EditorGameManager : Editor
{
#if UNITY_EDITOR
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DrawDefaultInspector();

        GameManager myScript = (GameManager)target;
        if(GUILayout.Button("Reset Xp & Currency"))
        {
            myScript.ResetXpCurrency();
        }

    }
#endif

}
