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

    GameObject[] pubs;
    GameObject[] brews;
    GameObject[] builders;
    GameObject[] saboteurs;

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
        // ray from mouse left click hit object
        if (Input.GetMouseButtonDown(0))
        {
            // get the transform
            Transform selectObjectTransform = Camera.main.GetComponent<cameraControls>().screenSelection();

            // set the selected
            if (selectObjectTransform.GetComponent<Pub>())
            {
                for (int i = 0; i < pubs.Length; ++i)
                {
                    if (selectObjectTransform.Equals(pubs[i].GetComponent<Transform>()))
                    {
                        pubs[i].GetComponent<Pub>().setSelected();
                    }
                }
            }

            if (selectObjectTransform.GetComponent<Builder>())
            {
                for (int i = 0; i < builders.Length; ++i)
                {
                    if (selectObjectTransform.Equals(pubs[i].GetComponent<Transform>()))
                    {
                        pubs[i].GetComponent<Builder>().setSelected();
                    }
                }
            }

            if (selectObjectTransform.GetComponent<Saboteur>())
            {
                for (int i = 0; i < saboteurs.Length; ++i)
                {
                    if (selectObjectTransform.Equals(pubs[i].GetComponent<Transform>()))
                    {
                        pubs[i].GetComponent<Saboteur>().setSelected();
                    }
                }
            }

            if (selectObjectTransform.GetComponent<Brewery>())
            {
                for (int i = 0; i < brews.Length; ++i)
                {
                    if (selectObjectTransform.Equals(pubs[i].GetComponent<Transform>()))
                    {
                        pubs[i].GetComponent<Brewery>().setSelected();
                    }
                }
            }
        }

        // ray from mouse right click hit object
        if (Input.GetMouseButtonDown(1))
        {
            Transform selectObjectTransform = Camera.main.GetComponent<cameraControls>().screenSelection();
            Debug.Log(selectObjectTransform.transform.name);
            Debug.Log("right click");

            if (selectObjectTransform.GetComponent<Builder>())
            {
                for (int i = 0; i < builders.Length; ++i)
                {
                   pubs[i].GetComponent<Builder>().build(selectObjectTransform);
                }
            }

            if (selectObjectTransform.GetComponent<Saboteur>())
            {
                for (int i = 0; i < saboteurs.Length; ++i)
                {
                    pubs[i].GetComponent<Saboteur>().destroy(selectObjectTransform);
                }
            }
        }
    }

    void Create()
    {
        float lvl0 = 0.0f;
        float lvl1 = 400.0f;
        float lvl2 = 800.0f;
        float lvl3 = 1200.0f;
        float lvl4 = 1600.0f;

        brews = new GameObject[playerCount];
        pubs = new GameObject[50];

        brews[0] = (GameObject)Instantiate(brewPrefab, new Vector3(0.0f, lvl0, 0.0f), Quaternion.identity);
        brews[1] = (GameObject)Instantiate(brewPrefab, new Vector3(0.0f, lvl0, 1350.0f), Quaternion.identity);

        // level 0
        pubs[0] = (GameObject)Instantiate(pubPrefab, new Vector3(684.0f, lvl0, 0.0f), Quaternion.identity);
        pubs[1] = (GameObject)Instantiate(pubPrefab, new Vector3(210.0f, lvl0, 250.0f), Quaternion.identity);
        pubs[2] = (GameObject)Instantiate(pubPrefab, new Vector3(850.0f, lvl0, 891.0f), Quaternion.identity);
        pubs[3] = (GameObject)Instantiate(pubPrefab, new Vector3(1458.0f, lvl0, 512.0f), Quaternion.identity);
        pubs[4] = (GameObject)Instantiate(pubPrefab, new Vector3(1026.0f, lvl0, 1274.0f), Quaternion.identity);
        pubs[5] = (GameObject)Instantiate(pubPrefab, new Vector3(-158.0f, lvl0, 541.0f), Quaternion.identity);
        pubs[6] = (GameObject)Instantiate(pubPrefab, new Vector3(-592.0f, lvl0, 153.0f), Quaternion.identity);
        pubs[7] = (GameObject)Instantiate(pubPrefab, new Vector3(-942.0f, lvl0, 789.0f), Quaternion.identity);
        pubs[8] = (GameObject)Instantiate(pubPrefab, new Vector3(-1420.0f, lvl0, 1053.0f), Quaternion.identity);
        pubs[9] = (GameObject)Instantiate(pubPrefab, new Vector3(314.0f, lvl0, 784.0f), Quaternion.identity);
        // level 1
        pubs[10] = (GameObject)Instantiate(pubPrefab, new Vector3(0.0f, lvl1, 0.0f), Quaternion.identity);
        pubs[11] = (GameObject)Instantiate(pubPrefab, new Vector3(-392.0f, lvl1, 125.0f), Quaternion.identity);
        pubs[12] = (GameObject)Instantiate(pubPrefab, new Vector3(-778.0f, lvl1, 585.0f), Quaternion.identity);
        pubs[13] = (GameObject)Instantiate(pubPrefab, new Vector3(-1125.0f, lvl1, 240.0f), Quaternion.identity);
        pubs[14] = (GameObject)Instantiate(pubPrefab, new Vector3(-168.0f, lvl1, 850.0f), Quaternion.identity);
        pubs[15] = (GameObject)Instantiate(pubPrefab, new Vector3(200.0f, lvl1, 294.0f), Quaternion.identity);
        pubs[16] = (GameObject)Instantiate(pubPrefab, new Vector3(548.0f, lvl1, 598.0f), Quaternion.identity);
        pubs[17] = (GameObject)Instantiate(pubPrefab, new Vector3(997.0f, lvl1, 389.0f), Quaternion.identity);
        pubs[18] = (GameObject)Instantiate(pubPrefab, new Vector3(1024.0f, lvl1, 1242.0f), Quaternion.identity);
        pubs[19] = (GameObject)Instantiate(pubPrefab, new Vector3(210.0f, lvl1, 921.0f), Quaternion.identity);
        // level 2
        pubs[20] = (GameObject)Instantiate(pubPrefab, new Vector3(100.0f, lvl2, 0.0f), Quaternion.identity);
        pubs[21] = (GameObject)Instantiate(pubPrefab, new Vector3(750.0f, lvl2, 148.0f), Quaternion.identity);
        pubs[22] = (GameObject)Instantiate(pubPrefab, new Vector3(1000.0f, lvl2, 650.0f), Quaternion.identity);
        pubs[23] = (GameObject)Instantiate(pubPrefab, new Vector3(648.0f, lvl2, 1230.0f), Quaternion.identity);
        pubs[24] = (GameObject)Instantiate(masterBrewPrefab, new Vector3(300.0f, lvl2, 600.0f), Quaternion.identity); ///< middle
        pubs[25] = (GameObject)Instantiate(pubPrefab, new Vector3(-245.0f, lvl2, 112.0f), Quaternion.identity);
        pubs[26] = (GameObject)Instantiate(pubPrefab, new Vector3(-598.0f, lvl2, 479.0f), Quaternion.identity);
        pubs[27] = (GameObject)Instantiate(pubPrefab, new Vector3(-865.0f, lvl2, 912.0f), Quaternion.identity);
        pubs[28] = (GameObject)Instantiate(pubPrefab, new Vector3(-470.0f, lvl2, 1352.0f), Quaternion.identity);
        pubs[29] = (GameObject)Instantiate(pubPrefab, new Vector3(71.0f, lvl2, 1197.0f), Quaternion.identity);
        // level 3
        pubs[30] = (GameObject)Instantiate(pubPrefab, new Vector3(-740.0f, lvl3, 872.0f), Quaternion.identity);
        pubs[31] = (GameObject)Instantiate(pubPrefab, new Vector3(-98.0f, lvl3, 753.0f), Quaternion.identity);
        pubs[32] = (GameObject)Instantiate(pubPrefab, new Vector3(245.0f, lvl3, 1200.0f), Quaternion.identity);
        pubs[33] = (GameObject)Instantiate(pubPrefab, new Vector3(908.0f, lvl3, 1350.0f), Quaternion.identity);
        pubs[34] = (GameObject)Instantiate(pubPrefab, new Vector3(1080.0f, lvl3, 752.0f), Quaternion.identity);
        pubs[35] = (GameObject)Instantiate(pubPrefab, new Vector3(930.0f, lvl3, 192.0f), Quaternion.identity);
        pubs[36] = (GameObject)Instantiate(pubPrefab, new Vector3(478.0f, lvl3, 353.0f), Quaternion.identity);
        pubs[37] = (GameObject)Instantiate(pubPrefab, new Vector3(245.0f, lvl3, 1200.0f), Quaternion.identity);
        pubs[38] = (GameObject)Instantiate(pubPrefab, new Vector3(690.0f, lvl3, 752.0f), Quaternion.identity);
        pubs[39] = (GameObject)Instantiate(pubPrefab, new Vector3(-740.0f, lvl3, 872.0f), Quaternion.identity);
        // level 4
        pubs[40] = (GameObject)Instantiate(pubPrefab, new Vector3(0.0f, lvl4, 0.0f), Quaternion.identity);
        pubs[41] = (GameObject)Instantiate(pubPrefab, new Vector3(-449.8f, lvl4, 135.0f), Quaternion.identity);
        pubs[42] = (GameObject)Instantiate(pubPrefab, new Vector3(-290.0f, lvl4, 478.0f), Quaternion.identity);
        pubs[43] = (GameObject)Instantiate(pubPrefab, new Vector3(-492.0f, lvl4, 845.0f), Quaternion.identity);
        pubs[44] = (GameObject)Instantiate(pubPrefab, new Vector3(89.0f, lvl4, 1200.0f), Quaternion.identity);
        pubs[45] = (GameObject)Instantiate(pubPrefab, new Vector3(336.0f, lvl4, 752.0f), Quaternion.identity);
        pubs[46] = (GameObject)Instantiate(pubPrefab, new Vector3(688.0f, lvl4, 1001.0f), Quaternion.identity);
        pubs[47] = (GameObject)Instantiate(pubPrefab, new Vector3(1091.0f, lvl4, 578.0f), Quaternion.identity);
        pubs[48] = (GameObject)Instantiate(pubPrefab, new Vector3(777.0f, lvl4, 0.0f), Quaternion.identity);
        pubs[49] = (GameObject)Instantiate(pubPrefab, new Vector3(340.0f, lvl4, 204.0f), Quaternion.identity);
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
