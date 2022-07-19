using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIController : MonoBehaviour
{
    [SerializeField] GameObject[] heart;

    public void RemoveHeart(int heartNumber)
    {
        heart[heartNumber].SetActive(false);
    }
}
