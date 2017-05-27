namespace ShaderTools.CodeAnalysis.Hlsl.Syntax
{
    public enum SyntaxKind
    {
        None,

        // Keywords
        BoolKeyword,
        Bool1Keyword,
        Bool2Keyword,
        Bool3Keyword,
        Bool4Keyword,
        BufferKeyword,
        BreakKeyword,
        CaseKeyword,
        CentroidKeyword,
        ClassKeyword,
        ColumnMajorKeyword,
        CompileKeyword,
        CompileShaderKeyword,
        ConstKeyword,
        ContinueKeyword,
        DefaultKeyword,
        DefKeyword,
        DiscardKeyword,
        DoKeyword,
        DoubleKeyword,
        Double1Keyword,
        Double2Keyword,
        Double3Keyword,
        Double4Keyword,
        Double2x2Keyword,
        Double2x3Keyword,
        Double2x4Keyword,
        Double3x2Keyword,
        Double3x3Keyword,
        Double3x4Keyword,
        Double4x2Keyword,
        Double4x3Keyword,
        Double4x4Keyword,
        ElseKeyword,
        ErrorKeyword,
        ExportKeyword,
        ExternKeyword,
        FloatKeyword,
        Float1Keyword,
        Float2Keyword,
        Float3Keyword,
        Float4Keyword,
        Float2x2Keyword,
        Float2x3Keyword,
        Float2x4Keyword,
        Float3x2Keyword,
        Float3x3Keyword,
        Float3x4Keyword,
        Float4x2Keyword,
        Float4x3Keyword,
        Float4x4Keyword,
        ForKeyword,
        GloballycoherentKeyword,
        GroupsharedKeyword,
        IfKeyword,
        InKeyword,
        InlineKeyword,
        InoutKeyword,
        IntKeyword,
        Int1Keyword,
        Int2Keyword,
        Int3Keyword,
        Int4Keyword,
        InterfaceKeyword,
        LineKeyword,
        LineAdjKeyword,
        LineStreamKeyword,
        LinearKeyword,
        MatrixKeyword,
        NamespaceKeyword,
        NointerpolationKeyword,
        NoperspectiveKeyword,
        NullKeyword,
        OutKeyword,
        OutputPatchKeyword,
        PackMatrixKeyword,
        PackoffsetKeyword,
        PassKeyword,
        PointKeyword,
        PointStreamKeyword,
        PragmaKeyword,
        PreciseKeyword,
        RegisterKeyword,
        ReturnKeyword,
        RowMajorKeyword,

        SamplerKeyword,
        SamplerShadowKeyword,
        SamplerBufferKeyword,
        IsamplerBufferKeyword,
        UsamplerBufferKeyword,
        Sampler1DKeyword,
        Sampler1DArrayKeyword,
        Sampler1DShadowKeyword,
        Sampler1DArrayShadowKeyword,
        Isampler1DKeyword,
        Isampler1DArrayKeyword,
        Usampler1DKeyword,
        Usampler1DArrayKeyword,
        Sampler2DKeyword,
        Sampler2DArrayKeyword,
        Sampler2DShadowKeyword,
        Sampler2DArrayShadowKeyword,
        Sampler2DRectKeyword,
        Sampler2DRectShadowKeyword,
        Sampler2DMSKeyword,
        Sampler2DMSArrayKeyword,
        Isampler2DKeyword,
        Isampler2DArrayKeyword,
        Isampler2DRectKeyword,
        Isampler2DMSKeyword,
        Isampler2DMSArrayKeyword,
        Usampler2DKeyword,
        Usampler2DArrayKeyword,
        Usampler2DRectKeyword,
        Usampler2DMSKeyword,
        Usampler2DMSArrayKeyword,
        Sampler3DKeyword,
        Isampler3DKeyword,
        Usampler3DKeyword,
        SamplerCubeKeyword,
        SamplerCubeArrayKeyword,
        SamplerCubeShadowKeyword,
        SamplerCubeArrayShadowKeyword,
        IsamplerCubeKeyword,
        IsamplerCubeArrayKeyword,
        UsamplerCubeKeyword,
        UsamplerCubeArrayKeyword,

        Texture1DKeyword,
        Itexture1DKeyword,
        Utexture1DKeyword,
        Image1DKeyword,
        Iimage1DKeyword,
        Uimage1DKeyword,
        Texture1DArrayKeyword,
        Itexture1DArrayKeyword,
        Utexture1DArrayKeyword,
        Image1DArrayKeyword,
        Iimage1DArrayKeyword,
        Uimage1DArrayKeyword,
        Texture2DKeyword,
        Itexture2DKeyword,
        Utexture2DKeyword,
        Image2DKeyword,
        Iimage2DKeyword,
        Uimage2DKeyword,
        Image2DRectKeyword,
        Iimage2DRectKeyword,
        Uimage2DRectKeyword,
        SubpassInputKeyword,
        SubpassInputMSKeyword,
        IsubpassInputKeyword,
        IsubpassInputMSKeyword,
        UsubpassInputKeyword,
        UsubpassInputMSKeyword,
        Texture2DArrayKeyword,
        Itexture2DArrayKeyword,
        Utexture2DArrayKeyword,
        Image2DArrayKeyword,
        Iimage2DArrayKeyword,
        Uimage2DArrayKeyword,
        Texture2DMSKeyword,
        Itexture2DMSKeyword,
        Utexture2DMSKeyword,
        Image2DMSKeyword,
        Iimage2DMSKeyword,
        Uimage2DMSKeyword,
        Texture2DMSArrayKeyword,
        Itexture2DMSArrayKeyword,
        Utexture2DMSArrayKeyword,
        Image2DMSArrayKeyword,
        Iimage2DMSArrayKeyword,
        Uimage2DMSArrayKeyword,
        Texture3DKeyword,
        Itexture3DKeyword,
        Utexture3DKeyword,
        Image3DKeyword,
        Iimage3DKeyword,
        Uimage3DKeyword,
        TextureCubeKeyword,
        ItextureCubeKeyword,
        UtextureCubeKeyword,
        ImageCubeKeyword,
        IimageCubeKeyword,
        UimageCubeKeyword,
        TextureCubeArrayKeyword,
        ItextureCubeArrayKeyword,
        UtextureCubeArrayKeyword,
        ImageCubeArrayKeyword,
        IimageCubeArrayKeyword,
        UimageCubeArrayKeyword,

        SharedKeyword,
        SNormKeyword,
        StaticKeyword,
        StringKeyword,
        StructKeyword,
        SwitchKeyword,

        TriangleKeyword,
        TriangleAdjKeyword,
        TriangleStreamKeyword,
        TypedefKeyword,
        UniformKeyword,
        UNormKeyword,
        UintKeyword,
        Uint1Keyword,
        Uint2Keyword,
        Uint3Keyword,
        Uint4Keyword,
        VectorKeyword,
        VolatileKeyword,
        VoidKeyword,
        WarningKeyword,
        WhileKeyword,

        TrueKeyword,
        FalseKeyword,

        // Tokens
        OpenParenToken,
        CloseParenToken,
        OpenBracketToken,
        CloseBracketToken,
        OpenBraceToken,
        CloseBraceToken,

        SemiToken,
        CommaToken,

        LessThanToken,
        LessThanEqualsToken,
        GreaterThanToken,
        GreaterThanEqualsToken,
        LessThanLessThanToken,
        GreaterThanGreaterThanToken,
        PlusToken,
        PlusPlusToken,
        MinusToken,
        MinusMinusToken,
        AsteriskToken,
        SlashToken,
        PercentToken,
        AmpersandToken,
        BarToken,
        AmpersandAmpersandToken,
        BarBarToken,
        CaretToken,
        NotToken,
        TildeToken,
        QuestionToken,
        ColonToken,
        ColonColonToken,

        EqualsToken,
        AsteriskEqualsToken,
        SlashEqualsToken,
        PercentEqualsToken,
        PlusEqualsToken,
        MinusEqualsToken,
        LessThanLessThanEqualsToken,
        GreaterThanGreaterThanEqualsToken,
        AmpersandEqualsToken,
        CaretEqualsToken,
        BarEqualsToken,

        EqualsEqualsToken,
        ExclamationEqualsToken,
        DotToken,
        HashToken,
        HashHashToken,

        UnsignedKeyword,
        DwordKeyword,

        IdentifierToken,
        IntegerLiteralToken,
        FloatLiteralToken,
        StringLiteralToken,
        BracketedStringLiteralToken,
        PreprocessingNumber,

        // Additional preprocessor keywords
        IfDefKeyword,
        IfNDefKeyword,
        ElifKeyword,
        EndIfKeyword,
        DefineKeyword,
        UndefKeyword,
        DefinedKeyword,
        IncludeKeyword,

        EndOfDirectiveToken,

        // Trivia
        EndOfLineTrivia,
        WhitespaceTrivia,
        SingleLineCommentTrivia,
        BlockCommentEndOfFile,
        MultiLineCommentTrivia,
        BackslashNewlineTrivia,
        SkippedTokensTrivia,
        BadDirectiveTrivia,

        EmptyExpandedMacroTrivia,
        DisabledTextTrivia,
        PreprocessingMessageTrivia,
        IfDirectiveTrivia,
        IfDefDirectiveTrivia,
        IfNDefDirectiveTrivia,
        ElifDirectiveTrivia,
        ElseDirectiveTrivia,
        EndIfDirectiveTrivia,
        ObjectLikeDefineDirectiveTrivia,
        FunctionLikeDefineDirectiveTrivia,
        FunctionLikeDefineDirectiveParameterList,
        FunctionLikeDefineDirectiveParameter,
        UndefDirectiveTrivia,
        LineDirectiveTrivia,
        IncludeDirectiveTrivia,
        ErrorDirectiveTrivia,
        PragmaDirectiveTrivia,

        EndOfFileToken,

        // Names
        IdentifierName = EndOfFileToken + 1000,
        QualifiedName,
        PredefinedScalarType,
        PredefinedVectorType,
        PredefinedGenericVectorType,
        PredefinedMatrixType,
        PredefinedGenericMatrixType,
        PredefinedObjectType,
        ArrayRankSpecifier,
        StructType,

        IdentifierDeclarationName,
        QualifiedDeclarationName,

        // HLSL-specific
        PackOffsetLocation,
        PackOffsetComponentPart,
        RegisterLocation,
        LogicalRegisterSpace,
        SemanticName,

        StateProperty,

        // Expressions
        ParenthesizedExpression,
        ConditionalExpression,
        MethodInvocationExpression,
        FunctionInvocationExpression,
        NumericConstructorInvocationExpression,
        ElementAccessExpression,
        Argument,
        ArgumentList,
        TemplateArgumentList,
        CastExpression,
        ArrayInitializerExpression,
        StateInitializer,
        StateArrayInitializer,
        SamplerStateInitializer,
        CompoundExpression,
        CompileExpression,

        // Binary expressions
        AddExpression,
        SubtractExpression,
        MultiplyExpression,
        DivideExpression,
        ModuloExpression,
        LeftShiftExpression,
        RightShiftExpression,
        LogicalOrExpression,
        LogicalAndExpression,
        BitwiseOrExpression,
        BitwiseAndExpression,
        ExclusiveOrExpression,
        EqualsExpression,
        NotEqualsExpression,
        LessThanExpression,
        LessThanOrEqualExpression,
        GreaterThanExpression,
        GreaterThanOrEqualExpression,

        FieldAccessExpression,

        // Assignment expressions
        SimpleAssignmentExpression,
        AddAssignmentExpression,
        SubtractAssignmentExpression,
        MultiplyAssignmentExpression,
        DivideAssignmentExpression,
        ModuloAssignmentExpression,
        AndAssignmentExpression,
        ExclusiveOrAssignmentExpression,
        OrAssignmentExpression,
        LeftShiftAssignmentExpression,
        RightShiftAssignmentExpression,

        // Unary expressions
        UnaryPlusExpression,
        UnaryMinusExpression,
        BitwiseNotExpression,
        LogicalNotExpression,
        PreIncrementExpression,
        PreDecrementExpression,
        PostIncrementExpression,
        PostDecrementExpression,

        // Primary expressions
        NumericLiteralExpression,
        StringLiteralExpression,
        TrueLiteralExpression,
        FalseLiteralExpression,

        // Statements
        Block,
        TypeDeclarationStatement,
        VariableDeclarationStatement,
        VariableDeclaration,
        VariableDeclarator,
        EqualsValueClause,
        ExpressionStatement,
        TypedefStatement,
        TypeAlias,
        EmptyStatement,

        // Jump statements
        BreakStatement,
        ContinueStatement,
        DiscardStatement,
        ReturnStatement,
        WhileStatement,
        DoStatement,
        ForStatement,
        IfStatement,
        ElseClause,
        SwitchStatement,
        SwitchSection,
        CaseSwitchLabel,
        DefaultSwitchLabel,

        // Declarations
        CompilationUnit,
        GlobalStatement,
        Namespace,

        // Attributes
        Attribute,
        AttributeArgumentList,

        // Annotations
        Annotations,

        // Type declarations
        ClassType,
        InterfaceType,
        ConstantBufferDeclaration,
        TechniqueDeclaration,
        PassDeclaration,

        BaseList,
        FunctionDeclaration,
        FunctionDefinition,

        MacroArgument,
        MacroArgumentList,

        Parameter,

        BadToken
    }
}