using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Builder : MonoBehaviour {

    public int owner; // playerID, which player owns it
    public bool alive; // is this ship alive? if not it need to be cleaned up and removed from the world.
    private bool selected;
    public GameObject pathfinder;
    private List<Vector3> seekPosition = new List<Vector3>();
    int state = 0;
    private Vector3 velocity;
    private float speed;
    public GameObject world;
    private float health;



    // Use this for initialization
    void Start () {

        health = 200;

    }
	
	// Update is called once per frame
	void Update () {
	
        if(state == 0) //idel;
        {
           
        }
        else if(state == 1) //seek
        {


            if(seekPosition.Count == 0)
            {
                state = 0;
            }
        }
        else if (state == 2) // build
        {
            
        }

	}


    void actions(Vector3 targetlocation, bool action)
    {
        //pathfind the target location
        //set the correct state 

        if (action == false)
        {
            state = 1;
        }
        else
        {
            state = 2;
        }

    }




    public void setSelected()
    {
        selected = true;
    }
    public void unselect()
    {
        selected = false;
    }


    void separation()
    {



    }

}
