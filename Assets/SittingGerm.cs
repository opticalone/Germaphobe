using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingGerm : MonoBehaviour {

    int health = 50;
    [SerializeField]
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update () {
        if (health <= 0)
        {
            anim.SetBool("IsDead", true);
            //StartCoroutine(killMe());

        }
    }
    private void OnParticleCollision(GameObject other)
    {
        health--;
        
        Debug.Log("health on" + transform.name + " = " + health);
    }
    IEnumerator killMe()
    {
        
        yield return new WaitForSecondsRealtime(anim.playbackTime);
        gameObject.SetActive(false);
    }
}
