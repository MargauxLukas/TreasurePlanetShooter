using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject endLevelGo;
    public GameObject loseLevelGo;
    public Image ulti;

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

    public void UltiUp()
    {
        ulti.gameObject.SetActive(true);
    }

    public void ResetUlti()
    {
        ulti.gameObject.SetActive(false);
    }
}
