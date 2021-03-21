using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour {

    public GameObject Ore;
    public Transform OreSpawnPoint;
    private bool isSpawn;

    private void Update() {
        isSpawn = Input.GetKey(KeyCode.T);
        if (Input.GetKeyDown(KeyCode.T)) {
            StartCoroutine(SpawnOre());
        }
    }

    IEnumerator SpawnOre() {
        while (isSpawn) {
            Instantiate(Ore, OreSpawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
        }
    }




}
