using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cameraControls : MonoBehaviour {

    private float speed = 50.0f;
    private float transitionSpeed = 100.0f;

    private bool keyRight;
    private bool keyLeft;
    private bool keyUp;
    private bool keyDown;

    private bool mouseUp;
    private bool mouseDown;
    private bool mouseRight;
    private bool mouseLeft;
        
    public Vector3 worldCenter;
    public float worldRad;

    private int indexY = 0;
    public List<float> yLevel = new List<float>();
    bool yTransition = false;

    void Start ()
    {
        transform.rotation = Quaternion.AngleAxis(45.0f, new Vector3(1, 0, 0));
        keyRight = keyLeft = keyUp = keyDown = false;
        mouseUp = mouseDown = mouseLeft = mouseRight = false;

        yLevel.Add(400.0f);
        yLevel.Add(400.0f * 2.0f);
        yLevel.Add(400.0f * 3.0f);
        yLevel.Add(400.0f * 4.0f);
        yLevel.Add(400.0f * 5.0f);

    }
	
	// Update is called once per frame
	void Update () {

        zoomsetting();
        keyboardControls();
        mouseControls();

        if (keyUp == true || mouseUp == true)
        {
            transform.position += (new Vector3(0, 0, 1) * speed) * Time.deltaTime;

            ///if(Vector3.Distance(worldCenter,transform.position) > worldRad)
            //{
              //  transform.position -= (new Vector3(0, 0, 1) * speed) * Time.deltaTime;
            //}
        }
        if (keyDown == true || mouseDown == true)
        {
            transform.position += (new Vector3(0, 0, -1) * speed) * Time.deltaTime;

           /// if (Vector3.Distance(worldCenter, transform.position) > worldRad)
           // {
           //     transform.position += (new Vector3(0, 0, 1) * speed) * Time.deltaTime;
            //}
        }
        if (keyRight == true || mouseRight == true)
        {
            transform.position += (new Vector3(1, 0, 0) * speed) * Time.deltaTime;

            if (Vector3.Distance(worldCenter, transform.position) > worldRad)
            {
                transform.position += (new Vector3(0, 0, 1) * speed) * Time.deltaTime;
            }
        }
        if (keyLeft == true || mouseLeft == true)
        {
            transform.position += (new Vector3(-1, 0, 0) * speed) * Time.deltaTime;

            if (Vector3.Distance(worldCenter, transform.position) > worldRad)
            {
                transform.position += (new Vector3(0, 0, 1) * speed) * Time.deltaTime;
            }
        }

        if (yTransition == true)
        {
            Vector3 toSeek = new Vector3(transform.position.x, yLevel[indexY], transform.position.z);
            Vector3 go = (Vector3.Normalize(toSeek - transform.position) * transitionSpeed) * Time.deltaTime;
            transform.position += go;

            if(within(transform.position.y, yLevel[indexY]))
            {
                yTransition = false;
            }     
        }

        // removes floating point error which creates flickering
        transform.position = new Vector3(transform.position.x, (float)((int)transform.position.y), transform.position.z);
    }

    void keyboardControls()
    {
        if (Input.GetKeyDown("up"))
        {
            keyUp = true;
        }
        else if (Input.GetKeyUp("up"))
        {
            keyUp = false;
        }
        if (Input.GetKeyDown("down"))
        {
            keyDown = true;
        }
        else if (Input.GetKeyUp("down"))
        {
            keyDown = false;
        }
        if (Input.GetKeyDown("right"))
        {
            keyRight = true;
        }
        else if (Input.GetKeyUp("right"))
        {
            keyRight = false;
        }
        if (Input.GetKeyDown("left"))
        {
            keyLeft = true;
        }
        else if (Input.GetKeyUp("left"))
        {
            keyLeft = false;
        }
    }

    void mouseControls()
    {

        Vector2 mousePos = Input.mousePosition;


        float screenHeight = Screen.height;
        float screenWidth = Screen.width;

        if(mousePos.y >= screenHeight - (screenHeight * 0.10))
        {
            mouseUp = true;
        }
        else
        {
            mouseUp = false;
        }

        if (mousePos.y <= 0 + (screenHeight * 0.10))
        {
            mouseDown = true;
        }
        else
        {
            mouseDown = false;
        }

        if (mousePos.x >= screenWidth - (screenWidth * 0.10))
        {
            mouseRight = true;
        }
        else
        {
            mouseRight = false;
        }

        if (mousePos.x <= 0 + (screenWidth * 0.10))
        {
            mouseLeft = true;
        }
        else
        {
            mouseLeft = false;
        }

    }

    void zoomsetting()
    {

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && yTransition == false && indexY != yLevel.Count -1 )
        {
            indexY++;
            yTransition = true;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && yTransition == false && indexY != 0)
        {
            indexY--;
            yTransition = true;
        }

    }

    bool within(float current, float target)
    {
        if(Mathf.Abs(current - target) < 0.001f)
        {
            return true;
        }


        return false;
    }

    public Transform screenSelection()
    {
       RaycastHit hit;
       Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

       if (Physics.Raycast(mouseRay, out hit, 2500.0f))
       {
           return hit.transform;
       }

       return hit.transform;
    }


    public void worlddata(Vector3 wCenter, float rad, List<float> levels)
    {
        worldCenter = wCenter;
        worldRad = rad;
        yLevel = levels;
    }

}
