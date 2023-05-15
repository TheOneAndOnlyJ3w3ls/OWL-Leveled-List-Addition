using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Records;
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
        //public List<FormLink>
        [SettingName("Ignore Vanilla")]
        [Tooltip("Ignore Skyrim and DLCs weapons and armours (which OWL already handled)")]
        public bool IgnoreVanilla = true;

        [SettingName("Populate Armour leveled lists")]
        [Tooltip("Will populate weapons AND armours into OWL leveled lists")]
        public bool DoArmours = true;

        [SettingName("Only populate shields and no other armour")]
        [Tooltip("Will populate shields (and weapons) into OWL leveled lists, but no other armour pieces.")]
        public bool DoShieldsOnly = false;

        [SettingName("Maximum items per mod for sublist: ")]
        [Tooltip("If a mod has more than this number of items to be added to one of OWL's leveled lists, a new sublist will be created and added instead.")]
        public int MinAmountLeveledList = 10;

        [SettingName("Debug setting")]
        [Tooltip("Enables additional info to be printed out, leave unticked")]
        public bool Debug = false;



        [SettingName("Blacklisted mods")]
        [Tooltip("These mods will be ignored by the patcher")]
        public HashSet<ModKey> BlacklistedMods = new() { ModKey.FromNameAndExtension("LegacyoftheDragonborn.esm") };

        [SettingName("Blacklisted weapons")]
        [Tooltip("These weapons will NOT be added into OWL leveled lists")]
        public HashSet<FormLink<IWeaponGetter>> BlacklistedWeapons = new();

        [SettingName("Blacklisted armours")]
        [Tooltip("These armours will NOT be added into OWL leveled lists")]
        public HashSet<FormLink<IArmorGetter>> BlacklistedArmours = new();

    }
}