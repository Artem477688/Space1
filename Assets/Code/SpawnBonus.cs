using UnityEngine;

[System.Serializable]
public class BonusOption
{
    public GameObject prefab;
    public float weight; // Вес вероятностьности спавна
}

public class SpawnBonus : MonoBehaviour
{
    public BonusOption[] bonusOptions; // Массив с бонусами и их весами
    public Transform spawnPoint;
    public float fireInterval = 2f;

    private float timer;

    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireInterval)
        {
            SpawnBonus1();
            timer = 0f;
        }
    }

    void SpawnBonus1()
    {
        if (bonusOptions.Length == 0 || spawnPoint == null) return;

        // Расчёт общей суммы весов
        float totalWeight = 0f;
        foreach (var option in bonusOptions)
        {
            totalWeight += option.weight;
        }

        // Генерируем случайное число в диапазоне [0, totalWeight)
        float randomWeight = Random.Range(0f, totalWeight);
        float cumulativeWeight = 0f;

        GameObject selectedPrefab = null;

        // Выбираем бонус на основе вероятности
        foreach (var option in bonusOptions)
        {
            cumulativeWeight += option.weight;
            if (randomWeight <= cumulativeWeight)
            {
                selectedPrefab = option.prefab;
                break;
            }
        }

        if (selectedPrefab != null)
        {
            // Спавним выбранный бонус
            Vector3 spawnPosition = spawnPoint.position + Vector3.right * Random.Range(-2f, 2f);
            GameObject bonus = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
            Rigidbody rb = bonus.GetComponent<Rigidbody>();
            // Тут можно добавить физические действия, если нужно
        }
    }
}