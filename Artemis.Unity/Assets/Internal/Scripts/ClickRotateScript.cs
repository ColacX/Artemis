using UnityEngine;
using System.Collections;

public class ClickRotateScript : MonoBehaviour {
    new Collider collider;
    Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        collider = GetComponent<Collider>();
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            var hit = Physics.Raycast(ray, out hitInfo);
            
            if(!hit) return;

            Debug.Log(hitInfo);
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red, Time.deltaTime, false);

            if(hitInfo.collider != collider) return;

            rigidBody.angularVelocity += new Vector3(0, 1);
        }
    }
}
