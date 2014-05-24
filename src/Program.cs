// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;

using NuGet;

namespace MonoNetPortable
{
	class Program
	{
		public static void Main(string[] args)
		{
			try {
				var program = new Program();
				program.Run(args);
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}
		
		void Run(string[] args)
		{
			var options = new Options();
			if (!options.Parse(args)) {
				options.ShowUsage();
				return;
			}
			
			if (options.ListProfiles) {
				ShowProfiles();
			} else if (options.FindCompatibileProfiles) {
				FindCompatibleProfiles(options.TargetFramework);
			}
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
			foreach (NetPortableProfile profile in GetAllProfiles()) {
				WriteProfile(profile);
			}
		}
		
		void WriteProfile(NetPortableProfile profile)
		{
			WriteLine("{0} {1}", profile.Name, profile.CustomProfileString);
		}
		
		IEnumerable<NetPortableProfile> GetAllProfiles()
		{
			return NetPortableProfileTable.Profiles.OrderBy(OrderProfileByName);
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
		
		string OrderProfileByName(NetPortableProfile profile)
		{
			string number = profile.Name.ToLowerInvariant().Replace("profile", "");
			return number.PadLeft(4, '0');
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
		
		void FindCompatibleProfiles(string targetFramework)
		{
			FrameworkName framework = VersionUtility.ParseFrameworkName(targetFramework);
			if (framework.IsPortableFramework()) {
				NetPortableProfile portableProfile = NetPortableProfile.Parse(framework.Profile);
				ShowCompatibleProfiles(profile => profile.IsCompatibleWith(portableProfile));
			} else {
				ShowCompatibleProfiles(profile => profile.IsCompatibleWith(framework));
			}
		}
		
		void ShowCompatibleProfiles(Func<NetPortableProfile, bool> isCompatible)
		{
			WriteLine("Compatible profiles:");
			foreach (NetPortableProfile profile in GetAllProfiles().Where(isCompatible)) {
				WriteProfile(profile);
			}
		}
	}
}