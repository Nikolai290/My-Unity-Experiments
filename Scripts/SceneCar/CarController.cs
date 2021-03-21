using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CarController : MonoBehaviour {

    public Rigidbody2D frontWheel;
    public Rigidbody2D rearWheel;
    public Rigidbody2D carRigidbody;

    public UnityEngine.UI.Image FuelImage;
    public float ForwardMaxSpeed = 90f;
    public float BackMaxSpeed = 20f;

    public float FuelCapacity = 50f;
    public float FuelConsumption = 5f;
    public float CarTorque = 10f;
    public float Speed = 6000f;
    public float FuelConsumptionIdle = 0.5f;
    public float movement { get; private set; }
    public float CurrentSpeedKMH { get; private set; }

    public float TorqueMoment { get; private set; }
    public float AbsoluteForce { get; private set; }
    private bool IsBrake;
    private float Fuel;

    private void Start() {
        FillTank();
    }

    void Update() {
        IsBrake = Input.GetKey(KeyCode.Space);
        movement = -Input.GetAxis("Horizontal");
        FuelImage.fillAmount = Fuel / FuelCapacity;
    }

    void FixedUpdate() {
        CurrentSpeedKMH = Mathf.Abs(carRigidbody.velocity.x * 5);
        TorqueMoment = movement > 0 ?
           1.1f - (CurrentSpeedKMH * CurrentSpeedKMH) / (BackMaxSpeed * BackMaxSpeed):
           1.1f - (CurrentSpeedKMH * CurrentSpeedKMH) / (ForwardMaxSpeed * ForwardMaxSpeed);

        TorqueMoment = TorqueMoment < 0 ? 0 : TorqueMoment;

        AbsoluteForce = movement * TorqueMoment * Speed;

        Debug.Log(frontWheel.rotation.ToString());

        if (IsBrake) {
            Braking(frontWheel);
            Braking(rearWheel);

        } else {
            frontWheel.freezeRotation = false;
            rearWheel.freezeRotation = false;
        }

        if (Fuel > 0) {
            frontWheel.AddTorque(AbsoluteForce * Time.fixedDeltaTime);
            rearWheel.AddTorque(AbsoluteForce * Time.fixedDeltaTime * 1.2f);
            

            Fuel -= FuelConsumption * Mathf.Abs(movement) * Time.fixedDeltaTime;
            Fuel -= FuelConsumptionIdle * Time.fixedDeltaTime;

        }
    }

    void Braking(Rigidbody2D rigidbody) {

            rigidbody.freezeRotation = true;
        
    }



    public void FillTank() {
        Fuel = FuelCapacity;
    }
}

