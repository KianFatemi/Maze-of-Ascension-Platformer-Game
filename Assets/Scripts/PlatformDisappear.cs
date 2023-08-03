using UnityEngine;

public class PlatformDisappear : MonoBehaviour
{
    public GameObject platform; 
    public float appearTime = 2f; 
    public float disappearTime = 2f; 

    private float timer = 0f; 
    private bool platformVisible = false; 

    void Start()
    {
        platform.SetActive(false);
    }

    void Update()
    {
        timer += Time.deltaTime; 

        if (!platformVisible && timer >= disappearTime)
        {
            platform.SetActive(true); 
            timer = 0f;
            platformVisible = true; 
        }
        else if (platformVisible && timer >= appearTime)
        {
            platform.SetActive(false); 
            timer = 0f; 
            platformVisible = false; 
        }
    }
}
