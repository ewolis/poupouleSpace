using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] private string levelName;
    [SerializeField] private bool replaceCurrentScene = true;

    public void LoadScene()
    {
        SceneManager.LoadScene(levelName, replaceCurrentScene ? LoadSceneMode.Single : LoadSceneMode.Additive);
    }
}
