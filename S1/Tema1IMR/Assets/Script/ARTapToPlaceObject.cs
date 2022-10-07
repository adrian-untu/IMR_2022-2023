using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlaceObject : MonoBehaviour
{

    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;
    private GameObject spawnedObject1;
    private GameObject spawnedObject2;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    private Animator mAnimator;

    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        mAnimator = GetComponent<Animator>();
    }

    // need to update placement indicator, placement pose and spawn 
    void Update()
    {
        if (spawnedObject1 == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject(spawnedObject1);
        }
        /*if (spawnedObject1 != null && spawnedObject2 == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject(spawnedObject2);


            spawnedObject1.GetComponent<Animator>().SetTrigger("TrAttack");
            spawnedObject2.GetComponent<Animator>().SetTrigger("TrAttack");
        }*/
        if (spawnedObject1 != null && spawnedObject2 == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject(spawnedObject2);

            float distance = Vector3.Distance(spawnedObject1.GetComponent<Transform>().position, spawnedObject2.GetComponent<Transform>().position);

            if (distance < 0.5)
            {
                spawnedObject1.GetComponent<Animator>().SetTrigger("TrAttack");
                spawnedObject2.GetComponent<Animator>().SetTrigger("TrAttack");
            }
        }


        UpdatePlacementPose();
            UpdatePlacementIndicator();
        
    }
    void UpdatePlacementIndicator()
    {
        if (spawnedObject1 == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;
        }
    }

    void ARPlaceObject(GameObject spawnedObject)
    {
        spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation);
    }


}