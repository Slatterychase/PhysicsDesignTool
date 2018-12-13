using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonAnimatedProp : MonoBehaviour {
    private Rigidbody rb;
    public float speed = 1.0f;
    private float startTime;
    private float journeyLength; 
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(rb.velocity.sqrMagnitude < 0.1f)
        {
            Debug.Log(rb.velocity.sqrMagnitude);
            startTime = Time.time;
            rb.isKinematic = true;
            Vector3 drop = new Vector3(0, 5.0f, 0);
            Vector3 changedDirection = new Vector3(0, 0, 0);
            Vector3 start = gameObject.transform.position;
            changedDirection =  gameObject.transform.position - drop;
            journeyLength = Vector3.Distance(gameObject.transform.position, changedDirection);
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(start, changedDirection, fracJourney);
        }
	}
}
