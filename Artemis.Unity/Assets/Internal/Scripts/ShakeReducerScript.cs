using UnityEngine;
using System.Collections;
using Vuforia;

public class ShakeReducerScript : MonoBehaviour {
	
	public GameObject target;

	private float slerp = 0.1f;
	private Vector3 oldPosition;
	private Quaternion oldRotation;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//var parent = GetComponentInParent(typeof(Transform));
		//Debug.Log("parent position: " + parent.transform.position);
		//var newPosition = transform.position;

		
		transform.position = Vector3.Slerp(this.transform.position, target.transform.position, slerp);
		transform.rotation = Quaternion.Slerp(this.transform.rotation, target.transform.rotation, slerp);

		var tracker = target.GetComponent<DefaultTrackableEventHandler>();
		if(tracker.Found)
		{
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

			// Enable rendering:
			foreach(Renderer component in rendererComponents)
			{
				component.enabled = true;
			}

			// Enable colliders:
			foreach(Collider component in colliderComponents)
			{
				component.enabled = true;
			}
		}
		else
		{
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

			// Disable rendering:
			foreach(Renderer component in rendererComponents)
			{
				component.enabled = false;
			}

			// Disable colliders:
			foreach(Collider component in colliderComponents)
			{
				component.enabled = false;
			}
		}

		Debug.Log("Found: " + tracker.Found);
		//this.transform.position = target.transform.position;
		//this.transform.rotation = target.transform.rotation;

		//transform.localPosition = oldPosition - newPosition;

		//oldPosition = newPosition;
		//oldRotation = transform.rotation;
	}
}
