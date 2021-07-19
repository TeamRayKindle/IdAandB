using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// intializing gameobjects
    /// </summary>
    public GameObject AnchorPosition;
    public GameObject JoyStickControl;
    public GameObject Character;
    public GameObject Canvas;
    public GameObject CapI;
    public GameObject smoke;
    public GameObject smallI;
    
    private FirstPersonController joystick;

    

    
    
    public Animator Animator;

    public CanvasVisiblityHandler makevis { get; private set; }

    public AudioManager am;
    public Animator animator2;
    public Animator animator3;

    /// <summary>
    ///  variables used in the script
    /// </summary>
    private float _displace = 0f;
    private float _i = 0;
    private float _speed = 0f;
    private float _speed2 = 0f;

    private CameraShake Shake;

    

    
    // Start is called before the first frame update

    public void Start()
    {
        makevis = Canvas.GetComponent<CanvasVisiblityHandler>(); //making visible script
        am = AudioManager.instance; //taking instance of audio manager
        JoyStickControl.SetActive(false);   // joystick is set inactive
        gameObject.GetComponent<FirstPersonController>().enabled = false; //first person controller is set inactive
       StartCoroutine(Narrate());  // naration coroutine starts
       // animator2.applyRootMotion = false;
       // animator3.applyRootMotion = false;
       // Shake = gameObject.GetComponentInChildren<CameraShake>(); //camera shaking 
        am.Play("star");//play star sound
        joystick = gameObject.GetComponent<FirstPersonController>();
        am.Play("sc2");


    }

    //carpet gets set to position on reaching a distance of the target character
    void Update()
    {
        _displace = Vector3.Distance(transform.position, Character.transform.position);//calculate distance
        if (_displace < 10f && _i==0)  //when distance between carpet and character becomes less than 20 units condition satisfies and carpet sets to place
        {
            am.Play("star");//star sound plays
            gameObject.GetComponent<FirstPersonController>().enabled = false;//fps movement is disabled
            JoyStickControl.SetActive(false);//joystick is disabled
            StartCoroutine(FollowPath());//carpet sets to position corotine starts
            am.Play("sc4");//narration plays
            
            _i = _i + 1;//variable i changes values thus the if condition is no longer satisfied
            makevis.call(2);
            
        }
        
       
    }
   //intial naration sequence
   /// <summary>
   /// corutine naration starts here
   /// </summary>
   /// <returns></returns>
    IEnumerator Narrate() 
    {
        
        yield return new WaitForSeconds(6f);//execution stops for 8 seconds
        joystick.enabled = true;
        am.Play("star");
       
        
        yield return new WaitForSeconds(4f);
        JoyStickControl.SetActive(true);
        am.Play("sc3");
        StopCoroutine(Narrate());// coroutine narration  stops here


    }
    //mechanism by which the carpet gets set to  the position
    IEnumerator FollowPath()
    {

        Vector3 start = transform.position;//current position of carpet
        Vector3 end = AnchorPosition.transform.position;//position of character
        //transform.LookAt(lion.transform.position);
        while (_speed < 1f)//until value of speed becomes 1 
        {
            _speed += Time.deltaTime * 0.5f;//speed value increases 
            _speed2 += Time.deltaTime * 0.1f;//same as above

            transform.position = Vector3.Lerp(start, end, _speed);//change position using lerp functon
            transform.rotation = Quaternion.Lerp(transform.rotation, AnchorPosition.transform.rotation, _speed2);
            transform.eulerAngles = Vector3.RotateTowards(transform.eulerAngles, Character.transform.eulerAngles, 0.1f * Time.deltaTime, 0.5f);//change angle using rotate function


            // transform.rotation = position.transform.rotation;
            yield return new WaitForEndOfFrame();
        }
        //  makevis.call(2);//words become visible
        // yield return new WaitForSeconds(3f);
        transform.rotation = AnchorPosition.transform.rotation;
        makevis.call(4);
        am.Play("trans");

        StopCoroutine(FollowPath());//folow stops
    







    }
    
    public void OnCharacterClick()//Character click event
    {
        Character.GetComponent<BoxCollider>().enabled = false;
        makevis.Invisible(4);
        am.Play("star");

        // Animator.SetBool("chesthit", true);
        
        
       // makevis.call(5);
        StartCoroutine(reveal());
       
    }


    IEnumerator reveal()
    {
        am.Play("coin");
        yield return new WaitForEndOfFrame();
        smoke.SetActive(false);
        yield return new WaitForSeconds(3f);
        CapI.SetActive(true);
        am.Play("sc6");
        yield return new WaitForSeconds(2f);
       // makevis.call(5);
       // CapI.SetActive(false);

        smoke.SetActive(false);
       // CapI.GetComponent<Animator>().SetBool("Come", true);
        yield return new WaitForSeconds(2f);
        smallI.SetActive(true);
        
        am.Play("xylo");
        yield return new WaitForSeconds(2f);
       // makevis.call(6);
        //smallI.SetActive(false);
        am.Play("sc7");
        yield return new WaitForSeconds(2f);
        makevis.call(3);
        am.Play("sc8");
        makevis.Invisible(2);
        

        StopCoroutine(reveal());

    }




}