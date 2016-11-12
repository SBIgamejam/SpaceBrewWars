using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinder : MonoBehaviour {

    public List<GameObject> Nodes = new List<GameObject>();

    public List<GameObject> openlist = new List<GameObject>();
    public List<GameObject> clostlis = new List<GameObject>();

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public List<Vector3> returnPath(Vector3 start, Vector3 end)
    {
       List<Vector3> thePath = new List<Vector3>();
        List<GameObject> pathOfNodes = new List<GameObject>();

        GameObject startnode = findclosest(start);
        GameObject endnode = findclosest(end);

        thePath.Add(startnode.transform.position);
        openlist.Add(startnode);
        int f = 10000000;
        bool reachdest = false;
        int nextindex;
        GameObject bestscoreobject = null;

        if(startnode == endnode)
        {
            return thePath;
        }
        else
        {
            while (reachdest == false)
            {

                f = 1000000;
                if(openlist.Count == 0)
                {
                    return null; //no path possible
                }

                for (int i = 0; i < openlist.Count; i++)
                {
                    nodes nodedata = openlist[i].GetComponent<nodes>(); //get the best node from the openlist (should be the closest)

                    if (nodedata.F < f)
                    {
                        f = nodedata.F;
                        nextindex = i;
                        bestscoreobject = openlist[i];
                    }
                }
                
                if(bestscoreobject == endnode) // we have found the node we want
                {
                    break;
                }

                List<GameObject> connections = bestscoreobject.GetComponent<nodes>().getnodes(); // add all of the connects of the best node to the open list

                for(int i = 0; i < connections.Count; i++)
                {
                    nodes nodeCons = connections[i].GetComponent<nodes>();
                    nodeCons.costsetup(endnode, bestscoreobject); //set up the cost and parent of all the connected nodes
                    openlist.Add(connections[i]);
                }


                clostlis.Add(bestscoreobject); //now add the node we just checked to the closed list
                openlist.Remove(bestscoreobject); // and remove it from the open list
            }

            pathOfNodes.Add(endnode); //now we need to strat tracing our path back
            thePath.Insert(1,endnode.GetComponent<nodes>().position); // add it to second index as our strat node is the first place we seek to
            int k = 0;

            while (true)
            {
                GameObject getParent = pathOfNodes[k].GetComponent<nodes>().myPartent; // go thorugh each parent and get the position untill we reach our starting node
                if(getParent == startnode)
                {
                    break;
                }
                pathOfNodes.Insert(0,getParent);
                thePath.Insert(1, getParent.GetComponent<nodes>().position);
                if (pathOfNodes.Count > 200) //failsafe
                {
                    break;
                }

            }

        }




        return thePath;

    }


    private GameObject findclosest(Vector3 pos)
    {
        GameObject closestNode = null;

        float distance = 100000;


        for(int i = 0; i < Nodes.Count; i++)
        {
            float closest = Vector3.Distance(Nodes[i].transform.position, pos);
            if(closest < distance)
            {
                closestNode = Nodes[i];
                distance = closest;
            }
        }


        return closestNode;
    }

}
