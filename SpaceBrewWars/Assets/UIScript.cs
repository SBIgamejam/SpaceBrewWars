using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public Text Currency;
    public GameObject world;

    // Use this for initialization
    void Start () {
        world = GameObject.FindGameObjectWithTag("World");
        Currency = GetComponent<Text>();
        Currency.text = world.GetComponent<World>().players[0].GetComponent<Player>().money.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        Currency.text = "hi";


    }
}
