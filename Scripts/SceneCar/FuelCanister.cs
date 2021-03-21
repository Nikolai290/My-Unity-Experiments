using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCanister : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponentInParent<CarController>().FillTank();
            Destroy(gameObject);
        }
    }

}
