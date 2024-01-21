using UnityEngine;

public class EnemyController : MonoBehaviour// ДВИЖЕНИЕ
{
    public float moveSpeed;
    private Path thePath;
    private int currentPoint;
    private bool reachedEnd;

    public float timeBetweenAttacks, damagePerAttack;
    private float attackCounter;
    private Castle theCastle;
    private int selectedAttackPoint;

    void Start()
    {
        if (thePath == null)
        {
            thePath = FindObjectOfType<Path>();
        }
        if (theCastle == null)
        {
            theCastle = FindObjectOfType<Castle>();
        }

        attackCounter = timeBetweenAttacks;
    }

    void Update()
    {
        if (reachedEnd == false)
        {
            transform.LookAt(thePath.points[currentPoint]);
            transform.position = Vector3.MoveTowards(transform.position, thePath.points[currentPoint].position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, thePath.points[currentPoint].position) < .01f)
            {
                currentPoint = currentPoint + 1;
                if (currentPoint >= thePath.points.Length)
                {
                    reachedEnd = true;
                    selectedAttackPoint = Random.Range(0, theCastle.attackPoints.Length);
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, theCastle.attackPoints[selectedAttackPoint].position, moveSpeed * Time.deltaTime);
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                attackCounter = timeBetweenAttacks;
                theCastle.TakeDamage(damagePerAttack);
                Destroy(this.gameObject);
            }
        }
    }

    public void Setup(Castle newCastle, Path newPath)
    {
        theCastle = newCastle;
        thePath = newPath;
    }
}
