using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public string inputSteerAxis = "Horizontal";
    public string inputThrottleAxis = "Vertical";

    public float ThrottleInput { get; private set; }
    public float SteerInput {get; private set; }

    // Variabili per i controlli touch
    public bool isSteeringLeft = false;
    public bool isSteeringRight = false;
    public bool isAccelerating = false;
    public bool isReversing = false;

    public void StartSteeringLeft()
    {
        isSteeringLeft = true;
    }

    public void StopSteeringLeft()
    {
        isSteeringLeft = false;
    }

    public void StartSteeringRight()
    {
        isSteeringRight = true;
    }

    public void StopSteeringRight()
    {
        isSteeringRight = false;
    }

    public void StartAccelerating()
    {
        isAccelerating = true;
    }

    public void StopAccelerating()
    {
        isAccelerating = false;
    }

    public void StartReversing()
    {
        isReversing = true;
    }

    public void StopReversing()
    {
        isReversing = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        // Controlla se il gioco è iniziato
        if (GameManager.Instance.isGameStarted)
        {
            // Controlli tastiera
            SteerInput = Input.GetAxis(inputSteerAxis);
            ThrottleInput = Input.GetAxis(inputThrottleAxis);

            if (isSteeringLeft)
                SteerInput = -1;
            else if (isSteeringRight)
                SteerInput = 1;
            else
                SteerInput = 0;

            if (isAccelerating)
                ThrottleInput = 1;
            else if (isReversing)
                ThrottleInput = -1;
            else
                ThrottleInput = 0;
        }
        else
        {
            // Se il gioco non è iniziato, disabilita gli input
            SteerInput = 0;
            ThrottleInput = 0;
        }
    }
}
