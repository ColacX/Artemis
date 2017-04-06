using UnityEngine;
using System.Collections;
using Vuforia;
using System;

public class ShakeReducerScript : MonoBehaviour, ITrackableEventHandler
{

	public GameObject target;

	private float slerp = 0.1f;
	private Vector3 position = Vector3.zero;
	private Quaternion rotation = Quaternion.identity;
	private TrackableBehaviour mTrackableBehaviour;

	// Use this for initialization
	void Start()
	{
		mTrackableBehaviour = target.GetComponent<TrackableBehaviour>();
		if(mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.Slerp(this.transform.position, target.transform.position, slerp);
		transform.rotation = Quaternion.Slerp(this.transform.rotation, target.transform.rotation, slerp);
	}

	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
	{
		if(newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
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
