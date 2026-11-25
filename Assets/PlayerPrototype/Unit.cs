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

    private Animator anim;
    void Start()
    {
       // body = GetComponent<Rigidbody>();
        agent=GetComponent<NavMeshAgent>();
        anim=GetComponent<Animator>();   
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
        anim.SetBool("IsSleeping", false);
        anim.SetBool("IsFight", true);
        float dist = Vector3.Distance(transform.position, Player.position);
        if (dist > 2f)
        {
            agent.SetDestination(Player.position);
        }
        else agent.SetDestination(transform.position);
        
    }

    void GoHome()
    {
        anim.SetBool("IsFight", false);
        if (transform.position.x != Home.position.x && transform.position.z != Home.position.z)
        {
            anim.SetBool("IsSleeping", false);
            anim.SetBool("IsWalking", true);
            agent.SetDestination(Home.position);
        }
        else
        {
            anim.SetBool("IsSleeping", true);
            anim.SetBool("IsWalking", false);
        }
    }
}
