using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public int ID;
    public int money;

	// Use this for initialization
	void Start () {
        money = 1000;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void CollectIncome(int income)
    {
        money += income;
    }

    void CollectDebt(int debt)
    {
        money -= debt;
    }
}
