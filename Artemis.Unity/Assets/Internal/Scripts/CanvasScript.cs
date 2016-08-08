using UnityEngine;
using System.Collections;

public class CanvasScript : MonoBehaviour {
    private Canvas mCanvas;

    // Use this for initialization
    void Start () {
        mCanvas = GetComponent<Canvas>();
        mCanvas.worldCamera = Camera.main;
        mCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        mCanvas.planeDistance = 5;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
