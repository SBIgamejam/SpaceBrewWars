using UnityEngine;
using System.Collections;

public class Pub : MonoBehaviour {

    //public System.Collections.Generic.List<Link> links;
    public int ecoValue;
    public int owner;
    public GameObject world;

	// Use this for initialization
	void Start () {
        world = GameObject.FindGameObjectWithTag("World");
        ecoValue = 10;
	}
	
	// Update is called once per frame
	void Update () {
        world.GetComponent<World>().players[owner].CollectIncome(ecoValue * Time.deltaTime);
	}
}
