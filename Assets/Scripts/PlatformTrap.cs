using System.Collections;
using UnityEngine;

public class PlatformTrap : MonoBehaviour
{
    public float disappearTime = 2f;
    public float reappearTime = 2f; 

    private Collider platformCollider;
    private Renderer platformRenderer;

    private void Start()
    {
        platformCollider = GetComponent<Collider>();
        platformRenderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Disappear());
        }
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(disappearTime);

        platformCollider.enabled = false;
        platformRenderer.enabled = false;

        yield return new WaitForSeconds(reappearTime);

        platformCollider.enabled = true;
        platformRenderer.enabled = true;
    }
}
