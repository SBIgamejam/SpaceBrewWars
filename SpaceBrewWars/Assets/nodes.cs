using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class nodes {

    public Vector3 position;
    public List<nodes> Connnections = new List<nodes>();
    public int F;
    public int G;
    public int H;
    public nodes myPartent;
    public int preG;
	public bool inclosed;

	public void startup()
	{
		myPartent = null;
		F = 0;
		G = 0;
		H = 0;
		preG = 1000000;
		inclosed = false;
	}

    public Vector3 getPos()
    {
        return position;
    }

    public List<nodes> getnodes()
    {
        return Connnections;
    }

    public void setPos(Vector3 test)
    {
        position = test;
    }

    public void addConnection(nodes addnode)
    {
        Connnections.Add(addnode);
    }

    public void reset()
    {
        myPartent = null;
        F = 0;
        G = 0;
        H = 0;
        preG = 1000000;
		inclosed = false;
    }
    
    public void costsetup(nodes destination, nodes parent)
    {
        nodes nodedata = destination;

        nodes parentnode = parent;

        int cost = (int)Mathf.Abs(Vector3.Distance(parentnode.getPos(), position));

        if (G + cost + nodedata.G <= preG)
        {
            G = 0;
            G += cost; // G is based on cost from parent node to this node
            myPartent = parent;
            G += parentnode.G; // G is also the total cost from other nodes so far


            H = (int)Mathf.Abs(Vector3.Distance(position,nodedata.getPos())); // H is cost from this node to our destination (i have done all of the costs based on lenght calculation)

            F = G + H; // F = G + H

            preG = G; // update G for possiblity of better node

        }

    }

}
