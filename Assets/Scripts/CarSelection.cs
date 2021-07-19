using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    public int currentCar;

    private void Awake()
    {
        SelectCar(1);
    }

    private void SelectCar(int _index)
    {
        previousButton.interactable = (_index != 0);
        nextButton.interactable = (_index != transform.childCount-1);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
    }
    public void Update()
    {
       
    }

    public void SelectCar()
    {
        if (currentCar == 0)
        {
            Debug.Log(StaticString.Car1);
            SaveCarSelection(StaticString.Car1);
            SceneManager.LoadScene(StaticString.LevelScreenlevelName);

        }
        else if (currentCar == 1)
        {
            Debug.Log(StaticString.Car2);
            SaveCarSelection(StaticString.Car2);
            SceneManager.LoadScene(StaticString.LevelScreenlevelName);
        }
        else if (currentCar == 2)
        {
            Debug.Log(StaticString.Car3);
            SaveCarSelection(StaticString.Car3);
            SceneManager.LoadScene(StaticString.LevelScreenlevelName);
        }
    }
    public void SaveCarSelection(string CarName)
    {
        PlayerPrefs.SetString("vehicle", CarName);
        PlayerPrefs.Save();   
    }
    public void ChangeCar(int _change)
    {
        currentCar += _change;
        SelectCar(currentCar);
    }
}
