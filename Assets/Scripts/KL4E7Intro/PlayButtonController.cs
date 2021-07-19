using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonController : MonoBehaviour
{
    public IntroSceneController IntroSceneManager;
    // Start is called before the first frame update
    void Start()
    {
        //Ref: https://forum.unity.com/threads/onclick-on-button-from-code.264111/
        //gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { OnButtonClicked(); });
        gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnPlayButtonClicked());
    }



    public void OnPlayButtonClicked()
    {
        //Debug.Log("play button clicked ");
        IntroSceneManager.OnPlayButtonClicked();
    }
}
