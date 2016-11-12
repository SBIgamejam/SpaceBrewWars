using UnityEngine;
using System.Collections;

public class Saboteur : MonoBehaviour {
    public Vector3 position; // current position in the world
    public int owner; // playerID, which player owns it
    public bool alive; // is this ship alive? if not it need to be cleaned up and removed from the world.

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
