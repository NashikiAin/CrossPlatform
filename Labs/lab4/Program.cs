using System;
using System.IO;
using System.Runtime.InteropServices;
using McMaster.Extensions.CommandLineUtils;

[Command(Name = "LabsRunnerApp", Description = "Console app to run labs")]
[Subcommand(typeof(VersionCommand), typeof(RunCommand), typeof(SetPathCommand))]
class Program
{
	public static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);

	private void OnExecute()
	{
		Console.WriteLine("Please provide a command. Available commands: version, run, set-path");
	}
}

[Command(Name = "version", Description = "Displays info")]
class VersionCommand
{
	public int OnExecute()
	{
		Console.WriteLine("Author: Oleh Symaka, Version: 1.0.2");
		return 0;
	}
}

[Command(Name = "run", Description = "Executes the specified lab project")]
class RunCommand
{
	[Argument(0, Description = "Labs: lab1, lab2, or lab3")]
	public string? LabName { get; }

	[Option("-I|--input", Description = "Direct path to the input file")]
	public string? InputPath { get; }

	[Option("-O|--output", Description = "Direct path to the output file")]
	public string? OutputPath { get; }

	public int OnExecute()
	{
		try
		{
			var labRunner = new LabsLibrary.RunnerLabs();
			string inputPath = Path.Combine(GetDirectoryPath(InputPath, "LAB_PATH"), "input.txt");
			string outputPath = Path.Combine(GetDirectoryPath(OutputPath, "LAB_PATH"), "output.txt");

			if (!File.Exists(inputPath))
			{
				Console.WriteLine(inputPath);
				throw new FileNotFoundException("Required files 'input.txt' not found in any specified path.");
			}

			switch (LabName?.ToLower())
			{
				case "lab1":
					labRunner.RunLab1(inputPath, outputPath);
					break;
				case "lab2":
					labRunner.RunLab2(inputPath, outputPath);
					break;
				case "lab3":
					labRunner.RunLab3(inputPath, outputPath);
					break;
				default:
					Console.WriteLine("Unknown lab. Available options: lab1, lab2, lab3.");
					return 1;
			}
			Console.WriteLine($"Lab {LabName} executed.");
			return 0;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return 1;
		}
	}

	private string GetDirectoryPath(string? directPath, string envVariable)
	{
		if (!string.IsNullOrEmpty(directPath) && Directory.Exists(directPath))
		{
			return directPath;
		}

		string? envPath = Environment.GetEnvironmentVariable(envVariable);
		if (!string.IsNullOrEmpty(envPath) && Directory.Exists(envPath))
		{
			return envPath;
		}

		
		string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
		return homePath;
	}
}

[Command(Name = "set-path", Description = "Sets the path for input and output files")]
class SetPathCommand
{
	public string envVariable;
	[Option("-p|--path", Description = "Path to the directory containing input and output files", ShowInHelpText = true)]

	public string? Path { get; }

	public int OnExecute()
	{
		if (Directory.Exists(Path))
		{
			Environment.SetEnvironmentVariable("LAB_PATH", Path, EnvironmentVariableTarget.User);
			string? envPath = Environment.GetEnvironmentVariable(envVariable, EnvironmentVariableTarget.User);
			Console.WriteLine($"Environment variable 'LAB_PATH' set to {Path}");
			return 0;
		}
		else
		{
			Console.WriteLine("Invalid path. Directory does not exist.");
			return 1;
		}
	}
}
