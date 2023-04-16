using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toilet : MonoBehaviour
{
    public float toilet_finish= 5f;
    public float time_to_toilet =0f;
    public float delayTime = 10f;
    private Vector3 _initialOffset;
    public Transform targetObject;
    public float moveSpeed = 100f;
    public float maxRotationAngle = 5f;
    public float fixedDistance = 10f;
    public bool hasPlayedStartAnim = false;
    public bool waiting = false;



    public void Start(){
    }

    // Update is called once per frame
    public void going_toilet(){
            randommove ran  = GetComponent<randommove>();
            Vector3 targetPosition = targetObject.position;
            Vector3 objectPosition = transform.position;
            Vector3 direction = targetPosition - objectPosition;
            direction.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxRotationAngle);
            // Calculate target offset position based on initial offset and target position
            Vector3 targetOffsetPosition = targetPosition + targetObject.transform.rotation * _initialOffset;
            targetOffsetPosition.y = objectPosition.y;

        float distanceToTarget = Vector3.Distance(transform.position, targetOffsetPosition);
        
        // Check if the distance to the target is greater than the fixed distance
        if (distanceToTarget >= fixedDistance)
        {
            // Move the object towards the target offset position
            transform.position = Vector3.MoveTowards(transform.position, targetOffsetPosition, moveSpeed * Time.deltaTime);
    
        }   
    else
        {
            if (!hasPlayedStartAnim)
            {
                ran.anim.Play("CatSimple_Sit_start");
                hasPlayedStartAnim = true;
                }
        if (!waiting)
            {
          
           if (!ran.anim.GetCurrentAnimatorStateInfo(0).IsName("CatSimple_Sit_loop_2") && time_to_toilet>1.2)
                {
                ran.anim.Play("CatSimple_Sit_loop_2");
                }
            time_to_toilet += Time.deltaTime;
            }
        if (time_to_toilet > toilet_finish)
            {
            waiting = true;
            ran.anim.Play("CatSimple_Sit_end");
           Invoke("ResetToiletTime", 1f);
            }
        }
    }

private void ResetToiletTime()
{
    print("hello");
    randommove ran  = GetComponent<randommove>();
    time_to_toilet = 0;
    ran.toiletTime =0f;
    hasPlayedStartAnim = false;
    waiting = false;
}
}