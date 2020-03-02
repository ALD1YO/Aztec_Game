using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    public Transform playerCam, character, centerPoint;
    public MovementAnimation moveAnim;

    private float mouseX, mouseY;
    public float mouseSensitivity = 10f;
    public float mouseYPosition = 1f;

    private float moveFB, moveLR;
    public float moveSpeed = 4f;
    public float gravityForce = 9.8f;

    private float zoom;
    public float zoomSpeed = 2;

    public float zoomMin = -0.4f;
    public float zoomMax = -1.5f;

    public float rotationSpeed = 5f;

    float energia;
    bool puedeCorrer;
    bool puedeCaminar;
    bool pausa;

    // Use this for initialization
    void Start()
    {
        puedeCorrer = true;
        zoom = -1;

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
                puedeCorrer = true;
                moveSpeed = 10f;
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
            moveSpeed = 3f;
            energia += .2f + Time.deltaTime;
            if (energia >= 200f)
                energia = 200f;
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
        centerPoint.position = new Vector3(character.position.x, character.position.y + mouseYPosition, character.position.z);

        if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0 
            || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {

            Quaternion turnAngle = Quaternion.Euler(0, centerPoint.eulerAngles.y, 0);

            character.rotation = Quaternion.Slerp(character.rotation, turnAngle, Time.deltaTime * rotationSpeed);

        }
    }
    void centraCamara()
    {
        playerCam.transform.localPosition = new Vector3(0, 0, zoom);
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
