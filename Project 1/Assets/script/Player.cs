using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PlayerController))]
[RequireComponent (typeof (GunController))]
public class Player : HP {

	public float moveSpeed =5;

    PlayerController controller;
    Camera ViewCamera;
    GunController gunController;

	protected override void Start () {
        base.Start();
        controller = GetComponent<PlayerController>();
        ViewCamera = Camera.main;
        gunController = GetComponent<GunController>();
	}
	
	
	void Update () {
        //이동 입력
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        //바라보는 곳 입력
        Ray ray = ViewCamera.ScreenPointToRay(Input.mousePosition);
        Plane GroundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (GroundPlane.Raycast(ray, out rayDistance )) {
            Vector3 point = ray.GetPoint(rayDistance);
            //Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);
        }

        //무기조작 입력
        if(Input.GetMouseButton(0))
        {
            gunController.Shoot();
        }
	}
}
