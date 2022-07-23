using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] private float _maxCoolDown;
    [SerializeField] private GameObject RocketPrefab;
    [SerializeField] private Transform _trapArea;
    [SerializeField] private GameObject DangerShower;

    private void Start()
    {
        StartCoroutine(Launch());
    }

    private IEnumerator Launch()
    {
        while (true)
        {
            var randomCoolDown = Random.Range(1, _maxCoolDown);
            yield return new WaitForSeconds(randomCoolDown);
            ShowDanger(true);
            yield return new WaitForSeconds(2);
            Instantiate(RocketPrefab, transform.position, quaternion.identity, _trapArea);
            ShowDanger(false);
        }
    }

    void ShowDanger(bool show)
    {
        DangerShower.SetActive(show);
    }
}
