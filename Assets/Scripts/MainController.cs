using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("MainCharacters")]
    [SerializeField] GameObject SuperTurtle;
    [SerializeField] GameObject FlyingFrog;
    [SerializeField] GameObject LeafBoy;
    [SerializeField] GameObject ZebraElephant;
    [Header("Letters")]
    [SerializeField] GameObject M;
    [SerializeField] GameObject E;
    [SerializeField] GameObject S;
    [SerializeField] GameObject Leaf;

    [SerializeField] GameObject Maths;
    [SerializeField] GameObject English;
    [SerializeField] GameObject Science;
    [SerializeField] GameObject EnvironmentalScience;
    [Header("Position of MainCharacters")]
    [SerializeField] GameObject Pos_SuperTurtle;
    [SerializeField] GameObject Pos_LeafBoy;
    [SerializeField] GameObject Pos_ZebraElephant;
    [SerializeField] GameObject Pos_FlyingFrog;
    [SerializeField] GameObject Pos_Center;
    [Header("Audio Section")]
    [SerializeField] AudioClip[] narration;
    [SerializeField] AudioSource audioSource;
    [Header("Animators")]
    [SerializeField] Animator SuperTurtle_Animator;
    [SerializeField] Animator FlyingFrog_Animator;
    [SerializeField] Animator LeafBoy_Animator;
    [SerializeField] Animator ZebraElephant_Animator;
    [Header("Letters Animators")]
    [SerializeField] Animator M_Animator;
    [SerializeField] Animator E_Animator;
    [SerializeField] Animator S_Animator;
    [SerializeField] Animator Leaf_Animator;
    [SerializeField] Animator Maths_Animator;
    [SerializeField] Animator English_Animator;
    [SerializeField] Animator Science_Animator;
    [SerializeField] Animator EnvironmentalScience_Animator;

    [Header("UI Button")]
    [SerializeField] GameObject Play;
    // [SerializeField] Animator M_Animator;
    void Start()
    {
        
       // audioSource.clip = narration[7];
        //audioSource.Play();
       // audioSource.volume = 0.5f;
        StartCoroutine("StoryPlay");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator StoryPlay()
    {
        yield return new WaitForSeconds(2f);
        audioSource.clip = narration[8];//effects
        audioSource.Play();
        iTween.MoveTo(ZebraElephant, Pos_ZebraElephant.GetComponent<Transform>().position, 1);
       // yield return new WaitForSeconds(2f);
        iTween.MoveTo(ZebraElephant, Pos_Center.GetComponent<Transform>().position, 5);
        yield return new WaitForSeconds(3f);

        audioSource.clip = narration[1];   //sc1
        audioSource.Play();
        ZebraElephant_Animator.SetBool("isTalking",true);
        yield return new WaitForSeconds(8.5f);
        ZebraElephant_Animator.SetBool("isTalking", false);
        yield return new WaitForSeconds(1f);

        M.SetActive(true);
        M_Animator.SetBool("isPopping", true);
        audioSource.clip = narration[9];//effects
        audioSource.Play();
        yield return new WaitForSeconds(1.1f);
        M_Animator.SetBool("isPopping", false);
        M.SetActive(false);
        Maths.SetActive(true);
        Maths_Animator.SetBool("isVisible", true);

        audioSource.clip = narration[2];    //sc2
        audioSource.Play();
        ZebraElephant_Animator.SetBool("isTalking", true);
        yield return new WaitForSeconds(audioSource.clip.length);
        ZebraElephant_Animator.SetBool("isTalking", false);
        yield return new WaitForSeconds(1f);
        iTween.MoveTo(ZebraElephant, Pos_ZebraElephant.GetComponent<Transform>().position, 5);
        yield return new WaitForSeconds(3f);
        

        audioSource.clip = narration[8];//effects
        audioSource.Play();
        iTween.MoveTo(SuperTurtle, Pos_SuperTurtle.GetComponent<Transform>().position, 1);
        yield return new WaitForSeconds(2f);
        audioSource.clip = narration[3];     //sc3
        audioSource.Play();
        SuperTurtle_Animator.SetBool("isTalking", true);
        yield return new WaitForSeconds(audioSource.clip.length);
        SuperTurtle_Animator.SetBool("isTalking", false);
        yield return new WaitForSeconds(1f);

        E.SetActive(true);
        E_Animator.SetBool("isPopping", true);
        audioSource.clip = narration[9];//effects
        audioSource.Play();
        yield return new WaitForSeconds(1.1f);
        E_Animator.SetBool("isPopping", false);
        E.SetActive(false);
        English.SetActive(true);
        English_Animator.SetBool("isVisible", true);


        audioSource.clip = narration[8];//effects
        audioSource.Play();
        iTween.MoveTo(FlyingFrog, Pos_FlyingFrog.GetComponent<Transform>().position, 1);
        yield return new WaitForSeconds(2f);
        audioSource.clip = narration[4];      //sc4
        audioSource.Play();
        FlyingFrog_Animator.SetBool("isTalking", true);
        yield return new WaitForSeconds(audioSource.clip.length);
        FlyingFrog_Animator.SetBool("isTalking", false);
        yield return new WaitForSeconds(1f);

        S.SetActive(true);
        S_Animator.SetBool("isPopping", true);
        audioSource.clip = narration[9];//effects
        audioSource.Play();
        yield return new WaitForSeconds(1.1f);
        S_Animator.SetBool("isPopping", false);
        S.SetActive(false);
        Science.SetActive(true);
        Science_Animator.SetBool("isVisible", true);

        audioSource.clip = narration[8];//effects
        audioSource.Play();
        iTween.MoveTo(LeafBoy, Pos_LeafBoy.GetComponent<Transform>().position, 1);
        yield return new WaitForSeconds(2f);
        audioSource.clip = narration[5];     //sc5
        audioSource.Play();
        LeafBoy_Animator.SetBool("isTalking", true);
        yield return new WaitForSeconds(audioSource.clip.length);
        LeafBoy_Animator.SetBool("isTalking", false);
        yield return new WaitForSeconds(1f);

        Leaf.SetActive(true);
        Leaf_Animator.SetBool("isPopping", true);
        audioSource.clip = narration[9];//effects
        audioSource.Play();
        yield return new WaitForSeconds(1.1f);
        Leaf_Animator.SetBool("isPopping", false);
        Leaf.SetActive(false);
        EnvironmentalScience.SetActive(true);
        EnvironmentalScience_Animator.SetBool("isVisible", true);

        yield return new WaitForSeconds(1f);
        SuperTurtle_Animator.SetBool("isTalking", true);
        audioSource.clip = narration[6]; //sc6
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        SuperTurtle_Animator.SetBool("isTalking", false);
        ItweenSimpleVersion.Scale(Play, 1, 1, 1, 3);

    }

    public void NextScene()
    {
        SceneManager.LoadScene(StaticString.CarSelectionlevelName);
    }
}
