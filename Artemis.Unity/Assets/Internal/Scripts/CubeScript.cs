using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour
{
    BoxCollider boxCollider;

    // Use this for initialization
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
    }
}
