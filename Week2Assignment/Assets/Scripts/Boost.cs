using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost {

    public GameObject boostVisual;
    public int xCoord;
    public int yCoord;
    public string name;
    public Transform boostPos;

    public Vector3 screenPos;

    public static int frequency;

    public int scoreBonus = 10;
	

    public Boost()
    {
        //constructor - runs when we say "new"

        frequency = (int) UnityEngine.Random.Range(0, 1);    
		
        //casting a float as an int
        xCoord = (int) UnityEngine.Random.Range(-8f,8f);
        yCoord = (int) UnityEngine.Random.Range(5f,10f);

        //instantiating our visual with our prefab
        //setting the parent object to the formation object
        boostVisual = GameObject.Instantiate(EnemyManager.Instance.boostPrefab, new Vector3(xCoord, yCoord), Quaternion.identity);
        boostVisual.transform.parent = EnemyManager.Instance.enemyFormation.transform;
    }

}
