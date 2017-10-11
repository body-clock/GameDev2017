using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBar : MonoBehaviour
{

	public static BoostBar instance;
	public Turret turretScript;

	// Use this for initialization
	void Start ()
	{
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		ReduceBoost();
	}

	void ReduceBoost()
	{
		transform.localScale = new Vector3(turretScript.currentBoost / turretScript.totalBoost, .7f, 1);
	}
}
