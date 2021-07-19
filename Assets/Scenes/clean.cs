using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clean : MonoBehaviour
{
    public GameObject mask;
    private bool ispressed = false;
    public GameObject mk;
    public int Notc;
    public AudioSource AD;
    public AudioSource ADc;
    public void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 2;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        if (Input.GetMouseButtonDown(0))
        {
            AD.Play();
        }
        if (Input.GetMouseButtonUp(0))
        {
            AD.Pause();
        }
        if(ispressed == true)
        {
            Notc += 1;
            GameObject masksprite = Instantiate(mask, mousePos, Quaternion.identity);
            //mask.transform.parent = mk.transform;
           
        }
        else
        {
            
        }
        if (Input.GetMouseButton(0))
        {
            ispressed = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            ispressed = false;
        }
        if(Notc >= NumberOfClone && iswon == false)
        {
            win();
            iswon = true;
        }
    }
    private bool iswon=false;
    public int NumberOfClone;
    public void win()
    {
        mk.SetActive(false);
        ADc.Play();
        StartCoroutine(introwin());
    }
    public GameObject oldtext;
    public GameObject B;
    public GameObject b;
    public AudioSource BB;
    public AudioSource BBc;
    public AudioSource BBcc;
    IEnumerator introwin()
    {

        yield return new WaitForSeconds(1f);
        oldtext.SetActive(false);
        B.SetActive(true);
        b.SetActive(true);
        iTween.ScaleTo(B, iTween.Hash("scale", new Vector3(2.5f, 2.5f, 2.5f), "time", 3f));
        BBc.Play();
        yield return new WaitForSeconds(2f);
        iTween.ScaleTo(b, iTween.Hash("scale", new Vector3(2.5f, 2.5f, 2.5f), "time", 3f));
        BBcc.Play();
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Boutro");
    }

    public Texture2D mouseCursor;

    Vector2 hotSpot = new Vector2(0, 0);
    CursorMode cursorMode = CursorMode.ForceSoftware;

    private void Start()
    {
        Cursor.SetCursor(mouseCursor, hotSpot, cursorMode);
    }
}
