using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    [SerializeField] GameEvent playerDiedEvent;
    [SerializeField] Transform[] guns;
    [SerializeField] GameObject muzzleFlash;
    [SerializeField] GameObject bullet;
    private LineRenderer[] lineRenderers;
    private GameObject player;

    [SerializeField] float waitToShoot = 1.5f;
    [SerializeField] float fireRate = 1.5f;
    [SerializeField] float waitForTargetLost = 4f;
    [SerializeField] float bulletForce = 100f;

    private bool inFireRange = false;
    public bool isShooting = false;

    private void Start()
    {
        lineRenderers = GetComponentsInChildren<LineRenderer>();
        player = FindObjectOfType<FirstPersonController>().gameObject;
    }

    private void Update()
    {
        if (inFireRange)
        {
            CheckAim();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inFireRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inFireRange = false;
            StartCoroutine(TargetLost());
        }
    }

    private void CheckAim()
    {
        if (Physics.Linecast(gameObject.transform.position, player.transform.position))
        {
            //Debug.Log("Hit");

            for (int i = 0; i < 4; i++)
            {
                lineRenderers[i].enabled = true;
                lineRenderers[i].SetPosition(0, guns[i].position);
                lineRenderers[i].SetPosition(1, player.transform.position);
            }

            if (!isShooting)
            {
                StartCoroutine(WaitToShoot());
            }

            isShooting = true;
        }
        else
        {
            foreach (var line in lineRenderers)
            {
                line.enabled = false;
            }
        }
    }

    private IEnumerator TargetLost()
    {
        // lens sound
        yield return new WaitForSeconds(waitForTargetLost);

        if (!inFireRange)
        {
            foreach (var line in lineRenderers)
            {
                // click sound
                line.enabled = false;
                yield return new WaitForSeconds(0.4f);
            }

            isShooting = false;
        }
    }

    private IEnumerator WaitToShoot()
    {
        yield return new WaitForSeconds(waitToShoot);
        // turbine sound

        StartCoroutine(Shoot());        
    }

    private IEnumerator Shoot()
    {
        if (inFireRange)
        {
            foreach (var gun in guns)
            {
                int i = 0;
                Bullet(gun);
                MuzzleFlash(gun);
                // Deal damage
                // Shoot sound
                i++;
                yield return new WaitForSeconds(0.1f);
            }

            StartCoroutine(Shoot());
        }
    }

    private void MuzzleFlash(Transform spawnPos)
    {
        GameObject clone;
        clone = Instantiate(muzzleFlash, spawnPos.position, spawnPos.rotation);
        Destroy(clone, 0.4f);
    }

    private void Bullet(Transform spawnPos)
    {
        GameObject clone;
        clone = Instantiate(bullet, spawnPos.position, spawnPos.rotation);
        clone.GetComponent<Rigidbody>().AddForce(-(spawnPos.position - player.transform.position) * bulletForce, ForceMode.Impulse);
        Destroy(clone, 0.5f);
    }
}
