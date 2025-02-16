using UnityEngine;

public class GhostEyesScript : MonoBehaviour
{
    public Sprite[] eyeSpriteArray;
    private SpriteRenderer eyeSpriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eyeSpriteRenderer = GetComponent<SpriteRenderer>();
        eyeSpriteRenderer.sprite = eyeSpriteArray[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
