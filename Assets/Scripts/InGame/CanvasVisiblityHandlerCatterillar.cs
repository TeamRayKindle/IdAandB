using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasVisiblityHandlerCatterillar : MonoBehaviour
{
    public AudioManager am;//referencing audio manager
    
    public void vis(int i)//method to make child objects visible
    {

        transform.GetChild(i).transform.gameObject.SetActive(true);

    }

    public void Invisible(int i)//method to make child objects invisible
    {
        transform.GetChild(i).transform.gameObject.SetActive(false);
    }
  
  
}
