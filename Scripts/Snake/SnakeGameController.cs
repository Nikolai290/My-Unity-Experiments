using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SnakeGameController : MonoBehaviour {

    public GameObject Apple;
    public GameObject SnakeHead;
    public Text text;

    public int XRange = 17;
    public int YRange = 9;
    public int MaxApples = 3;

    public bool IsLose { get; protected set; }
    private IList<GameObject> apples;

    private void Start() {
        apples = new List<GameObject>();
    }

    private void SpawnApple() {
        try {
            foreach (var a in apples)
                if (a == null) {
                    apples.Remove(a);
                    text.text = "Score: " + SnakeHead.GetComponent<SnakeHead>().body.Count.ToString();
                    break;
                }
        } finally {

        }

        while (apples.Count < MaxApples) {
            var pos = RandomPosition(XRange, YRange);
            Debug.Log("Spawn apple: " + pos);
            apples.Add(Instantiate(Apple, pos, Quaternion.identity));
        }
    }

    private void Update() {
        SpawnApple();
    }


    public Vector2 RandomPosition(int x, int y) {
        float X = Random.Range(-x, x);
        float Y = Random.Range(-y, y);
        var V = new Vector2(X, Y);
        return V;
    }
}
