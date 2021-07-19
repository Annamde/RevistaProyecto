using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(GameManager))]
public class EditorGameManager : Editor
{
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
}
#endif
