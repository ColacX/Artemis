using UnityEngine;
using System.Collections;
using System;

public class NewBehaviourScript : MonoBehaviour {
    public DateTime StartTime { get; set; }
    public float ElapsedTime { get; set; }

    // Use this for initialization
    void Start () {
        StartTime = DateTime.UtcNow;
	}
	
	// Update is called once per frame
	void Update () {
        ElapsedTime = (float)(DateTime.UtcNow - StartTime).TotalMilliseconds;
        var material = GetComponent<Renderer>().material;
        material.SetFloat("ElapsedTime", ElapsedTime);
    }
}
