using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private GameObject gameManager;
    private PointCounter pointCounterScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pointCounterScript = gameManager.GetComponent<PointCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        pointCounterScript.IncrementScore();
        Destroy(gameObject);

    }
}
