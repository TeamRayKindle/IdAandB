using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCarSprite : MonoBehaviour
{
    public Sprite car1;
    public Sprite car2;
    public Sprite car3;

    public void Update()
    {
        if (StaticString.GetCarName() == StaticString.Car1)
        {
            gameObject.GetComponent<Image>().sprite = car1;
        }
        else if (StaticString.GetCarName() == StaticString.Car2)
        {
            gameObject.GetComponent<Image>().sprite = car2;
        }
        else if (StaticString.GetCarName() == StaticString.Car3)
        {
            gameObject.GetComponent<Image>().sprite = car3;
        }
        
    }
}
