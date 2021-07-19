using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColoringManagmnt : MonoBehaviour
{
    public AudioManager2 am;
    [HideInInspector]
    public AudioSource amSource;

    public GameObject ColoringNumber_1;
    public GameObject ColoringNumber_2;
    public GameObject ColoringNumber_3;
    public GameObject ColoringNumber_4;

    public GameObject colorPalette;

    public GameObject Finished_Panel;
    public GameObject coloring_Panel;
    public GameObject pallette;
    
    public GameObject leafBoy_Idle;
    public GameObject leafBoy_Talk;
    public GameObject leafBoy_Bye;
    public GameObject Boy_IdleBye;



    public Texture2D cursorTexturePinkOne;
    public Texture2D cursorTexturePurpleTwo;
    public Texture2D cursorTextureBrownThree;
    public Texture2D cursorTextureOrangeFour;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {

        pallette.SetActive(true);
        coloring_Panel.SetActive(true);
        Fade.Finished = false;
        amSource = am.GetComponent<AudioSource>();
        Finished_Panel.SetActive(false);
        leafBoy_Idle.SetActive(false);
        leafBoy_Talk.SetActive(false);
        leafBoy_Bye.SetActive(false);
        Boy_IdleBye.SetActive(false);
        

        foreach (Transform t in colorPalette.transform)
        {
            t.GetComponent<Button>().enabled = false;
        }

        foreach (Transform t in ColoringNumber_1.transform)
        {
            t.GetComponent<PolygonCollider2D>().enabled = false;
        }

        foreach (Transform t in ColoringNumber_2.transform)
        {
            t.GetComponent<PolygonCollider2D>().enabled = false;
        }
        foreach (Transform t in ColoringNumber_3.transform)
        {
            t.GetComponent<PolygonCollider2D>().enabled = false;
        }
        foreach (Transform t in ColoringNumber_4.transform)
        {
            t.GetComponent<PolygonCollider2D>().enabled = false;
        }

        StartCoroutine(StartSupportSecondScene());
    }

    IEnumerator StartSupportSecondScene()
    {
        amSource.clip = am.narrations[12];
        amSource.Play();
        yield return new WaitForSeconds(amSource.clip.length);

        amSource.clip = am.narrations[9];
        amSource.Play();
        yield return new WaitForSeconds(amSource.clip.length);

        foreach (Transform t in colorPalette.transform)
        {
            t.GetComponent<Button>().enabled = true;
        }

    }

    private void Update()
    {
        if (Fade.Finished == true)
        {
            StartCoroutine(FinisherSupporter());
        }
    }

    IEnumerator FinisherSupporter()
    {
        Fade.Finished = false;
        pallette.SetActive(false);
        amSource.clip = am.narrations[10];
        amSource.Play();
        leafBoy_Talk.SetActive(true);
        yield return new WaitForSeconds(amSource.clip.length);
        coloring_Panel.SetActive(false);
        Finished_Panel.SetActive(true);


        amSource.clip = am.narrations[13];
        amSource.Play();
        leafBoy_Talk.SetActive(false);
        leafBoy_Bye.SetActive(true);
        yield return new WaitForSeconds(.25f);
        leafBoy_Bye.SetActive(false);
        Boy_IdleBye.SetActive(true);
        amSource.clip = am.narrations[14];
    }

    public void Color_One_Brush()
    {
        Cursor.SetCursor(cursorTexturePinkOne, hotSpot, cursorMode);

        amSource.clip = am.narrations[7];
        amSource.Play();

        foreach (Transform t in ColoringNumber_1.transform)
        {
            t.GetComponent<PolygonCollider2D>().enabled = true;
        }
        foreach (Transform t in ColoringNumber_2.transform)
        {
            t.GetComponent<PolygonCollider2D>().enabled = false;
        }
        foreach (Transform t in ColoringNumber_3.transform)
        {
            t.GetComponent<PolygonCollider2D>().enabled = false;
        }
        foreach (Transform t in ColoringNumber_4.transform)
        {
            t.GetComponent<PolygonCollider2D>().enabled = false;
        }
    }

    //public void OnMouseExit()
    //{
    //    Cursor.SetCursor(null, Vector2.zero, cursorMode);

    //}

    public void Color_Two_Brush()
    {
        Cursor.SetCursor(cursorTexturePurpleTwo, hotSpot, cursorMode);

        amSource.clip = am.narrations[5];
        amSource.Play();

        foreach (Transform t in ColoringNumber_1.transform)
        {
            t.GetComponent<PolygonCollider2D>().enabled = false;
        }

        foreach (Transform t in ColoringNumber_2.transform)
        {
            t.GetComponent<PolygonCollider2D>().enabled = true;
        }
        foreach (Transform t in ColoringNumber_3.transform)
        {
            t.GetComponent<PolygonCollider2D>().enabled = false;
        }
        foreach (Transform t in ColoringNumber_4.transform)
        {
            t.GetComponent<PolygonCollider2D>().enabled = false;
        }

    }

    public void Color_Three_Brush()
    {
        Cursor.SetCursor(cursorTextureBrownThree, hotSpot, cursorMode);

        amSource.clip = am.narrations[4];
        amSource.Play();

        foreach (Transform t in ColoringNumber_1.transform)
        {
            t.GetComponent<PolygonCollider2D>().enabled = false;
        }
        foreach (Transform t in ColoringNumber_2.transform)
        {
            t.GetComponent<PolygonCollider2D>().enabled = false;
        }
        foreach (Transform t in ColoringNumber_3.transform)
        {
            t.GetComponent<PolygonCollider2D>().enabled = true;
        }
        foreach (Transform t in ColoringNumber_4.transform)
        {
            t.GetComponent<PolygonCollider2D>().enabled = false;
        }

    }

    public void Color_Four_Brush()
    {
        Cursor.SetCursor(cursorTextureOrangeFour, hotSpot, cursorMode);

        amSource.clip = am.narrations[6];
        amSource.Play();

        foreach (Transform t in ColoringNumber_1.transform)
        {
            t.GetComponent<PolygonCollider2D>().enabled = false;
        }
        foreach (Transform t in ColoringNumber_2.transform)
        {
            t.GetComponent<PolygonCollider2D>().enabled = false;
        }
        foreach (Transform t in ColoringNumber_3.transform)
        {
            t.GetComponent<PolygonCollider2D>().enabled = false;
        }
        foreach (Transform t in ColoringNumber_4.transform)
        {
            t.GetComponent<PolygonCollider2D>().enabled = true;
        }

    }

}
