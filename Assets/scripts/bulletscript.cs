using Unity.VisualScripting;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    [SerializeField]
    private float timeplay;
    [SerializeField]
    private float speed;

    private float time;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        time = 0;
    }
        

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        time += Time.deltaTime;
        if (this.gameObject.activeInHierarchy)
        {

            if (time >= timeplay)
            {
                gameObject.SetActive(false);

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            gameObject.SetActive(false);

        }
    }
}
