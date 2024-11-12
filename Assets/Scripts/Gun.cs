using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Projectile projectilePrefab;
    public int municao = 10;
    public int municaoMax = 10;
    public int damage = 1;

    //Variável para mudar entre os tipos de disparo
    public int tiposTiro = 0;

    //Variáveis cronômetro
    private float autoTimer = 0f;
    public float reloadSetTime;
    private float reloadTimer = 0f;
    private bool reloadTimerAtivo = false;

    //void SwitchType()
    //{
    //    if (Input.GetButtonDown("Fire3"))
    //    {
    //        tiposTiro++;
    //        if (tiposTiro > 2)
    //        {
    //            tiposTiro = 0;
    //        }
    //    }
    //}

    void FireProjectile()
    {
        //Decide que tipo de tiro será feito
        switch(tiposTiro)
        {
            case 0: SingleFire(); break;
            case 1: AutoFire(); break;
            case 2: SpreadFire(); break;
        }
    }

    void ReloadGun()
    {
        //Esse if é para começar o recarregamento a partir do Input do jogador
        if (Input.GetButtonDown("Fire2") && !reloadTimerAtivo)
        {
            reloadTimerAtivo = true;
        }

        //Esse if é para dar tempo antes de recarregar a arma
        if (reloadTimerAtivo)
        {
            reloadTimer -= Time.deltaTime;
            if (reloadTimer <= 0)
            {
                reloadTimer = reloadSetTime;
                reloadTimerAtivo = false;
                municao = municaoMax;
            }

        }
    }

    //Região de comportamento dos tipos de disparo
    #region Tipos de Tiro

    //Método para tiro de disparo único
    void SingleFire()
    {
        if (Input.GetButtonDown("Fire1") /*&& municao > 0 && !reloadTimerAtivo*/)
        {
            Projectile _projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            _projectile.damage = damage;
            //municao--;
        }
    }

    //Método para tiro de disparo automático
    void AutoFire()
    {
        autoTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && municao > 0 && autoTimer <= 0 & !reloadTimerAtivo)
        {
            autoTimer = 0.095f;
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            municao--;
        }
    }

    //Método para tiro de disparo de dispersão
    void SpreadFire()
    {
        if (Input.GetButtonDown("Fire1") && municao > 2 && !reloadTimerAtivo)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Instantiate(projectilePrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, +20f)));
            Instantiate(projectilePrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -20f)));
            municao -= 3;
        }
    }
    #endregion

    private void Start()
    {
        reloadTimer = reloadSetTime;
    }
    private void Update()
    {
        FireProjectile();
        ReloadGun();
        //SwitchType();
    }

}
