using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;
using Microsoft.CodeAnalysis;

namespace FreecraftCore
{
	class Program
	{
		static async Task Main(string[] args)
		{
			foreach (string filePath in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.cs"))
			{
				string[] file = await File.ReadAllLinesAsync(filePath);

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
							if (file[j][0] != '[')
							{
								file[j] = file[j].Replace("{ get; }", "{ get; internal set; }");
								file[j] = file[j].Replace("private set", "internal set");
								file[j] = file[j].Replace("protected set", "internal set");
								file[j] = file[j].Replace("{ get; set; }", "{ get; internal set; }");
								break;
							}
						}
					}
				}

				await File.WriteAllLinesAsync(filePath, file);
			}
		}
	}
}
