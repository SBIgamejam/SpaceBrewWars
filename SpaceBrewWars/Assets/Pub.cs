﻿using UnityEngine;
using System.Collections;

public class Pub : MonoBehaviour {

    //public System.Collections.Generic.List<Link> links;
    public int ecoValue;
    public int owner;
    public GameObject world;
    public GameObject tower;
    public GameObject towerPrefab;
    private bool selected;
    public int PlayerID;

    // Use this for initialization
    void Start() {
        world = GameObject.FindGameObjectWithTag("World");
        ecoValue = 10;
        tower = null;
        BuildTower();
    }

    // Update is called once per frame
    void Update() {
        world.GetComponent<World>().players[owner].GetComponent<Player>().CollectIncome(ecoValue * Time.deltaTime);
    }

    public void BuildTower()
    {
        tower = (GameObject)Instantiate(towerPrefab, this.transform.position + new Vector3(0,0.7f,0), Quaternion.identity);
    }

    public void UpgradeTower()
    {
        if(tower.GetComponent<Tower>().upgradeLevel == 2)
        {
            //can't upgrade any higher so do nothing
            return;
        } else
        {
            tower.GetComponent<Tower>().Upgrade();
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

    public void setteam(int PId)
    {
        PlayerID = PId;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            world.GetComponent<World>().selectedrightobject = gameObject;
        }
        if (Input.GetMouseButtonDown(0))
        {
            world.GetComponent<World>().selectedleftobject = gameObject;
        }

    }
}
