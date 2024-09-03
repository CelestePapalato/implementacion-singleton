using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static Action onDead;

    [SerializeField]
    GameObject proyectil;
    [SerializeField]
    float cooldownDisparo;

    bool canShoot = true;

    private void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }
        VerificarInput();
    }

    private void VerificarInput()
    {
        if (Input.anyKeyDown)
        {
            Disparar();
        }
    }

    private void Disparar()
    {
        if(!proyectil || !canShoot) { return; }
        Instantiate(proyectil, transform.position, Quaternion.identity);
        Debug.Log("pium");
        SoundManager.Instance.Play("disparo");
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldownDisparo);
        canShoot = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        onDead?.Invoke();
    }
}
