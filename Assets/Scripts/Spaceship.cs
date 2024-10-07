using UnityEngine;

public class Spaceship : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private Bounds _cameraBounds;
    public Projectile projectilePrefab;
    public float speed = 5f;
    public int municaoAtualDaNave;
    public int municaoMaximaDaNave;
    public float tempoAtualDosDisparos;
    public float tempoMaximoEntreOsDisparos;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        var height = Camera.main.orthographicSize * 2f;
        var width = height * Camera.main.aspect;
        _cameraBounds = new Bounds(Vector3.zero, new Vector3(width, height));
        municaoAtualDaNave = municaoMaximaDaNave;
        tempoAtualDosDisparos = tempoMaximoEntreOsDisparos;
    }

    void LateUpdate()
    {
        var spriteWidth = _renderer.sprite.bounds.extents.x;
        var spriteHeight = _renderer.sprite.bounds.extents.y;

        var newPositon = transform.position;
        newPositon.x = Mathf.Clamp(newPositon.x, _cameraBounds.min.x + spriteWidth, _cameraBounds.max.x - spriteWidth);
        newPositon.y = Mathf.Clamp(newPositon.y, _cameraBounds.min.y + spriteHeight, _cameraBounds.max.y - spriteHeight);
        transform.position = newPositon;
    }

    void Update()
    {
        ApplyMovement();
        if(municaoAtualDaNave > 0)
        {
            FireProjectile();
        }
        else
        {
            RecarregarMunicaoDaNave();
        }
        
    }

    

    void FireProjectile()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            municaoAtualDaNave--;
        }
    }

    void ApplyMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        transform.Translate(Time.deltaTime * speed * new Vector3(horizontal, vertical));
    }

    private void RecarregarMunicaoDaNave()
    {
        if(tempoAtualDosDisparos > 0)
        {
            tempoAtualDosDisparos -= Time.deltaTime;
        }
        else
        {
            municaoAtualDaNave = municaoMaximaDaNave;
            tempoAtualDosDisparos = tempoMaximoEntreOsDisparos;
        }
    }
}
