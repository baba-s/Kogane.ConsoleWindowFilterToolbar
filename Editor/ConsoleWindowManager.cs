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

        public static EditorWindow Get()
        {
            if ( m_consoleWindow != null )
            {
                return m_consoleWindow;
            }

            m_consoleWindow = ( EditorWindow )Resources
                    .FindObjectsOfTypeAll( TYPE )
                    .FirstOrDefault()
                ;

            return m_consoleWindow;
        }
    }
}