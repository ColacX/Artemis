using UnityEngine;
using System.Collections;

public class TestSceneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        ray.direction = ray.direction * 10000.0f;
        RaycastHit hitInfo;
        var isHit = Physics.Raycast(ray, out hitInfo, float.MaxValue);
        //var isHit = Physics.Raycast(ray.origin, ray.direction, out hitInfo);
        if(isHit)
        {
            Debug.Log("hit");
        }

        Debug.DrawLine(ray.origin, ray.direction * 1000.0f, Color.yellow, Time.deltaTime, false);
    }
}
