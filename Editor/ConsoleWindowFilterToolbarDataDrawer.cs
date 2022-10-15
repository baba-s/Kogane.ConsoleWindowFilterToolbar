using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [CustomPropertyDrawer( typeof( ConsoleWindowFilterToolbarData ), true )]
    internal sealed class ConsoleWindowFilterToolbarDataDrawer : PropertyDrawer
    {
        public override void OnGUI
        (
            Rect               position,
            SerializedProperty property,
            GUIContent         label
        )
        {
            using ( new EditorGUI.PropertyScope( position, label, property ) )
            {
                const int labelWidth = 96;

                var height             = EditorGUIUtility.singleLineHeight;
                var secondLineY        = position.y + height + 2;
                var propertyFieldX     = position.x + labelWidth;
                var propertyFieldWidth = position.width - labelWidth;

                var labelRect = new Rect( position )
                {
                    width  = labelWidth,
                    height = height,
                };

                var propertyFieldRect = new Rect( position )
                {
                    x      = propertyFieldX,
                    width  = propertyFieldWidth,
                    height = height,
                };

                var buttonTextLabelRect       = new Rect( labelRect );
                var buttonTextPropertyRect    = new Rect( propertyFieldRect );
                var filteringTextLabelRect    = new Rect( labelRect ) { y         = secondLineY };
                var filteringTextPropertyRect = new Rect( propertyFieldRect ) { y = secondLineY };

                var buttonTextProperty    = property.FindPropertyRelative( "m_buttonText" );
                var filteringTextProperty = property.FindPropertyRelative( "m_filteringText" );

                EditorGUI.PrefixLabel( buttonTextLabelRect, new( "Button Text" ) );
                EditorGUI.PropertyField( buttonTextPropertyRect, buttonTextProperty, GUIContent.none );
                EditorGUI.PrefixLabel( filteringTextLabelRect, new( "Filtering Text" ) );
                EditorGUI.PropertyField( filteringTextPropertyRect, filteringTextProperty, GUIContent.none );
            }
        }

        public override float GetPropertyHeight
        (
            SerializedProperty property,
            GUIContent         label
        )
        {
            return 38;
        }
    }
}