using UnityEngine;
public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _direction;

    [SerializeField] float _gravity = 9.81f * 2f;
    [SerializeField] private float _forseJump;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>(); 
    }

    private void OnEnable()
    {
        _direction = Vector3.zero;
    }

    private void Update()
    {
        _direction += Vector3.down * _gravity * Time.deltaTime;
        _characterController.Move(_direction * Time.deltaTime);

        if (_characterController.isGrounded)
        {
            if (Input.GetButton("Jump")) _direction = Vector3.up * _forseJump;
        };
        
    }
}


 