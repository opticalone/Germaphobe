using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GermAi : MonoBehaviour {


    NavMeshAgent agent;
    public Transform target;

    [Header("things")]
    public int health = 10;
    public float attackThreshold;
    public FlyingGerm fg;
    // Use this for initialization

    Vector3 Pos;
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<JanitorController>().transform;
    
     
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(target.position);
        if (health<=0)
        {
            gameObject.SetActive(false);
        
        }
        if (Vector3.Distance(transform.position, target.transform.position) > attackThreshold)
        {
          
        }
        else
        {
            Barf();
        }
    }

    private void Barf()
    {
        Instantiate(fg);
    }

    //private void LateUpdate()
    //{
    //    FindObjectsOfTypeAll();
    //}
    private void OnParticleCollision(GameObject other)
    {
        health--;
        Debug.Log("health on" + transform.name + " = " + health);
    }
    
}
