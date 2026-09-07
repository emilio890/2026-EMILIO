using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class enemyscript : MonoBehaviour
{
 Rigidbody2D rbenemy;
   


    void Start()
    {
        rbenemy = GetComponent<Rigidbody2D>();
        rbenemy.AddForce(Vector2.down * 100);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            managerscript.instance.addscore(25);
            Destroy(this.gameObject);

        }
    }
}

