using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerState))]
public class CharacterControllerScript : MonoBehaviour {
    private GameObject _camera;
    private float _speed = 3f;
    private float _groundFadeSpeed = 10f;
    private float _airFadeSpeed = 0.1f;
    private float _jumpPower = 5f;
    private Vector3 _momentum;
    private PlayerState _playerState;
    private CharacterController _controller;

    // Use this for initialization
    void Start () {
        _camera = this.transform.FindChild("Camera").gameObject;
        _playerState = this.GetComponent<PlayerState>();
        _controller = this.GetComponent<CharacterController>();
        _momentum = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
        HandleMovementFade(_controller);
        HandleMovement(_controller);
        HandleGravity(_controller);
        HandleRotation(_controller);
        ApplyMomentum(_controller);
    }

    void HandleMovement(CharacterController controller)
    {
        Vector3 moveDirection = new Vector3();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= _speed;


            if (Input.GetKey(KeyCode.LeftShift) && _playerState.GetStamina(1))
                moveDirection *= _playerState.GetRunBooster();


            _momentum.x = moveDirection.x;
            _momentum.z = moveDirection.z;

            if (Input.GetButton("Jump") && _playerState.GetStamina(10))
                _momentum.y += _playerState.GetJumpPower();
        }
    }

    void HandleMovementFade(CharacterController controller)
    {
        if((!controller.isGrounded)||(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0))
        {
            _momentum.x = Mathf.MoveTowards(_momentum.x, 0, controller.isGrounded ? _groundFadeSpeed * Time.deltaTime : _airFadeSpeed * Time.deltaTime);
            _momentum.z = Mathf.MoveTowards(_momentum.z, 0, controller.isGrounded ? _groundFadeSpeed * Time.deltaTime : _airFadeSpeed * Time.deltaTime);
        }
    }

    void HandleGravity(CharacterController controller)
    {
        if (controller.isGrounded && _momentum.y < 0)
            _momentum.y = 0;
        else if (!controller.isGrounded)
            _momentum.y -= Settings.Gravity * Time.deltaTime;
    }

    void ApplyMomentum(CharacterController controller)
    {
        controller.Move(_momentum * Time.deltaTime);
    }

    void HandleRotation(CharacterController controller)
    {
        float h = Settings.MouseSensetive * Input.GetAxis("Mouse X");
        float v = -Settings.MouseSensetive * Input.GetAxis("Mouse Y");
        transform.Rotate(0, h, 0);
        _camera.transform.Rotate(v, 0, 0);
    }
}
