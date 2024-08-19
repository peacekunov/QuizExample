using UnityEditor;
using UnityEngine;

public class CustomMenuItems
{
    [MenuItem("QUIZ/Clear PlayerPrefs")]
    static void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs cleared");
    }
}
