using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuInput : MonoBehaviour
{
    public void StartButton()
    {
        SaveData.Instance.playerNameText = SaveData.Instance.playerNameInput.text;
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
