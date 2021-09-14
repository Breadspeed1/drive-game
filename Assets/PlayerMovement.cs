using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public List<float> setPoints = new List<float>();
    public float currentSetPointVal = 0;
    private int currentSetPoint = 1;
    public float movementSpeed = 3;

    private void Start()
    {
        setPoints.Add(-2);
        setPoints.Add(0);
        setPoints.Add(2);
    }

    public void changeSetpointLeft(InputAction.CallbackContext ctx)
    {
        //Debug.Log("changing setpoint left");
        
        if (currentSetPoint != 0 && ctx.performed)
        {
            currentSetPoint -= 1;
            currentSetPointVal = setPoints[currentSetPoint];
        }
    }

    public void changeSetpointRight(InputAction.CallbackContext ctx)
    {
        //Debug.Log("changing setpoint right");
        if (currentSetPoint != 2 && ctx.performed)
        {
            currentSetPoint += 1;
            currentSetPointVal = setPoints[currentSetPoint];
        }
    }

    private void Update()
    {
        if (Math.Abs(gameObject.transform.localPosition.x - currentSetPointVal) > 0.01f)
        {
            float movement = -(gameObject.transform.localPosition.x - currentSetPointVal);
            float difference = gameObject.transform.localPosition.x + (movement * Time.deltaTime * movementSpeed);
            gameObject.transform.localPosition = new Vector3(difference, 1.25f, -3.36f);
            //     if (currentSetPointVal != 0)
            //     {
            //         gameObject.transform.localPosition += new Vector3(Convert.ToSingle(3.5 * setPoints[currentSetPoint]) * Time.deltaTime, 0, 0);
            //     }
            //     else if (gameObject.transform.localPosition.x < 0)
            //     {
            //         gameObject.transform.localPosition += new Vector3(7f * Time.deltaTime, 0, 0);
            //     }
            //     else if (gameObject.transform.localPosition.x > 0)
            //     {
            //         gameObject.transform.localPosition += new Vector3(-7f * Time.deltaTime, 0, 0);
            //     }
        }
        else if (gameObject.transform.localPosition.x != currentSetPoint)
        {
            gameObject.transform.localPosition = new Vector3(setPoints[currentSetPoint], 1.25f, -3.36f);
        }
    }
}