using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{

	//simple script to scroll our background
	public float bgSpeed = 1f;
	
	void Update ()
	{
		MeshRenderer mr = GetComponent<MeshRenderer>();

		Material mat = mr.material;

		Vector2 offset = mat.mainTextureOffset;

		offset.y += bgSpeed * Time.deltaTime;
		
		mat.mainTextureOffset = offset;

	}
}
