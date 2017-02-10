using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Microsoft.DotNet.PlatformAbstractions;

namespace Microsoft.DotNet.Build.Tasks
{
    public class Select : Task
    {
        [Required]
        public ITaskItem[] Collection { get; set; }

        [Required]
        public string Selection { get; set; }

        [Output]
        public ITaskItem[] Selected { get; set; }

        public override bool Execute()
        {
            var requested = Selection.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            var selected = new List<ITaskItem>(requested.Length);

            Log.LogCommandLine(MessageImportance.High, $"Selecting {Selection}");

            foreach (var item in Collection)
            {
                if (requested.Contains(item.ItemSpec))
                {
                    Log.LogCommandLine(MessageImportance.High, $"Selected {item.ItemSpec}...");

                    // select it
                    selected.Add(item);
                }
            }


            Selected = selected.ToArray();
            return true;
        }
    }
}
