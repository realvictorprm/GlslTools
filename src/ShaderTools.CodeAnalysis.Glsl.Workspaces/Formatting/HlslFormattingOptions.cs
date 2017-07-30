﻿using ShaderTools.CodeAnalysis.Options;

namespace ShaderTools.CodeAnalysis.Glsl.Formatting
{
    internal static class GlslFormattingOptions
    {
        private const string RegistryPath = LocalUserProfileStorageLocation.RootRegistryPath + @"TextEditor\GLSL\Specific\";

        // Newline options

        public static Option<OpenBracesPosition> OpenBracePositionForTypes { get; } = new Option<OpenBracesPosition>(nameof(GlslFormattingOptions), nameof(OpenBracePositionForTypes), defaultValue: OpenBracesPosition.MoveToNewLine,
            storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(OpenBracePositionForTypes))});

        public static Option<OpenBracesPosition> OpenBracePositionForTechniques { get; } = new Option<OpenBracesPosition>(nameof(GlslFormattingOptions), nameof(OpenBracePositionForTechniques), defaultValue: OpenBracesPosition.MoveToNewLine,
            storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(OpenBracePositionForTechniques))});

        public static Option<OpenBracesPosition> OpenBracePositionForFunctions { get; } = new Option<OpenBracesPosition>(nameof(GlslFormattingOptions), nameof(OpenBracePositionForFunctions), defaultValue: OpenBracesPosition.MoveToNewLine,
            storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(OpenBracePositionForFunctions))});

        public static Option<OpenBracesPosition> OpenBracePositionForControlBlocks { get; } = new Option<OpenBracesPosition>(nameof(GlslFormattingOptions), nameof(OpenBracePositionForControlBlocks), defaultValue: OpenBracesPosition.MoveToNewLine,
            storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(OpenBracePositionForControlBlocks))});

        public static Option<OpenBracesPosition> OpenBracePositionForStateBlocks { get; } = new Option<OpenBracesPosition>(nameof(GlslFormattingOptions), nameof(OpenBracePositionForStateBlocks), defaultValue: OpenBracesPosition.MoveToNewLine,
            storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(OpenBracePositionForStateBlocks))});

        public static Option<OpenBracesPosition> OpenBracePositionForArrayInitializers { get; } = new Option<OpenBracesPosition>(nameof(GlslFormattingOptions), nameof(OpenBracePositionForArrayInitializers), defaultValue: OpenBracesPosition.MoveToNewLine,
            storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(OpenBracePositionForArrayInitializers))});

        public static Option<bool> PlaceElseOnNewLine { get; } = new Option<bool>(nameof(GlslFormattingOptions), nameof(PlaceElseOnNewLine), defaultValue: true,
            storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(PlaceElseOnNewLine))});

        // Indentation options

        public static Option<bool> IndentBlockContents { get; } = new Option<bool>(nameof(GlslFormattingOptions), nameof(IndentBlockContents), defaultValue: true,
            storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(IndentBlockContents))});

        public static Option<bool> IndentOpenAndCloseBraces { get; } = new Option<bool>(nameof(GlslFormattingOptions), nameof(IndentOpenAndCloseBraces), defaultValue: false,
            storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(IndentOpenAndCloseBraces))});

        public static Option<bool> IndentCaseContents { get; } = new Option<bool>(nameof(GlslFormattingOptions), nameof(IndentCaseContents), defaultValue: true,
            storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(IndentCaseContents))});

        public static Option<bool> IndentCaseLabels { get; } = new Option<bool>(nameof(GlslFormattingOptions), nameof(IndentCaseLabels), defaultValue: true,
            storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(IndentCaseLabels))});

        public static Option<PreprocessorDirectivePosition> PreprocessorDirectivePosition { get; } = new Option<PreprocessorDirectivePosition>(nameof(GlslFormattingOptions), nameof(PreprocessorDirectivePosition), defaultValue: Formatting.PreprocessorDirectivePosition.MoveToLeftmostColumn,
            storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(PreprocessorDirectivePosition))});

        // Spacing options

        public static Option<bool> SpaceAfterFunctionDeclarationName { get; } = new Option<bool>(
            nameof(GlslFormattingOptions), 
            nameof(SpaceAfterFunctionDeclarationName), 
            defaultValue: false,
            storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceAfterFunctionDeclarationName))});

        public static Option<bool> SpaceWithinFunctionDeclarationParentheses { get; } = new Option<bool>(
            nameof(GlslFormattingOptions),
            nameof(SpaceWithinFunctionDeclarationParentheses),
            defaultValue: false,
            storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceWithinFunctionDeclarationParentheses))});

        public static Option<bool> SpaceWithinFunctionDeclarationEmptyParentheses { get; } = new Option<bool>(
           nameof(GlslFormattingOptions),
           nameof(SpaceWithinFunctionDeclarationEmptyParentheses),
           defaultValue: false,
           storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceWithinFunctionDeclarationEmptyParentheses))});

        public static Option<bool> SpaceAfterFunctionCallName { get; } = new Option<bool>(
            nameof(GlslFormattingOptions),
            nameof(SpaceAfterFunctionCallName),
            defaultValue: false,
            storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceAfterFunctionCallName))});

        public static Option<bool> SpaceWithinFunctionCallParentheses { get; } = new Option<bool>(
            nameof(GlslFormattingOptions),
            nameof(SpaceWithinFunctionCallParentheses),
            defaultValue: false,
            storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceWithinFunctionCallParentheses))});

        public static Option<bool> SpaceWithinFunctionCallEmptyParentheses { get; } = new Option<bool>(
           nameof(GlslFormattingOptions),
           nameof(SpaceWithinFunctionCallEmptyParentheses),
           defaultValue: false,
           storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceWithinFunctionCallEmptyParentheses))});

        public static Option<bool> SpaceAfterControlFlowStatementKeyword { get; } = new Option<bool>(
           nameof(GlslFormattingOptions),
           nameof(SpaceAfterControlFlowStatementKeyword),
           defaultValue: true,
           storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceAfterControlFlowStatementKeyword))});

        public static Option<bool> SpaceWithinExpressionParentheses { get; } = new Option<bool>(
           nameof(GlslFormattingOptions),
           nameof(SpaceWithinExpressionParentheses),
           defaultValue: false,
           storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceWithinExpressionParentheses))});

        public static Option<bool> SpaceWithinTypeCastParentheses { get; } = new Option<bool>(
           nameof(GlslFormattingOptions),
           nameof(SpaceWithinTypeCastParentheses),
           defaultValue: false,
           storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceWithinTypeCastParentheses))});

        public static Option<bool> SpaceWithinControlFlowStatementParentheses { get; } = new Option<bool>(
           nameof(GlslFormattingOptions),
           nameof(SpaceWithinControlFlowStatementParentheses),
           defaultValue: false,
           storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceWithinControlFlowStatementParentheses))});

        public static Option<bool> SpaceWithinRegisterOrPackOffsetParentheses { get; } = new Option<bool>(
          nameof(GlslFormattingOptions),
          nameof(SpaceWithinRegisterOrPackOffsetParentheses),
          defaultValue: false,
          storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceWithinRegisterOrPackOffsetParentheses))});

        public static Option<bool> SpaceWithinArrayInitializerBraces { get; } = new Option<bool>(
          nameof(GlslFormattingOptions),
          nameof(SpaceWithinArrayInitializerBraces),
          defaultValue: true,
          storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceWithinArrayInitializerBraces))});

        public static Option<bool> SpaceAfterTypeCast { get; } = new Option<bool>(
          nameof(GlslFormattingOptions),
          nameof(SpaceAfterTypeCast),
          defaultValue: true,
          storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceAfterTypeCast))});

        public static Option<bool> SpaceBeforeOpenSquareBracket { get; } = new Option<bool>(
          nameof(GlslFormattingOptions),
          nameof(SpaceBeforeOpenSquareBracket),
          defaultValue: false,
          storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceBeforeOpenSquareBracket))});

        public static Option<bool> SpaceWithinEmptySquareBrackets { get; } = new Option<bool>(
          nameof(GlslFormattingOptions),
          nameof(SpaceWithinEmptySquareBrackets),
          defaultValue: false,
          storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceWithinEmptySquareBrackets))});

        public static Option<bool> SpaceWithinSquareBrackets { get; } = new Option<bool>(
          nameof(GlslFormattingOptions),
          nameof(SpaceWithinSquareBrackets),
          defaultValue: false,
          storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceWithinSquareBrackets))});

        public static Option<bool> SpaceBeforeColonInBaseTypeDeclaration { get; } = new Option<bool>(
          nameof(GlslFormattingOptions),
          nameof(SpaceBeforeColonInBaseTypeDeclaration),
          defaultValue: true,
          storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceBeforeColonInBaseTypeDeclaration))});

        public static Option<bool> SpaceAfterColonInBaseTypeDeclaration { get; } = new Option<bool>(
          nameof(GlslFormattingOptions),
          nameof(SpaceAfterColonInBaseTypeDeclaration),
          defaultValue: true,
          storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceAfterColonInBaseTypeDeclaration))});

        public static Option<bool> SpaceBeforeColonInSemanticOrRegisterOrPackOffset { get; } = new Option<bool>(
          nameof(GlslFormattingOptions),
          nameof(SpaceBeforeColonInSemanticOrRegisterOrPackOffset),
          defaultValue: true,
          storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceBeforeColonInSemanticOrRegisterOrPackOffset))});

        public static Option<bool> SpaceAfterColonInSemanticOrRegisterOrPackOffset { get; } = new Option<bool>(
          nameof(GlslFormattingOptions),
          nameof(SpaceAfterColonInSemanticOrRegisterOrPackOffset),
          defaultValue: true,
          storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceAfterColonInSemanticOrRegisterOrPackOffset))});

        public static Option<bool> SpaceBeforeComma { get; } = new Option<bool>(
          nameof(GlslFormattingOptions),
          nameof(SpaceBeforeComma),
          defaultValue: false,
          storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceBeforeComma))});

        public static Option<bool> SpaceAfterComma { get; } = new Option<bool>(
          nameof(GlslFormattingOptions),
          nameof(SpaceAfterComma),
          defaultValue: true,
          storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceAfterComma))});

        public static Option<bool> SpaceBeforeDot { get; } = new Option<bool>(
         nameof(GlslFormattingOptions),
         nameof(SpaceBeforeDot),
         defaultValue: false,
         storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceBeforeDot))});

        public static Option<bool> SpaceAfterDot { get; } = new Option<bool>(
         nameof(GlslFormattingOptions),
         nameof(SpaceAfterDot),
         defaultValue: false,
         storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceAfterDot))});

        public static Option<bool> SpaceBeforeSemicolonsInForStatement { get; } = new Option<bool>(
          nameof(GlslFormattingOptions),
          nameof(SpaceBeforeSemicolonsInForStatement),
          defaultValue: false,
          storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceBeforeSemicolonsInForStatement))});

        public static Option<bool> SpaceAfterSemicolonsInForStatement { get; } = new Option<bool>(
          nameof(GlslFormattingOptions),
          nameof(SpaceAfterSemicolonsInForStatement),
          defaultValue: true,
          storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(SpaceAfterSemicolonsInForStatement))});

        public static Option<BinaryOperatorSpaces> BinaryOperatorSpaces { get; } = new Option<BinaryOperatorSpaces>(
          nameof(GlslFormattingOptions),
          nameof(BinaryOperatorSpaces),
          defaultValue: Formatting.BinaryOperatorSpaces.InsertSpaces,
          storageLocations: new OptionStorageLocation[] {
                new LocalUserProfileStorageLocation(RegistryPath + nameof(BinaryOperatorSpaces))});
    }
}