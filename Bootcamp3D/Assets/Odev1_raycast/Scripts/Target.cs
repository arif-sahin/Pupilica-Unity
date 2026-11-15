using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeTime);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit()
    {
        Debug.Log("Hedef Vuruldu!");
        Destroy(gameObject);
    }
}
