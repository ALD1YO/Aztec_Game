using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject Bullet_Emitter;
    public MovementAnimation moveAnim;
    public ParticleSystem tinyExplosion;
    public ParticleSystem dustExplosionL;
    public ParticleSystem dustExplosionR;
    public ParticleSystem EarthShaker;
    public float speed;

    int spellLightValue;

    public bool puedeAtacar;
    public bool estaAtacando;

    private void Awake()
    {
        tinyExplosion.Stop();
        dustExplosionL.Stop();
        dustExplosionR.Stop();
        EarthShaker.Stop();
        puedeAtacar = true;
    }

    // Update is called once per frame
    void Update()
    {
        triggerBullet();
        puedeAtacar = moveAnim.puedeAtacar;
        estaAtacando = moveAnim.estaAtacando;
        spellLightValue = P_Singleton.instance.currentSpellValue;
    }

    void shootBullet()
    {
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
        Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
        Temporary_RigidBody.AddForce((transform.forward + new Vector3(0, 0.02f, 0)) * speed);
        Renderer Temporary_Renderer;
        Temporary_Renderer = Temporary_Bullet_Handler.GetComponent<Renderer>();
        Temporary_Renderer.material.color = P_Singleton.instance.spellLight;
        
    }
    void triggerBullet()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (puedeAtacar && estaAtacando == false && spellLightValue == 1)
            {
                StartCoroutine(waitForShootFire());
            }
            if (puedeAtacar && estaAtacando == false && spellLightValue == 2)
            {
                StartCoroutine(waitForShootEarth());
            }
        }
    }
    IEnumerator waitForShootFire()
    {
        yield return new WaitForSeconds(1.2f);
        AudioManager.instance.Play("Fireball");
        tinyExplosion.Play();
        shootBullet();
    }
    IEnumerator waitForShootEarth()
    {
        yield return new WaitForSeconds(1.2f);
        AudioManager.instance.Play("Blast");
        dustExplosionL.Play();
        dustExplosionR.Play();
        EarthShaker.Play();
        shootBullet();
    }
}
