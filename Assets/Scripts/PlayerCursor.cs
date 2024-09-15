using System.Collections;
using UnityEditor;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{

    public GameObject explosionEffect;

    public float clickDelay = 2.5f;
    public int clickDamage = 2;
    private Vector3 spawnOffset = new Vector3(0, 0.1f, 0);
    private bool canClick = true;
    public bool gameOver = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canClick && !gameOver)
        {
            Click();
        }
    }

    public void Click() // ABSTRACTION
    {
        // Dont allow clicks
        canClick = false;
        // Damage Enemy if hit
        DamageEnemy();
        // Spawn effect at mouse position
        SpawnEffect();
        // Start click delay
        StartCoroutine(ResetClick());
    }

    IEnumerator ResetClick()
    {
        yield return new WaitForSeconds(clickDelay);
        canClick = true;
    }

    private void DamageEnemy()
    {
        // Create a ray from the camera through the mouse's screen position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Store the hit information
        RaycastHit hit;

        // Perform a raycast to detect objects in the scene
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                // Check object tag
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    // Damage the enemy with the current click damage
                    Enemy enemyhealth = hit.collider.gameObject.GetComponent<Enemy>();
                    enemyhealth.Hit(clickDamage);
                }
            }
        }
    }

    private void SpawnEffect()
    {
        // Create a ray from the camera through the mouse's screen position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Store the hit information
        RaycastHit hit;

        // Perform a raycast to detect objects in the scene
        if (Physics.Raycast(ray, out hit))
        {
            // Get the position where the ray hits an object in the scene
            Vector3 hitPosition = hit.point;

            // Log the 3D position of the hit point
            Instantiate(explosionEffect, hitPosition + spawnOffset, explosionEffect.transform.rotation);
        }
    }
}
