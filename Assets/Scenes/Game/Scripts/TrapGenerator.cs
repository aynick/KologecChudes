using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrapGenerator : MonoBehaviour
{
    public float coolDown;
    public event Action OnGameFinish;
    private float targetCoolDown;
    [SerializeField] private List<GameObject> Traps;
    [SerializeField] private List<Transform> points;
    [SerializeField] private Transform TrapArea;

    private void Start()
    {
       
        if (PlayerPrefs.GetFloat("CoolDown") > 0.5f)
        {
            coolDown = PlayerPrefs.GetFloat("CoolDown");
        }
        else
        {
            coolDown = 2;   
        }
        targetCoolDown = coolDown - 0.1f;
        StartCoroutine(GenerateTraps());
    }

    IEnumerator GenerateTraps()
    {
        if (coolDown <= 0)
        {
            OnGameFinish?.Invoke();
            PlayerPrefs.SetFloat("CoolDown",targetCoolDown);
            yield break;
        }
        yield return new WaitForSeconds(coolDown);
        int randomTrapIndex = Random.Range(0, Traps.Count);
        int randomPointIndex = Random.Range(0, points.Count);
        Vector2 randomPosition = new Vector2(points[randomPointIndex].position.x, transform.position.y);
        GameObject trap = Instantiate(Traps[randomTrapIndex], randomPosition,Quaternion.identity,TrapArea);
        coolDown -= Time.fixedDeltaTime;
        StartCoroutine(GenerateTraps());
    }
}
