using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.WPF.Reflection.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWLLeveledListAddition
{
    public class Settings
    {
    
        [SettingName("Maximum items per mod for sublist: ")]
        [Tooltip("If a mod has more than this number of items to be added to one of OWL's leveled lists, a new sublist will be created and added instead.")]
        public int MinAmountLeveledList = 10;

        [SettingName("Debug setting")]
        [Tooltip("Enables additional info to be printed out, leave unticked")]
        public bool Debug = false;

    }
}