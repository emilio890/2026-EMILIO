using DG.Tweening;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyTeleregyScript : MonoBehaviour
{
    Rigidbody2D rbenemy;

    [SerializeField]
    private float speedenemyN;
    [SerializeField]
    private float speedenemyC;
    private Transform player;
    [SerializeField]
    private float chasedistance;
    [SerializeField]
    private int enemyhp ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerobjet = GameObject.FindGameObjectWithTag("Player");
         if (playerobjet != null)
        {
            player = playerobjet.transform;
        }
        rbenemy = GetComponent<Rigidbody2D>();
        //speedenemyN += 1f;
        //speedenemyC += 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        float velocityone = speedenemyN;
        if (distance < chasedistance)
        {
            velocityone = speedenemyC;
        }
        transform.position = Vector2.MoveTowards(transform.position, player.position, velocityone * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            enemyhp--;

            GetComponent<SpriteRenderer>().material.DOColor(Color.blue, 1).From();
            GetComponent<SpriteRenderer>().material.DOColor(Color.red, 1);
            if (enemyhp <= 0)
            {
                managerscript.instance.addscore(75);
                Destroy(this.gameObject);
            }
        }
            if (collision.gameObject.CompareTag("killbox"))
            {
                Destroy(this.gameObject);

            }
    }
    
}
