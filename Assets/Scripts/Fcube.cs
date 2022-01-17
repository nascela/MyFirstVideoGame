using System;
using UnityEngine;

public class Fcube : MonoBehaviour

{
    private float FlySpeed;
    private bool canFly = false;
    private float z = 1.0f;
    private float elapsedTime;
    private Quaternion newRotation;
    private Quaternion startRotation;
    private bool isRotation = false;
    private int i = 0; 
    
    void Start()
    {
        SetFlySpeed(5f);
        Vector3 startRotation = transform.rotation.eulerAngles;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (FlySpeed > 0 && canFly)
        {
             
            Vector3 endPosition = new Vector3(transform.position.x + Input.GetAxis("Horizontal"), transform.position.y + Input.GetAxis("Vertical"), transform.position.z + z);
            transform.position = Vector3.Lerp(transform.position, endPosition, Time.deltaTime * FlySpeed);
            
            
            
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isRotation)
        {
                
            Vector3 endRotationValue = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180f, transform.rotation.eulerAngles.z);
            newRotation = new Quaternion();
            newRotation.eulerAngles = endRotationValue;
            StopCube();
            z *= (-1);
            elapsedTime = 0f;
            isRotation = true;

        }

        
        if (isRotation )
        {
            i += 1;
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / FlySpeed;
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation,percentageComplete );
        }

        //int x = (int) (transform.rotation.eulerAngles.y % 180);
        
        if (isRotation && ( transform.rotation.eulerAngles.y % 180 == 0 || i >= 226)  ) 
        {
            isRotation = false;
            StartCube();
            i = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCube(); 
            isRotation = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StopCube();
        }
    }

    
    void StartCube()
    {
        canFly = true;
    }

    void StopCube()
    {
        canFly = false;
    }
    
    void SetFlySpeed(float currentSpeed)
    {
        FlySpeed = currentSpeed;
    }
    float GetflySpeed()
    {
        return FlySpeed;
    }
    
}




