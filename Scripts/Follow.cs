using UnityEngine;
using UnityEngine.SceneManagement;

public class Follow : MonoBehaviour {

    public Transform target;
    public float Offset = 2;
    public float CamSpeed = 5;
   

    // Update is called once per frame
    void Update() {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x + Offset, target.position.y, transform.position.z), Time.deltaTime * CamSpeed);

        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(0);
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
