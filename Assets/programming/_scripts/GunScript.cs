using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunScript : MonoBehaviour {

    public ParticleSystem particle;
    public TextMeshProUGUI text;
    public int counter;
    public List<ParticleCollisionEvent> collisionEvents;

	// Use this for initialization
	void Start () {
        collisionEvents = new List<ParticleCollisionEvent>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            particle.Play();

        }
       
	}
    private void OnParticleCollision(GameObject other)
    {
        int colEvents = particle.GetCollisionEvents(other, collisionEvents);
        if (other.gameObject.tag == "Enemy")
        {
            counter++;
            text.text = counter.ToString();
        }
    }


}
