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

        [SettingName("Populate Ammunition leveled lists")]
        [Tooltip("Will populate ammunition into OWL leveled lists")]
        public bool DoAmmo = true;

        [SettingName("Attempt to fix ammunition keywords?")]
        [Tooltip("Will attempt to fix the ammunition keywords by looking at the crafting recipes")]
        public bool FixAmmoKeywords = true;

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


        [SettingName("Are the mods below a whitelist?")]
        [Tooltip("Tick to have the mods listed below be the ONLY ones considered. Leave unticked to consider every mod EXCEPT those listed below.")]
        public bool IsWhitelist = false;

        [SettingName("Mods to whitelist/blacklist")]
        [Tooltip("These mods will be ignored by the patcher")]
        public HashSet<ModKey> ListedMods = new() { ModKey.FromNameAndExtension("LegacyoftheDragonborn.esm"),
                                                    ModKey.FromNameAndExtension("DBM_RelicNotifications.esp"),
                                                    ModKey.FromNameAndExtension("Vigilant.esm"),
                                                    ModKey.FromNameAndExtension("Ordinator - Perks of Skyrim.esp")};

        [SettingName("Blacklisted weapons")]
        [Tooltip("These weapons will NOT be added into OWL leveled lists")]
        public HashSet<FormLink<IWeaponGetter>> BlacklistedWeapons = new();

        [SettingName("Blacklisted armours")]
        [Tooltip("These armours will NOT be added into OWL leveled lists")]
        public HashSet<FormLink<IArmorGetter>> BlacklistedArmours = new();

        [SettingName("Blacklisted ammunition")]
        [Tooltip("These arrows/bolts will NOT be added into OWL leveled lists")]
        public HashSet<FormLink<IAmmunitionGetter>> BlacklistedAmmo = new();
    }
}