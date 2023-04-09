using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class move_towards : MonoBehaviour{
 public float moveSpeed = 5f;
    public GameObject toilte;
    private Transform targetTransform;
     private bool isMoving = true;
    void Start()
    {
        targetTransform = toilte.transform;
    }

    void Update()
    {
      finding_sOne();  
    }

    public void finding_sOne(){
        if (isMoving)
        {
        // Calculate the direction and distance between the game object and the target object
        Vector3 direction = targetTransform.position - transform.position;
        float distance = direction.magnitude;

        // Move the game object towards the target object
        if (distance > 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, moveSpeed * Time.deltaTime);
            transform.up = transform.position-targetTransform.position;        
        }
        }
    }


 public void Click ()
    {   
        Debug.Log("Clicked");
         if (isMoving)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }
    }



