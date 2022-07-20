using UnityEngine;

namespace Platatformer2D
{
    public class CustomTag : MonoBehaviour
    {
        [SerializeField] EnumTag enumTag;

        public bool compareTag(EnumTag tag)
        {
            return enumTag.Equals(tag);
        }
    }
}