using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
        pubs = new GameObject[50];

        // TODO: make generation more random
        for (int i = 0; i < brews.Length; i++)
        {
            brews[i] = (GameObject)Instantiate(brewPrefab, new Vector3(i, 10, i), Quaternion.identity);
        }

        // level 0
        pubs[0] = (GameObject)Instantiate(pubPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        pubs[1] = (GameObject)Instantiate(pubPrefab, new Vector3(210.0f, 0.0f, 578.0f), Quaternion.identity);
        pubs[2] = (GameObject)Instantiate(pubPrefab, new Vector3(-210.0f, 0.0f, 845.0f), Quaternion.identity);
        pubs[3] = (GameObject)Instantiate(pubPrefab, new Vector3(340.0f, 0.0f, 204.0f), Quaternion.identity);
        pubs[4] = (GameObject)Instantiate(pubPrefab, new Vector3(-150.0f, 0.0f, 135.0f), Quaternion.identity);
        pubs[5] = (GameObject)Instantiate(pubPrefab, new Vector3(500.0f, 0.0f, 0.0f), Quaternion.identity);
        pubs[6] = (GameObject)Instantiate(pubPrefab, new Vector3(-290.0f, 0.0f, 153.0f), Quaternion.identity);
        pubs[7] = (GameObject)Instantiate(pubPrefab, new Vector3(0.0f, 0.0f, 1200.0f), Quaternion.identity);
        pubs[8] = (GameObject)Instantiate(pubPrefab, new Vector3(70.0f, 0.0f, 752.0f), Quaternion.identity);
        pubs[9] = (GameObject)Instantiate(pubPrefab, new Vector3(-91.0f, 0.0f, 872.0f), Quaternion.identity);
        // level 1
        pubs[10] = (GameObject)Instantiate(pubPrefab, new Vector3(0.0f, 200.0f, 255.0f), Quaternion.identity);
        pubs[11] = (GameObject)Instantiate(pubPrefab, new Vector3(-10.0f, 200.0f, 125.0f), Quaternion.identity);
        pubs[12] = (GameObject)Instantiate(pubPrefab, new Vector3(-378.0f, 200.0f, 485.0f), Quaternion.identity);
        pubs[13] = (GameObject)Instantiate(pubPrefab, new Vector3(410.0f, 200.0f, 215.0f), Quaternion.identity);
        pubs[14] = (GameObject)Instantiate(pubPrefab, new Vector3(-168.0f, 200.0f, 94.0f), Quaternion.identity);
        pubs[15] = (GameObject)Instantiate(pubPrefab, new Vector3(548.0f, 200.0f, 0.0f), Quaternion.identity);
        pubs[16] = (GameObject)Instantiate(pubPrefab, new Vector3(-248.0f, 200.0f, 128.0f), Quaternion.identity);
        pubs[17] = (GameObject)Instantiate(pubPrefab, new Vector3(5.0f, 200.0f, 800.0f), Quaternion.identity);
        pubs[18] = (GameObject)Instantiate(pubPrefab, new Vector3(-70.0f, 200.0f, 742.0f), Quaternion.identity);
        pubs[19] = (GameObject)Instantiate(pubPrefab, new Vector3(-91.0f, 200.0f, 921.0f), Quaternion.identity);
        // level 2
        pubs[20] = (GameObject)Instantiate(pubPrefab, new Vector3(100.0f, 400.0f, 0.0f), Quaternion.identity);
        pubs[21] = (GameObject)Instantiate(pubPrefab, new Vector3(210.0f, 400.0f, 348.0f), Quaternion.identity);
        pubs[22] = (GameObject)Instantiate(pubPrefab, new Vector3(-210.0f, 400.0f, 495.0f), Quaternion.identity);
        pubs[23] = (GameObject)Instantiate(pubPrefab, new Vector3(340.0f, 400.0f, 604.0f), Quaternion.identity);
        pubs[24] = (GameObject)Instantiate(pubPrefab, new Vector3(0.0f, 400.0f, 600.0f), Quaternion.identity); ///< middle
        pubs[25] = (GameObject)Instantiate(pubPrefab, new Vector3(500.0f, 400.0f, 241.0f), Quaternion.identity);
        pubs[26] = (GameObject)Instantiate(pubPrefab, new Vector3(-290.0f, 400.0f, 100.0f), Quaternion.identity);
        pubs[27] = (GameObject)Instantiate(pubPrefab, new Vector3(0.0f, 400.0f, 1158.0f), Quaternion.identity);
        pubs[28] = (GameObject)Instantiate(pubPrefab, new Vector3(70.0f, 400.0f, 852.0f), Quaternion.identity);
        pubs[29] = (GameObject)Instantiate(pubPrefab, new Vector3(-91.0f, 400.0f, 372.0f), Quaternion.identity);
        // level 3
        pubs[30] = (GameObject)Instantiate(pubPrefab, new Vector3(0.0f, 600.0f, 0.0f), Quaternion.identity);
        pubs[31] = (GameObject)Instantiate(pubPrefab, new Vector3(-15.0f, 600.0f, 578.0f), Quaternion.identity);
        pubs[32] = (GameObject)Instantiate(pubPrefab, new Vector3(350.0f, 600.0f, 845.0f), Quaternion.identity);
        pubs[33] = (GameObject)Instantiate(pubPrefab, new Vector3(478.0f, 600.0f, 204.0f), Quaternion.identity);
        pubs[34] = (GameObject)Instantiate(pubPrefab, new Vector3(-320.0f, 600.0f, 135.0f), Quaternion.identity);
        pubs[35] = (GameObject)Instantiate(pubPrefab, new Vector3(780.0f, 600.0f, 0.0f), Quaternion.identity);
        pubs[36] = (GameObject)Instantiate(pubPrefab, new Vector3(-420.0f, 600.0f, 153.0f), Quaternion.identity);
        pubs[37] = (GameObject)Instantiate(pubPrefab, new Vector3(245.0f, 600.0f, 1200.0f), Quaternion.identity);
        pubs[38] = (GameObject)Instantiate(pubPrefab, new Vector3(690.0f, 600.0f, 752.0f), Quaternion.identity);
        pubs[39] = (GameObject)Instantiate(pubPrefab, new Vector3(-740.0f, 600.0f, 872.0f), Quaternion.identity);
        // level 4
        pubs[40] = (GameObject)Instantiate(pubPrefab, new Vector3(0.0f, 800.0f, 0.0f), Quaternion.identity);
        pubs[41] = (GameObject)Instantiate(pubPrefab, new Vector3(210.0f, 800.0f, 578.0f), Quaternion.identity);
        pubs[42] = (GameObject)Instantiate(pubPrefab, new Vector3(-210.0f, 800.0f, 845.0f), Quaternion.identity);
        pubs[43] = (GameObject)Instantiate(pubPrefab, new Vector3(340.0f, 800.0f, 204.0f), Quaternion.identity);
        pubs[44] = (GameObject)Instantiate(pubPrefab, new Vector3(-150.0f, 800.0f, 135.0f), Quaternion.identity);
        pubs[45] = (GameObject)Instantiate(pubPrefab, new Vector3(500.0f, 800.0f, 0.0f), Quaternion.identity);
        pubs[46] = (GameObject)Instantiate(pubPrefab, new Vector3(-290.0f, 800.0f, 153.0f), Quaternion.identity);
        pubs[47] = (GameObject)Instantiate(pubPrefab, new Vector3(0.0f, 800.0f, 1200.0f), Quaternion.identity);
        pubs[48] = (GameObject)Instantiate(pubPrefab, new Vector3(70.0f, 800.0f, 752.0f), Quaternion.identity);
        pubs[49] = (GameObject)Instantiate(pubPrefab, new Vector3(-91.0f, 800.0f, 872.0f), Quaternion.identity);


    }


    List<Vector3> setnearme(Vector3 Pos, float rad)
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
