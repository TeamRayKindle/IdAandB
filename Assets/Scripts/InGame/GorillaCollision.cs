using UnityEngine;
using UnityEngine.UI;

public class GorillaCollision : MonoBehaviour
{
	[SerializeField]
	Text _letterTxt;

	string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "CarpetFrontCollider") {
			_letterTxt.gameObject.SetActive(true);
			_letterTxt.text = letters[Random.Range(0, letters.Length)];
			Invoke("OpenGameOverScene",3);
		}
	}

	void OpenGameOverScene() {
		CancelInvoke("OpenGameOverScene");
		GameHelper.YouWinScene();
	}
}
