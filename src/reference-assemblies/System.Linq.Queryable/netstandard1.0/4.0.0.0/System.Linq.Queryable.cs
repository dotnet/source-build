[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Linq.Queryable")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Linq.Queryable")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Linq.Queryable")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Linq
{
    public abstract partial class EnumerableExecutor
    {
        protected EnumerableExecutor() { }
    }
    public partial class EnumerableExecutor<T> : System.Linq.EnumerableExecutor
    {
        public EnumerableExecutor(System.Linq.Expressions.Expression expression) { }
    }
    public abstract partial class EnumerableQuery
    {
        protected EnumerableQuery() { }
    }
    public partial class EnumerableQuery<T> : System.Linq.EnumerableQuery, System.Collections.Generic.IEnumerable<T>, System.Collections.IEnumerable, System.Linq.IOrderedQueryable, System.Linq.IOrderedQueryable<T>, System.Linq.IQueryable, System.Linq.IQueryable<T>, System.Linq.IQueryProvider
    {
        public EnumerableQuery(System.Collections.Generic.IEnumerable<T> enumerable) { }
        public EnumerableQuery(System.Linq.Expressions.Expression expression) { }
        System.Type System.Linq.IQueryable.ElementType { get { throw null; } }
        System.Linq.Expressions.Expression System.Linq.IQueryable.Expression { get { throw null; } }
        System.Linq.IQueryProvider System.Linq.IQueryable.Provider { get { throw null; } }
        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        System.Linq.IQueryable System.Linq.IQueryProvider.CreateQuery(System.Linq.Expressions.Expression expression) { throw null; }
        System.Linq.IQueryable<S> System.Linq.IQueryProvider.CreateQuery<S>(System.Linq.Expressions.Expression expression) { throw null; }
        object System.Linq.IQueryProvider.Execute(System.Linq.Expressions.Expression expression) { throw null; }
        S System.Linq.IQueryProvider.Execute<S>(System.Linq.Expressions.Expression expression) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class Queryable
    {
        public static TSource Aggregate<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, TSource, TSource>> func) { throw null; }
        public static TAccumulate Aggregate<TSource, TAccumulate>(this System.Linq.IQueryable<TSource> source, TAccumulate seed, System.Linq.Expressions.Expression<System.Func<TAccumulate, TSource, TAccumulate>> func) { throw null; }
        public static TResult Aggregate<TSource, TAccumulate, TResult>(this System.Linq.IQueryable<TSource> source, TAccumulate seed, System.Linq.Expressions.Expression<System.Func<TAccumulate, TSource, TAccumulate>> func, System.Linq.Expressions.Expression<System.Func<TAccumulate, TResult>> selector) { throw null; }
        public static bool All<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, bool>> predicate) { throw null; }
        public static bool Any<TSource>(this System.Linq.IQueryable<TSource> source) { throw null; }
        public static bool Any<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, bool>> predicate) { throw null; }
        public static System.Linq.IQueryable AsQueryable(this System.Collections.IEnumerable source) { throw null; }
        public static System.Linq.IQueryable<TElement> AsQueryable<TElement>(this System.Collections.Generic.IEnumerable<TElement> source) { throw null; }
        public static decimal Average(this System.Linq.IQueryable<decimal> source) { throw null; }
        public static double Average(this System.Linq.IQueryable<double> source) { throw null; }
        public static double Average(this System.Linq.IQueryable<int> source) { throw null; }
        public static double Average(this System.Linq.IQueryable<long> source) { throw null; }
        public static System.Nullable<decimal> Average(this System.Linq.IQueryable<System.Nullable<decimal>> source) { throw null; }
        public static System.Nullable<double> Average(this System.Linq.IQueryable<System.Nullable<double>> source) { throw null; }
        public static System.Nullable<double> Average(this System.Linq.IQueryable<System.Nullable<int>> source) { throw null; }
        public static System.Nullable<double> Average(this System.Linq.IQueryable<System.Nullable<long>> source) { throw null; }
        public static System.Nullable<float> Average(this System.Linq.IQueryable<System.Nullable<float>> source) { throw null; }
        public static float Average(this System.Linq.IQueryable<float> source) { throw null; }
        public static decimal Average<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, decimal>> selector) { throw null; }
        public static double Average<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, double>> selector) { throw null; }
        public static double Average<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, int>> selector) { throw null; }
        public static double Average<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, long>> selector) { throw null; }
        public static System.Nullable<decimal> Average<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, System.Nullable<decimal>>> selector) { throw null; }
        public static System.Nullable<double> Average<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, System.Nullable<double>>> selector) { throw null; }
        public static System.Nullable<double> Average<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, System.Nullable<int>>> selector) { throw null; }
        public static System.Nullable<double> Average<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, System.Nullable<long>>> selector) { throw null; }
        public static System.Nullable<float> Average<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, System.Nullable<float>>> selector) { throw null; }
        public static float Average<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, float>> selector) { throw null; }
        public static System.Linq.IQueryable<TResult> Cast<TResult>(this System.Linq.IQueryable source) { throw null; }
        public static System.Linq.IQueryable<TSource> Concat<TSource>(this System.Linq.IQueryable<TSource> source1, System.Collections.Generic.IEnumerable<TSource> source2) { throw null; }
        public static bool Contains<TSource>(this System.Linq.IQueryable<TSource> source, TSource item) { throw null; }
        public static bool Contains<TSource>(this System.Linq.IQueryable<TSource> source, TSource item, System.Collections.Generic.IEqualityComparer<TSource> comparer) { throw null; }
        public static int Count<TSource>(this System.Linq.IQueryable<TSource> source) { throw null; }
        public static int Count<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, bool>> predicate) { throw null; }
        public static System.Linq.IQueryable<TSource> DefaultIfEmpty<TSource>(this System.Linq.IQueryable<TSource> source) { throw null; }
        public static System.Linq.IQueryable<TSource> DefaultIfEmpty<TSource>(this System.Linq.IQueryable<TSource> source, TSource defaultValue) { throw null; }
        public static System.Linq.IQueryable<TSource> Distinct<TSource>(this System.Linq.IQueryable<TSource> source) { throw null; }
        public static System.Linq.IQueryable<TSource> Distinct<TSource>(this System.Linq.IQueryable<TSource> source, System.Collections.Generic.IEqualityComparer<TSource> comparer) { throw null; }
        public static TSource ElementAtOrDefault<TSource>(this System.Linq.IQueryable<TSource> source, int index) { throw null; }
        public static TSource ElementAt<TSource>(this System.Linq.IQueryable<TSource> source, int index) { throw null; }
        public static System.Linq.IQueryable<TSource> Except<TSource>(this System.Linq.IQueryable<TSource> source1, System.Collections.Generic.IEnumerable<TSource> source2) { throw null; }
        public static System.Linq.IQueryable<TSource> Except<TSource>(this System.Linq.IQueryable<TSource> source1, System.Collections.Generic.IEnumerable<TSource> source2, System.Collections.Generic.IEqualityComparer<TSource> comparer) { throw null; }
        public static TSource FirstOrDefault<TSource>(this System.Linq.IQueryable<TSource> source) { throw null; }
        public static TSource FirstOrDefault<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, bool>> predicate) { throw null; }
        public static TSource First<TSource>(this System.Linq.IQueryable<TSource> source) { throw null; }
        public static TSource First<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, bool>> predicate) { throw null; }
        public static System.Linq.IQueryable<System.Linq.IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, TKey>> keySelector) { throw null; }
        public static System.Linq.IQueryable<System.Linq.IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, TKey>> keySelector, System.Collections.Generic.IEqualityComparer<TKey> comparer) { throw null; }
        public static System.Linq.IQueryable<System.Linq.IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, TKey>> keySelector, System.Linq.Expressions.Expression<System.Func<TSource, TElement>> elementSelector) { throw null; }
        public static System.Linq.IQueryable<System.Linq.IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, TKey>> keySelector, System.Linq.Expressions.Expression<System.Func<TSource, TElement>> elementSelector, System.Collections.Generic.IEqualityComparer<TKey> comparer) { throw null; }
        public static System.Linq.IQueryable<TResult> GroupBy<TSource, TKey, TResult>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, TKey>> keySelector, System.Linq.Expressions.Expression<System.Func<TKey, System.Collections.Generic.IEnumerable<TSource>, TResult>> resultSelector) { throw null; }
        public static System.Linq.IQueryable<TResult> GroupBy<TSource, TKey, TResult>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, TKey>> keySelector, System.Linq.Expressions.Expression<System.Func<TKey, System.Collections.Generic.IEnumerable<TSource>, TResult>> resultSelector, System.Collections.Generic.IEqualityComparer<TKey> comparer) { throw null; }
        public static System.Linq.IQueryable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, TKey>> keySelector, System.Linq.Expressions.Expression<System.Func<TSource, TElement>> elementSelector, System.Linq.Expressions.Expression<System.Func<TKey, System.Collections.Generic.IEnumerable<TElement>, TResult>> resultSelector) { throw null; }
        public static System.Linq.IQueryable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, TKey>> keySelector, System.Linq.Expressions.Expression<System.Func<TSource, TElement>> elementSelector, System.Linq.Expressions.Expression<System.Func<TKey, System.Collections.Generic.IEnumerable<TElement>, TResult>> resultSelector, System.Collections.Generic.IEqualityComparer<TKey> comparer) { throw null; }
        public static System.Linq.IQueryable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this System.Linq.IQueryable<TOuter> outer, System.Collections.Generic.IEnumerable<TInner> inner, System.Linq.Expressions.Expression<System.Func<TOuter, TKey>> outerKeySelector, System.Linq.Expressions.Expression<System.Func<TInner, TKey>> innerKeySelector, System.Linq.Expressions.Expression<System.Func<TOuter, System.Collections.Generic.IEnumerable<TInner>, TResult>> resultSelector) { throw null; }
        public static System.Linq.IQueryable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this System.Linq.IQueryable<TOuter> outer, System.Collections.Generic.IEnumerable<TInner> inner, System.Linq.Expressions.Expression<System.Func<TOuter, TKey>> outerKeySelector, System.Linq.Expressions.Expression<System.Func<TInner, TKey>> innerKeySelector, System.Linq.Expressions.Expression<System.Func<TOuter, System.Collections.Generic.IEnumerable<TInner>, TResult>> resultSelector, System.Collections.Generic.IEqualityComparer<TKey> comparer) { throw null; }
        public static System.Linq.IQueryable<TSource> Intersect<TSource>(this System.Linq.IQueryable<TSource> source1, System.Collections.Generic.IEnumerable<TSource> source2) { throw null; }
        public static System.Linq.IQueryable<TSource> Intersect<TSource>(this System.Linq.IQueryable<TSource> source1, System.Collections.Generic.IEnumerable<TSource> source2, System.Collections.Generic.IEqualityComparer<TSource> comparer) { throw null; }
        public static System.Linq.IQueryable<TResult> Join<TOuter, TInner, TKey, TResult>(this System.Linq.IQueryable<TOuter> outer, System.Collections.Generic.IEnumerable<TInner> inner, System.Linq.Expressions.Expression<System.Func<TOuter, TKey>> outerKeySelector, System.Linq.Expressions.Expression<System.Func<TInner, TKey>> innerKeySelector, System.Linq.Expressions.Expression<System.Func<TOuter, TInner, TResult>> resultSelector) { throw null; }
        public static System.Linq.IQueryable<TResult> Join<TOuter, TInner, TKey, TResult>(this System.Linq.IQueryable<TOuter> outer, System.Collections.Generic.IEnumerable<TInner> inner, System.Linq.Expressions.Expression<System.Func<TOuter, TKey>> outerKeySelector, System.Linq.Expressions.Expression<System.Func<TInner, TKey>> innerKeySelector, System.Linq.Expressions.Expression<System.Func<TOuter, TInner, TResult>> resultSelector, System.Collections.Generic.IEqualityComparer<TKey> comparer) { throw null; }
        public static TSource LastOrDefault<TSource>(this System.Linq.IQueryable<TSource> source) { throw null; }
        public static TSource LastOrDefault<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, bool>> predicate) { throw null; }
        public static TSource Last<TSource>(this System.Linq.IQueryable<TSource> source) { throw null; }
        public static TSource Last<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, bool>> predicate) { throw null; }
        public static long LongCount<TSource>(this System.Linq.IQueryable<TSource> source) { throw null; }
        public static long LongCount<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, bool>> predicate) { throw null; }
        public static TSource Max<TSource>(this System.Linq.IQueryable<TSource> source) { throw null; }
        public static TResult Max<TSource, TResult>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, TResult>> selector) { throw null; }
        public static TSource Min<TSource>(this System.Linq.IQueryable<TSource> source) { throw null; }
        public static TResult Min<TSource, TResult>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, TResult>> selector) { throw null; }
        public static System.Linq.IQueryable<TResult> OfType<TResult>(this System.Linq.IQueryable source) { throw null; }
        public static System.Linq.IOrderedQueryable<TSource> OrderByDescending<TSource, TKey>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, TKey>> keySelector) { throw null; }
        public static System.Linq.IOrderedQueryable<TSource> OrderByDescending<TSource, TKey>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, TKey>> keySelector, System.Collections.Generic.IComparer<TKey> comparer) { throw null; }
        public static System.Linq.IOrderedQueryable<TSource> OrderBy<TSource, TKey>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, TKey>> keySelector) { throw null; }
        public static System.Linq.IOrderedQueryable<TSource> OrderBy<TSource, TKey>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, TKey>> keySelector, System.Collections.Generic.IComparer<TKey> comparer) { throw null; }
        public static System.Linq.IQueryable<TSource> Reverse<TSource>(this System.Linq.IQueryable<TSource> source) { throw null; }
        public static System.Linq.IQueryable<TResult> SelectMany<TSource, TResult>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, System.Collections.Generic.IEnumerable<TResult>>> selector) { throw null; }
        public static System.Linq.IQueryable<TResult> SelectMany<TSource, TResult>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, int, System.Collections.Generic.IEnumerable<TResult>>> selector) { throw null; }
        public static System.Linq.IQueryable<TResult> SelectMany<TSource, TCollection, TResult>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, System.Collections.Generic.IEnumerable<TCollection>>> collectionSelector, System.Linq.Expressions.Expression<System.Func<TSource, TCollection, TResult>> resultSelector) { throw null; }
        public static System.Linq.IQueryable<TResult> SelectMany<TSource, TCollection, TResult>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, int, System.Collections.Generic.IEnumerable<TCollection>>> collectionSelector, System.Linq.Expressions.Expression<System.Func<TSource, TCollection, TResult>> resultSelector) { throw null; }
        public static System.Linq.IQueryable<TResult> Select<TSource, TResult>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, int, TResult>> selector) { throw null; }
        public static System.Linq.IQueryable<TResult> Select<TSource, TResult>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, TResult>> selector) { throw null; }
        public static bool SequenceEqual<TSource>(this System.Linq.IQueryable<TSource> source1, System.Collections.Generic.IEnumerable<TSource> source2) { throw null; }
        public static bool SequenceEqual<TSource>(this System.Linq.IQueryable<TSource> source1, System.Collections.Generic.IEnumerable<TSource> source2, System.Collections.Generic.IEqualityComparer<TSource> comparer) { throw null; }
        public static TSource SingleOrDefault<TSource>(this System.Linq.IQueryable<TSource> source) { throw null; }
        public static TSource SingleOrDefault<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, bool>> predicate) { throw null; }
        public static TSource Single<TSource>(this System.Linq.IQueryable<TSource> source) { throw null; }
        public static TSource Single<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, bool>> predicate) { throw null; }
        public static System.Linq.IQueryable<TSource> SkipWhile<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, bool>> predicate) { throw null; }
        public static System.Linq.IQueryable<TSource> SkipWhile<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, int, bool>> predicate) { throw null; }
        public static System.Linq.IQueryable<TSource> Skip<TSource>(this System.Linq.IQueryable<TSource> source, int count) { throw null; }
        public static decimal Sum(this System.Linq.IQueryable<decimal> source) { throw null; }
        public static double Sum(this System.Linq.IQueryable<double> source) { throw null; }
        public static int Sum(this System.Linq.IQueryable<int> source) { throw null; }
        public static long Sum(this System.Linq.IQueryable<long> source) { throw null; }
        public static System.Nullable<decimal> Sum(this System.Linq.IQueryable<System.Nullable<decimal>> source) { throw null; }
        public static System.Nullable<double> Sum(this System.Linq.IQueryable<System.Nullable<double>> source) { throw null; }
        public static System.Nullable<int> Sum(this System.Linq.IQueryable<System.Nullable<int>> source) { throw null; }
        public static System.Nullable<long> Sum(this System.Linq.IQueryable<System.Nullable<long>> source) { throw null; }
        public static System.Nullable<float> Sum(this System.Linq.IQueryable<System.Nullable<float>> source) { throw null; }
        public static float Sum(this System.Linq.IQueryable<float> source) { throw null; }
        public static decimal Sum<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, decimal>> selector) { throw null; }
        public static double Sum<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, double>> selector) { throw null; }
        public static int Sum<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, int>> selector) { throw null; }
        public static long Sum<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, long>> selector) { throw null; }
        public static System.Nullable<decimal> Sum<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, System.Nullable<decimal>>> selector) { throw null; }
        public static System.Nullable<double> Sum<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, System.Nullable<double>>> selector) { throw null; }
        public static System.Nullable<int> Sum<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, System.Nullable<int>>> selector) { throw null; }
        public static System.Nullable<long> Sum<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, System.Nullable<long>>> selector) { throw null; }
        public static System.Nullable<float> Sum<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, System.Nullable<float>>> selector) { throw null; }
        public static float Sum<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, float>> selector) { throw null; }
        public static System.Linq.IQueryable<TSource> TakeWhile<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, bool>> predicate) { throw null; }
        public static System.Linq.IQueryable<TSource> TakeWhile<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, int, bool>> predicate) { throw null; }
        public static System.Linq.IQueryable<TSource> Take<TSource>(this System.Linq.IQueryable<TSource> source, int count) { throw null; }
        public static System.Linq.IOrderedQueryable<TSource> ThenByDescending<TSource, TKey>(this System.Linq.IOrderedQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, TKey>> keySelector) { throw null; }
        public static System.Linq.IOrderedQueryable<TSource> ThenByDescending<TSource, TKey>(this System.Linq.IOrderedQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, TKey>> keySelector, System.Collections.Generic.IComparer<TKey> comparer) { throw null; }
        public static System.Linq.IOrderedQueryable<TSource> ThenBy<TSource, TKey>(this System.Linq.IOrderedQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, TKey>> keySelector) { throw null; }
        public static System.Linq.IOrderedQueryable<TSource> ThenBy<TSource, TKey>(this System.Linq.IOrderedQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, TKey>> keySelector, System.Collections.Generic.IComparer<TKey> comparer) { throw null; }
        public static System.Linq.IQueryable<TSource> Union<TSource>(this System.Linq.IQueryable<TSource> source1, System.Collections.Generic.IEnumerable<TSource> source2) { throw null; }
        public static System.Linq.IQueryable<TSource> Union<TSource>(this System.Linq.IQueryable<TSource> source1, System.Collections.Generic.IEnumerable<TSource> source2, System.Collections.Generic.IEqualityComparer<TSource> comparer) { throw null; }
        public static System.Linq.IQueryable<TSource> Where<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, bool>> predicate) { throw null; }
        public static System.Linq.IQueryable<TSource> Where<TSource>(this System.Linq.IQueryable<TSource> source, System.Linq.Expressions.Expression<System.Func<TSource, int, bool>> predicate) { throw null; }
        public static System.Linq.IQueryable<TResult> Zip<TFirst, TSecond, TResult>(this System.Linq.IQueryable<TFirst> source1, System.Collections.Generic.IEnumerable<TSecond> source2, System.Linq.Expressions.Expression<System.Func<TFirst, TSecond, TResult>> resultSelector) { throw null; }
    }
}
