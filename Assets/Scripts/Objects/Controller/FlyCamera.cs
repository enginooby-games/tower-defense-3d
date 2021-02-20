using UnityEngine;
using System.Collections;

public class FlyCamera : MonoBehaviour
{

    /* 
    Made simple to use (drag and drop, done) for regular keyboard layout  
    wasd : basic movement
    shift : Makes camera accelerate
    space : Moves camera on X and Z axis only.  So camera doesn't gain any height*/
    public float mainSpeed = 50.0f; //regular speed
    public float shiftAdd = 150.0f; //multiplied by how long shift is held.  Basically running
    public float maxShift = 1000.0f; //Maximum speed when holding shift
    public float sensitivity = 0.25f; //How sensitive it with mouse
    public bool rotateOnlyIfMousedown = true;
    public bool movementStaysFlat = true;

    [Header("BOUNDARIES")]
    public bool boundaryEnabled = true;
    public Vector2 xRange = new Vector2(-60, 60);
    public Vector2 yRange = new Vector2(8, 60);
    public Vector2 zRange = new Vector2(-50, 55);

    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
    private float totalRun = 1.0f;

    void Awake()
    {
        // ResetCamera();
    }

    void ResetCamera()
    {
        Debug.Log("FlyCamera Awake() - RESETTING CAMERA POSITION");
        transform.position = new Vector3(0, 8, -32);
        transform.rotation = Quaternion.Euler(25, 0, 0);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            lastMouse = Input.mousePosition; // $CTK reset when we begin
        }

        if (!rotateOnlyIfMousedown || (rotateOnlyIfMousedown && Input.GetMouseButton(1)))
        {
            lastMouse = Input.mousePosition - lastMouse;
            lastMouse = new Vector3(-lastMouse.y * sensitivity, lastMouse.x * sensitivity, 0);
            lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
            transform.eulerAngles = lastMouse;
            lastMouse = Input.mousePosition;
            //Mouse  camera angle done.  
        }

        //Keyboard commands
        float f = 0.0f;
        Vector3 p = GetBaseInput();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            totalRun += Time.deltaTime;
            p = p * totalRun * shiftAdd;
            p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
            p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
            p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
        }
        else
        {
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p * mainSpeed;
        }

        p = p * Time.deltaTime;

        //If player wants to move on X and Z axis only
        if (Input.GetKey(KeyCode.Space) || (movementStaysFlat && !(rotateOnlyIfMousedown && Input.GetMouseButton(1))))
        {
            Vector3 newPosition = transform.position;
            transform.Translate(p);
            newPosition.x = transform.position.x;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
        }
        else
        {
            transform.Translate(p);
        }

        if (boundaryEnabled) ProcessBoundaries();
    }

    private void ProcessBoundaries()
    {
        Vector3 newPosition;
        newPosition.x = Mathf.Clamp(transform.position.x, xRange.x, xRange.y);
        newPosition.y = Mathf.Clamp(transform.position.y, yRange.x, yRange.y);
        newPosition.z = Mathf.Clamp(transform.position.z, zRange.x, zRange.y);

        transform.position = newPosition;
    }

    private Vector3 GetBaseInput()
    { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            p_Velocity += new Vector3(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            p_Velocity += new Vector3(0, 1, 0);
        }
        return p_Velocity;
    }
}