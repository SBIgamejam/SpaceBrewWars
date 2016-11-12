﻿using UnityEngine;
using System.Collections;

public class Brewery : MonoBehaviour {

    //public System.Collections.Generic.List<Link> links;
    public int ecoCost;
    public int owner;
    public GameObject world;
    private bool selected;

    // Use this for initialization
    void Start () {
        world = GameObject.FindGameObjectWithTag("World");
    }
	
	// Update is called once per frame
	void Update () {
        world.GetComponent<World>().players[owner].GetComponent<Player>().CollectDebt(ecoCost * Time.deltaTime);
    }

    public void setSelected()
    {
        selected = true;
    }
    public void unselect()
    {
        selected = false;
    }
}
