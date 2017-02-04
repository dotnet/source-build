using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Microsoft.DotNet.PlatformAbstractions;

namespace Microsoft.DotNet.Build.Tasks
{
    public class SelectBuildTargets : Task
    {
        [Required]
        public ITaskItem[] RepositoryCollection { get; set; }

        [Required]
        public string SpecifiedRepositories { get; set; }

        [Output]
        public ITaskItem[] SelectedRepositories { get; set; }

        public override bool Execute()
        {
            var specList = SpecifiedRepositories.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            var finalList = new List<ITaskItem>(specList.Length);

            Log.LogCommandLine(MessageImportance.High, $"SPECIFIED: {SpecifiedRepositories}");

            foreach (var repository in RepositoryCollection)
            {

                if (specList.Contains(repository.ItemSpec))
                {
                    Log.LogCommandLine(MessageImportance.High, $"Selected {repository.ItemSpec}");

                    // select it
                    finalList.Add(repository);
                }
            }


            SelectedRepositories = finalList.ToArray();
            return true;
        }
    }
}
