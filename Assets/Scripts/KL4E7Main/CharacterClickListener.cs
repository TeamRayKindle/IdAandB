using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClickListener : MonoBehaviour
{
    public GameManager GameManagerObject;
    private void OnMouseDown()//Character click event
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
       // GameManagerObject.OnPlayerClickedCharacter();
    }
}
