using UnityEngine;
using System.Collections.Generic; // Для использования List<GameObject>
// using System.Linq; // Можно удалить, если не используется в других частях

public class PlayerControl : MonoBehaviour
{
    public float detectionRadius = 10f;
    public float moveSpeed = 5f;
    public float minX = -2.8f;
    public float maxX = 2.8f;
    public float minY = -3f;
    public float maxY = 3f;

    void Update()
    {
        GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteor");
        GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        GameObject[] bonuses = GameObject.FindGameObjectsWithTag("Bonus");
        GameObject[] shields = GameObject.FindGameObjectsWithTag("Shield");

        Vector3 targetPosition = transform.position;
        List<GameObject> dangers = GetAllDangers(meteors, enemyBullets); // Собираем все опасности

        bool dangerNearby = IsDangerNearby(dangers);

        if (dangerNearby)
        {
            targetPosition = FindSafestPosition(dangers);
        }
        else
        {
            targetPosition = FindClosestTarget(bonuses, shields, dangers);
        }

        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    // Метод для сбора всех опасных объектов в один список
    List<GameObject> GetAllDangers(GameObject[] meteors, GameObject[] enemyBullets)
    {
        List<GameObject> allDangers = new List<GameObject>();
        allDangers.AddRange(meteors);
        allDangers.AddRange(enemyBullets);
        return allDangers;
    }

    // Проверяет, находится ли опасность в радиусе обнаружения
    bool IsDangerNearby(List<GameObject> dangers)
    {
        foreach (var obj in dangers)
        {
            if (IsWithinDetectionRadius(obj))
            {
                return true;
            }
        }
        return false;
    }

    // Находит позицию с наименьшим количеством опасностей в радиусе
    Vector3 FindSafestPosition(List<GameObject> dangers)
    {
        float bestX = transform.position.x;
        float minObjectsCount = float.MaxValue;
        float step = 0.4f;

        for (float x = minX; x <= maxX; x += step)
        {
            int count = 0;
            Vector3 currentCheckPosition = new Vector3(x, transform.position.y, 0);

            foreach (var obj in dangers)
            {
                if (Vector3.Distance(currentCheckPosition, obj.transform.position) < detectionRadius)
                {
                    count++;
                }
            }

            if (count < minObjectsCount)
            {
                minObjectsCount = count;
                bestX = x;
            }
        }
        return new Vector3(Mathf.Clamp(bestX, minX, maxX), transform.position.y, 0);
    }

    // Находит ближайшую цель (бонус или щит), к которой нет препятствий
    Vector3 FindClosestTarget(GameObject[] bonuses, GameObject[] shields, List<GameObject> dangers)
    {
        Transform closestTarget = null;
        float closestDistanceX = float.MaxValue;

        foreach (var target in bonuses)
        {
            if (target != null && !IsObstructed(target.transform, dangers))
            {
                float deltaX = Mathf.Abs(transform.position.x - target.transform.position.x);
                if (deltaX < closestDistanceX)
                {
                    closestDistanceX = deltaX;
                    closestTarget = target.transform;
                }
            }
        }

        foreach (var target in shields)
        {
            if (target != null && !IsObstructed(target.transform, dangers))
            {
                float deltaX = Mathf.Abs(transform.position.x - target.transform.position.x);
                if (deltaX < closestDistanceX)
                {
                    closestDistanceX = deltaX;
                    closestTarget = target.transform;
                }
            }
        }

        if (closestTarget != null)
        {
            return closestTarget.position;
        }
        else
        {
            return new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    // Проверяет, находится ли объект в радиусе обнаружения игрока
    bool IsWithinDetectionRadius(GameObject obj)
    {
        if (obj == null) return false;
        float dist = Vector3.Distance(new Vector3(transform.position.x, transform.position.y, 0),
                                        new Vector3(obj.transform.position.x, obj.transform.position.y, 0));
        return dist < detectionRadius;
    }

    // Проверяет, есть ли преграда (опасный объект) на пути к цели
    bool IsObstructed(Transform target, List<GameObject> dangers)
    {
        Vector3 start = transform.position;
        Vector3 end = target.position;
        RaycastHit2D hit = Physics2D.Linecast(start, end);

        if (hit.collider != null && hit.transform != target)
        {
            // Проверяем, является ли препятствие одним из опасных объектов
            foreach (var danger in dangers)
            {
                if (hit.transform == danger.transform)
                {
                    return true; // Преграда есть
                }
            }
        }
        return false; // Преград нет
    }
}
