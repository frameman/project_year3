using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacement : MonoBehaviour
{
    public GameObject arObjectToSpawn;
    private GameObject spawnedObject;
    private Pose placementPose;
    private ARRaycastManager arRaycastManager;
    private bool placementPoseIsValid = false;
    public bool Running = false;
    
    [SerializeField]
    private GameObject visualCuePrefab;

    private GameObject visualCue;

    void Start()
    {   
        Debug.Log("start");
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        visualCue = Instantiate(visualCuePrefab, Vector3.zero, Quaternion.identity);
        visualCue.SetActive(false);
    }

    void Update()
    {
        UpdatePlacementPose();
        UpdateVisualCue();
        if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("ARPlaceObject");
            ARPlaceObject();
        }
    }

    void UpdatePlacementPose()
    {
        Debug.Log("UpdatePlacementPose");
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            Debug.Log("hits  1");
            placementPose = hits[0].pose;
        }
    }

    void UpdateVisualCue()
{
    if (placementPoseIsValid)
    {
        visualCue.SetActive(true);
        visualCue.transform.position = placementPose.position;
        visualCue.transform.rotation = placementPose.rotation;
    }
    else
    {
        visualCue.SetActive(false);
        visualCue.transform.position = Vector3.zero;
        visualCue.transform.rotation = Quaternion.identity;
    }
}


    void ARPlaceObject()
    {
        spawnedObject = Instantiate(arObjectToSpawn, placementPose.position, placementPose.rotation);
        Debug.Log("Object placed!");
    }

    
}
