using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanitorController : MonoBehaviour {

    public float speed = 10f;
    public float lookSensitivity = 3;
    
    //component cache
    private JanitorMotor motor;

	// Use this for initialization
	void Start () {
        motor = GetComponent<JanitorMotor>();
        Cursor.lockState = CursorLockMode.Confined;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float xMove = Input.GetAxis("Horizontal");                          //calc movement
        float yMove = Input.GetAxis("Vertical");
        Vector3 _moveHorizontal = transform.right * xMove;
        Vector3 _moveVertical = transform.forward * yMove;                  

        Vector3 _velocity = (_moveHorizontal + _moveVertical) * speed;      //calculate final movement vector
        motor.Move(_velocity);                                              //apply movement


        float _yRot = Input.GetAxisRaw("Mouse X");                          // calculate player rotation
        Vector3 _rotation = new Vector3(0, _yRot,0)* lookSensitivity;       //add sensitivities
        motor.Rotate(_rotation);                                            //do it

        float _xRot = Input.GetAxisRaw("Mouse Y");                          //calculate camera rotate
        float _camRotx = _xRot * lookSensitivity;                           //add  sense
        motor.CameraRotate(-_camRotx);                                       //do
	}
}
