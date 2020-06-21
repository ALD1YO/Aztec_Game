using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    public Transform playerCam, character, centerPoint;
    public P_Anim moveAnim;

    public float centerPoint_y_personalAdjustment;

    private float mouseX, mouseY;
    public float mouseSensitivity = 10f;
    public float mouseYPosition = 1f;

    private float moveFB, moveLR;
    public float moveSpeed = 4f;
    public float gravityForce = 9.8f;

    public float zoom;
    public float zoomSpeed = 2;

    public float zoomMin = -0.4f;
    public float zoomMax = -1.5f;

    public float rotationSpeed = 5f;

    float energia;
    bool puedeCorrer;
    bool puedeCaminar;
    bool pausa;

    public ShapeShift shapeShift;
    public float WalkSpeed=3f;
    public float RunSpeed = 10f;
    public float ShapeShiftSpeed = 1f;
    private bool EsJaguar = false; 

    //private ShapeShift shapeShift;
    //public GameObject ShapeShift_script;
    // Use this for initialization
    private void Awake()
    {
        //shapeShift = new ShapeShift();

        
        
    }
    void Start()
    {
        puedeCorrer = true;
        EsJaguar = shapeShift.EsJaguar;
    }

    // Update is called once per frame
    void Update()
    {
        pausa = G_Singleton.instance.pausa;
        if (pausa == false)
        {
            zoomCamara();
            moverCamara();
            centraCamara();
            if (puedeCaminar)
                Movimiento();
        }
        puedeCaminar = moveAnim.puedeCaminar;

       
    }

    void Movimiento()
    {
        moveAnim.puedeCorrer = puedeCorrer;
        energia = P_Singleton.instance.stamina;
        moveFB = Input.GetAxis("Vertical") * moveSpeed;
        moveLR = Input.GetAxis("Horizontal") * moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift) && puedeCorrer)
        {
            if (energia > 0f)
            {
                EsJaguar = shapeShift.EsJaguar;
                if (EsJaguar)
                {
                    ShapeShiftSpeed = 1.8f;
                }
                else
                {
                    ShapeShiftSpeed = 1.0f;
                }
                puedeCorrer = true;
                moveSpeed = RunSpeed*ShapeShiftSpeed;
                energia -= .4f + Time.deltaTime;
                if (energia <= 0)
                    energia = 0f;
                P_Singleton.instance.setStamina(energia);
            }
            else
            {
                puedeCorrer = false;
            }
        }
        else
        {
            moveSpeed = WalkSpeed;
            energia += .2f + Time.deltaTime;
            if (energia >= 100f)
                energia = 100f;
            P_Singleton.instance.setStamina(energia);
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveSpeed = moveSpeed / 2;
        }
        if (energia >= 20f)
        {
            puedeCorrer = true;
        }


        Vector3 movement = new Vector3(moveLR, -gravityForce, moveFB);
        movement = character.rotation * movement;
        character.GetComponent<CharacterController>().Move(movement * Time.deltaTime);
        centerPoint.position = new Vector3(character.position.x, character.position.y- centerPoint_y_personalAdjustment + mouseYPosition, character.position.z);

        if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0 
            || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {

            Quaternion turnAngle = Quaternion.Euler(0, centerPoint.eulerAngles.y, 0);

            character.rotation = Quaternion.Slerp(character.rotation, turnAngle, Time.deltaTime * rotationSpeed);

        }
    }
    void centraCamara()
    {
        //ShapeShift shapeShift = ShapeShift_script.GetComponent<ShapeShift>();
        //playerCam.transform.localPosition = new Vector3(0, shapeShift.posicion_camara, zoom);
        mouseY = Mathf.Clamp(mouseY, -20f, 30f);
        playerCam.LookAt(centerPoint);
        centerPoint.localRotation = Quaternion.Euler(mouseY, mouseX, 0);
    }
    void moverCamara()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY -= Input.GetAxis("Mouse Y");
    }
    void zoomCamara()
    {
        zoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        if (zoom > zoomMin)
            zoom = zoomMin;

        if (zoom < zoomMax)
            zoom = zoomMax;
    }
}
