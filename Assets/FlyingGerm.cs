using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingGerm : MonoBehaviour {


    Rigidbody rb;
    [SerializeField]
    Transform target;
    public float attackThreshold;
    Animator anim;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        target = FindObjectOfType<JanitorController>().transform;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target.position);
        rb.AddForce(transform.forward, ForceMode.Force);
        if (Vector3.Distance(transform.position, target.transform.position) <= attackThreshold)
        {
            anim.SetBool("ShouldExplode", true);
        }
   
        
	}

   
}
