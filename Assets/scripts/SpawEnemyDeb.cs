using Unity.VisualScripting;
using UnityEngine;

public class SpawEnemyDeb : MonoBehaviour
{

    [SerializeField]
    private GameObject prefabEnemydeb;
    public float timeinwave;
    public int waveEnemy;
    [SerializeField]
    private float dOnEnemy;

    private float cronometre;
    
    void Start()
    {
        SpawnerFila();
    }

    // Update is called once per frame
    void Update()
    {
        cronometre += Time.deltaTime;
        if (cronometre >= timeinwave)
        {
            SpawnerFila();
            cronometre = 0;
            timeinwave += 5;
        }
    }
    void SpawnerFila()
    {
        float anchoTotal = dOnEnemy * (waveEnemy - 1);
        float posIY = transform.position.y - (anchoTotal / 2f);
        for (int i = 0; i < waveEnemy; i++)
        {
            float posY = posIY + (i * dOnEnemy);
            Vector3 pos = new Vector3(transform.position.x, posY, transform.position.z);

            Instantiate(prefabEnemydeb, pos, Quaternion.identity);
        }
    }
}
