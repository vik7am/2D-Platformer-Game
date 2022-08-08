using UnityEngine;

namespace Platatformer2D
{
    public class CustomTag : MonoBehaviour
    {
        [SerializeField] EnumTag enumTag;

        public EnumTag getTag()
        {
            return enumTag;
        }
    }
}