// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;

namespace MonoNetPortable
{
	public class Options
	{
		public Options()
		{
		}
		
		public void ShowUsage()
		{
			Console.WriteLine("Usage: MonoPcl <command> [args]");
			Console.WriteLine();
			Console.WriteLine("Available commands:");
			Console.WriteLine("    list                   Lists all .NET Portable profiles");
			Console.WriteLine("    match <framework>      Displays the compatible .NET Portable profiles");
		}
		
		public bool ListProfiles { get; private set; }
		public bool FindCompatibileProfiles { get; private set; }
		public string TargetFramework { get; private set; }
		
		public bool Parse(string[] args)
		{
			if (args.Length == 0)
				return false;
			
			switch (args[0].ToLowerInvariant()) {
				case "list":
					ListProfiles = true;
					return true;
				case "match":
					return ParseMatchOption(args);
				default:
					return false;
			}
		}
		
		bool ParseMatchOption(string[] args)
		{
			if (args.Length != 2)
				return false;
			
			TargetFramework = args[1];
			FindCompatibileProfiles = true;
			
			return true;
		}
	}
}
