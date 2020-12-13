using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject _cam;
    private Transform _body;
    private CharacterController _player;

    [HideInInspector] public bool _isSit;
    [Range(0, 5)] public float _bodySpeed;
    private float _rotCamaraY;
    private Vector3 _camForward, _camRight;

    void Awake()
    {
        _player = GetComponent<CharacterController>();
        _cam = GameObject.FindGameObjectWithTag("MainCamera");

        _body = transform.GetChild(1);
        _isSit = false;
    }

    void Update()
    { 
        _rotCamaraY = _cam.transform.localEulerAngles.y;
        _body.localRotation = Quaternion.Euler(0, _rotCamaraY, 0);

        if (!_isSit)
        {
            float _h, _v;
            _h = Input.GetAxis("Horizontal");
            _v = Input.GetAxis("Vertical");

            Vector3 playerInput = new Vector3(_h, 0, _v);
            playerInput = Vector3.ClampMagnitude(playerInput, 1);

            GetCamDirection();

            Vector3 movePlayer = playerInput.x * _camRight + playerInput.z * _camForward;
            movePlayer = movePlayer * _bodySpeed;

            _player.Move(movePlayer * Time.deltaTime);

            /*if (_h != 0 || _v != 0)
                transform.position = new Vector3(transform.position.x, 1, transform.position.z);*/
        }
    }
    void GetCamDirection()
    {
        _camForward = _cam.transform.forward;
        _camRight = _cam.transform.right;

        _camForward.y = 0;
        _camRight.y = 0;

        _camForward = _camForward.normalized;
        _camRight = _camRight.normalized;
    }
}