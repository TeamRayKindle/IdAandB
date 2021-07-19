using UnityEngine;

public class CollisionHandlercATTERPILLAR : MonoBehaviour
{
    
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject Player;
    public AudioManager AM;

    private string ObjectName;
    private Vector3 start;
    private GameObject CollisionBoxSwitch;
    public int c;
    public GameObject gm;
    public GameObject[] Items;
    private void OnCollisionEnter(Collision collision)
    {
        TurnOnEverCollider();
        Player.GetComponent<GameManagerCatterpillar>().InteractionInitializer(gameObject);
      
        Player.GetComponent<GameManagerCatterpillar>().InteractionHandler(gameObject);
        ItweenSimpleVersion.Rotate(Player, gm.transform, 3);
        ItweenSimpleVersion.Move(Player, gm.transform, 3);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
    public void TurnOnEverCollider()
    {
        foreach(GameObject c in Items)
        {
            c.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
