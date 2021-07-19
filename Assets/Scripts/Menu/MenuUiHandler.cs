using UnityEngine;

public class MenuUiHandler : MonoBehaviour
{
	[SerializeField]
	GameObject _panelHowToPlay;

	private void Start() {
		_panelHowToPlay.SetActive(false);
	}

	public void OpenHowToPlay() {
		_panelHowToPlay.SetActive(true);
	}

	public void CloseHowToPlay() {
		_panelHowToPlay.SetActive(false);
	}

	public void PlayTheGame() {
		GameHelper.GameScene();
	}

	public void QuitGame() {
		Application.Quit();
	}
}
