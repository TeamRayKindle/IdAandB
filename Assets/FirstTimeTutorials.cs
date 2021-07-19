using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstTimeTutorials : MonoBehaviour
{
    [Header("Level Base Selection")]
    public GameObject LevelTutorialPointer;

    [Header("Level Game")]
    public GameObject Pointer1;
    public GameObject Pointer2;
    public GameObject Pointer3;
    public GameObject Pointer4;
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void EndTutorials()
    {
        PlayerPrefs.SetInt("played", 1);
        PlayerPrefs.Save();
    }
    public void SetActiveObjects(GameObject c, bool b)
    {
        c.SetActive(b);
    }

    public void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("played", 0) == 1)
        {
            Destroy(gameObject);
        }
    }
}
