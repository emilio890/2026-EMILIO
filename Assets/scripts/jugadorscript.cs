using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class jugadorscript : MonoBehaviour
{
    [SerializeField]
    private InputAction inputmovement;
    [SerializeField]
    private InputAction shoot;
    [SerializeField]
    private Rigidbody2D rbd2D;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private List<GameObject> bullets = new List<GameObject>();
    [SerializeField]
    private int ammo;
    [SerializeField]
    private float minlimitX;
    [SerializeField]
    private float maxlimitX;
    [SerializeField]
    private float minlimitY;
    [SerializeField]
    private float maxlimitY;
    [SerializeField]
    private managerscript Gamemanager;
    [SerializeField]
    private AudioSource disparo;
    private void OnEnable()
    {
        inputmovement.Enable();

        shoot.Enable();

    }
    private void OnDisable()
    {
        inputmovement.Disable();

        shoot.Disable();
    }
    private void FixedUpdate()
    {
        Vector2 movement = inputmovement.ReadValue<Vector2>();
        rbd2D.linearVelocity = movement * 5;

        Vector2 pos = rbd2D.position;
        pos.x = Mathf.Clamp(pos.x, minlimitX, maxlimitX);
        pos.y = Mathf.Clamp(pos.y, minlimitY, maxlimitY);
        rbd2D.position = pos;
        rbd2D.linearVelocity = Vector2.ClampMagnitude(rbd2D.linearVelocity, 10);
    }

  
    void Start()
    {
       
        for (int i = 0; i < ammo; i++)
        {
            GameObject temp = Instantiate(bullet);
            temp.SetActive(false);
            bullets.Add(temp);
        }
    }

   
    void Update()
    {
      
        if (shoot.triggered)
        {
     
            GameObject temp = Getbullet();
            temp.SetActive(true);
            temp.transform.position = transform.position;
            disparo.PlayOneShot(disparo.clip);
      
        }
        
    }
    GameObject Getbullet()
    {
        foreach (GameObject b in bullets)
        {
            if (!b.activeInHierarchy)
            {
                return b;
            }
        }
            GameObject temp = Instantiate(bullet);
            temp.SetActive(false);
            bullets.Add(temp);
            return temp;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Gamemanager.gameover();
            Destroy(this.gameObject);
        }
    }
}
