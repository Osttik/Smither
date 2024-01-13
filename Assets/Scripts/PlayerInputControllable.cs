using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputControllable : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 3f;

    private PlayerController _playerController;
    private Vector2 _delta = Vector2.zero;

    private ActControll _actControll;


    private void Awake()
    {
        _playerController = new PlayerController();

        _playerController.Player.Move.performed += Move;
        _playerController.Player.Move.canceled += CancelMove;
        _playerController.Player.Fire.performed += Interact;
    }

    // Start is called before the first frame update
    void Start()
    {
        _actControll = GetComponent<ActControll>();
    }

    private void OnEnable()
    {
        _playerController.Enable();
    }

    private void OnDisable()
    {
        _playerController.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + _moveSpeed * Time.deltaTime * (Vector3)_delta.normalized;
    }

    public void Move(InputAction.CallbackContext context)
    {
        _delta = context.action.ReadValue<Vector2>();
    }

    public void CancelMove(InputAction.CallbackContext _) 
    {
        _delta = Vector2.zero;
    }

    public void Interact(InputAction.CallbackContext context)
    {
        _actControll.DoAction();
    }
}
