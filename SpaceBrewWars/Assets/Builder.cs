using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Builder : MonoBehaviour {

    public int owner; // playerID, which player owns it
    public bool alive; // is this ship alive? if not it need to be cleaned up and removed from the world.
    private bool selected;
    private GameObject pathfinder;
    private List<Vector3> seekPosition = new List<Vector3>();
    int state = 0;
    private Vector3 velocity;
    private float speed;
    public GameObject world;



    // Use this for initialization
    void Start () {

	    
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




    void setselected()
    {
        selected = true;
    }
    void unselect()
    {
        selected = false;
    }


    void separation()
    {



    }

}
