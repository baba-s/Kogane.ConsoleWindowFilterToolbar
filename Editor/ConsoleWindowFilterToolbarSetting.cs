﻿using System;
using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [FilePath( "UserSettings/Kogane/ConsoleWindowFilterToolbar.asset", FilePathAttribute.Location.ProjectFolder )]
    internal sealed class ConsoleWindowFilterToolbarSetting : ScriptableSingleton<ConsoleWindowFilterToolbarSetting>
    {
        [SerializeField] private string[] m_list = Array.Empty<string>();

        public string[] List => m_list;

        public void Save()
        {
            Save( true );
        }
    }
}