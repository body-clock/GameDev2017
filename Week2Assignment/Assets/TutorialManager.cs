using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
	//tutorial specific UI
	public GameObject leftClick;
	public GameObject moveCursor;
	
	//ui elements
	public GameObject boostUI;

	public GameObject car;
	public GameObject cashPrefab;
	
	public bool cursorMoved = false;
	public bool mouseClicked = false;
	
	private Transform carBeginTransform;
	private Transform carCurrentTransform;

	private Vector3 exampleVector;

	public Animator cursorAnim;

	// Use this for initialization
	void Start ()
	{
		carBeginTransform = car.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{

		carCurrentTransform = car.transform;
		
		if (!cursorMoved)
		{
			if (carCurrentTransform.position.x < -4 || carBeginTransform.position.x > 4)
			{
				iTween.FadeTo(moveCursor, 1, 2);
				GameObject.Destroy(moveCursor);
				
				cursorMoved = true;
			}
		}

		if (cursorMoved)
		{
			
			leftClick.SetActive(true);
			if (!mouseClicked)
			{
				if (Input.GetMouseButtonDown(0))
				{
					mouseClicked = true;
					GameObject.Destroy(leftClick);
					boostUI.SetActive(true);
				}
			}
		}
		
	}

	void SpawnExample(GameObject prefab)
	{
		int randomX = Random.Range(-4, 4);
		exampleVector = new Vector3(randomX, 10, 0);
		Instantiate(prefab, exampleVector, Quaternion.identity);
	}
}
