using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class demo_manager : MonoBehaviour
{
    //This script manages:
    //Title screen
    //Instruction menu
    //Spawning mechanic


    public GameObject titleScreen;
    public bool canShoot;
    private int shapeNum = 1;
    public GameObject shapeSelectGameObject;
    public Sprite sphere;
    public Sprite cube;
    public Sprite capsule;
    public Sprite cylinder;
    private RectTransform shapeSelectRect;
    private Image shapeSelectImg;
    private GameObject newWaypoint;
    private Rigidbody newWaypointRB;
    public float spawnSpeed = 5f;
    private string shapeName = "Sphere";
    public Transform spawnPos;
    public static int spawnCount = 0;
    private int spawnCountMax = 500;
    public TextMeshProUGUI spawnCountTextField;
    public TextMeshProUGUI spawnDescTextField;


    //Instructions Window
    private Canvas mainCanvas;
    private bool instructionsWindowOpen;
    private GameObject instructionsWindowGameObject;
    private RectTransform instructionsWindowRect;


    void Start()
    {
        mainCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        shapeSelectRect = shapeSelectGameObject.GetComponent<RectTransform>();
        shapeSelectImg = shapeSelectRect.GetComponent<Image>();
        Cursor.lockState = CursorLockMode.Locked;

        spawnCountTextField.text = "0";
        spawnDescTextField.text = "Waypoints";

        //Hides title screen, then turns on the instructions prompt
        Invoke("HideTitleScreen", 0f);
    }

    void Update()
    {
        //Toggle Instructions Popup
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInstructions();
        }

        //Cycle through Game Object types
        if (Input.GetKeyDown("q") || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            shapeNum--;
            if (shapeNum == 0)
            {
                shapeNum = 4;
            }
        }

        if (Input.GetKeyDown("e") || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            shapeNum++;
            if (shapeNum == 5)
            {
                shapeNum = 1;
            }
        }

        switch (shapeNum)
        {
            case 1:
                shapeSelectImg.sprite = sphere;
                shapeName = "Sphere";
                break;
            case 2:
                shapeSelectImg.sprite = cube;
                shapeName = "Cube";
                break;
            case 3:
                shapeSelectImg.sprite = capsule;
                shapeName = "Capsule";
                break;
            case 4:
                shapeSelectImg.sprite = cylinder;
                shapeName = "Cylinder";
                break;
        }

        //SHOOT
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) //Shoot primary weapon
        {
            if (canShoot)
            {
                if (spawnCount < spawnCountMax)
                {
                    Shoot(shapeName);
                    spawnCount++;
                }
            }
            
        }

        //UPDATE TEXT
        if (spawnCount < spawnCountMax)
        {
            spawnCountTextField.text = spawnCount.ToString();
            spawnDescTextField.text = "Waypoints";
        }
        else
        {
            spawnCountTextField.text = "MAX";
            spawnDescTextField.text = "Press [R] to reset";
        }

    }


    void HideTitleScreen()
    {
        titleScreen.SetActive(false);
        //Turns Instructions window on
        ToggleInstructions();
    }

    void Shoot(string str)
    {
        newWaypoint = Instantiate(Resources.Load(str, typeof(GameObject)), spawnPos.position, Quaternion.identity) as GameObject;
        newWaypointRB = newWaypoint.AddComponent<Rigidbody>();
        newWaypointRB = newWaypoint.GetComponent<Rigidbody>();
        newWaypointRB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        newWaypointRB.AddForce(spawnPos.forward * spawnSpeed, ForceMode.Impulse); //give velocity forward
        Destroy(newWaypointRB.GetComponent<Rigidbody>(), 1f);
    }


    public void ToggleInstructions()
    {
        if (!instructionsWindowOpen) //If options window is closed, open it
        {
            instructionsWindowGameObject = Instantiate(Resources.Load("UI/Intructions Window", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
            instructionsWindowGameObject.layer = 5;
            instructionsWindowRect = instructionsWindowGameObject.GetComponent<RectTransform>();
            instructionsWindowRect.transform.SetParent(mainCanvas.transform);
            instructionsWindowRect.localScale = new Vector2(1f, 1f); //user set scale
            instructionsWindowRect.transform.localPosition = new Vector3(0f, 0f, 0f);

            //Debug.Log("Options Window Open");
            instructionsWindowOpen = true;
            Cursor.lockState = CursorLockMode.None;
            //Stop player movement
            fpc.playerCanMove = false;
            canShoot = false;
        }
        else //Close options window
        {
            Destroy(instructionsWindowGameObject);
            //Debug.Log("Options Window Closed");
            instructionsWindowOpen = false;
            Cursor.lockState = CursorLockMode.Locked;
            //Enable player movement
            fpc.playerCanMove = true;
            canShoot = true;
        }
    }
}
