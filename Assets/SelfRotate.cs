using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    private RectTransform rt;

    private void Start()
    {
        rt = transform.GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        rt.localEulerAngles = new Vector3(rt.localEulerAngles.x, rt.localEulerAngles.y, rt.localEulerAngles.z + 15f * Time.deltaTime);
        //Debug.Log(rt.localEulerAngles);
    }
}
