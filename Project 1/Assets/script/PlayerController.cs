﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class PlayerController : MonoBehaviour {

    Vector3 velocity;
    Rigidbody myRigidbody;

	void Start () {
        myRigidbody = GetComponent<Rigidbody> ();
	}
	
	public void LookAt(Vector3 LookPoint)
    {
        Vector3 HeightCorrectedPoint = new Vector3(LookPoint.x, transform.position.y, LookPoint.z);
        transform.LookAt(HeightCorrectedPoint);
    }

	public void Move (Vector3 _velocity) {
        velocity = _velocity;
    }

    void FixedUpdate(){
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
