using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager rayManager;
    private GameObject visual;
    // Start is called before the first frame update
    void Start()
    {
        rayManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;
        //hide placement indicator

        visual.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        //shoot raycast from center of screen
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2),
        hits, TrackableType.Planes);
        //if we hit AR plane update position and rotation
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
            if (!visual.activeInHierarchy)
                visual.SetActive(true);
        }
    }
}