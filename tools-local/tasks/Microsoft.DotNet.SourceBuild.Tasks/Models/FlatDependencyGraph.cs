// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Microsoft.DotNet.SourceBuild.Tasks.Models
{
    internal class FlatDependencyGraph
    {
        internal IEnumerable<Dependency> Dependencies { get { return _dependencies; } }

        private List<Dependency> _dependencies;

        private FlatDependencyGraph()
        {
            _dependencies = new List<Dependency>();
        }

        internal static FlatDependencyGraph ReadFile(string path)
        {
            var ret = new FlatDependencyGraph();
            var outOfDateDeps = new HashSet<string>();
            var lines = File.ReadAllLines(path);
            if (lines[0].Trim().ToLowerInvariant() != "repositories:")
            {
                throw new InvalidDataException($"first line of dependency graph {lines[0]} is unrecognized");
            }
            bool latest = true;
            Dependency dep = null;
            for (int i = 1; i < lines.Length; ++i)
            {
                var split = lines[i].Split(':');
                if (lines[i].StartsWith("  - Repo:"))
                {
                    if (latest && dep != null)
                    {
                        AttemptToAddDependency(ret, dep);
                    }
                    else if (dep != null)
                    {
                        outOfDateDeps.Add(dep.Repo);
                    }
                    dep = new Dependency();
                    latest = true;
                    dep.Repo = string.Join(":", split.Skip(1)).Trim();
                }
                else if (lines[i].StartsWith("    Commit:"))
                {
                    dep.Commit = split[1].Trim().ToLowerInvariant();
                }
                else if (lines[i].StartsWith("    Delta:"))
                {
                    latest = split[1].Trim().ToLowerInvariant() == "latest";
                }
                else if (lines[i].StartsWith("    Builds:"))
                {
                    if (split[1].Trim() == "[]")
                    {
                        dep.BuildNumber = "unknown";
                    }
                    else
                    {
                        if (!lines[i + 1].StartsWith("    -") || (i + 2 < lines.Length && lines[i + 2].StartsWith("    -")))
                        {
                            throw new InvalidDataException($"dependency graph line {i}: either too many or not enough build numbers");
                        }
                        else
                        {
                            split = lines[i + 1].TrimStart(' ', '-').Split(' ');
                            dep.BuildNumber = split[0];
                            ++i;
                        }
                    }
                }
                else if (lines[i].Trim() == string.Empty)
                {
                    // skip empty lines
                }
                else
                {
                    throw new NotImplementedException($"don't recognize graph dependency line: {lines[i]}");
                }
            }
            if (latest)
            {
                AttemptToAddDependency(ret, dep);
            }

            foreach (var d in outOfDateDeps)
            {
                if (!ret.Dependencies.Any(r => r.Repo.ToLowerInvariant() == d.ToLowerInvariant()))
                {
                    throw new InvalidDataException($"dependency graph marked {d} out of date but has no alternative marked latest");
                }
            }

            return ret;
        }

        private static void AttemptToAddDependency(FlatDependencyGraph ret, Dependency dep)
        {
            var dupe = ret.Dependencies.SingleOrDefault(r => r.Repo.ToLowerInvariant() == dep.Repo.ToLowerInvariant());
            if (dupe != null)
            {
                if (dupe.Commit != dep.Commit)
                {
                    throw new InvalidDataException($"dependency graph has two copies of repo {dep.Repo}, {dep.Commit} and {dupe.Commit}, both marked latest");
                }
                if (dupe.BuildNumber != dep.BuildNumber)
                {
                    throw new InvalidDataException($"dependency graph has two copies of repo {dep.Repo}, {dep.BuildNumber} and {dupe.BuildNumber}, both marked latest");
                }
            }
            else
            {
                ret._dependencies.Add(dep);
            }
        }

        internal class Dependency
        {
            internal string Repo { get; set; }
            internal string Commit { get; set; }
            internal string BuildNumber { get; set; }

            public override string ToString()
            {
                return $"{Repo}@{Commit ?? "unknown"} ({BuildNumber ?? "no build number"}";
            }
        }
    }
}
