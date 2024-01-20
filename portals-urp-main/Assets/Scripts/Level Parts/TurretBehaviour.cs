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

    [SerializeField] float aimDelay = 0.3f;
    [SerializeField] float waitToShoot = 1.5f;
    [SerializeField] float fireRate = 0.1f;
    [SerializeField] float waitForTargetLost = 4f;
    [SerializeField] float bulletForce = 100f;

    private bool inFireRange = false;
    public bool isShooting = false;
    [HideInInspector] public bool isDisplaced = false;

    [SerializeField] private AudioClipHolder shootSound;
    [SerializeField] private AudioClipHolder[] lensSound;
    private bool isPlayingLensSound = false;

    private void Start()
    {
        lineRenderers = GetComponentsInChildren<LineRenderer>();
        player = FindObjectOfType<FirstPersonController>().gameObject;
    }

    private void Update()
    {
        if (inFireRange && !isDisplaced)
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

    private bool isUpright()
    {
        if (transform.rotation.eulerAngles.x > 0.3 && transform.rotation.eulerAngles.x < 0.35)
        {
            return true;
        }

        else
        {
            Debug.Log(transform.rotation.eulerAngles.x);
            return false;
        }
    }

    private void CheckAim()
    {
        RaycastHit hit;

        if (Physics.Raycast(gameObject.transform.position, player.transform.position, out hit) && hit.transform.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Hit");
            if (!isPlayingLensSound)
            {
                isPlayingLensSound = true;
                int i = Random.Range(0, lensSound.Length);
                AudioManager.Instance.PlaySound(lensSound[i].AudioClip, lensSound[i].Volume);
            }

            StartCoroutine(DrawLine());

            if (!isShooting && !isDisplaced)
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

    private IEnumerator DrawLine()
    {
        Vector3 target = player.transform.position;

        yield return new WaitForSeconds(aimDelay);

        for (int i = 0; i < 4; i++)
        {
            lineRenderers[i].enabled = true;
            lineRenderers[i].SetPosition(0, guns[i].position);
            lineRenderers[i].SetPosition(1, target);
        }
    }

    private IEnumerator TargetLost()
    {
        isShooting = false;
        isPlayingLensSound = false;

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
        if (inFireRange && GameManager.Instance.playerIsAlive && isUpright())
        {
            foreach (var gun in guns)
            {
                AudioManager.Instance.PlaySound(shootSound.AudioClip, shootSound.Volume);
                StartCoroutine(Bullet(gun));
                yield return new WaitForSeconds(fireRate);
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

    private IEnumerator Bullet(Transform spawnPos)
    {
        Vector3 target = player.transform.position;

        yield return new WaitForSeconds(aimDelay);
        MuzzleFlash(spawnPos);
        GameObject clone;
        clone = Instantiate(bullet, spawnPos.position, spawnPos.rotation);
        clone.GetComponent<Rigidbody>().AddForce(-(spawnPos.position - target) * bulletForce, ForceMode.Impulse);
        Destroy(clone, 0.5f);
    }
}
