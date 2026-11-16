using UnityEngine;
using UnityEngine.InputSystem;

public class WolfController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f; // dönüş hızı
    [SerializeField] private int jumpHash;
    private Animator animator;
    private int isMovingHash; // IsMoving'in sayısal kimliği - her karede string aramamak için
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        isMovingHash = Animator.StringToHash("isMoving");
        jumpHash = Animator.StringToHash("Jump");
        
    }

    // Update is called once per frame
    void Update()
    {
        // güvenlik kontrolü
        if (Keyboard.current == null) return;
        float horizantal = 0f;
        float vertical = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            vertical += 1f;
        } 
        if (Keyboard.current.sKey.isPressed)
        {
            vertical -= 1f;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            horizantal += 1f;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            horizantal -= 1f;
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            animator.SetTrigger(jumpHash);
        }

        Vector3 moveDir = new Vector3(horizantal, 0f, vertical).normalized;

        bool isMoving = moveDir.sqrMagnitude > 0.01f;

        if(isMoving)
        {
            transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);

            Quaternion targetRotation = Quaternion.LookRotation(moveDir); // Kurdun bakması gereken yönü açıya çevirme
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // kavisle döndür
        }

        animator.SetBool(isMovingHash, isMoving);

    }
}
