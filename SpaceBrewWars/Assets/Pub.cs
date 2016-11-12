using UnityEngine;
using System.Collections;

public class Pub : MonoBehaviour {

    //public System.Collections.Generic.List<Link> links;
    public int ecoValue;
    public int owner;
    public GameObject world;
    public GameObject tower;
    public GameObject towerPrefab;

    // Use this for initialization
    void Start() {
        world = GameObject.FindGameObjectWithTag("World");
        towerPrefab = GameObject.FindGameObjectWithTag("Tower");
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
        Debug.Log(this.transform.position);
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
}
