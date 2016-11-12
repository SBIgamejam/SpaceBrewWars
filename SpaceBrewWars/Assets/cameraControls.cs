using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cameraControls : MonoBehaviour {

    private float speed = 30.0f;
    private float transitionSpeed = 75.0f;

    private bool keyRight;
    private bool keyLeft;
    private bool keyUp;
    private bool keyDown;

    private bool mouseUp;
    private bool mouseDown;
    private bool mouseRight;
    private bool mouseLeft;

    private int indexY = 0;
    private List<float> yLevel = new List<float>();
    bool yTransition = false;

    void Start () {

        transform.rotation = Quaternion.AngleAxis(45.0f, new Vector3(1, 0, 0));
        keyRight = keyLeft = keyUp = keyDown = false;
        mouseUp = mouseDown = mouseLeft = mouseRight = false;

        yLevel.Add(200.0f);
        yLevel.Add(200.0f * 2.0f);
        yLevel.Add(200.0f * 3.0f);
        yLevel.Add(200.0f * 4.0f);
        yLevel.Add(200.0f * 5.0f);

        Debug.Log(yLevel.Count);

        Debug.Log(Screen.width);
    }
	
	// Update is called once per frame
	void Update () {

        zoomsetting();
        keyboardControls();
        mouseControls();

        if (keyUp == true || mouseUp == true)
        {
            transform.position += (new Vector3(0, 0, 1) * speed) * Time.deltaTime;
        }
        if (keyDown == true || mouseDown == true)
        {
            transform.position += (new Vector3(0, 0, -1) * speed) * Time.deltaTime;
        }
        if (keyRight == true || mouseRight == true)
        {
            transform.position += (new Vector3(1, 0, 0) * speed) * Time.deltaTime;
        }
        if (keyLeft == true || mouseLeft == true)
        {
            transform.position += (new Vector3(-1, 0, 0) * speed) * Time.deltaTime;
        }

        if(yTransition == true)
        {
            Vector3 toSeek = new Vector3(transform.position.x, yLevel[indexY], transform.position.z);
            Vector3 go = (Vector3.Normalize(toSeek - transform.position) * transitionSpeed) * Time.deltaTime;
            transform.position += go;

            if(within(transform.position.y, yLevel[indexY]))
            {
                yTransition = false;
            }

        }
    }

    void FixedUpdate()
    {
        screenSelection();
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
        if(Mathf.Abs(current - target) < 0.1)
        {
            return true;
        }


        return false;
    }

    void screenSelection()
    {
        // ray from mouse left click hit object
        if (Input.GetMouseButtonDown(0))
        {
            print("mouse clicked");
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log(mouseRay.origin);
            Debug.Log(mouseRay.direction);

            if (Physics.Raycast(mouseRay, out hit, 2500.0f))
            {
                Debug.Log("HIT");
            }


                // set isSelected in hit object
            }
    }

}
