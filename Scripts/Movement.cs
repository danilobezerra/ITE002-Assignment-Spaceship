using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 10f;

    private float dirChangeTimer = 0;
    public float dirChangeTime = 1.2f;
    private float noMovTimer = 0f;
    public float noMovTime = 2f;

    //Variáveis que definem os comportamentos que teram as entidades.
    public bool startsStill;
    public bool entityTurns;
    public bool entityWaves;
    public bool enemyEntity;

    private void Update()
    {
        //Está definindo se a entidade é um jogador ou outra entidade
        if (!enemyEntity)
        { PlayerMovement(); }
        else
        {
            //Esse if define se a entidade vai começar parada
            if (!startsStill)
            {
                StraightMovement();
                WavingMovement();
                TurningMovement();
            }
            else
            {
                noMovTimer += Time.deltaTime;
                if (noMovTimer > noMovTime)
                {
                    startsStill = false;
                }
            }
        }
    }

    //Método que pega o input do jogador e transforma em movimento
    void PlayerMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        transform.Translate(Time.deltaTime * speed * new Vector3(horizontal, vertical));
    }

    //Adiciona movimento reto para inimigos ou entidades.
    void StraightMovement()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.up);
    }

    //Adiciona movimento de curva para um lado a inimigos ou entidades.
    void TurningMovement()
    {
        if (entityTurns && !entityWaves)
        {
            transform.Rotate(new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
        }
    }

    //Adiciona movimento ondular a inimigos ou entidades.
    void WavingMovement()
    {
        if (entityWaves)
        {
            dirChangeTimer += Time.deltaTime;
            if (dirChangeTimer > dirChangeTime)
            {
                dirChangeTimer = -dirChangeTime;
                rotationSpeed *= -1;
            }
            transform.Rotate(new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
        }
    }

}
