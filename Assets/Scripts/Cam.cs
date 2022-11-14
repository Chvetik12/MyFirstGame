using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour { 
private Transform AstroMan;

public bool debug;


void Start()
{
	Screen.SetResolution(256, 240, true, 60);
	AstroMan = GameObject.Find("AstroMan").transform;
}


void Update()
{
	if (AstroMan.position.x > transform.position.x || debug)
	{
		transform.position = new Vector3(AstroMan.position.x, transform.position.y, -10);
	}
}
}

