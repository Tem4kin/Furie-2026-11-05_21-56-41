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
        rb.AddForce(speed.x, 0, speed.y);
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
        //rb.AddForce(speed);
    }
}