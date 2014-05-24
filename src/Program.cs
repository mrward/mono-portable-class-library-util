// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.IO;
using NuGet;

namespace MonoNetPortable
{
	class Program
	{
		public static void Main(string[] args)
		{
			var program = new Program();
			program.Run();
		}
		
		void Run()
		{
			ShowProfiles();
		}
		
		void ShowProfiles()
		{
			if (EnvironmentUtility.IsUnix) {
				ShowUnixProfileLocation();
			} else {
				ShowWindowsProfileLocation();
			}

			WriteLine();

			WriteLine(".NETPortable profiles:");
			foreach (var profile in NetPortableProfileTable.Profiles) {
				WriteLine("{0} {1}", profile.Name, profile.CustomProfileString);
			}
		}
		
		void ShowUnixProfileLocation()
		{
			if (ShowNuGetPortableReferencePathOverrideIfExists()) {
				return;
			}
			
			WriteLine("Possible .NETPortable root paths:");
			
			var resolver = new MonoNetPortableProfilePathResolver();
			foreach (string path in resolver.GetPossibleMonoNetPortablePaths()) {
				WriteLine(path);
			}
			
			WriteLine();
			
			string directory = resolver.GetRootDirectory();
			WriteNetPortableRootPath(directory);
		}
		
		static string AppendQuotesIfContainsSpaces(string directory)
		{
			if (directory.Contains(" ")) {
				return String.Format("\"{0}\"", directory);
			}
			return directory;
		}
		
		bool ShowNuGetPortableReferencePathOverrideIfExists()
		{
			string overrideEnvironmentVariableName = "NuGetPortableReferenceAssemblyPath";
			string directory = Environment.GetEnvironmentVariable(overrideEnvironmentVariableName);
			
			if (String.IsNullOrEmpty(directory)) {
				return false;
			} else {
				WriteLine("NuGetPortableReferenceAssemblyPath environment variable overrides .NETPortable path.");
				WriteNetPortableRootPath(directory);
				return true;
			}
		}
		
		void ShowWindowsProfileLocation()
		{
			if (ShowNuGetPortableReferencePathOverrideIfExists()) {
				return;
			}
			
			string directory = NetPortableProfileTable.GetPortableRootDirectory();
			if (!Directory.Exists(directory)) {
				directory = String.Empty;
			}
			WriteNetPortableRootPath(directory);
		}
		
		void WriteNetPortableRootPath(string directory)
		{
			WriteLine(".NETPortable root path: {0}", AppendQuotesIfContainsSpaces(directory));
		}
		
		void WriteLine()
		{
			Console.WriteLine();
		}
		
		void WriteLine(string format, params object[] args)
		{
			Console.WriteLine(format, args);
		}
	}
}