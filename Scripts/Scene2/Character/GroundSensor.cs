using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{

    public bool IsGrounded { get; protected set; }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Ground") {
            IsGrounded = true;
            Debug.Log("trigger enter");

        }
    }

    //private void OnTriggerEnter2D(Collider2D collision) {
    //    if (collision.tag == "Ground") {
    //        IsGrounded = true;
    //        Debug.Log("trigger enter");

    //    }
    //}

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Ground") {
            IsGrounded = false;
            Debug.Log("trigger exit");

        }
    }
}
