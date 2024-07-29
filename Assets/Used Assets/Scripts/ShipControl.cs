using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Animations;

public class ShipControl : MonoBehaviour
{

    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xPosRange = 12.8f;
    [SerializeField] float yPosRange = 12.8f;

    [SerializeField] float xAimRange = 12.8f;
    [SerializeField] float yAimRange = 12.8f;
    [SerializeField] float sensitivity = 50f;
    [SerializeField] GameObject[] lasers;

    [SerializeField] int frameCount = 2;

    bool firstMouse;

    Vector2 laserEulerRotation;

    Vector2 mousePos;

    public GameObject[] Lasers { get => lasers; set => lasers = value; }

    void Start()
    {
        ResetFields();
        Debug.Log("First mouse: " + firstMouse);
    }

    public void ResetFields()
    {
        mousePos = new Vector2(0.0f, 0.0f);
        laserEulerRotation = new Vector2(0.0f, 0.0f);
        firstMouse = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveShip();
        Aim();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {
            DoShoot();

        }
        else
        {
            StopShoot();
        }
    }

    private void StopShoot()
    {
        foreach (var laser in Lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = false;
        }
    }

    private void DoShoot()
    {
        foreach (var laser in Lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = true;
        }
    }

    private void Aim()
    {
        Vector3 currentMousePos = Input.mousePosition;
        foreach (var laser in Lasers)
        {
            if (firstMouse)
            {
                mousePos = new Vector2(currentMousePos.x, currentMousePos.y);
                if (frameCount == 0)
                    firstMouse = false;
                else 
                    frameCount--;
            }

            float mouseXDiff = currentMousePos.x - mousePos.x;
            float mouseYDiff = currentMousePos.y - mousePos.y;

            laserEulerRotation.y += mouseXDiff * Time.deltaTime * sensitivity;
            laserEulerRotation.x -= mouseYDiff * Time.deltaTime * sensitivity;

            if (laserEulerRotation.y > yAimRange)
                laserEulerRotation.y = yAimRange;

            if (laserEulerRotation.y < -yAimRange)
                laserEulerRotation.y = -yAimRange;

            if (laserEulerRotation.x > xAimRange)
                laserEulerRotation.x = xAimRange;

            if (laserEulerRotation.x < -xAimRange)
                laserEulerRotation.x = -xAimRange;

            laser.transform.localRotation = Quaternion.Euler(
                laserEulerRotation.x,
                laserEulerRotation.y,
                0
            );

            mousePos = currentMousePos;
        }
    }

    private void MoveShip()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        //enhance how much we push since that value is too small
        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float yOffset = yThrow * Time.deltaTime * controlSpeed;

        //the current pos after the throw
        //this is to make the smooth movement, not an immediate jump
        float currentX = transform.localPosition.x + xOffset;
        float currentY = transform.localPosition.y + yOffset;

        currentX = Mathf.Clamp(currentX, -xPosRange, xPosRange);
        currentY = Mathf.Clamp(currentY, -yPosRange, yPosRange);

        transform.localPosition = new Vector3(currentX, currentY, 0);
    }
}
