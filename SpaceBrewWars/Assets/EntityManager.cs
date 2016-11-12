using UnityEngine;
using System.Collections;

public class EntityManager : MonoBehaviour {
    public int playerCount = 1;
    public GameObject pubPrefab;
    public GameObject brewPrefab;
    public GameObject builderPrefab;
    public GameObject saboteurPrefab;

    GameObject[] pubs;
    GameObject[] brews;
    GameObject[] builders;
    GameObject[] saboteurs;

	// Use this for initialization
	void Start () {
        // cannot have 0 players... People will play this :) 
        if (playerCount == 0)
            playerCount = 1;

        // generate the world
        Create();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Create()
    {
        brews = new GameObject[playerCount];
        pubs = new GameObject[10];

        // TODO: make generation more random
        for (int i = 0; i < brews.Length - 1; i++)
        {
            brews[i] = (GameObject)Instantiate(brewPrefab, new Vector3(i, 10, i), Quaternion.identity);
        }

        for(int i = 0; i < pubs.Length - 1; i++)
        {
            pubs[i] = (GameObject)Instantiate(pubPrefab, new Vector3(i, 0, i), Quaternion.identity);
        }
    }

    void Find()
    {

    }

    void GetSelected()
    {

    }
}
