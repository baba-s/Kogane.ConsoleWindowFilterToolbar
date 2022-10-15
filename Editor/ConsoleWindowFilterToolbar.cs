using UnityEditor;
using UnityEngine.UIElements;

namespace Kogane.Internal
{
    [InitializeOnLoad]
    internal static class ConsoleWindowFilterToolbar
    {
        private static VisualElement m_toolbar;

        static ConsoleWindowFilterToolbar()
        {
            EditorApplication.delayCall += () => Refresh();
            EditorApplication.update    += () => Refresh();
        }

        public static void Refresh()
        {
            ConsoleWindowManager.TryGet( out var consoleWindow );

            if ( consoleWindow == null )
            {
                m_toolbar?.parent?.Remove( m_toolbar );
                m_toolbar = null;
                return;
            }

            if ( m_toolbar != null ) return;

            m_toolbar = ToolbarCreator.CreateToolbar();

            var rootVisualElement = consoleWindow.rootVisualElement;
            rootVisualElement.Add( m_toolbar );
        }
    }
}