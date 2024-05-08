using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;

    public bool destroyOnKill = false;

    private int currentLife;
    private bool isDeath = false;

    private void Awake()
    {
        currentLife = startLife;
        isDeath = false;
    }

    public void Damage(int damage)
    {
        if (isDeath) return;

        if (currentLife <= 0)
            Kill();

        currentLife -= damage;
    }

    private void Kill()
    {
        isDeath = true;

        if (destroyOnKill)
            Destroy(gameObject);
    }

}
