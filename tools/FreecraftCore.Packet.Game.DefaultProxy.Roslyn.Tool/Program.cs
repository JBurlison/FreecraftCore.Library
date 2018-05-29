using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FreecraftCore.Serializer;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;

namespace FreecraftCore
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<NetworkOperationCode, CompilationUnitSyntax> compilationUnits = new Dictionary<NetworkOperationCode, CompilationUnitSyntax>(Enum.GetValues(typeof(NetworkOperationCode)).Length);

			foreach(NetworkOperationCode code in GamePacketMetadataMarker.UnimplementedOperationCodes.Value)
			{
				compilationUnits.Add(code, BuildPayloadClassSyntax($"{code}_DTO_PROXY", code));
			}

			string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "Packets");

			if(!Directory.Exists(outputPath))
				Directory.CreateDirectory(outputPath);

			foreach(var cu in compilationUnits)
			{
				SyntaxNode formattedNode = Formatter.Format(cu.Value, new AdhocWorkspace());

				StringBuilder sb = new StringBuilder();
				using(TextWriter classFileWriter = new StringWriter(sb))
				{
					formattedNode.WriteTo(classFileWriter);
				}

				//Write the packet file out
				File.WriteAllText($"Packets/{cu.Key}_DTO_PROXY.cs", sb.ToString());
			}
		}

		public static CompilationUnitSyntax BuildPayloadClassSyntax(string className, NetworkOperationCode code)
		{
			return SyntaxFactory.CompilationUnit()
					.WithUsings
					(
						SyntaxFactory.List<UsingDirectiveSyntax>
						(
							new UsingDirectiveSyntax[]
							{
								SyntaxFactory.UsingDirective
								(
									SyntaxFactory.IdentifierName(nameof(FreecraftCore))
								),
								SyntaxFactory.UsingDirective
								(
									SyntaxFactory.QualifiedName
									(
										SyntaxFactory.IdentifierName(nameof(FreecraftCore)),
										SyntaxFactory.IdentifierName(nameof(Serializer))
									)
								)
							}
						)
					)
					.WithMembers
					(
						SyntaxFactory.SingletonList<MemberDeclarationSyntax>
						(
							SyntaxFactory.ClassDeclaration(className)
								.WithAttributeLists
								(
									SyntaxFactory.List<AttributeListSyntax>
									(
										new AttributeListSyntax[]
										{
											SyntaxFactory.AttributeList
											(
												SyntaxFactory.SingletonSeparatedList<AttributeSyntax>
												(
													SyntaxFactory.Attribute
													(
														SyntaxFactory.IdentifierName(nameof(GamePayloadOperationCodeAttribute))
													)
													.WithArgumentList
													(
														SyntaxFactory.AttributeArgumentList
														(
															SyntaxFactory.SingletonSeparatedList<AttributeArgumentSyntax>
															(
																SyntaxFactory.AttributeArgument
																(
																	SyntaxFactory.MemberAccessExpression
																	(
																		SyntaxKind.SimpleMemberAccessExpression,
																		SyntaxFactory.IdentifierName(nameof(NetworkOperationCode)),
																		SyntaxFactory.IdentifierName(code.ToString())
																	)
																)
															)
														)
													)
												)
											),
											SyntaxFactory.AttributeList
											(
												SyntaxFactory.SingletonSeparatedList<AttributeSyntax>
												(
													SyntaxFactory.Attribute
													(
														SyntaxFactory.IdentifierName(nameof(WireDataContractAttribute))
													)
												)
											)
										}
									)
								)
								.WithModifiers
								(
									SyntaxFactory.TokenList
									(
										new[]
										{
											SyntaxFactory.Token(SyntaxKind.PublicKeyword),
											SyntaxFactory.Token(SyntaxKind.SealedKeyword)
										}
									)
								)
								.WithBaseList
								(
									SyntaxFactory.BaseList
									(
										SyntaxFactory.SeparatedList<BaseTypeSyntax>
										(
											new SyntaxNodeOrToken[]
											{
												SyntaxFactory.SimpleBaseType
												(
													SyntaxFactory.IdentifierName(nameof(GamePacketPayload))
												),
												SyntaxFactory.Token(SyntaxKind.CommaToken),
												SyntaxFactory.SimpleBaseType
												(
													SyntaxFactory.IdentifierName(nameof(IUnimplementedGamePacketPayload))
												)
											}
										)
									)
								)
								.WithMembers
								(
									SyntaxFactory.List<MemberDeclarationSyntax>
									(
										new MemberDeclarationSyntax[]
										{
											SyntaxFactory.FieldDeclaration
												(
													SyntaxFactory.VariableDeclaration
														(
															SyntaxFactory.ArrayType
																(
																	SyntaxFactory.PredefinedType
																	(
																		SyntaxFactory.Token(SyntaxKind.ByteKeyword)
																	)
																)
																.WithRankSpecifiers
																(
																	SyntaxFactory.SingletonList<ArrayRankSpecifierSyntax>
																	(
																		SyntaxFactory.ArrayRankSpecifier
																		(
																			SyntaxFactory.SingletonSeparatedList<ExpressionSyntax>
																			(
																				SyntaxFactory.OmittedArraySizeExpression()
																			)
																		)
																	)
																)
														)
														.WithVariables
														(
															SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>
															(
																SyntaxFactory.VariableDeclarator
																(
																	SyntaxFactory.Identifier($"_{nameof(IUnimplementedGamePacketPayload.Data)}")
																)
															)
														)
												)
												.WithAttributeLists
												(
													SyntaxFactory.List<AttributeListSyntax>
													(
														new AttributeListSyntax[]
														{
															SyntaxFactory.AttributeList
															(
																SyntaxFactory.SingletonSeparatedList<AttributeSyntax>
																(
																	SyntaxFactory.Attribute
																	(
																		SyntaxFactory.IdentifierName(nameof(ReadToEndAttribute))
																	)
																)
															),
															SyntaxFactory.AttributeList
															(
																SyntaxFactory.SingletonSeparatedList<AttributeSyntax>
																(
																	SyntaxFactory.Attribute
																		(
																			SyntaxFactory.IdentifierName(nameof(WireMemberAttribute))
																		)
																		.WithArgumentList
																		(
																			SyntaxFactory.AttributeArgumentList
																			(
																				SyntaxFactory.SingletonSeparatedList<AttributeArgumentSyntax>
																				(
																					SyntaxFactory.AttributeArgument
																					(
																						SyntaxFactory.LiteralExpression
																						(
																							SyntaxKind.NumericLiteralExpression,
																							SyntaxFactory.Literal(1)
																						)
																					)
																				)
																			)
																		)
																)
															)
														}
													)
												)
												.WithModifiers
												(
													SyntaxFactory.TokenList
													(
														SyntaxFactory.Token(SyntaxKind.PrivateKeyword)
													)
												),
											SyntaxFactory.PropertyDeclaration
												(
													SyntaxFactory.ArrayType
														(
															SyntaxFactory.PredefinedType
															(
																SyntaxFactory.Token(SyntaxKind.ByteKeyword)
															)
														)
														.WithRankSpecifiers
														(
															SyntaxFactory.SingletonList<ArrayRankSpecifierSyntax>
															(
																SyntaxFactory.ArrayRankSpecifier
																(
																	SyntaxFactory.SingletonSeparatedList<ExpressionSyntax>
																	(
																		SyntaxFactory.OmittedArraySizeExpression()
																	)
																)
															)
														),
													SyntaxFactory.Identifier(nameof(IUnimplementedGamePacketPayload.Data))
												)
												.WithModifiers
												(
													SyntaxFactory.TokenList
													(
														SyntaxFactory.Token(SyntaxKind.PublicKeyword)
													)
												)
												.WithAccessorList
												(
													SyntaxFactory.AccessorList
													(
														SyntaxFactory.List<AccessorDeclarationSyntax>
														(
															new AccessorDeclarationSyntax[]
															{
																SyntaxFactory.AccessorDeclaration
																	(
																		SyntaxKind.GetAccessorDeclaration
																	)
																	.WithBody
																	(
																		SyntaxFactory.Block
																		(
																			SyntaxFactory.SingletonList<StatementSyntax>
																			(
																				SyntaxFactory.ReturnStatement
																				(
																					SyntaxFactory.IdentifierName($"{nameof(IUnimplementedGamePacketPayload.Data)}")
																				)
																			)
																		)
																	),
																SyntaxFactory.AccessorDeclaration
																	(
																		SyntaxKind.SetAccessorDeclaration
																	)
																	.WithBody
																	(
																		SyntaxFactory.Block
																		(
																			SyntaxFactory.SingletonList<StatementSyntax>
																			(
																				SyntaxFactory.ExpressionStatement
																					(
																						SyntaxFactory.AssignmentExpression
																						(
																							SyntaxKind.SimpleAssignmentExpression,
																							SyntaxFactory.IdentifierName($"{nameof(IUnimplementedGamePacketPayload.Data)}"),
																							SyntaxFactory.IdentifierName("value")
																						)
																					)
																			)
																		)
																	)
															}
														)
													)
												),
											SyntaxFactory.ConstructorDeclaration
												(
													SyntaxFactory.Identifier(className)
												)
												.WithModifiers
												(
													SyntaxFactory.TokenList
													(
														SyntaxFactory.Token(SyntaxKind.PublicKeyword)
													)
												)
												.WithBody
												(
													SyntaxFactory.Block()
												)
										}
									)
								)
						)
					)
					.NormalizeWhitespace();
		}
	}
}
