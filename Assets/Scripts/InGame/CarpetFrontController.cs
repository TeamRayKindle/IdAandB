using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetFrontController : MonoBehaviour
{
	[SerializeField]
	FirstPersonController fpc;

    private void OnCollisionEnter(Collision collision) {
        fpc.carpetWindOffset = 0f;
        //if(collision.gameObject.CompareTag("Barrier"))
        //{
           // fpc.gm.isCollidedWithBarrier = true;
        //}
    }

    private void OnCollisionExit(Collision collision) {
        fpc.carpetWindOffset = 1f;
        //if (collision.gameObject.CompareTag("Barrier"))
        //{
            // fpc.gm.isCollidedWithBarrier = false;
        //}
    }
}
