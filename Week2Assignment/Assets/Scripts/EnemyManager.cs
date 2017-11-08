using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class EnemyManager : MonoBehaviour
{
    //get prefabs
    public GameObject terrainPrefab;
    public GameObject cashPrefab;
    public GameObject boostPrefab;
    public GameObject healthPrefab;
    public GameObject currentPoint;
    public GameObject spawnedObject;

    public GameObject enemyFormation;

    public GameObject[] obstaclePrefabs;
    public List<GameObject> spawnedObjects;

    public int xCount = 10;
    public int yCount = 5;
    public int buffer = 8;
    public int index;
    public float spacing = 1;
    public float speed = 5f;
    public float randomValue = 0;

    public bool formationSpawned = false;

    public Turret turretScript;

    public int waveCounter = 0;
    
    //create grid
    
    //when enemy count is == 0
        //instantiate prefabs at points on the grid in nested for loop
    
    //add all objects as child of formation
    
    //move formation down

    private void Start()
    {
        obstaclePrefabs = new GameObject[] {cashPrefab,boostPrefab};
    }

    private void Update()
    {
        if (enemyFormation.transform.childCount == 0)
        {
            SpawnEnemies();
            turretScript.streakCounter = 0;
            waveCounter++;
            
            if (waveCounter % 5 == 0)
            {
                speed *= 1.13f;
            }
        }
        
        MoveFormationDown();
        
    }

    void SpawnEnemies()
    {
        for (int i = 0 + buffer; i < yCount + buffer; i++)
        {
            for (int j = 0 - buffer; j < xCount - buffer; j++)
            {
                
                //get random value
                //set currentpoint to gameobject depending on frequency
                //instantiate current point

                randomValue = Random.value;
                index = Random.Range(0, obstaclePrefabs.Length);
                float offset = Random.Range(-1f, 1f);
                
                //spawning objects based on probability 
                if (randomValue < .7)
                {
                    //spawn terrain
                    currentPoint = terrainPrefab;
                } else if (randomValue > .7 && randomValue <= .8)
                {
                    //spawn anything
                    currentPoint = cashPrefab;
                }else if (randomValue > .8 && randomValue < .85)
                {
                    currentPoint = boostPrefab;
                } 
                else if (randomValue > .97)
                {
                    //spawn health
                    currentPoint = healthPrefab;
                }

                spawnedObject = Instantiate(currentPoint, 
                    new Vector3(j+offset * spacing, i+offset * spacing, 0), transform.rotation);
                
                spawnedObject.transform.parent = enemyFormation.transform; 
                
                spawnedObjects.Add(spawnedObject);
                
                j++;

            }
            i++;
        }
        formationSpawned = true;
        randomValue = 0;
    }

    void MoveFormationDown()
    {
        enemyFormation.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    
}
