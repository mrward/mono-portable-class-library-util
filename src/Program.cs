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
				string directory = resolver.GetRootDirectory();
				
				Console.WriteLine(".NETPortable Root: {0}", directory);
			}

			foreach (var profile in NetPortableProfileTable.Profiles) {
				Console.WriteLine("{0} {1}", profile.Name, profile.CustomProfileString);
			}
		}
	}
}