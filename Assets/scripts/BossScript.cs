using DG.Tweening;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bossscript : MonoBehaviour
{
    Rigidbody2D rbenemy;

    [SerializeField]
    private float speedenemy;
    [SerializeField]
    private int enemyhp = 5;
    [SerializeField]
    private GameObject bulletenemy;
    [SerializeField]
    private List<GameObject> bullets = new List<GameObject>();
    [SerializeField]
    private int ammo;
    [SerializeField]
    private float tiemonshoot;
    private float cronometreshoot;
   
    [SerializeField]
    private float ymax = 4.02f;

    private bool posya = false;
    private Transform[] puntoDisparo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void FixedUpdate()
    {
        if (!posya)
        {
            rbenemy.linearVelocity = new Vector2(0, -speedenemy);
            if (transform.position.y <= ymax)
            {
                posya = true;
                rbenemy.linearVelocity = Vector2.zero;
            }
        }
        else
        {
            rbenemy.linearVelocity = Vector2.zero;
        }
    }
    void Start()
    {
        puntoDisparo = new Transform[4];
        puntoDisparo[0] = transform.Find("disparo1");
        puntoDisparo[1] = transform.Find("disparo2");
        puntoDisparo[2] = transform.Find("disparo3");
        puntoDisparo[3] = transform.Find("disparo4");

        rbenemy = GetComponent<Rigidbody2D>();
        rbenemy.AddForce(Vector2.down * speedenemy);


        for (int i = 0; i < ammo; i++)
        {
            GameObject bullet = Instantiate(bulletenemy);
            bullet.SetActive(false);
            bullets.Add(bullet);
        }
    }

    // Update is called once per frame
    void Update()
    {

        cronometreshoot += Time.deltaTime;
        if (cronometreshoot >= tiemonshoot)
        {
            for(int i = 0; i <puntoDisparo.Length; i++)
            { 
                GameObject bullet = Getbullet();
                bullet.transform.position = puntoDisparo[i].position;
                bullet.SetActive(true);
            }
            cronometreshoot = 0;
        }
    }
    GameObject Getbullet()
    {
        foreach (GameObject bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        GameObject newbullet = Instantiate(bulletenemy);
        newbullet.SetActive(false);
        bullets.Add(newbullet);
        return newbullet;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {

            enemyhp--;

            GetComponent<SpriteRenderer>().material.DOColor(Color.black, 1).From();
            GetComponent<SpriteRenderer>().material.DOColor(Color.pink, 1);
            if (enemyhp <= 0)
            {
                managerscript.instance.addscore(100);
                Destroy(this.gameObject);
            }

        }
    }
}
