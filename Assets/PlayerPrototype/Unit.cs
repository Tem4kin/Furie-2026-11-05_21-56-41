using System.Drawing;
using Unity.AppUI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //public Rigidbody body;
    public Transform Player;

    public Transform Home;

    public TriggerArea TriggerArea;

    public float speed;

    public float area;
    
    private NavMeshAgent agent;
    void Start()
    {
       // body = GetComponent<Rigidbody>();
        agent=GetComponent<NavMeshAgent>();
        
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
        float dist = Vector3.Distance(transform.position, Player.position);
        if (dist > 2f)
        {
            agent.SetDestination(Player.position);
        }
        else agent.SetDestination(transform.position);
        
    }

    void GoHome()
    {
        if (transform.position != Home.position)
        {
            agent.SetDestination(Home.position);
        }
        
    }
}
