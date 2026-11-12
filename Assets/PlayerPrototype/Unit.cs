using System.Drawing;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody body;
    public Transform Player;

    public Transform Home;

    public TriggerArea TriggerArea;

    public float speed;

    public float area;
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist=Vector3.Distance(transform.position, Player.position);

        Debug.Log("Дистанция"+dist);
        Debug.Log("Дистанция по x " + (transform.position.x - Player.position.x));
        Debug.Log("Дистанция по z " + (transform.position.z - Player.position.z));

        if (dist < area)
        {
            Arg();
        }
        else
        {
            GoHome();
        }    
    }

    void Arg()
    {
        if (transform.position != Player.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
            Vector3 derection =transform.position - Player.position;

            Quaternion rotation =Quaternion.LookRotation(derection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5f * Time.deltaTime);
        }
        //if (Player.position.x < transform.position.x && Player.position.z < transform.position.z)
        //{
        //    body.linearVelocity = new Vector3(-speed, 0, -speed);
        //    Quaternion rotation = Quaternion.LookRotation(body.linearVelocity);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 0.025f);
        //}
        //else if (Player.position.x > transform.position.x && Player.position.z < transform.position.z)
        //{
        //    body.linearVelocity = new Vector3(speed, 0, -speed);
        //    Quaternion rotation = Quaternion.LookRotation(body.linearVelocity);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 0.025f);
        //}
        //else if (Player.position.x > transform.position.x && Player.position.z > transform.position.z)
        //{
        //    body.linearVelocity = new Vector3(speed, 0, speed);
        //    Quaternion rotation = Quaternion.LookRotation(body.linearVelocity);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 0.025f);
        //}
        //else { body.linearVelocity = new Vector3(-speed, 0, speed); Quaternion rotation = Quaternion.LookRotation(body.linearVelocity); transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 0.025f); }
    }

    void GoHome()
    {
        if (transform.position != Home.position)
        {
            transform.position =Vector3.MoveTowards(transform.position,Home.position,speed* Time.deltaTime);
            Vector3 derection = transform.position - Home.position;
            Quaternion rotation = Quaternion.LookRotation(derection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5f * Time.deltaTime);
        }
        
    }
}
