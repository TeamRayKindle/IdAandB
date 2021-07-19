using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextscene : MonoBehaviour
{
   public void NextScene(string c)
    {
        SceneManager.LoadScene(c);
    }
}
