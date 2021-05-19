using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject endLevelGo;
    public GameObject loseLevelGo;

    void Awake()
    {
        instance = this;
    }

    public void LoadLevel(int lvlInt)
    {
        SceneManager.LoadScene(lvlInt);
    }

    public void EndLevel()
    {
        endLevelGo.SetActive(true);
    }

    public void LoseLevel()
    {
        loseLevelGo.SetActive(true);
    }
}
