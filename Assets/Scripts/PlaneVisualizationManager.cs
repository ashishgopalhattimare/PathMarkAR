using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using GoogleARCore.Examples.HelloAR;
using GoogleARCore.Examples.Common;

public class PlaneVisualizationManager : MonoBehaviour {

    public GameObject TrackedPlanePrefab;
    private List<DetectedPlane> _newPlanes = new List<DetectedPlane>();
    
	void Update ()
	{
		Session.GetTrackables<DetectedPlane>(_newPlanes, TrackableQueryFilter.New);
	    
	    foreach (var curPlane in _newPlanes)
	    {
	        var planeObject = Instantiate(TrackedPlanePrefab, Vector3.zero, Quaternion.identity,transform);
	        planeObject.GetComponent<DetectedPlaneVisualizer>().Initialize(curPlane);

	        planeObject.GetComponent<Renderer>().material.SetColor("_GridColor", new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f)));
	        planeObject.GetComponent<Renderer>().material.SetFloat("_UvRotation", Random.Range(0.0f, 360.0f));
	    }
    }
}