using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace FreecraftCore
{
	class Program
	{
		static async Task Main(string[] args)
		{
			foreach (string filePath in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.cs", SearchOption.AllDirectories))
			{
				string[] file = await File.ReadAllLinesAsync(filePath);

				bool isFileModified = false;
				int errorCount = 0;

				//Find the a WireMember
				for (int i = 0; i < file.Length; i++)
				{
					if (file[i].Contains("[WireMember"))
					{
						//Now, find the member it's actually tagging
						for (int j = i; j < file.Length; j++)
						{
							//TODO: Support same line.
							//Attributes are done.
							if (file[j].Contains("{ get"))
							{
								string original = file[j];

								file[j] = file[j].Replace("{ get; }", "{ get; internal set; }");

								//All privates should be internal
								file[j] = file[j].Replace("private ", "internal ");
								file[j] = file[j].Replace("protected set", "internal set");
								file[j] = file[j].Replace("{ get; set; }", "{ get; internal set; }");

								//Cover case where it's internal i { get; internal set; }
								if (file[j].Contains("internal set") && file[j].Contains("\tinternal "))
									file[j] = file[j].Replace("internal set", "set");

								if (original != file[j])
								{
									isFileModified = true;
									errorCount++;
								}

								break;
							}
						}
					}

					if (file[i].Contains(": GamePacketPayload") && !file[i].Contains("partial class"))
					{
						file[i] = file[i].Replace("public sealed class", "public sealed partial class");
						file[i] = file[i].Replace("public class", "public partial class");
						isFileModified = true;
					}
				}

				if (isFileModified)
				{
					Console.WriteLine($"Fixed Errors in {Path.GetFileNameWithoutExtension(filePath)}: {errorCount}");
					await File.WriteAllLinesAsync(filePath, file);
				}
			}
		}
	}
}
