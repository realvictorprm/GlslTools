﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using HlslTools.Binding.Signatures;
using HlslTools.Diagnostics;
using HlslTools.Symbols;
using HlslTools.Syntax;

namespace HlslTools.Binding
{
    internal partial class Binder
    {
        private void AddSymbol(Symbol symbol)
        {
            _symbols.Add(symbol);
        }

        protected virtual IEnumerable<Symbol> LocalSymbols => _symbols;

        private IEnumerable<Symbol> LookupSymbol(string name)
        {
            return LocalSymbols.Where(x => x.Name == name);
        }

        private TypeSymbol LookupType(TypeSyntax syntax)
        {
            var type = syntax.GetTypeSymbol(this);
            if (type != null)
                return type;

            Diagnostics.ReportUndeclaredType(syntax);
            return TypeFacts.Unknown;
        }

        private IEnumerable<T> LookupSymbols<T>(SyntaxToken name)
            where T : Symbol
        {
            return LookupSymbols(name, s => s is T).OfType<T>();
        }

        private IEnumerable<VariableSymbol> LookupVariable(SyntaxToken name)
        {
            return LookupSymbols<VariableSymbol>(name);
        }

        public IEnumerable<TypeSymbol> LookupTypeSymbol(SyntaxToken name)
        {
            return LookupSymbols<TypeSymbol>(name);
        }

        private IEnumerable<Symbol> LookupSymbols(SyntaxToken name, Func<Symbol, bool> filter)
        {
            var text = name.ValueText;

            IEnumerable<Symbol> result;
            var binder = this;
            do
            {
                result = binder.LookupSymbol(text).Where(filter);
                binder = binder.Parent;
            } while (!result.Any() && binder != null);

            return result;
        }

        public virtual IEnumerable<MethodSymbol> LookupMethods(TypeSymbol type)
        {
            return Parent.LookupMethods(type);
        }

        private IEnumerable<MethodSymbol> LookupMethod(TypeSymbol type, SyntaxToken name)
        {
            return LookupMethods(type).Where(m => name.Text == m.Name);
        }

        private OverloadResolutionResult<MethodSymbolSignature> LookupMethod(TypeSymbol type, SyntaxToken name, ImmutableArray<TypeSymbol> argumentTypes)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            var signatures = from m in LookupMethod(type, name)
                             select new MethodSymbolSignature(m);
            return OverloadResolution.Perform(signatures, argumentTypes);
        }

        private OverloadResolutionResult<FunctionSymbolSignature> LookupFunction(SyntaxToken name, ImmutableArray<TypeSymbol> argumentTypes)
        {
            var signatures = from f in LookupSymbols<FunctionSymbol>(name)
                             where name.Text == f.Name
                             select new FunctionSymbolSignature(f);
            return OverloadResolution.Perform(signatures, argumentTypes);
        }
    }
}