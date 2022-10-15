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
            EditorApplication.delayCall += () => Refresh( false );
            EditorApplication.update    += () => Refresh( false );
        }

        public static void Refresh( bool force )
        {
            var setting = ConsoleWindowFilterToolbarSetting.instance;

            if ( setting.List is not { Length: > 0 } )
            {
                m_toolbar?.parent?.Remove( m_toolbar );
                m_toolbar = null;
                return;
            }

            var consoleWindow = ConsoleWindowManager.Get();

            if ( consoleWindow == null )
            {
                m_toolbar?.parent?.Remove( m_toolbar );
                m_toolbar = null;
                return;
            }

            if ( force )
            {
                m_toolbar?.parent?.Remove( m_toolbar );
                m_toolbar = null;
            }

            if ( m_toolbar != null ) return;

            m_toolbar = ToolbarCreator.Create();

            var rootVisualElement = consoleWindow.rootVisualElement;
            rootVisualElement.Add( m_toolbar );
        }
    }
}