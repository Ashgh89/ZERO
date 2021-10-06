using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float xOnRotation;
   // float yOnRotation;

    public float mouseSensitivity = 100f;
    public Transform player;

   
   
    // Start is called before the first frame update
    void Start()
    {
        //Hide mouse Cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame

    void LateUpdate()
    {
        float mouseY =  Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        float mouseX =  Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        

        xOnRotation -= mouseY;
        xOnRotation = Mathf.Clamp(xOnRotation, -90f, 90f);
        transform.localEulerAngles = new Vector3(xOnRotation, 0f, 0f);

        player.Rotate(Vector3.up * mouseX);
    }


   




}
