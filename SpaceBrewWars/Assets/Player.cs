using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public int ID;
    public float money;

	// Use this for initialization
	void Start () {
        money = 1000;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void CollectIncome(float income)
    {
        money += income;
    }

    public void CollectDebt(float debt)
    {
        money -= debt;
    }
}
