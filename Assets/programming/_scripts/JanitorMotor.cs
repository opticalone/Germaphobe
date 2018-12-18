using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanitorMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 vel = Vector3.zero;
    private Vector3 rot = Vector3.zero;
    private float camRotX = 0;
    private float currentCamRotX = 0;

    [SerializeField]
    private float cameraRotateLimit = 89f;
    private Rigidbody rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

    public void Move(Vector3 _vel) //get move vector
    {
        vel = _vel;
    }
    public void Rotate(Vector3 _rot) // get rotation vector
    {
        rot = _rot;
    }
    public void CameraRotate(float _camRotate)
    {
        camRotX = _camRotate;
    }
	// Update is called once per frame
	void Update () {
        doRotate();
	}
    private void LateUpdate()
    {
        doMove();
    }

    void doMove()
    {
        if (vel != Vector3.zero)
        {
            rb.MovePosition(rb.position + vel * Time.fixedDeltaTime);
        }        
    }
    void doRotate()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rot));
        if (cam!=null)
        {
            currentCamRotX += camRotX;
            currentCamRotX = Mathf.Clamp(currentCamRotX, -cameraRotateLimit, cameraRotateLimit);
            cam.transform.localEulerAngles = new Vector3(currentCamRotX, 0, 0);
        }

    }
}
