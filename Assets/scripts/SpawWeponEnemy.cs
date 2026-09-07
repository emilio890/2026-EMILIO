using UnityEngine;

public class SpawWeponEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabEnemyChase;
    public float timeinwave;
    public int waveEnemy;
    [SerializeField]
    private float dOnEnemy;
    private float cronometre;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        cronometre += Time.deltaTime;
        if (cronometre >= timeinwave)
        {
            SpawnerFila();

            cronometre = 0;

        }
        
    }
    void SpawnerFila()
    {
        float anchoTotal = dOnEnemy * (waveEnemy - 1);
        float posIX = transform.position.x - (anchoTotal / 2f);
        for (int i = 0; i < waveEnemy; i++)
        {
            float posX = posIX + (i * dOnEnemy);
            Vector3 pos = new Vector3(posX, transform.position.y, transform.position.z);

            Instantiate(prefabEnemyChase, pos, Quaternion.identity);
        }
    }
}
