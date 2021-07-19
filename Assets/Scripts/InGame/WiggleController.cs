using UnityEngine;

public class WiggleController : MonoBehaviour
{
	public bool isWiggling;

	[SerializeField] float _distance;
	[SerializeField] float _movementSpeed;
 
    [HideInInspector]
    public enum wiggleDirection {
        flyingUp,
        flyingDown
    }

    [HideInInspector]
    public wiggleDirection wigglingDirection;
    //[Tooltip("Set true if the gameobject is rotated to back view")]
    //public bool changeRotation;


    int _direction; //1 -> flying up, -1 -> flying down
    float _limit;
    Vector3 _originalPosition;

    void Start() {
        isWiggling = true;
        _direction = 1;
        _originalPosition = transform.position;
    }

    private void OnEnable() {
        _originalPosition = transform.position;
    }

    void Update() {
        if (isWiggling) {
            if (_direction == 1) {
                _limit = _originalPosition.y + _distance;
                if (transform.position.y > _limit) _direction = -1;
            }
            else if (_direction == -1)
            {
                _limit = _originalPosition.y - _distance;
                if (transform.position.y < _limit) _direction = 1;
            }

           switch(_direction) {
                case 1: wigglingDirection = wiggleDirection.flyingUp; break;
                case -1: wigglingDirection = wiggleDirection.flyingDown; break;
            }
            this.transform.position = Vector3.MoveTowards(this.transform.position, 
                new Vector3(transform.position.x, 
                transform.position.y + _movementSpeed * Time.deltaTime * _direction, 
                transform.position.z), 5f);
        }
    }
}
