using DG.Tweening;
using UnityEngine;

public class DropScript : MonoBehaviour
{
    Rigidbody2D rbenemy;

    [SerializeField]
    private float speededrop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbenemy = GetComponent<Rigidbody2D>();
        rbenemy.AddForce(Vector2.down * speededrop);
    }

    // Update is called once per frame
    void Update()
    {
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
           
          
           managerscript.instance.addscore(100);
           
            Destroy(this.gameObject);

        }
        if (collision.gameObject.CompareTag("killbox"))
        {
            Destroy(this.gameObject);

        }
    }
}

