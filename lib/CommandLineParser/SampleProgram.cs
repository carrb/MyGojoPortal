using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;
using CommandLine.Text;


sealed class Program
	{
    private static readonly HeadingInfo _headingInfo = new HeadingInfo("sampleapp", "1.8");

private sealed class Options : CommandLineOptionsBase
		{
			#region Standard Option Attribute
			[Option("r", "read",
					Required = true,
					HelpText = "Input file with data to process.")]
			public string InputFile = String.Empty;

			[Option("w", "write",
					HelpText = "Output file with processed data (otherwise standard output).")]
			public string OutputFile = String.Empty;

			[Option(null, "calculate",
					HelpText = "Add results in bottom of tabular data.")]
			public bool Calculate = false;

			[Option("v", null,
					HelpText = "Verbose level. Range: from 0 to 2.")]
			public int? VerboseLevel = null;

			[Option("i", null,
				   HelpText = "If file has errors don't stop processing.")]
			public bool IgnoreErrors = false;

			[Option("j", "jump",
					HelpText = "Data processing start offset.")]
			public double StartOffset = 0;

			[Option(null, "optimize",
				HelpText = "Optimize for Speed|Accuracy.")]
			public OptimizeFor Optimization = OptimizeFor.Unspecified;
			#endregion

			#region Specialized Option Attribute
			[ValueList(typeof(List<string>))]
			public IList<string> DefinitionFiles = null;

			[OptionList("o", "operators", Separator = ';',
				HelpText = "Operators included in processing (+;-;...)." +
				" Separate each operator with a semicolon." +
				" Do not include spaces between operators and separator.")]
			public IList<string> AllowedOperators = null;
			
			[HelpOption(
					HelpText = "Dispaly this help screen.")]
			public string GetUsage()
			{
				var help = new HelpText(Program._headingInfo);
				help.AdditionalNewLineAfterOption = true;
				help.Copyright = new CopyrightInfo("Giacomo Stelluti Scala", 2005, 2009);
				this.HandleParsingErrorsInHelp(help);
				help.AddPreOptionsLine("This is free software. You may redistribute copies of it under the terms of");
				help.AddPreOptionsLine("the MIT License <http://www.opensource.org/licenses/mit-license.php>.");
				help.AddPreOptionsLine("Usage: SampleApp -rMyData.in -wMyData.out --calculate");
				help.AddPreOptionsLine(string.Format("       SampleApp -rMyData.in -i -j{0} file0.def file1.def", 9.7));
				help.AddPreOptionsLine("       SampleApp -rMath.xml -wReport.bin -o *;/;+;-");
				help.AddOptions(this);

				return help;
			}

			private void HandleParsingErrorsInHelp(HelpText help)
			{
				if (this.LastPostParsingState.Errors.Count > 0)
				{
				}
				string errors = help.RenderParsingErrorsText(this, 2); // indent with two spaces
				if (!string.IsNullOrEmpty(errors))
				{
					help.AddPreOptionsLine(string.Concat(Environment.NewLine, "ERROR(S):"));
					help.AddPreOptionsLine(errors);
				}
			}
			#endregion
		}



private static void Main(string[] args)
{
      var options = new Options();
			ICommandLineParser parser = new CommandLineParser(new CommandLineParserSettings(Console.Error));
			if (!parser.ParseArguments(args, options))
				Environment.Exit(1);

			DoCoreTask(options);

			Environment.Exit(0);
}



private static void DoCoreTask(Options options)
		{
			if (options.VerboseLevel == null)
				Console.Write("verbose [off]");
			else
				Console.WriteLine("verbose [on]: {0}", (options.VerboseLevel < 0 || options.VerboseLevel > 2) ? "#invalid value#" : options.VerboseLevel.ToString());
			Console.WriteLine();
			Console.WriteLine("input file: {0} ...", options.InputFile);
			foreach (string defFile in options.DefinitionFiles)
			{
				Console.WriteLine("  using definition file: {0}", defFile);
			}
			Console.WriteLine("  start offset: {0}", options.StartOffset);
			Console.WriteLine("  tabular data computation: {0}", options.Calculate.ToString().ToLowerInvariant());
			Console.WriteLine("  on errors: {0}", options.IgnoreErrors ? "continue" : "stop processing");
			Console.WriteLine("  optimize for: {0}", options.Optimization.ToString().ToLowerInvariant());
			if (options.AllowedOperators != null)
			{
				var builder = new StringBuilder();
				builder.Append("  allowed operators: ");
				foreach (string op in options.AllowedOperators)
				{
					builder.Append(op);
					builder.Append(", ");
				}
				Console.WriteLine(builder.Remove(builder.Length - 2, 2).ToString());
			}
			Console.WriteLine();
			if (options.OutputFile.Length > 0)
				_headingInfo.WriteMessage(string.Format("writing elaborated data: {0} ...", options.OutputFile));
			else
			{
				_headingInfo.WriteMessage("elaborated data:");
				Console.WriteLine("[...]");
			}
}





}