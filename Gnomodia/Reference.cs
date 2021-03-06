/*
 *  Gnomodia
 *
 *  Copyright © 2013 Faark (http://faark.de/)
 *  Copyright © 2013 Alexander Krivács Schrøder (https://alexanderschroeder.net/)
 *
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU Lesser General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU Lesser General Public License
 *   along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Gnomodia.Properties;

namespace Gnomodia
{
    public static class Reference
    {
        private static ISettings s_Settings;
        internal static ISettings Settings
        {
            get
            {
                return s_Settings ?? Properties.Settings.Default;
            }
            set { s_Settings = value; }
        }

        public const string ConfigurationFileName = "Gnomodia.xml";
        public const string OriginalExecutable = "Gnomoria.exe";
        public const string ModdedExecutable = "GnomoriaModded.dll";
        public const string OriginalLibrary = "gnomorialib.dll";
        public const string ModdedLibrary = "gnomorialibModded.dll";
        public const string GnomodiaLibrary = "Gnomodia.dll";
        public const string SevenZip = "SevenZipSharp.dll";
        public static readonly string[] Dependencies = new[] { OriginalExecutable, OriginalLibrary, SevenZip };

        private static readonly Lazy<DirectoryInfo> LazyGameDirectory = new Lazy<DirectoryInfo>(() => new DirectoryInfo(Settings.GnomoriaInstallationPath), true);
        public static DirectoryInfo GameDirectory
        {
            get { return LazyGameDirectory.Value; }
        }

        private static readonly Lazy<DirectoryInfo> LazyGnomodiaDirectory = new Lazy<DirectoryInfo>(() => new FileInfo(new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath).Directory, true);
        public static DirectoryInfo GnomodiaDirectory
        {
            get { return LazyGnomodiaDirectory.Value; }
        }

        private static readonly Lazy<DirectoryInfo> LazyModDirectory = new Lazy<DirectoryInfo>(() => GnomodiaDirectory.GetDirectories("mods").SingleOrDefault() ?? GnomodiaDirectory.CreateSubdirectory("mods"), true);
        public static DirectoryInfo ModDirectory
        {
            get { return LazyModDirectory.Value; }
        }
    }
}
