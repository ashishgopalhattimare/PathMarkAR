using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

public class InputManager : MonoBehaviour {

	public static int MAX_LEN = 1000;		// Maximum length of the pathArray

	public GameObject arrowGameObject;		// Original instance of the arrow figure

	private Vector3[] hitArr;				// store the points of the current path
	private Vector3[] path1Array,			// store source to destination path of the location A
					  path2Array;			// store source to destination path of the location B

	private GameObject[] gameArray;			// store the drawable figure of the arrow on the flat plane

	private int i;							// Number of vector points in the current pathArray
	private int len, k;						// totalLength of the pathArray to be iterated or stored in location X

	private int path1Len, path2Len;			// length of the path of location A and B, respectively
	
	public float speed;						// manage the speed of the helper rabit

	public GameObject followPrefab;			// the original figure of the rabit
	private GameObject travellingSalesman;	// replicate the figure of the rabit for the application

	private int followPathBool;				// whether the path is to followed or not

	public static bool rabitVisible;		// whether the rabit is visible on the flat plane or not

	void Start ()
	{
		initialize();

		path1Array = new Vector3[MAX_LEN];		// create an array for the path1Array
		path2Array = new Vector3[MAX_LEN];		// create an array for the path2Array

		gameArray  = new GameObject[MAX_LEN];	// create an array of the arrow figure

		path1Len = 0; path2Len = 0;				// initialize the pathLen to 0

		rabitVisible = false; 					// initial not visible state
	}

	public void initialize()
	{
		hitArr = new Vector3[MAX_LEN];	// reset the current pathArray for the current path
		i = 0;							// set pathArray length to 0
		len = -1;						// set final pathArray length to -1 (for safety purposes)
		followPathBool = 0;				// set followPath Boolean to false, initially
		speed = 0.55f;					// set the speed of the helper rabit
	}
	
	void Update ()
	{
		if(Input.GetMouseButtonDown(0) && followPathBool == 0)
		{
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;

			if(Physics.Raycast(ray , out hitInfo))
			{
				hitArr[i] = hitInfo.point;
				var go  = GameObject.Instantiate(arrowGameObject , hitInfo.point , Quaternion.identity);
				go.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();

				gameArray[i] = go;
				i++;
			}
		}

		if(followPathBool == 1)
		{
			float step = speed * Time.deltaTime;
			
			if(k < len)
			{
				travellingSalesman.transform.position = Vector3.MoveTowards(travellingSalesman.transform.position, hitArr[k], step);

				Vector3 relativePos = hitArr[k] - travellingSalesman.transform.position;
				Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
				travellingSalesman.transform.rotation = rotation;

				if(travellingSalesman.transform.position == hitArr[k]) {
					k++;
				}
			}

			if(k == len) {
				followPathBool = 0;
				Destroy(travellingSalesman); // delete the instance

				reset();

				rabitVisible = false; // reset visibility to initial state	
			}
		}
	}
	 
	public void follow()
	{
		if(rabitVisible) { // already following
			Destroy(travellingSalesman);
		}

		followPathBool = 1;
		travellingSalesman =  GameObject.Instantiate(followPrefab , hitArr[0] , Quaternion.identity);

		len = i;
		k = 1;

		rabitVisible = true;
	}

	public void drawPath(Vector3[] arr, int limit) {

		for(int x = 0; x < limit; x++) {
			var go  = GameObject.Instantiate(arrowGameObject , arr[x] , Quaternion.identity);
			go.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();

			gameArray[x] = go;
		}
	}

	public void reset() {
		for(int x = 0; x < i; x++) {
			Destroy(gameArray[x]);
		}
		initialize(); // i = 0, len = 0

		if(rabitVisible) { // if rabit moving
			followPathBool = 0;
			rabitVisible = false;
			Destroy(travellingSalesman);

			rabitVisible = false;
		}
	}

	public void path1Save() {

		if(rabitVisible) return; // if rabit moving

		rabitVisible = true;
		path1Len = i; // n
		for(int x = 0; x < path1Len; x++) {
			path1Array[x] = hitArr[x];
		}
		reset();
		initialize();
	}

	public void followPath1() {

		if(rabitVisible == true) {
			Destroy(travellingSalesman); // current rabit Destroy
		}
		rabitVisible = true;

		for(int x = 0; x < path1Len; x++) {
			hitArr[x] = path1Array[x];
		}
		i = path1Len; // i = n

		drawPath(path1Array, path1Len); // redraw, gameArray store
		follow();
	}

	public void path2Save() {

		if(rabitVisible) return; // if rabit moving
		
		rabitVisible = true;
		path2Len = i; // n
		for(int x = 0; x < path2Len; x++) {
			path2Array[x] = hitArr[x];
		}
		reset();
		initialize();
	}

	public void followPath2() {

		if(rabitVisible == true) {
			Destroy(travellingSalesman); // current rabit Destroy
		}
		rabitVisible = true;
		
		for(int x = 0; x < path2Len; x++) {
			hitArr[x] = path2Array[x];
		}
		i = path2Len; // i = n

		drawPath(path2Array, path2Len); // redraw, gameArray store
		follow();


	}
}
