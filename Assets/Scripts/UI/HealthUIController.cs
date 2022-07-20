using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platatformer2D
{
    public class HealthUIController : MonoBehaviour
    {
        [SerializeField] GameObject[] heart;

        public void RemoveHeart(int heartNumber)
        {
            heart[heartNumber].SetActive(false);
        }

        public void updateHeartUI(int remainingHeart)
        {
            heart[remainingHeart].SetActive(false);
        }
    }
}
