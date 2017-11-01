using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

	public static HealthBar instance;
	public Turret turretScript;

	void Start ()
	{
		instance = this;
	}

	private void Update()
	{
		ReduceHealth();
	}

	void ReduceHealth()
	{
		//changing the scale of our sprite in order to indicate decreasing health
		transform.localScale = new Vector3((turretScript.currentHealth / turretScript.totalHealth), .7f, 1);
	}
}
