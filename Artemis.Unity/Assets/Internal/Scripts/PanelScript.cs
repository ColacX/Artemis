using UnityEngine;
using System.Collections;

public class PanelScript : MonoBehaviour {
    public Quaternion fromRotation;
    public Vector3 fromPosition;

    private Transform mTransform;
    private float mProgress = 0.0f;
    private Vector3 defaultPosition;
    
    // Use this for initialization
    void Start () {
        mTransform = GetComponent<Transform>();
        defaultPosition = mTransform.position;
        UpdateTransform();
    }
	
	// Update is called once per frame
	void Update () {
        UpdateTransform();

        mProgress += 0.01f;
        if(mProgress > 1.0f)
        {
            mProgress = 1.0f;
        }
	}

    void UpdateTransform()
    {
        mTransform.localRotation = Quaternion.Slerp(fromRotation * Quaternion.AngleAxis(90, new Vector3(1, 0, 0)),
            Quaternion.identity,
            mProgress
        );

        mTransform.position = Vector3.Slerp(fromPosition,
            new Vector3(12.0f, 0.0f, 0.0f), //why 12?
            mProgress);

        mTransform.localScale = Vector3.Slerp(new Vector3(0.1f, 0.1f, 0.1f),
            new Vector3(1.0f, 1.0f, 1.0f),
            mProgress);
    }
}
