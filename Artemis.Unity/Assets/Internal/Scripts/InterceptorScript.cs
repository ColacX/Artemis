using UnityEngine;
using System.Collections;

public class InterceptorScript : MonoBehaviour {

    Vector3 nextPoint;
    float nextRadius = 0.1f;
    new Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        var delta = nextPoint - transform.position;

        if(delta.magnitude < 0.1f)
        {
            //calculate next navigation point
            nextPoint = new Vector3(
                Random.Range(-nextRadius, +nextRadius),
                Random.Range(-nextRadius, +nextRadius),
                Random.Range(-nextRadius, +nextRadius));
        }
        else
        {
            //move closer to the point
            rigidBody.AddForce(delta.normalized * 10);
        }
        
	}
}
