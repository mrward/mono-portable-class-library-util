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
			if (EnvironmentUtility.IsUnix)
			{
				var resolver = new MonoNetPortableProfilePathResolver();
				
				Console.WriteLine("Possible .NETPortable root paths:");
				foreach (string path in resolver.GetPossibleMonoNetPortablePaths()) {
					Console.WriteLine(path);
				}
				
				string directory = resolver.GetRootDirectory();
				Console.WriteLine();
				Console.WriteLine(".NETPortable root path found: {0}", directory);
			}

			Console.WriteLine();
			Console.WriteLine(".NETPortable profiles:");
			foreach (var profile in NetPortableProfileTable.Profiles) {
				Console.WriteLine("{0} {1}", profile.Name, profile.CustomProfileString);
			}
		}
	}
}