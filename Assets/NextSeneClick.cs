using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextSeneClick : MonoBehaviour
{
    [SerializeField] AudioManager AudioManager;

    public void OnMouseDown()//Character click event
    {
        Debug.Log("clicked");
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<Animator>().SetBool("Launch", true);
      //  AudioManager.Play("Launch");
        SceneManager.LoadScene(1);
    }
}
