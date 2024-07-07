using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 maxPosition;
    public Vector3 minPosition;

    public float cameraSpeed = 5f;
    public float panBorderThickness = 50f;

    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * cameraSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * cameraSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime, Space.World);
        }

        Vector3 currentPos = transform.position;
        
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        currentPos.y -= scroll * cameraSpeed * 50f * Time.deltaTime;

        currentPos.x = Mathf.Clamp(currentPos.x, minPosition.x, maxPosition.x);
        currentPos.y = Mathf.Clamp(currentPos.y, minPosition.y, maxPosition.y);
        currentPos.z = Mathf.Clamp(currentPos.z, minPosition.z, maxPosition.z);
        transform.position = currentPos;
    }
}
