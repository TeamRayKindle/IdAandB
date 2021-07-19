using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LOADINGBAR : MonoBehaviour
{
    public GameObject Loading ;
    public Slider slider;
    public int sceneIndex;
   void Start()
    {
        //PlayerPrefs.GetInt("ToLoad");
         
        if (PlayerPrefs.GetInt("played", 0) != 1)
        {
            StartCoroutine(LoadAsynchronously(StaticString.IntroLevelName));
        }
        else
        {
            StartCoroutine(LoadAsynchronously(StaticString.LevelScreenlevelName));
        }
      
        
    }
    IEnumerator LoadAsynchronously(string sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;

            yield return null;

        }
       
    }
}
