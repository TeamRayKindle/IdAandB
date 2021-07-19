
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float carpetWindOffset = 1f;
	public float rotateAngle;
	public float rotateAngleSpeed;
	public float z;

	[SerializeField]  CharacterController _controller;
	[SerializeField] float _speed = 3f;
	[SerializeField] bl_Joystick _joystick;
	[SerializeField] bool _idleShake;
	[SerializeField] int _carpetPos;//1 = up, 2= down
	[SerializeField] GameObject _joyStickButton;
	[SerializeField] Camera _mainCam;
	[SerializeField] GameObject _carpet;
	[SerializeField] AudioSource _cSound;

    bool _autoMoving;
	WiggleController _wiggle;
    public bool CanTc = true;
	void Start() {
        if (CanTc == true)
        {
            _wiggle = transform.GetComponent<WiggleController>();
            _cSound = _carpet.GetComponent<AudioSource>();
        }

        _carpetPos = 1;
    }

    void Update() {
        _carpetPos = 2;//this is a hack - mmj
        if (_carpetPos == 1)
            if (CanTc == true)
            { _wiggle.enabled = true; }
                
        if (_carpetPos == 2) { 
            //Controllable only if down
			_autoMoving = false;
            if (CanTc == true)
            {
                _wiggle.enabled = true;
            }
			rotateAngle = -_joystick.Horizontal/ rotateAngleSpeed;

			z = -_joystick.Vertical;

            Vector3 move = transform.forward * z;//transform.right * x + transform.forward * z;
            if (_controller.enabled)
                _controller.Move(move * _speed / 4f * Time.deltaTime);

            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + rotateAngle * -8 * _speed * Time.deltaTime, transform.localEulerAngles.z);
            _mainCam.transform.localEulerAngles = new Vector3(z, _mainCam.transform.localEulerAngles.y, rotateAngle * 2f);
            _carpet.transform.localEulerAngles = new Vector3(rotateAngle * 2f, _carpet.transform.localEulerAngles.y, -z);
            _cSound.volume = (Mathf.Abs(z) / 20f) * carpetWindOffset;

            if (_idleShake && !_autoMoving) {
                if (z <= 0.1f && z >= 0) {
                    if (CanTc == true)
                    {
                        _wiggle.isWiggling = true;
                    }
                        _controller.enabled = false;
                    
                }
                else {
                    if (CanTc == true)
                    {
                        _wiggle.isWiggling = false;
                    }
                    _controller.enabled = true;
                }
            }
        }
    }
}
