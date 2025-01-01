using UnityEditor;
using UnityEngine;

namespace Technical.VarRef.Editor
{
    [CustomPropertyDrawer(typeof(VarContainer), true)]
    public class VarContainerDrawer<T> : PropertyDrawer
    {
        private SerializedProperty m_state;
        private SerializedProperty m_value;
        private SerializedProperty m_reference;
        private int m_selected = 0;
        private readonly string[] m_options = new string[2] { "Value", "Ref" };

        public override void OnGUI(Rect a_position, SerializedProperty a_property, GUIContent a_label)
        {
            m_state = a_property.FindPropertyRelative("m_state");
            m_value = a_property.FindPropertyRelative("m_varValue");
            m_reference = a_property.FindPropertyRelative("m_varRef");
            EditorGUI.BeginProperty(a_position, a_label, a_property);

            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.Label(a_label);
                m_state.enumValueIndex =
                    EditorGUILayout.Popup("", m_state.enumValueIndex, m_options, GUILayout.Width(60));
                switch ((VarContainer.VarEnum)m_state.enumValueIndex)
                {
                    default:
                    case VarContainer.VarEnum.Value:
                        EditorGUILayout.PropertyField(m_value, new GUIContent());
                        break;
                    case VarContainer.VarEnum.Ref:
                        Object varRef = EditorGUILayout.ObjectField(m_reference.objectReferenceValue,
                            typeof(T),
                            false);
                        m_reference.objectReferenceValue = varRef;
                        break;
                }
            }

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(FloatContainer), true)]
    class FloatContainerDrawer : VarContainerDrawer<FloatRef>
    {
    }

    [CustomPropertyDrawer(typeof(BoolContainer), true)]
    class BoolContainerDrawer : VarContainerDrawer<BoolRef>
    {
    }

    [CustomPropertyDrawer(typeof(TileContainer), true)]
    class TileContainerDrawer : VarContainerDrawer<TileRef>
    {
    }
}