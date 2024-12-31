using System;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UIElements;

namespace Technical.VarRef.Editor
{
    [CustomPropertyDrawer(typeof(VarContainer), true)]
    public class VarContainerDrawer : PropertyDrawer
    {
        SerializedProperty state;
        SerializedProperty value;
        SerializedProperty reference;
        private AdvancedStringOptionsDropdown m_dropdown;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            state = property.FindPropertyRelative("m_state");
            value = property.FindPropertyRelative("m_varValue");
            reference = property.FindPropertyRelative("m_varRef");

            if (m_dropdown == null)
            {
                m_dropdown = new AdvancedStringOptionsDropdown(state.enumDisplayNames);
                m_dropdown.OnOptionSelected += OnMDropdownOptionSelected;
            }

            EditorGUI.BeginProperty(position, label, property);

            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.Label(label);
                if (GUILayout.Button(":", GUILayout.Width(10)))
                {
                    m_dropdown.Show(position);
                }
                
                switch ((VarContainer.VarEnum)state.enumValueIndex)
                {
                    case VarContainer.VarEnum.Value:
                        EditorGUILayout.PropertyField(value);
                        break;
                    case VarContainer.VarEnum.Ref:
                        EditorGUILayout.PropertyField(reference);
                        break;
                }
                
            }


            EditorGUI.EndProperty();
        }

        private void OnMDropdownOptionSelected(int index)
        {
            state.enumValueIndex = index;
            state.serializedObject.ApplyModifiedProperties();
        }
    }

    public class AdvancedStringOptionsDropdown : AdvancedDropdown
    {
        private string[] _enumNames;

        public event Action<int> OnOptionSelected;

        public AdvancedStringOptionsDropdown(string[] stringOptions) : base(new AdvancedDropdownState())
        {
            _enumNames = stringOptions;
        }

        protected override void ItemSelected(AdvancedDropdownItem item)
        {
            OnOptionSelected?.Invoke(item.id);
        }

        protected override AdvancedDropdownItem BuildRoot()
        {
            var root = new AdvancedDropdownItem("");

            for (int i = 0; i < _enumNames.Length; i++)
            {
                var item = new AdvancedDropdownItem(_enumNames[i]);
                item.id = i;

                root.AddChild(item);
            }

            return root;
        }
    }
}