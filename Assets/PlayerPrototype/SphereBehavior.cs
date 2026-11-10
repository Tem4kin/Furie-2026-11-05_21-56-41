using Unity.AppUI.UI;
using Unity.XR.OpenVR;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SphereBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 speed;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    async void Update()
    {
        /*if (speed == Vector2.zero)
        {
            rb.linearVelocity = new Vector3(0,0,0);
            rb.angularVelocity = new Vector3(0, 0, 0);
        }*/
        //transform.position = new Vector3(speed.x * 0.2f + rb.position.x, 1.1f, speed.y*0.2f + rb.position.z);
        //transform.Translate(speed.x * 0.1f, 0 , speed.y * 0.1f);
        //rb.MovePosition(new Vector3(speed.x * 0.2f + rb.position.x, 1.1f, speed.y * 0.2f + rb.position.z));
        rb.linearVelocity = new Vector3(speed.x*6, 0, speed.y*6);
        rb.angularVelocity = new Vector3(0, 0, 0);
    }

    public void OnJump(InputValue iv)
    {
        Debug.Log("TRY JUMP");
        if (iv.isPressed)
        {
            Debug.Log("JUMP");
            rb.AddForce(new Vector3(0f, 100f, 0f));
        }
    }

    public void OnMove(InputValue iv)
    {
        Debug.Log("MOVE?");
        speed = iv.Get<Vector2>();
    }
}