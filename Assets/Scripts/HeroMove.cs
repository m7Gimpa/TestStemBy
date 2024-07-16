using Services.Input;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _movementSpeed;

    private IInputService _inputService;
    private Camera _camera;

    private void Awake()
    {
        _inputService = new InputService();
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        Vector2 movementVector = Vector2.zero;
        
            movementVector = _camera.transform.TransformDirection(_inputService.Axis);
            movementVector.Normalize();
            
        _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);

        if (movementVector.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (movementVector.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}