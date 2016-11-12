using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Saboteur : MonoBehaviour {


    public int owner; // playerID, which player owns it
    public bool alive; // is this ship alive? if not it need to be cleaned up and removed from the world.
    private bool selected;
    public GameObject pathfinder;
    private List<Vector3> seekPosition = new List<Vector3>();
    int state = 0;
    private Vector3 velocity;
    private float speed;
    public GameObject world;
    private float health;
    private float sepRad;
    public int PlayerID;

    // Use this for initialization
    void Start () {

        health = 100;
        state = 0;
        sepRad = 26;

    }
	
	// Update is called once per frame
	void Update () {

        if (state == 0) //idel;
        {
            velocity = new Vector3(0, 0, 0);
        }
        else if (state == 1) //seek
        {
            seek(seekPosition[0]);
            separation();

            velocity = Vector3.Normalize(velocity) * speed;

            if (Vector3.Distance(transform.position, seekPosition[0]) < 3)
            {
                seekPosition.Remove(seekPosition[0]);
            }

            if (seekPosition.Count == 0)
            {
                state = 0;
            }
        }
        else if (state == 2) // build
        {
            seek(seekPosition[0]);
            separation();

            velocity = Vector3.Normalize(velocity) * speed;

            if (Vector3.Distance(transform.position, seekPosition[0]) < 3)
            {
                seekPosition.Remove(seekPosition[0]);
            }

            if (Vector3.Distance(transform.position, seekPosition[0]) < 3)
            {
                seekPosition.Remove(seekPosition[0]);
            }

            if (seekPosition.Count == 0)
            {

            }
        }

        transform.position += velocity * Time.deltaTime;

    }


    void actions(Vector3 targetlocation, bool action)
    {
        pathfinder.GetComponent<Pathfinder>().returnPath(transform.position, targetlocation);

        if (action == false)
        {
            state = 1;
        }
        else
        {
            state = 2;
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

    void separation()
    {
        List<Vector3> sepFrom = world.GetComponent<World>().entityManager.GetComponent<EntityManager>().setnearme(transform.position, sepRad);
        Vector3 sep = new Vector3(0, 0, 0);

        for (int i = 0; i < sepFrom.Count; i++)
        {
            sep += sepFrom[i] - transform.position;
        }

        sep /= sepFrom.Count;
        sep *= -1;
        velocity += Vector3.Normalize(sep);
    }
    void seek(Vector3 seekPos)
    {
        velocity += Vector3.Normalize(seekPos - transform.position);

    }

    public void destroy(Transform buildTarget)
    {

    }

   public void setteam(int PId)
    {
        PlayerID = PId;

    }
}
