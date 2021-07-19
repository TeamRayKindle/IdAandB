using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEvents : MonoBehaviour
{
    public GameObject Events;
   
   

    private void OnMouseDown()//Character click event
    {
        Events.GetComponent<GameManager>().OnCharacterClick();
    }
}
