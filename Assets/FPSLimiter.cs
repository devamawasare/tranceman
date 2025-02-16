using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    public int frameRate = 60;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = frameRate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
