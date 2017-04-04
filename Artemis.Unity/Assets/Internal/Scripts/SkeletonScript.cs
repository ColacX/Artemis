using UnityEngine;
using System.Collections;

public class SkeletonScript : MonoBehaviour {

	private Animation animationComponent;

	// Use this for initialization
	void Start () {
		animationComponent = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {

		if(!animationComponent.isPlaying)
		{
			animationComponent.Play();
		}
	}
}
