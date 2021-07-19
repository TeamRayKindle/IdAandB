using UnityEngine.SceneManagement;

public class GameHelper
{
	public static void NextScene() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public static void PreviousScene() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	public static void HomeScene() {
		SceneManager.LoadScene(0);
	}

	public static void GameScene() {
		SceneManager.LoadScene(1);
	}

	public static void YouWinScene() {
		SceneManager.LoadScene(2);
	}
}
