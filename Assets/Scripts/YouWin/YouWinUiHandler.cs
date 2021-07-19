using UnityEngine;

public class YouWinUiHandler : MonoBehaviour
{
	public void PlayOnceMore() {
		GameHelper.GameScene();
	}

	public void Home() {
		GameHelper.HomeScene();
	}
}
