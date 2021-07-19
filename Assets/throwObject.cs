using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class throwObject : MonoBehaviour
{
    public GameObject Obj;
    public int NumberOfClick=0;
    public Transform firstpos;
    public Transform secondpos;
    public ParticleSystem pr;
    public ParticleSystem st;
    public GameObject probj;
    public GameObject stbj;
    public GameObject O1;
    public GameObject O2;
    public GameObject O3;
    public Button btn;
    public GameObject canv;
    public GameObject Otxt;
    public Text txt;
    public Image img;
    public Sprite img1;
    public Sprite img2;

    public void onObjectIsClicked()
    {
        NumberOfClick += 1;
        Debug.Log("objectclicked N:"+NumberOfClick.ToString());
        FirstClick();
        btn.interactable = false;
    }
   
    public void FirstClick()
    {
        StartCoroutine(wait());
        iTween.MoveTo(Obj, iTween.Hash("position", secondpos, "time", 2.5f, "easetype", iTween.EaseType.easeInOutSine));
    }
    public void AddSplash()
    {
        Debug.Log("splash");
    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(2.4f);
        AddSplash();
        Obj.SetActive(false);
        probj.SetActive(true);
        pr.Play();
        yield return new WaitForSeconds(0.2f);
        if(NumberOfClick == 1)
        {
            O1.SetActive(true);
            btn.interactable = true;
        }
        if (NumberOfClick == 2)
        {
            O2.SetActive(true);
            btn.interactable = true;
        }
        if (NumberOfClick == 3)
        {
            O3.SetActive(true);
            probj.SetActive(false);
            yield return new WaitForSeconds(2f);
            win();
        }
        probj.SetActive(false);
        yield return new WaitForSeconds(0.6f);
        iTween.MoveTo(Obj, iTween.Hash("position", firstpos, "time", 0, "easetype", iTween.EaseType.easeInOutSine));
        stbj.SetActive(true);
        st.Play();
        Obj.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        stbj.SetActive(false);
    }
  
    public void win()
    {
        canv.SetActive(true);
        iTween.ScaleTo(Otxt, iTween.Hash("scale", new Vector3(1, 1, 1), "time", 3f));
    }
    public int turn = 0;
    public void FixedUpdate()
    {
        if (turn == 0)
        {
            img.sprite = img1;
            txt.text = "Capital Letter O";
        }
        else if (turn == 1)
        {
            img.sprite = img2;
            txt.text = "Small Letter o";
        }
        else if (turn == 2)
        {
            turn = 0;
            img.sprite = img2;
            txt.text = "Small Letter o";
        }
    }
   
    public void retry()
    {
        turn += 1;
        Repos();
    }
    public void Repos()
    {
        NumberOfClick = 0;
        O1.SetActive(false);
        O2.SetActive(false);
        O3.SetActive(false);
        btn.interactable = true;
        Otxt.GetComponent<Transform>().localScale = new Vector3(0.01f, 0.01f, 0.01f);
        canv.SetActive(false);
    }
}
