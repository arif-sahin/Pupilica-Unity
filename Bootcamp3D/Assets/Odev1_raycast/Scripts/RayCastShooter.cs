using UnityEngine;
using UnityEngine.InputSystem;

public class RayCastShooter : MonoBehaviour

{
    [SerializeField] Camera mainCamera;
    [SerializeField] float maxRange = 100f;
    [SerializeField] LayerMask targetLayerMask;

    [SerializeField] int score = 0;

    void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current == null) return;
        
        if (Mouse.current.leftButton.wasPressedThisFrame){
            Shoot();
        }
    }

    public void Shoot()
    {
        Debug.Log("Tıklandı!");
        RaycastHit hit;

        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = mainCamera.ScreenPointToRay(mousePos); // kameradan fare noktasına ışın
        
        Vector3 startPoint = mainCamera.transform.position + mainCamera.transform.right * 0.4f - mainCamera.transform.up * 0.3f;
        Vector3 endPoint = ray.origin + ray.direction * maxRange;

        if (Physics.Raycast(ray, out hit, maxRange, targetLayerMask))
        {
            endPoint = hit.point;
            Target target = hit.collider.GetComponent<Target>();


            if (target != null)
            {
                target.Hit();
                score += 1;
                Debug.Log($"hedef vuruldu. total skor: {score}");
            }
        }

        Debug.DrawLine(startPoint, endPoint, Color.red, 0.5f);
    }
}
