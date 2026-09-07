using UnityEngine;
using DG.Tweening;
public class EnemyTankScript : MonoBehaviour
{
    Rigidbody2D rbenemy;

    [SerializeField]
    private float speedenemy;
    [SerializeField]
    private int enemyhp = 5;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbenemy = GetComponent<Rigidbody2D>();
        rbenemy.AddForce(Vector2.down * speedenemy);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            
            enemyhp--;
            
            GetComponent<SpriteRenderer>().material.DOColor(Color.red, 1).From();
            GetComponent<SpriteRenderer>().material.DOColor(Color.orange, 1);
            if (enemyhp <= 0)
            {
                managerscript.instance.addscore(50);
                Destroy(this.gameObject);
            }
           

        }
    }
  
}
