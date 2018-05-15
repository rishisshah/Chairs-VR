using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingMonster : MonoBehaviour {

    public Transform player;
    public float speed = 0.1F;
    private Vector3 directionOfCharacter;
    public int numberOfHits;

	//public GameObject explosionPrefab;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "projectile")
        {
            if (numberOfHits == 0)
			{
				Destroy(gameObject); //inactivates object
			}
			else
				numberOfHits--; //subtract number of hits that enemy can take
        }
    }

    // Update is called once per frame
    void Update () {
        directionOfCharacter = player.transform.position - transform.position;
        directionOfCharacter = directionOfCharacter.normalized;
        transform.Translate(directionOfCharacter * speed, Space.World);
		//Debug.Log("VELOCITY OF CHAIR " + GetComponent<Rigidbody>().velocity);
	}
}
