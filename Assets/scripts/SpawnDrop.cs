using UnityEngine;

public class SpawnDrop : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabdrop;
    public float timeinwave;
    
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
            Spawner();
            cronometre = 0;
            timeinwave = Mathf.Max(20f, timeinwave - 0.4f);

        }
    }
    void Spawner()
    {

        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Instantiate(prefabdrop, pos, Quaternion.identity);
        
    }
}
