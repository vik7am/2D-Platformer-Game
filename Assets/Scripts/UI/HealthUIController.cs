using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIController : MonoBehaviour
{
    public GameObject[] heart;

    public void RemoveHeart(int heartNumber)
    {
        heart[heartNumber].SetActive(false);
    }
}
