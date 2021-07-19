using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public AudioManager2 am;
    [HideInInspector]
    public AudioSource amSource;
    [SerializeField] private GameObject Color_Panel;

    private Color32 currentColor;
    public bool isColorChanging,colorChanged;

    private static int score;
    public static bool Finished;
    
    private int alphaValue;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        amSource = am.GetComponent<AudioSource>();
        alphaValue = 255;
        isColorChanging = false;
        colorChanged = false;
        currentColor = transform.GetComponent<SpriteRenderer>().color;
        
        //currentColor = new Color32(currentColor.r, currentColor.g, currentColor.b,125);
        //transform.GetComponent<Image>().color= currentColor;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(currentColor.a);
      //  Debug.Log(alphaValue);
        if(currentColor.a == alphaValue)
        {
            colorChanged = true;
        }    
        if (isColorChanging&&!colorChanged&&currentColor.a!=alphaValue)
        {

            // byte temp = currentColor.a--;
            // Debug.Log(temp);
            int temp = currentColor.a;
            temp++;
            
            currentColor = new Color32(currentColor.r, currentColor.g, currentColor.b,(byte)temp);//Mathf.Lerp(currentColor.a,alphaValue));
            transform.GetComponent<SpriteRenderer>().color = currentColor;
        }
        else
        {
           // colorChanged = true;
        }
    }

    public void OnMouseUp()
    {
         
        isColorChanging = true;
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        amSource.clip = am.narrations[12];
        amSource.Play();

        StartCoroutine(ScoreSupporter());

    }

    IEnumerator ScoreSupporter()
    {
        yield return new WaitForSeconds(1f);
        score++;
        Debug.Log(score);

        if (score >= 5)
        {
            Finished = true;
            Color_Panel.SetActive(false);
        }
    }
   
}
