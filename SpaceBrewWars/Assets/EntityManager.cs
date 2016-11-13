using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntityManager : MonoBehaviour {
    public int playerCount = 2;
    public GameObject pubPrefab;
    public GameObject brewPrefab;
    public GameObject builderPrefab;
    public GameObject saboteurPrefab;
    public GameObject masterBrewPrefab;
    public List<nodes> mynodes = new List<nodes>();
    public World myworld;

    GameObject[] pubs;
    GameObject[] brews;
    GameObject[] builders;
    public List<GameObject> saboteurs = new List<GameObject>();
    GameObject[] masterpups;

    // Use this for initialization
    void Start () {
        // cannot have 0 players... People will play this :) 
        if (playerCount < 2)
            playerCount = 2;

        // generate the world
        Create();
    }

    // Update is called once per frame
    void Update() {
    
    }

    void Create()
    {
        float lvl0 = 0.0f;
        float lvl1 = 400.0f;
        float lvl2 = 800.0f;
        float lvl3 = 1200.0f;
        float lvl4 = 1600.0f;

        brews = new GameObject[playerCount];
        pubs = new GameObject[10];
        masterpups = new GameObject[1];

        brews[0] = (GameObject)Instantiate(brewPrefab, new Vector3(0.0f, lvl0, 0.0f), Quaternion.identity);
        brews[1] = (GameObject)Instantiate(brewPrefab, new Vector3(0.0f, lvl0, 1000.0f), Quaternion.identity);

        pubs[0] = (GameObject)Instantiate(pubPrefab, new Vector3(100.0f, lvl0, 100.0f), Quaternion.identity);
        pubs[1] = (GameObject)Instantiate(pubPrefab, new Vector3(-200.0f, lvl0, 250.0f), Quaternion.identity);
        pubs[2] = (GameObject)Instantiate(pubPrefab, new Vector3(50.0f, lvl0, 380.0f), Quaternion.identity);
        pubs[3] = (GameObject)Instantiate(pubPrefab, new Vector3(300.0f, lvl0, 400.0f), Quaternion.identity);

        pubs[4] = (GameObject)Instantiate(pubPrefab, new Vector3(-50.0f, lvl0, 600.0f), Quaternion.identity);
        pubs[5] = (GameObject)Instantiate(pubPrefab, new Vector3(150.0f, lvl0, 670.0f), Quaternion.identity);
        pubs[6] = (GameObject)Instantiate(pubPrefab, new Vector3(-200.0f, lvl0, 700.0f), Quaternion.identity);
        pubs[7] = (GameObject)Instantiate(pubPrefab, new Vector3(-100.0f, lvl0, 920.0f), Quaternion.identity);

        masterpups[0] = (GameObject)Instantiate(masterBrewPrefab, new Vector3(0.0f, lvl0, 500.0f), Quaternion.identity);

        GameObject sab = (GameObject)Instantiate(saboteurPrefab, new Vector3(0.0f, lvl0, 50.0f), Quaternion.identity);
        saboteurs.Add(sab);

    }


    public List<Vector3> setnearme(Vector3 Pos, float rad)
    {
        List<Vector3> nearMe = new List<Vector3>();

        for(int i = 0; i < pubs.Length; i++)
        {
            if (Vector3.Distance(pubs[i].transform.position, Pos) < rad && (Pos != pubs[i].transform.position))
            {
                nearMe.Add(pubs[i].transform.position);
            }
        }

        return nearMe;
    }

}
