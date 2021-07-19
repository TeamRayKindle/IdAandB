using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercentageSlider : MonoBehaviour
{
    public float Percentage;
    public SpriteSlider SS;
    public int TotalChild;
    public int completed;
    public bool IsActive=true;
    public bool MainIsland = true;
    public void Update()
    {
        Percentage = completed * (100 / TotalChild);
        if(Percentage >= 99)
        {
            Percentage = 100;
        }
        SS.Percentage = Percentage;
        SS.gameObject.SetActive(IsActive);
    }
}
