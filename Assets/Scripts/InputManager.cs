using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

public class InputManager : MonoBehaviour {

	public static int MAX_LEN = 1000;

	public GameObject arrowGameObject;
	// Use this for initialization

	private Vector3[] hitArr;		// default path setter
	private Vector3[] path1Array,	// path1 
					  path2Array;	// path2

	private GameObject[] gameArray;

	private int i;					// Number of vector points in the path
	private int len, k;				// path variables

	private int path1Len, path2Len;
	
	public float speed;

	public GameObject followPrefab;
	private GameObject travellingSalesman;

	private int followPathBool;

	public static bool rabitVisible;

	void Start () {
		initialize();

		path1Array = new Vector3[MAX_LEN];
		path2Array = new Vector3[MAX_LEN];

		gameArray  = new GameObject[MAX_LEN];

		path1Len = 0; path2Len = 0;

		rabitVisible = false; // initial not visible state
	}

	public void initialize() {

		hitArr = new Vector3[MAX_LEN];
		i = 0;
		len = -1;
		followPathBool = 0;
		speed = 0.55f;
	}
	
	// Update is called once per frame
	void Update () {

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

		// When follow button is pressed
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

    public void deleteArrows() {

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