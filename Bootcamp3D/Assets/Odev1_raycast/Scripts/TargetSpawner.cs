using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] GameObject targetPrefab;
    [SerializeField] Transform spawnCenter;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] Vector2 spawnRange = new Vector2(5f, 3f);
    
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;    
        if(timer >= spawnInterval)
        {
            timer = 0f;
            SpawnTarget();
        }

    }

    private void SpawnTarget()
    {
        float randomX = Random.Range(-spawnRange.x, spawnRange.x);
        float randomY = Random.Range(-spawnRange.y, spawnRange.y);
        
        Vector3 spawnPos= spawnCenter.position + new Vector3(randomX, randomY, 0f);

        Instantiate(targetPrefab, spawnPos, targetPrefab.transform.rotation);
    }
}
