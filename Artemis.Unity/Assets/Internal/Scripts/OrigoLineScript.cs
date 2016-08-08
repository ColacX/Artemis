using UnityEngine;
using System.Collections;

public class OrigoLineScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(Vector3.zero, this.transform.position, Color.red, Time.deltaTime, false);
	}
}
