using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{ 
//private Transform AstroMan;
//public bool debug;
//void Start()
//{
//	Screen.SetResolution(256, 240, true, 60);
//	AstroMan = GameObject.Find("AstroMan").transform;
//}
//void Update()
//{
//	if (AstroMan.position.x > transform.position.x || debug)
//	{
//		transform.position = new Vector3(AstroMan.position.x, transform.position.y, -10);
//	}
//}
//}
    [SerializeField] Transform AstroMan;
    [SerializeField] float sensetyCam = 5;
    Transform cameraTransform;
    Vector3 deltaPosCam;
    Vector3 target;

    void Start()
    {
        cameraTransform = transform;
        deltaPosCam = cameraTransform.position - AstroMan.position;
        deltaPosCam.z = -10;
    }

    void FixedUpdate()
    {
        target = AstroMan.transform.position + deltaPosCam;
        cameraTransform.position = Vector3.MoveTowards(cameraTransform.position, target, Time.deltaTime * sensetyCam);
    }
}

