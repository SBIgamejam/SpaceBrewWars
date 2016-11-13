using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {
    public int worldRadius = 100; // the radius of the world
    public int locationRadius = 10; // the radius of locations in the world
    public int selectionRadius = 10; // the radius for selecting buildings and units
    public int numberOfLevels = 3; // the number of depth levels that world contains

    //public AIManager aiManager;
    //public UIManager uiManagerl
    public int numberOfPlayers;
    public GameObject[] players;
    public GameObject playerPrefab;
    public EntityManager myentmanager;
	public GameObject mypathfind;

    public GameObject selectedleftobject;
    public GameObject selectedrightobject;

    // Use this for initialization
    void Start () {
        // make sure the radius and levels are not zero
        if (worldRadius == 0)
            worldRadius = 1;
        if (locationRadius == 0)
            locationRadius = 1;
        if (selectionRadius == 0)
            selectionRadius = 1;
        if (numberOfLevels == 0)
            numberOfLevels = 1;

        for(int i = 0; i < numberOfPlayers; i++)
        {
            players[i] = (GameObject) Instantiate(playerPrefab, new Vector3(0,0,0), Quaternion.identity);
            players[i].GetComponent<Player>().ID = i;
        }

        WorldGeneration();

        selectedleftobject = null;
        selectedrightobject = null;
}

// Update is called once per frame
void Update () {

        /* Update managers
         * INSERT CODE
         */

        if (selectedleftobject != null && selectedrightobject != null)
		{
            if (selectedleftobject.GetComponent<Saboteur>() && selectedrightobject.GetComponent<Pub>())
                {
				selectedleftobject.GetComponent<Saboteur> ().seekPosition = mypathfind.GetComponent<Pathfinder> ().returnPath (selectedleftobject.transform.position,selectedrightobject.transform.position);
				selectedleftobject.GetComponent<Saboteur>().state = 1;
                 selectedrightobject = null;
                }

			if (selectedleftobject.GetComponent<Builder>() && selectedrightobject.GetComponent<Pub>())
			{
				selectedleftobject.GetComponent<Builder> ().seekPosition = mypathfind.GetComponent<Pathfinder> ().returnPath (selectedleftobject.transform.position,selectedrightobject.transform.position);
				selectedleftobject.GetComponent<Builder>().state = 1;
				selectedrightobject = null;
			}
         }



      

    }

    void WorldGeneration()
    {
        // set the size of the transform
        Transform transform = GetComponent<Transform>();
        transform.localScale = new Vector3(worldRadius, worldRadius, worldRadius);

        // TODO: call entityCreationManager to create the world and store the results in the EntityManager
    }


}
