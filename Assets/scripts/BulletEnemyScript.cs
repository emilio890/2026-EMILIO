using UnityEngine;

public class BulletEnemyScript : MonoBehaviour
{
    [SerializeField]
    private float timeplay;
    [SerializeField]
    private float speed;

    private float time;


    private void OnEnable()
    {
        time = 0;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        time += Time.deltaTime;
        if (this.gameObject.activeInHierarchy)
        {

            if (time >= timeplay)
            {
                gameObject.SetActive(false);

            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }

    }


}
