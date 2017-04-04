using UnityEngine;
using System.Collections;
using Vuforia;

public class ShakeReducerScript : MonoBehaviour {
	
	public GameObject target;

	private float slerp = 0.1f;
	private Vector3 position = Vector3.zero;
	private Quaternion rotation = Quaternion.identity;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
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
	}
}
