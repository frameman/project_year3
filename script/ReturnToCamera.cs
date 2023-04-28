using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class ReturnToCamera : MonoBehaviour
{
    //public GameObject cameraToLookAt; // Assign the camera component to this variable in the Inspector
    public Camera cameraToLookAt;
    public float moveSpeed = 0.5f; // Speed at which the object moves towards the camera
    public float maxRotationAngle = 5f;
    public float fixedDistance = 2f; // Distance to keep the object from the camera
    public Animator animation;
    public bool _calling = true;
   // public void Update(){
   //     find_master();
   // }


    public void find_master()
    {
         ReturnToCamera2 objectToCamera = GetComponent<ReturnToCamera2>();
        if (objectToCamera == null)
            {
                gameObject.AddComponent<ReturnToCamera2>();
                return;
            }
       
        /*if (GetComponent<ARCameraManager>() == null)
        {
             cameraToLookAt = GameObject.Find("AR Camera");
            return;
        }*/

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
         if (distanceToTarget >= fixedDistance){
                animation.Play("atSimple_Walk_F_IPP");
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                print("distanceToTarget = " + distanceToTarget);
            }
            else{
                animation.Play("CatSimple_SharpenClaws_Vert");
            }
    }

}

