
/*
 * This file is being used by specified code analysis tools to maintaining messaging
 * and analysing code of this project and stores attributes that are applied to this project.
 * 
 * Project-level suppressions either have no target or are given
 * a specific target and scoped to namespace, type, member.
 */

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Info Code Smell", "S1133:Deprecated code should be removed", Justification = "Jenga must thrown error in IDEs when developer tries to use not supported API.", Scope = "member", Target = "~M:Zustand.Data.Arrays.Jenga`1.Add(`0)")]
