using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    internal static class ConsoleWindowManager
    {
        private static readonly Type TYPE =
            typeof( Editor ).Assembly.GetType( "UnityEditor.ConsoleWindow" );

        private static EditorWindow m_consoleWindow;

        public static void TryGet( out EditorWindow consoleWindow )
        {
            if ( m_consoleWindow != null )
            {
                consoleWindow = m_consoleWindow;
                return;
            }

            m_consoleWindow = ( EditorWindow )Resources
                    .FindObjectsOfTypeAll( TYPE )
                    .FirstOrDefault()
                ;

            consoleWindow = m_consoleWindow;
        }
    }
}