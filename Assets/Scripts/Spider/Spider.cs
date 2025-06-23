using UnityEngine;

public class Spider : MonoBehaviour
{
    private Animator animator;
    [Header("Freezing Spell Settings")]
    public GameObject speedSlowerPrefab;   // Assign the SpeedSlower prefab here (formerly freezingSpellPrefab)
    public Transform spellSpawnPoint;       // Where the spell spawns from (e.g., spider's mouth)
    public Transform player;

    public float speed = 2f;
    public float distance = 2f;

    private Vector3 startingPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("Taunt", 2f, 5f);

        startingPosition = transform.position;
    }

    void Taunt()
    {
        animator.SetTrigger("Taunt");

        ShootSpeedSlowerSpell();
    }
    void ShootSpeedSlowerSpell()
    {
        if (speedSlowerPrefab == null || spellSpawnPoint == null || player == null)
        {
            Debug.LogWarning("SpeedSlower prefab, spawn point, or player reference is missing!");
            return;
        }

        // Instantiate the SpeedSlower projectile at the spawn point with no rotation
        GameObject spell = Instantiate(speedSlowerPrefab, spellSpawnPoint.position, Quaternion.identity);

        // Get the SpeedSlower script component on the projectile and set the player as target
        SpeedSlower spellScript = spell.GetComponent<SpeedSlower>();
        if (spellScript != null)
        {
            spellScript.SetTarget(player);
        }
        else
        {
            Debug.LogWarning("SpeedSlower script missing on speedSlowerPrefab!");
        }
    }

    // Update is called once per frame
    void Update()
    {

        float movement = Mathf.Sin(Time.time * speed) * distance;
        transform.position = new Vector3(startingPosition.x + movement, startingPosition.y, startingPosition.z);
    }
}
