using UnityEngine;

public class ReturnToCamera2 : MonoBehaviour
{
    public Camera cameraToLookAt; // Assign the camera component to this variable in the Inspector
    public float moveSpeed = 100f; // Speed at which the object moves towards the camera
    public float maxRotationAngle = 5f;
    public float fixedDistance = 200f; // Distance to keep the object from the camera
    public actives Act;
    public Animator animation;
    public bool _go = false;
    public bool sit = true;

    void Update()
    {
        randommove ran = GetComponent<randommove>();
        if(Act.moveTo2 && ran.turning)
        {
          _go = true;
        }
        else if(Act.moveTo0){
            _go = false;
            ran._come = true;
           
        }
        if(_go){
            moveto();
            
        }
    }
    public void moveto(){
            randommove ran = GetComponent<randommove>();
            ran._come =false;
            
            ReturnToCamera2 objectToCamera = GetComponent<ReturnToCamera2>();

            // If the object is not staying in front of the camera yet, attach the ReturnToCamera script
            if (objectToCamera == null)
            {
                gameObject.AddComponent<ReturnToCamera2>();
                return;
            }

            Vector3 cameraPosition = cameraToLookAt.transform.position;
            Vector3 objectPosition = transform.position;
            Vector3 direction = cameraPosition - objectPosition;
            direction.y = 0f; // Set y component to 0
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxRotationAngle);

        // Calculate the target position of the object based on the camera position and forward vector
            Vector3 targetPosition = cameraPosition + cameraToLookAt.transform.forward * fixedDistance;
            targetPosition.y = objectPosition.y;
         // Move the object towards the target position

            
            float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
            if (distanceToTarget >= fixedDistance )
            {
                animation.Play("atSimple_Walk_F_IPP");
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                print("distanceToTarget = " + distanceToTarget);
                sit = true;
                
            }
            else{
                print(sit);
                if(sit){
                    animation.Play("CatSimple_Lie_belly_start");
                    Invoke("ResetToiletTime", 1f);
                    
                }
                else{
                    animation.Play("CatSimple_Lie_belly_loop_2");
                }
            }
    
            
    }


private void ResetToiletTime()
    {
    sit = false;
    }
}
