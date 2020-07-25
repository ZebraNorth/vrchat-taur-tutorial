/*
 * Debugging aid for showing bones in the Unity editor.
 *
 * By Zebra North
 *
 * If this script is placed on an object with a SkinnedMeshRenderer then it
 * will draw the bones associated with that renderer, else it will draw
 * the object hierarchy below itself.
 *
 * https://github.com/ZebraNorth/vrchat-taur-tutorial
 */

using UnityEngine;

public class DrawBones : MonoBehaviour
{
    private SkinnedMeshRenderer m_Renderer;
    public Color m_Color;

    void Start()
    {
        m_Renderer = GetComponent<SkinnedMeshRenderer>();
    }

    void Reset()
    {
        m_Color = new Color(1, 0, 0, 1);
    }

    void FixedUpdate()
    {
        if (m_Renderer)
        {
            var bones = m_Renderer.bones;

            foreach (var B in bones)
            {
                if (B.parent == null)
                    continue;

                Debug.DrawLine(B.position, B.parent.position, m_Color);
            }
        }
        else
        {
            foreach (Transform B in gameObject.GetComponentsInChildren<Transform>())
            {
                if (B.parent == null)
                    continue;

                Debug.DrawLine(B.position, B.parent.position, m_Color);
            }
        }
    }

    void OnDrawGizmos()
    {
        if (m_Renderer)
        {
            var bones = m_Renderer.bones;

            foreach (var B in bones)
            {
                if (B.parent == null)
                    continue;

                Gizmos.color = m_Color;
                Gizmos.DrawLine(B.position, B.parent.position);
            }
        }
        else
        {
            foreach (Transform B in gameObject.GetComponentsInChildren<Transform>())
            {
                if (B.parent == null)
                    continue;

                Gizmos.color = m_Color;
                Gizmos.DrawLine(B.position, B.parent.position);
            }
        }
    }
}
