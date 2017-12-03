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
	public GameObject healthUI;
	public GameObject streakText;
	public GameObject streakCounterText;

	public GameObject car;
	public GameObject cashPrefab;
	public GameObject boostPrefab;
	public GameObject healthPrefab;
	public GameObject terrainPrefab;
	public GameObject enemyFormation;
	public GameObject terrainClump;
	public GameObject cashClump;
	
	private GameObject cashInstance;
	private GameObject boostInstance;
	private GameObject healthInstance;
	private GameObject terrainInstance;
	private GameObject streakInstance;
	
	public bool cursorMoved = false;
	public bool mouseClicked = false;
	public bool cashSpawned = false;
	public bool streakSpawned = false;
	public bool boostSpawned = false;
	public bool terrainSpawned = false;
	public bool healthSpawned = false;
	
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
		
		//demonstrating moving the cursor to move
		if (!cursorMoved)
		{
			if (carCurrentTransform.position.x < -4 || carBeginTransform.position.x > 4)
			{
				iTween.FadeTo(moveCursor, 1, 2);
				moveCursor.SetActive(!moveCursor.activeSelf);
				
				cursorMoved = true;
			}
		}
		
		//demonstrating boost function
		if (cursorMoved && !mouseClicked)
		{
			
			leftClick.SetActive(true);
			if (!mouseClicked)
			{
				if (Input.GetMouseButtonDown(0))
				{
					mouseClicked = true;
					leftClick.SetActive(false);
					boostUI.SetActive(true);
				}
			}
		}

		if (mouseClicked && !cashSpawned)
		{
			cashInstance = Instantiate(cashPrefab, new Vector3(-4, 10, 0), Quaternion.identity);
			cashSpawned = true;	
		}

		if (cashSpawned)
		{
			if (cashInstance != null)
			{
				cashInstance.transform.Translate(Vector3.down * 5 * Time.deltaTime);
			}
		}

		if (GameObject.FindGameObjectsWithTag("Bonus").Length == 0 && cashSpawned)
		{
			if (!streakSpawned)
			{
				for (int i = 0; i < 3; i++)
				{
					streakInstance = Instantiate(cashPrefab, new Vector3(i,10,0), Quaternion.identity);
					streakInstance.transform.parent = cashClump.transform;
				}
				streakSpawned = true;
			}
				
		}
		
		if (streakSpawned)
		{
			//make streak UI visible
			streakCounterText.SetActive(true);
			streakText.SetActive(true);
			cashClump.transform.Translate(Vector3.down * 5 * Time.deltaTime);
		}
		
		if (GameObject.FindGameObjectsWithTag("Bonus").Length == 0 && streakSpawned)
		{
			if (!boostSpawned)
			{
				boostInstance = Instantiate(boostPrefab, new Vector3(4,10,0), Quaternion.identity);
				boostSpawned = true;
			}
				
		}

		if (boostSpawned)
		{
			if (boostInstance != null)
			{
				boostInstance.transform.Translate(Vector3.down * 5 * Time.deltaTime);
			}
		}

		if (GameObject.FindGameObjectsWithTag("Boost").Length == 0 && boostSpawned)
		{
			if (!terrainSpawned)
			{
				for (int i = 0; i < 5; i++)
				{
					terrainInstance = Instantiate(terrainPrefab, new Vector3(i, 10, 0), Quaternion.identity);
					terrainInstance.transform.parent = terrainClump.transform;
				}
				terrainSpawned = true;
			}

			if (terrainSpawned)
			{
				if (terrainInstance != null)
				{
					terrainClump.transform.Translate(Vector3.down * 5 * Time.deltaTime);
					healthUI.SetActive(true);
				}
			}
			
		}

		if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && terrainSpawned)
		{
			if (!healthSpawned)
			{
				healthInstance = Instantiate(healthPrefab, new Vector3(0,10,0), Quaternion.identity);
				healthSpawned = true;
			}
			
			if (healthSpawned)
			{
				if (healthInstance != null)
				{
					healthInstance.transform.Translate(Vector3.down * 5 * Time.deltaTime);
				}
			}
		}

		
	}

}
