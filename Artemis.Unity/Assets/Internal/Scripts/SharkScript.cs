using UnityEngine;
using System.Collections;
using Vuforia;
using System;

public class SharkScript : MonoBehaviour, ITrackableEventHandler
{
	public GameObject sharkPrefab;
	public GameObject chaseTarget;
	private GameObject instanceClone;

	// Use this for initialization
	void Start () {
		var mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if(mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
	{
		if(newStatus == TrackableBehaviour.Status.DETECTED ||
				newStatus == TrackableBehaviour.Status.TRACKED ||
				newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			instanceClone = Instantiate(sharkPrefab);
			instanceClone.transform.rotation = Quaternion.Euler(90, 180, 0) * transform.rotation;
			instanceClone.transform.position = transform.position;
			instanceClone.GetComponent<SharkChaseAttackScript>().chaseTarget = chaseTarget;
		}
		else
		{
			if(instanceClone)
			{
				Destroy(instanceClone);
			}
		}
	}
}
