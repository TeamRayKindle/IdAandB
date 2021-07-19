using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManagerCatterpillar : MonoBehaviour
{
    
    [SerializeField] GameObject SpawnPoint; 
    [SerializeField] GameObject Mainbutton; 
    [SerializeField] GameObject JoyStick;
    [SerializeField] GameObject JoyStickController;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject IntroCanvas;
    [SerializeField] GameObject InteractiveItems;
    

    public  AudioManager AM;



    private GameObject Item;
    private GameObject ItemLoacater;
   [SerializeField] Animator animator;
    private GameObject CollisionObject;
    private float _distance=0f;
    
    private string ObjectName1;
    private string ChildNumber=String.Empty;
    private List<GameObject> interactedItems;
   
    private Vector3 currentpos;
   
    private Vector3 offset2 = new Vector3(0, 10, 0);
    private Vector3 intial_pos;
    private Vector3 Joystick_Pos;


    public CanvasVisiblityHandlerCatterillar CanvasVisbility { get; private set; }
    private float lerpDuration = 2f;//should be same as projection clip's length
    private bool isCurrentlyInteracting;

    private void Start()
    {
        
        Joystick_Pos = JoyStickController.transform.position;
        CanvasVisbility = canvas.GetComponent<CanvasVisiblityHandlerCatterillar>();
        CanvasVisbility.Invisible(1);
        CanvasVisbility.Invisible(6);
        JoyStick.SetActive(false);
        gameObject.GetComponent<FirstPersonController>().enabled = false;
        canvas.transform.GetChild(1).GetComponent<Button>().enabled = false;
        interactedItems = new List<GameObject>();
        // StartCoroutine(Introduction());

    }
    private void Update()
    {
        //CollisionObject = GameObject.Find(ChildNumber);
        if (CollisionObject)
            _distance = Vector3.Distance(gameObject.transform.position, CollisionObject.transform.position);
        if (_distance > 25 && isCurrentlyInteracting)
            InteractionFinalizer(CollisionObject);
    }
    public GameObject pointer;
   
    IEnumerator Introduction()
    {
        AM.Play("sc1");
        yield return new WaitForSeconds(9f);
        IntroCanvas.SetActive(false);
        canvas.SetActive(true);
        AM.Play("sc2");
        AM.Play("Magic");
        yield return new WaitForSeconds(8f);
        
        AM.Play("sc3");
        yield return new WaitForSeconds(10f);
        
        
        AM.Play("sc4");
        yield return new WaitForSeconds(3f);
        AM.Play("Swirl");
        Debug.LogError("1");
        pointer.SetActive(false);
        CanvasVisbility.vis(1);
        animator.SetBool("shake", true);
        
    
        yield return new WaitForSeconds(3f);
        animator.SetBool("shake", false);
        CanvasVisbility.vis(6);
        AM.Play("freeze");
        CanvasVisbility.Invisible(1);
        pointer.SetActive(true);
        yield return new WaitForEndOfFrame();
        AM.Play("Magic");
        JoyStick.SetActive(true);
        gameObject.GetComponent<FirstPersonController>().enabled = true;
        canvas.transform.GetChild(1).GetComponent<Button>().enabled = true;
    }
    public void InteractionInitializer(GameObject collisionObject)
    {
        if (!isCurrentlyInteracting)
        {
            CollisionObject = collisionObject;
            AM.Play("Magic");
            canvas.GetComponent<CanvasVisiblityHandlerCatterillar>().Invisible(6);
            canvas.GetComponent<CanvasVisiblityHandlerCatterillar>().vis(1);
            AM.Play(collisionObject.tag + "a");
            
        }
    }
    /// <summary>
    /// popuping up the item and playing audio related to object and marking  it as visited
    /// passing the tag of the object as parameter for the method 
    /// </summary>
    /// <param name="ObjectName"></param>
    public void InteractionHandler(GameObject collisionObject)
    {
        if (!isCurrentlyInteracting)
        {
            ObjectName1 = collisionObject.tag;
            intial_pos = collisionObject.transform.position + offset2;
            deActivateJoystick();
            activateMainbutton();
            currentpos = gameObject.transform.position;
            //gameObject.transform.position = gameObject.transform.position+offset;
            // AM.Play("star");
            if (GameObject.FindGameObjectWithTag(ObjectName1 + "p")!=null)
                GameObject.FindGameObjectWithTag(ObjectName1 + "p").SetActive(false);
            isCurrentlyInteracting = true;
        }
    }

    public void InteractionFinalizer(GameObject collisionObject)
    {
        if (isCurrentlyInteracting)
        {
            deActivateMainbutton();
            isCurrentlyInteracting = false;
            addInteractedItemToQueue(collisionObject);
            activateGameEnd();
        }
    }

    private void activateGameEnd()
    {
        if (interactedItems.Count == InteractiveItems.transform.childCount)
        {
            canvas.GetComponent<CanvasVisiblityHandlerCatterillar>().vis(7);
        }
    }

    private void activateMainbutton()
    {
        Mainbutton.SetActive(true);
        canvas.transform.GetChild(1).GetComponent<Button>().enabled = true;
        CanvasVisbility.Invisible(6);
    }
    private void deActivateMainbutton()
    {
        animator.SetBool("Click", false);
        AM.Play("freeze");
        Mainbutton.SetActive(false);
        CanvasVisbility.vis(6);
    }
    public CharacterController cc;
    private void activateJoystick()
    {
        cc.enabled = true;
        JoyStick.SetActive(true);
      //  JoyStickController.transform.position = Joystick_Pos;
      //  AM.Play("Swirl");
        gameObject.GetComponent<FirstPersonController>().enabled = true;
    }
    private void deActivateJoystick()
    {
        cc.enabled = false;
        gameObject.GetComponent<FirstPersonController>().enabled = false;
      //  JoyStick.SetActive(false);
    }
    private void playCharacterAnimation()
    {
        canvas.transform.GetChild(4).GetComponent<Animator>().SetBool("Action", true);//character action animation
        AM.Play("eat");
    }
    private void stopCharacterAnimation()
    {
        canvas.transform.GetChild(4).GetComponent<Animator>().SetBool("Action", false);//character action animation
    }

    IEnumerator presentObject()
    {
        yield return new WaitForSeconds(1f);
        deActivateMainbutton();
        AM.Play("Projection");
        StartCoroutine(Lerp(Item, intial_pos, SpawnPoint.transform.position, lerpDuration));
        yield return new WaitForSeconds(lerpDuration);
        AM.Play(ObjectName1);
        yield return new WaitForSeconds(3f);
       // gameObject.transform.position = currentpos;

        playCharacterAnimation();
      
        Item.SetActive(false);
        yield return new  WaitForSeconds(2.5f);

        stopCharacterAnimation();
        AM.Play("trans");
        
        yield return new WaitForSeconds(1f);
        activateJoystick();
        StopCoroutine(presentObject());

    }

    IEnumerator finish()//game finish events
    {
        JoyStick.SetActive(false);
        gameObject.GetComponent<FirstPersonController>().enabled = false;
        yield return new WaitForSeconds(1f);
        CanvasVisbility.vis(6);
        CanvasVisbility.vis(0);
        CanvasVisbility.Invisible(4);
        CanvasVisbility.Invisible(6);
        CanvasVisbility.vis(2);
        CanvasVisbility.vis(3);
        CanvasVisbility.vis(5);
        canvas.transform.GetChild(4).GetComponent<Animator>().SetBool("full",true);//character final animation
        //character final animation
        yield return new WaitForSeconds(3f);
        AM.Play("Yay");
        yield return new WaitForSeconds(5f);
       
        AM.Play("Thankyou");
        yield return new WaitForSeconds(5f);
        canvas.transform.GetChild(5).GetComponent<Animator>().SetBool("idle", true);
        CanvasVisbility.vis(9);
        StopCoroutine(finish());
    }

    private void addInteractedItemToQueue(GameObject item)
    {
        bool isItemPresent = interactedItems.Any(x => x.tag == item.tag);
        if(!isItemPresent)
        interactedItems.Add(item);
    }

    public void onClick()
    {
        deActivateJoystick();
        AM.Play("switch");
        animator.SetBool("Click", true);
        canvas.transform.GetChild(1).GetComponent<Button>().enabled = false;
                
        ItemLoacater = GameObject.Find(ObjectName1);
        Item = GameObject.Instantiate(ItemLoacater, intial_pos, SpawnPoint.transform.rotation);
        StartCoroutine(presentObject());//make the object rotate in front
    }
    IEnumerator Lerp(GameObject itemToLerp,Vector3 startValue, Vector3 endValue, float lerpDuration)
    {
    float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            itemToLerp.transform.position = Vector3.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        itemToLerp.transform.position = endValue;
    }
    public void Finishbutton()
    {
        canvas.GetComponent<CanvasVisiblityHandlerCatterillar>().Invisible(7);
        JoyStick.SetActive(false);
        JoyStickController.SetActive(false);
        AM.Play("Greatjob");
        
        StopCoroutine(presentObject());
        
        StartCoroutine(finish());
       // AM.Play("Thankyou");
    }
    //introductionclick button
    public void Intro()//playbuttonClicked
    {
        IntroCanvas.GetComponent<CanvasVisiblityHandlerCatterillar>().Invisible(1);
        IntroCanvas.GetComponent<CanvasVisiblityHandlerCatterillar>().vis(2);
        IntroCanvas.GetComponent<CanvasVisiblityHandlerCatterillar>().vis(3);
        StartCoroutine(Introduction());
    }
    
}
