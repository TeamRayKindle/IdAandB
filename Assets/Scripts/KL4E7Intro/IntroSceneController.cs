using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneController : MonoBehaviour
{
   
    public GameObject Actors;
    public GameObject PlayButton;
    public GameObject IntroDrone;
    public AudioClip[] Narrations;
    private AudioSource audioSource;

    void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator PlayIntroScene()
    {
        audioSource.clip = Narrations[0]; //"Hello ..."
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length + 1f);
        IntroDrone.SetActive(true);
        audioSource.clip = Narrations[1]; //"Look the super drone..."
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length + 0.5f);
        SceneManager.LoadScene("Main");
    }

    public void OnPlayButtonClicked()
    {
        //Debug.Log("Processing Playbutton clicked");
        PlayButton.SetActive(false);
        Actors.SetActive(true);
        IntroDrone.SetActive(false);
        StartCoroutine(PlayIntroScene());
    }
}
