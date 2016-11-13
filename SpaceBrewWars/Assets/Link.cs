using UnityEngine;
using System.Collections;

public class Link : MonoBehaviour {
    public GameObject source; // pub or brew
    public GameObject destination; // pub or brew
    int owner;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Transform getPosition()
    {
        return transform;
    }

    public int getOwner()
    {
        return owner;
    }

    public void setTeam(int playerID)
    {
        owner = playerID;
    }
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //world.GetComponent<World>().selectedleftobject = gameObject;
        }
        if (Input.GetMouseButtonDown(1))
        {
            //world.GetComponent<World>().selectedrightobject = gameObject;
        }
    }
}
