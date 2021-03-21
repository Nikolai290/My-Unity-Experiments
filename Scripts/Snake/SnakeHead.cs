using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class SnakeHead : MonoBehaviour {
    public float Speed = 5f;
    public Vector2 Position { get; private set; }
    public GameObject Cell;
    public int StartLenght = 3; 


    private readonly float statTime = 1f;
    private float step = 0;
    private Vector2 target;

    public IList<GameObject> body { get; private set; }
    private bool up;
    private bool down;
    private bool left;
    private bool right;

    private void Start() {
        up = true;
        step = statTime;

        body = new List<GameObject>() { gameObject};
    }

    void Update()
    {
        Position = gameObject.transform.position;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !right) {
            up = false;
            down = false;
            right = false;
            left = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !left) {
            up = false;
            down = false;
            right = true;
            left = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !down) {
            up = true;
            down = false;
            right = false;
            left = false;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !up) {
            up = false;
            down = true;
            right = false;
            left = false;
        }
        if (up) target = Position + Vector2.up;
        if (down) target = Position + Vector2.down;
        if (left) target = Position + Vector2.left;
        if (right) target = Position + Vector2.right;


        if (step < 0.01) {
            if (body.Count < StartLenght) {
                AddCell();
            }
            Move();
            step = statTime/Speed;

        }
        step -= Time.deltaTime;
    }

    public void AddCell() {
        body.Add(Instantiate(Cell, body.Last().transform.position, Quaternion.identity));
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Snake") {
            Destroy(gameObject);
            Debug.Log("Snake eat tail");
        }
        if (collision.tag == "Border") {
            Destroy(gameObject);
            Debug.Log("Crash on border");
        }
        if (collision.tag == "Apple") {
            AddCell();
            Destroy(collision.gameObject);
            if (body.Count % 5 == 0)
                Speed++;
        }
    }


    private void Move() {
        var moveTarget = gameObject.transform.position;
        Vector2 temp;
        gameObject.transform.position = target;
        for (int i = 1; i < body.Count; i++) {
            temp = body[i].transform.position;
            body[i].transform.position = moveTarget;
            moveTarget = temp;

        }
    }
}
