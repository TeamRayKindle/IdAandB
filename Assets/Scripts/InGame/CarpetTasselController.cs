using UnityEngine;

public class CarpetTasselController : MonoBehaviour
{
    [Tooltip("Drag & Drop the gameobject where necessary WiggleScript is attached")]

	[SerializeField] WiggleController _wiggler;
	[SerializeField] FirstPersonController _player;
	[SerializeField] float _speed;

	public enum TasslePosition {
        left,
        right
    }

    public TasslePosition tasslePos;
    public Vector3 leftTasselForwardRot,temp;

    void Update() {
        if (_wiggler.isWiggling) {
            transform.GetChild(0).GetComponent<Animator>().enabled = false;
                if (_wiggler.wigglingDirection == WiggleController.wiggleDirection.flyingUp) {
                    transform.localEulerAngles = 
                    new Vector3(transform.localEulerAngles.x + _speed * Time.deltaTime, 
                    transform.localEulerAngles.y, 
                    transform.localEulerAngles.z);
                }
                else {
                    transform.localEulerAngles = 
                    new Vector3(transform.localEulerAngles.x - _speed * Time.deltaTime, 
                    transform.localEulerAngles.y, 
                    transform.localEulerAngles.z);
                }
        }
        else {
            transform.GetChild(0).GetComponent<Animator>().enabled = true;
            transform.parent.localEulerAngles = new Vector3(transform.parent.localEulerAngles.x, _player.rotateAngle * -6f, 20f * _player.z);
        }
    }
}
