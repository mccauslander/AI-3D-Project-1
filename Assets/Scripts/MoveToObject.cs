using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToObject : MonoBehaviour
{
    private NavMeshAgent agent;

    private GameObject followObject = null;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveAgentToPoint(true);
            followObject = null;
        }
        else if (Input.GetMouseButton(1))
        {
            MoveAgentToPoint(false);
        }

        if (followObject != null)
        {
            agent.destination = followObject.transform.position;
        }
        
    }

    private void MoveAgentToPoint(bool isFollowMouse)
    {
        //make a ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //hit info
        RaycastHit hitInfo;

        //cast a ray
        if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
        {
            if (isFollowMouse) 
            {
                agent.destination = hitInfo.point;
            }
            else
            {
                // we want to follow an object
                followObject = hitInfo.transform.gameObject;
            }
            
        }

        // followObject.transform.position;
    }
}
