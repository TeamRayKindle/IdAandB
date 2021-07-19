using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTriger : MonoBehaviour
{
    public GameObject player;
    public GameObject Canv;
    public bool CanGo;

    public void Update()
    {
        if(CanGo == true)
        {
            gameObject.GetComponent<SphereCollider>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }
    public void Start()
    {
        StartCoroutine(delay());
    }
    public IEnumerator delay()
    {
        CanGo = false;
        yield return new WaitForSeconds(4);
        CanGo = true;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.name == player.name)
        {
            Canv.SetActive(true);
            AudioManger.instance.Play("PortalOut");
            StartCoroutine(wait());
        }
    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(StaticString.LevelScreenlevelName);
    }
}
