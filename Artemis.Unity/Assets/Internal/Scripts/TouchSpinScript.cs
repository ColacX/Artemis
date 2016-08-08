using UnityEngine;

public class TouchSpinScript : MonoBehaviour {

    bool isPressed;
    Vector3 pressedPosition;
    Quaternion pressedRotation;
    float pressedTime;

    new Collider collider;
    Rigidbody rigidBody;

    // Use this for initialization
    void Start()
    {
        collider = GetComponent<Collider>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            var isHit = Physics.Raycast(ray, out hitInfo);

            if(!isHit) return;
            if(hitInfo.collider != collider) return;

            //Debug.Log("Pressed");
            isPressed = true;
            pressedPosition = Input.mousePosition;
            pressedRotation = transform.rotation;
            pressedTime = Time.time;
        }

        if(isPressed)
        {
            //Debug.Log("Drag");
            var delta = Input.mousePosition - pressedPosition;
            var crossVector = Vector3.Cross(new Vector3(delta.x, delta.y, 0).normalized, new Vector3(0, 0, 1));
            //m_transform.rotation = Quaternion.Euler(delta.y, -delta.x, 0) * pressedRotation;
            transform.rotation = Quaternion.AngleAxis(delta.magnitude, crossVector) * pressedRotation;
            rigidBody.angularVelocity = Vector3.zero;
        }

        if(Input.GetMouseButtonUp(0))
        {
            //Debug.Log("Released");
            isPressed = false;
            var delta = Input.mousePosition - pressedPosition;
            var deltaTime = Time.time - pressedTime;
            //Debug.Log(deltaTime);
            if(deltaTime < 0.200f)
            {
                rigidBody.AddTorque(new Vector3(delta.y, -delta.x));
            }
        }
    }
}
