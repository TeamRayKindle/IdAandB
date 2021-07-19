using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intromanager : MonoBehaviour
{
    public GameObject Player;
    public AudioManager am;
    public void OnClick()
    {
        gameObject.transform.GetChild(2).transform.gameObject.SetActive(false);
        gameObject.transform.GetChild(1).transform.gameObject.SetActive(true);
        StartCoroutine(Narrate());
    }

    IEnumerator Narrate()
    {
        am.Play("sc1");

        yield return new WaitForSeconds(6f);
        Player.GetComponent<GameManager>().enabled = true;
        gameObject.SetActive(false);

    }
}
