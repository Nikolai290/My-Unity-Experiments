using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UITextManager : MonoBehaviour
{
    public Text TextPanel;
    public Rigidbody2D CarRb;
    public GameObject CarController;

    private CarController CarScript;

    private float timer;

    private void Start() {
        CarScript = CarController.GetComponent<CarController>();
    }
    private void Update() {
        string text = "";
        timer += Time.deltaTime;

        text += "Timer: " + timer.ToString("F2") + " c" + '\n';
        text += "carVelocity: " + CarScript.CurrentSpeedKMH.ToString("F0") + " km/h" + '\n';
        text += "movement: " + CarScript.movement.ToString("F2") + '\n';
        text += "TorqueMoment: " + CarScript.TorqueMoment.ToString("F2") + '\n';
        text += "AbsoluteForce: " + CarScript.AbsoluteForce.ToString("F2") + '\n';


        TextPanel.text = text;
    }
}
