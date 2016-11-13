using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinder : MonoBehaviour {

    public List<nodes> Nodes = new List<nodes>();

    public List<nodes> openlist = new List<nodes>();
    public List<nodes> clostlis = new List<nodes>();

    // Use this for initialization
    void Start () {

        float lvl0 = 0.0f;

        nodes node1 = new nodes();
		node1.startup ();
        node1.position = new Vector3(0.0f, lvl0, 0.0f);

        nodes node2 = new nodes();
		node2.startup ();
        node2.position = new Vector3(100.0f, lvl0, 100.0f);

        nodes node3 = new nodes();
		node3.startup ();
        node3.position = new Vector3(-200.0f, lvl0, 250.0f);

        nodes node4 = new nodes();
		node4.startup ();
        node4.position = new Vector3(50.0f, lvl0, 380.0f);

        nodes node5 = new nodes();
		node5.startup ();
        node5.position = new Vector3(300.0f, lvl0, 400.0f);

        nodes node6 = new nodes();
		node6.startup ();
        node6.position = new Vector3(0, lvl0, 500);

        nodes node7 = new nodes();
		node7.startup ();
        node7.position = new Vector3(-50.0f, lvl0, 600.0f);

        nodes node8 = new nodes();
		node8.startup ();
        node8.position = new Vector3(150.0f, lvl0, 670.0f);

        nodes node9 = new nodes();
		node9.startup ();
        node9.position = new Vector3(-200.0f, lvl0, 700.0f);

        nodes node10 = new nodes();
		node10.startup ();
        node10.position = new Vector3(-100.0f, lvl0, 920.0f);

        nodes node11 = new nodes();
		node11.startup ();
        node11.position = new Vector3(0.0f, lvl0, 1000.0f);

        node1.addConnection(node2);
        node2.addConnection(node1);

        node2.addConnection(node3);
        node3.addConnection(node2);

        node3.addConnection(node4);
        node4.addConnection(node3);

        node4.addConnection(node5);
        node5.addConnection(node4);

        node5.addConnection(node6);
        node6.addConnection(node5);

        node6.addConnection(node7);
        node7.addConnection(node6);

        node7.addConnection(node8);
        node8.addConnection(node7);

        node8.addConnection(node9);
        node9.addConnection(node8);

        node9.addConnection(node10);
        node10.addConnection(node9);

        node10.addConnection(node11);
        node11.addConnection(node10);

        Nodes.Add(node1);
        Nodes.Add(node2);
        Nodes.Add(node3);
        Nodes.Add(node4);
        Nodes.Add(node5);
        Nodes.Add(node6);
        Nodes.Add(node7);
        Nodes.Add(node8);
        Nodes.Add(node9);
        Nodes.Add(node10);
        Nodes.Add(node11);


    }
	
	// Update is called once per frame
	void Update () {
	
	}


    public List<Vector3> returnPath(Vector3 start, Vector3 end)
    {
        List<Vector3> thePath = new List<Vector3>();
        List<nodes> pathOfNodes = new List<nodes>();

        Debug.Log("PATHFINDER");
        nodes startnode = findclosest(start);
        nodes endnode = findclosest(end);

		thePath.Add(startnode.position);
        openlist.Add(startnode);
        int f = 10000000;
        bool reachdest = false;
        int nextindex;
        nodes bestscoreobject = null;

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
					nodes nodedata = openlist [i]; //get the best node from the openlist (should be the closest)

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

                List<nodes> connections = bestscoreobject.getnodes(); // add all of the connects of the best node to the open list

                for(int i = 0; i < connections.Count; i++)
                {
                    nodes nodeCons = connections[i];
                    nodeCons.costsetup(endnode, bestscoreobject); //set up the cost and parent of all the connected nodes#
					if (nodeCons.inclosed != true) {
						openlist.Add (connections [i]);
					}
                }


                clostlis.Add(bestscoreobject); //now add the node we just checked to the closed list
				bestscoreobject.inclosed = true;
                openlist.Remove(bestscoreobject); // and remove it from the open list
            }

            pathOfNodes.Add(endnode); //now we need to strat tracing our path back
            thePath.Insert(1,endnode.position); // add it to second index as our strat node is the first place we seek to
            int k = 0;

            while (true)
            {
                nodes getParent = pathOfNodes[k].myPartent; // go thorugh each parent and get the position untill we reach our starting node
                if(getParent == startnode)
                {
                    break;
                }
                pathOfNodes.Insert(0,getParent);
                thePath.Insert(1, getParent.position);
                if (pathOfNodes.Count > 200) //failsafe
                {
                    break;
                }

            }

        }


        for(int i = 0; i < thePath.Count; i++)
        {
            Debug.Log(thePath[i]);
        }

        return thePath;

    }


    private nodes findclosest(Vector3 pos)
    {
		nodes closestNode = new nodes();

        float distance = 100000;


        for(int i = 0; i < Nodes.Count; i++)
        {
            float closest = Vector3.Distance(Nodes[i].position, pos);
            
            if (closest < distance)
            {
                closestNode = Nodes[i];
				closestNode.myPartent = Nodes[i];
                distance = closest;
            }
        }

        cleanNodesUp();
        return closestNode;
    }

    private void cleanNodesUp()
    {
        for (int i = 0; i < Nodes.Count; i++)
        {
			Nodes [i].reset ();
        }
    }

}
