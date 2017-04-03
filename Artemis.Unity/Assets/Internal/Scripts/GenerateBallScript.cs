using UnityEngine;
using System.Collections;
using Vuforia;
using System;

public class GenerateBallScript : MonoBehaviour, ITrackableEventHandler
{
	public GameObject instanceObject;

	private GameObject instanceClone;
	private TrackableBehaviour mTrackableBehaviour;
	private Transform mTransform;

	// Use this for initialization
	void Start()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if(mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
		mTransform = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
	{
		Debug.Log(previousStatus);
		Debug.Log(newStatus);

		if(newStatus == TrackableBehaviour.Status.TRACKED)
		{
			instanceClone = Instantiate(instanceObject);
			instanceClone.transform.rotation = mTransform.localRotation;
			instanceClone.transform.position = mTransform.localPosition;
		}
		else if(newStatus == TrackableBehaviour.Status.NOT_FOUND)
		{
			if(instanceClone)
			{
				Destroy(instanceClone);
			}
		}
	}
}
