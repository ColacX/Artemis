using UnityEngine;
using System.Collections;
using Vuforia;

public class CameraScript : MonoBehaviour {

	public bool steroscopicMode = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			steroscopicMode = !steroscopicMode;

			if(steroscopicMode)
			{
				DigitalEyewearBehaviour.Instance.SetEyewearType(DigitalEyewearAbstractBehaviour.EyewearType.VideoSeeThrough);
				DigitalEyewearBehaviour.Instance.SetViewerActive(true, true);
			}
			else
			{
				DigitalEyewearBehaviour.Instance.SetEyewearType(DigitalEyewearAbstractBehaviour.EyewearType.None);
				DigitalEyewearBehaviour.Instance.SetViewerActive(false, true);
			}
		}
	}
}
