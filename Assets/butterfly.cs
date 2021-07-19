using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butterfly : MonoBehaviour
{
    public GameObject butterflyObj;
    public GameObject Txt;
    public static int po;
    public whenWin wn;
    public GameObject[] butt;
    public GameObject buttmine;
    public void WhenButterflyClicked()
    {
        butterfly.po += 1;
        // butterflyObj.SetActive(false);
        // Txt.SetActive(true);
        
        StartCoroutine(butterflyAnim());
        Debug.Log(butterfly.po);
        foreach(GameObject c in butt)
        {
            c.SetActive(false);
        }


    }
    public IEnumerator butterflyAnim()
    {
        Debug.LogError("c");
        ItweenSimpleVersion.Scale(gameObject, 0, 0, 0, 2);
        wn.Adn.Play("t");
        yield return new WaitForSeconds(0.5f);
        Txt.SetActive(true);
        ItweenSimpleVersion.Scale(Txt, 0.6f, 0.6f, 0.6f, 2);
        wn.Adn.Play("m");
        yield return new WaitForSeconds(1);
        if (butterfly.po == 5)
        {
            wn.win();
        }
        foreach (GameObject c in butt)
        {
            c.SetActive(true);
        }
        buttmine.SetActive(false);
    }
}
