using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour
{

    public int health;
    public int upgradeLevel;

	// Use this for initialization
	void Start () {
        health = 200;
        upgradeLevel = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    //seek for enemy ships
	}

    public void Upgrade()
    {
        upgradeLevel++;
        health += 100;
    }

}
