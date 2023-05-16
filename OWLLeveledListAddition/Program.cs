using System;
using System.Collections.Generic;
using System.Linq;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.FormKeys.SkyrimSE;
using System.Threading.Tasks;
using Noggog;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Records;

namespace OWLLeveledListAddition
{

    public class Program
    {
        public static HashSet<FormKey> ArmourBlacklist { get; set; } = new()
        {
             Skyrim.Armor.ArmorAstrid.FormKey,
             Skyrim.Armor.ArmorAfflicted.FormKey,
             Skyrim.Armor.ArmorAtronachFlameDead.FormKey,
             Skyrim.Armor.ArmorAtronachFrostShield.FormKey,
             Skyrim.Armor.ArmorDragonPriestMaskBronzeHelmet.FormKey,
             Skyrim.Armor.ArmorDragonPriestMaskCorondrumHelmet.FormKey,
             Skyrim.Armor.ArmorDragonPriestMaskEbonyHelmet.FormKey,
             Skyrim.Armor.ArmorDragonPriestMaskIronHelmet.FormKey,
             Skyrim.Armor.ArmorDragonPriestMaskMarbleHelmet.FormKey,
             Skyrim.Armor.ArmorDragonPriestMaskMoonstoneHelmet.FormKey,
             Skyrim.Armor.ArmorDragonPriestMaskOrichalumHelmet.FormKey,
             Skyrim.Armor.ArmorDragonPriestMaskSteelHelmet.FormKey,
             Skyrim.Armor.ArmorDragonPriestMaskUltraHelmet.FormKey,
             Skyrim.Armor.ArmorDragonPriestMaskWoodHelmet.FormKey,
             Skyrim.Armor.dunDeepwoodBoots.FormKey,
             Skyrim.Armor.dunGauldurAmulet.FormKey,
             Skyrim.Armor.dunGauldurAmuletFragmentFolgunthur.FormKey,
             Skyrim.Armor.dunGauldurAmuletFragmentGeirmund.FormKey,
             Skyrim.Armor.dunGauldurAmuletFragmentSaarthal.FormKey,
             Skyrim.Armor.dunHunterRewardAmulet.FormKey,
             Skyrim.Armor.dunLabrynthianDraugrArmorFX.FormKey,
             Skyrim.Armor.dunLabyrinthianMazeCircletReward.FormKey,
             Skyrim.Armor.dunMistwatchRing.FormKey,
             Skyrim.Armor.dunMistwatchRingSell.FormKey,
             Skyrim.Armor.dunMovarthsBoots.FormKey,
             Skyrim.Armor.dunRatwayBrawlerGloves.FormKey,
             Skyrim.Armor.dunRRHerebanesFortress.FormKey,
             Skyrim.Armor.dunTargeOfTheBloodedShield.FormKey,
             Skyrim.Armor.dunWaywardPassGhostArmor.FormKey,
             Skyrim.Armor.dunWhiteRiverWatchGauntlets.FormKey,
             Skyrim.Armor.DA02Armor.FormKey,
             Skyrim.Armor.DA05HircinesRingCursed.FormKey,
             Skyrim.Armor.DA05HircinesRing.FormKey,
             Skyrim.Armor.DA05SaviorsHide.FormKey,
             Skyrim.Armor.DA09MeridiaBallofLightArmor.FormKey,
             Skyrim.Armor.DA11RingofNamira.FormKey,
             Skyrim.Armor.DA13Spellbreaker.FormKey,
             Skyrim.Armor.DA16VaerminaRobes.FormKey,
             Skyrim.Armor.DBArmor.FormKey,
             Skyrim.Armor.DBArmorBootsSP.FormKey,
             Skyrim.Armor.DBArmorBoots.FormKey,
             Skyrim.Armor.DBArmorBootsWorn.FormKey,
             Skyrim.Armor.DBArmorBootsWornPlayable.FormKey,
             Skyrim.Armor.DBArmorGloves.FormKey,
             Skyrim.Armor.DBArmorGlovesReward.FormKey,
             Skyrim.Armor.DBArmorGlovesSP.FormKey,
             Skyrim.Armor.DBArmorGlovesWorn.FormKey,
             Skyrim.Armor.DBArmorGlovesWornPlayable.FormKey,
             Skyrim.Armor.DBArmorHelmet.FormKey,
             Skyrim.Armor.DBArmorHelmetMaskLess.FormKey,
             Skyrim.Armor.DBArmorHelmetSP.FormKey,
             Skyrim.Armor.DBArmorHelmetWorn.FormKey,
             Skyrim.Armor.DBArmorHelmetWornPlayable.FormKey,
             Skyrim.Armor.DBArmorShortSleeve.FormKey,
             Skyrim.Armor.DBArmorSP.FormKey,
             Skyrim.Armor.DBArmorWorn.FormKey,
             Skyrim.Armor.DBArmorWornPlayable.FormKey,
             Skyrim.Armor.DBClothesHandWraps.FormKey,
             Skyrim.Armor.DBClothesHood.FormKey,
             Skyrim.Armor.DBClothesJester.FormKey,
             Skyrim.Armor.DBClothesJesterBoots.FormKey,
             Skyrim.Armor.DBClothesJesterBootsCicero.FormKey,
             Skyrim.Armor.DBClothesJesterCicero.FormKey,
             Skyrim.Armor.DBClothesJesterGloves.FormKey,
             Skyrim.Armor.DBClothesJesterGlovesCicero.FormKey,
             Skyrim.Armor.DBClothesJesterHat.FormKey,
             Skyrim.Armor.DBClothesJesterHatCicero.FormKey,
             Skyrim.Armor.DBClothesRedguardBoots.FormKey,
             Skyrim.Armor.DBClothesRedguardClothes.FormKey,
             Skyrim.Armor.DBClothesRedguardHood.FormKey,
             Skyrim.Armor.DBClothesRobes.FormKey,
             Skyrim.Armor.DBClothesShoes.FormKey,
             Skyrim.Armor.DBJeweledAmulet.FormKey,
             Skyrim.Armor.DBMuiriRing.FormKey,
             Skyrim.Armor.DBNightweaversBand.FormKey,
             Skyrim.Armor.DBSilverRing.FormKey,
             Skyrim.Armor.DBWeddingRing1.FormKey,
             Skyrim.Armor.DBWeddingRing2.FormKey,
             Skyrim.Armor.DunYngolBarrowSteelPlateHelmet.FormKey,
             Skyrim.Armor.MS02ForswornArmor.FormKey,
             Skyrim.Armor.MS02ForswornBoots.FormKey,
             Skyrim.Armor.MS02ForswornGauntlets.FormKey,
             Skyrim.Armor.MS02ForswornHelmet.FormKey,
             Skyrim.Armor.MS06ShieldL12.FormKey,
             Skyrim.Armor.MS06ShieldL18.FormKey,
             Skyrim.Armor.MS06ShieldL25.FormKey,
             Skyrim.Armor.MS06ShieldL32.FormKey,
             Skyrim.Armor.MS06ShieldL40.FormKey,
             Skyrim.Armor.PrisonerCuffs.FormKey,
             Skyrim.Armor.PrisonerCuffsPlayer.FormKey,
             Skyrim.Armor.PrisonerCuffsSolitude.FormKey,
             Skyrim.Armor.SheogorathBoots.FormKey,
             Skyrim.Armor.SheogorathOutfit.FormKey,
             Skyrim.Armor.FavorRoggiShield.FormKey,
             Skyrim.Armor.FavorOrcsGauntlets.FormKey,
             Skyrim.Armor.FavorNosterHelmet.FormKey,
             Skyrim.Armor.FavorIgmundShield.FormKey,
             Skyrim.Armor.FavorHelmofWinterhold.FormKey,
             Skyrim.Armor.FavorShahveeSymbol.FormKey,
             Skyrim.Armor.FavorWindhelmViolaRing.FormKey,
             Skyrim.Armor.FavorFridaRing.FormKey,
             Skyrim.Armor.ExecutionHoodDB.FormKey,
             Skyrim.Armor.ExecutionHood.FormKey,
             Skyrim.Armor.ElderScrollHandAttachArmor.FormKey,
             Skyrim.Armor.DummyShield.FormKey,
             Skyrim.Armor.DummyHelmet.FormKey,
             Skyrim.Armor.DummyCuirass.FormKey,
             Skyrim.Armor.DummyBoots.FormKey,
             Skyrim.Armor.ClavicusVileMask.FormKey,
             Skyrim.Armor.ArmorTsunCuirass.FormKey,
             Skyrim.Armor.ArmorTsunBoots.FormKey,
             Skyrim.Armor.ArmorThievesGuildBoots.FormKey,
             Skyrim.Armor.ArmorThievesGuildBootsPlayerImproved.FormKey,
             Skyrim.Armor.ArmorThievesGuildBootsPlayer.FormKey,
             Skyrim.Armor.ArmorThievesGuildCuirassPlayer.FormKey,
             Skyrim.Armor.ArmorThievesGuildCuirass.FormKey,
             Skyrim.Armor.ArmorThievesGuildCuirassPlayerImproved.FormKey,
             Skyrim.Armor.ArmorThievesGuildGauntlets.FormKey,
             Skyrim.Armor.ArmorThievesGuildGauntletsPlayer.FormKey,
             Skyrim.Armor.ArmorThievesGuildGauntletsPlayerImproved.FormKey,
             Skyrim.Armor.ArmorThievesGuildHelmet.FormKey,
             Skyrim.Armor.ArmorThievesGuildHelmetPlayer.FormKey,
             Skyrim.Armor.ArmorThievesGuildHelmetPlayerImproved.FormKey,
             Skyrim.Armor.ArmorThievesGuildKarliahBoots.FormKey,
             Skyrim.Armor.ArmorThievesGuildKarliahCuirass.FormKey,
             Skyrim.Armor.ArmorThievesGuildKarliahGauntlets.FormKey,
             Skyrim.Armor.ArmorThievesGuildKarliahHelmet.FormKey,
             Skyrim.Armor.ArmorThievesGuildLeaderBoots.FormKey,
             Skyrim.Armor.ArmorThievesGuildLeaderBootsMercer.FormKey,
             Skyrim.Armor.ArmorThievesGuildLeaderCuirass.FormKey,
             Skyrim.Armor.ArmorThievesGuildLeaderGauntlets.FormKey,
             Skyrim.Armor.ArmorThievesGuildLeaderGauntletsMercer.FormKey,
             Skyrim.Armor.ArmorThievesGuildLeaderHelmet.FormKey,
             Skyrim.Armor.ArmorThievesGuildVariant02Helmet.FormKey,
             Skyrim.Armor.ArmorThievesGuildVariantBoots.FormKey,
             Skyrim.Armor.ArmorThievesGuildVariantCuirass.FormKey,
             Skyrim.Armor.ArmorThievesGuildVariantGauntlets.FormKey,
             Skyrim.Armor.ArmorThievesGuildVariantHelmet.FormKey,
             Skyrim.Armor.ArmorSummersetShadowsGuildBoots.FormKey,
             Skyrim.Armor.ArmorSummersetShadowsGuildCuirass.FormKey,
             Skyrim.Armor.ArmorSummersetShadowsGuildGauntlets.FormKey,
             Skyrim.Armor.ArmorSummersetShadowsGuildHelmet.FormKey,
             Skyrim.Armor.ArmorShieldofYsgramor.FormKey,
             Skyrim.Armor.ArmorNightingaleBoots.FormKey,
             Skyrim.Armor.ArmorNightingaleBootsPlayer01.FormKey,
             Skyrim.Armor.ArmorNightingaleBootsPlayer02.FormKey,
             Skyrim.Armor.ArmorNightingaleBootsPlayer03.FormKey,
             Skyrim.Armor.ArmorNightingaleCuirass.FormKey,
             Skyrim.Armor.ArmorNightingaleCuirassPlayer01.FormKey,
             Skyrim.Armor.ArmorNightingaleCuirassPlayer02.FormKey,
             Skyrim.Armor.ArmorNightingaleCuirassPlayer03.FormKey,
             Skyrim.Armor.ArmorNightingaleGauntlets.FormKey,
             Skyrim.Armor.ArmorNightingaleGauntletsPlayer01.FormKey,
             Skyrim.Armor.ArmorNightingaleGauntletsPlayer02.FormKey,
             Skyrim.Armor.ArmorNightingaleGauntletsPlayer03.FormKey,
             Skyrim.Armor.ArmorNightingaleHelmet.FormKey,
             Skyrim.Armor.ArmorNightingaleHelmetPlayer01.FormKey,
             Skyrim.Armor.ArmorNightingaleHelmetPlayer02.FormKey,
             Skyrim.Armor.ArmorNightingaleHelmetPlayer03.FormKey,
             Skyrim.Armor.ArmorLinweBoots.FormKey,
             Skyrim.Armor.ArmorLinweCuirass.FormKey,
             Skyrim.Armor.ArmorLinweGauntlets.FormKey,
             Skyrim.Armor.ArmorLinweHelmet.FormKey,
             Skyrim.Armor.ArmorManakin.FormKey,
             Skyrim.Armor.ArmorGag.FormKey,
             Skyrim.Armor.TG00MadesiRing.FormKey
        };

        public static HashSet<FormKey> WeaponBlacklist { get; set; } = new()
        {
            Skyrim.Weapon.FavorAmrenIronSword.FormKey,
            Skyrim.Weapon.FavorGhorbashAxe.FormKey,
            Skyrim.Weapon.FavorNelacarStaffFear.FormKey,
            Skyrim.Weapon.FavorOengulSword.FormKey,
            Skyrim.Weapon.dunAngisBow.FormKey,
            Skyrim.Weapon.dunAnsilvundGhostblade.FormKey,
            Skyrim.Weapon.dunBlindCliffStaffReward.FormKey,
            Skyrim.Weapon.dunBloatedMansKatana.FormKey,
            Skyrim.Weapon.dunBluePalaceWabbajack.FormKey,
            Skyrim.Weapon.dunClearspringTarnBowOfHunt.FormKey,
            Skyrim.Weapon.dunCrystalDriftCaveStaff.FormKey,
            Skyrim.Weapon.dunDarklightSilviaStaff.FormKey,
            Skyrim.Weapon.dunFolgunthurMikrulSword02.FormKey,
            Skyrim.Weapon.dunFolgunthurMikrulSword03.FormKey,
            Skyrim.Weapon.dunFolgunthurMikrulSword04.FormKey,
            Skyrim.Weapon.dunFolgunthurMikrulSword05.FormKey,
            Skyrim.Weapon.dunFolgunthurMikrulSword06.FormKey,
            Skyrim.Weapon.dunFrostmereCryptPaleBlade01.FormKey,
            Skyrim.Weapon.dunFrostmereCryptPaleBlade02.FormKey,
            Skyrim.Weapon.dunFrostmereCryptPaleBlade03.FormKey,
            Skyrim.Weapon.dunFrostmereCryptPaleBlade04.FormKey,
            Skyrim.Weapon.dunFrostmereCryptPaleBlade05.FormKey,
            Skyrim.Weapon.dunGeirmundSigdisBow02.FormKey,
            Skyrim.Weapon.dunGeirmundSigdisBow03.FormKey,
            Skyrim.Weapon.dunGeirmundSigdisBow04.FormKey,
            Skyrim.Weapon.dunGeirmundSigdisBow05.FormKey,
            Skyrim.Weapon.dunGeirmundSigdisBow06.FormKey,
            Skyrim.Weapon.dunGeirmundSigdisBowIllusion.FormKey,
            Skyrim.Weapon.dunHagsEndDagger.FormKey,
            Skyrim.Weapon.dunHalldirsCairnHalldirsStaff.FormKey,
            Skyrim.Weapon.dunHaltedStreamPoachersAxe.FormKey,
            Skyrim.Weapon.dunHuntersBow.FormKey,
            Skyrim.Weapon.dunKatariahScimitar.FormKey,
            Skyrim.Weapon.dunLiarsRetreatLonghammer.FormKey,
            Skyrim.Weapon.dunLostValleyRedoubtAxe.FormKey,
            Skyrim.Weapon.dunMarkarthWizardSpiderControlStaff.FormKey,
            Skyrim.Weapon.dunMarkarthWizardSpiderControlStaffFake.FormKey,
            Skyrim.Weapon.dunMossMotherValdrDagger.FormKey,
            Skyrim.Weapon.dunPinewoodGroveWoodsmansFriend.FormKey,
            Skyrim.Weapon.dunPOITrollsbane.FormKey,
            Skyrim.Weapon.dunRannveigSildsStaff.FormKey,
            Skyrim.Weapon.dunRedEagleSwordBase.FormKey,
            Skyrim.Weapon.dunRedEagleSwordUpgraded.FormKey,
            Skyrim.Weapon.dunRRHerebanesCourage.FormKey,
            Skyrim.Weapon.dunSaarthalStaffJyrikStaff.FormKey,
            Skyrim.Weapon.dunSilentMoonsEnchIronMace01.FormKey,
            Skyrim.Weapon.dunSilentMoonsEnchIronMace02.FormKey,
            Skyrim.Weapon.dunSilentMoonsEnchIronMace03.FormKey,
            Skyrim.Weapon.dunSilentMoonsEnchIronSword01.FormKey,
            Skyrim.Weapon.dunSilentMoonsEnchIronSword02.FormKey,
            Skyrim.Weapon.dunSilentMoonsEnchIronWarAxe01.FormKey,
            Skyrim.Weapon.dunSilentMoonsEnchIronSword03.FormKey,
            Skyrim.Weapon.dunSilentMoonsEnchIronWarAxe02.FormKey,
            Skyrim.Weapon.dunSilentMoonsEnchIronWarAxe03.FormKey,
            Skyrim.Weapon.dunSilentMoonsEnchSteelMace01.FormKey,
            Skyrim.Weapon.dunSilentMoonsEnchSteelMace02.FormKey,
            Skyrim.Weapon.dunSilentMoonsEnchSteelMace03.FormKey,
            Skyrim.Weapon.dunSilentMoonsEnchSteelSword01.FormKey,
            Skyrim.Weapon.dunSilentMoonsEnchSteelSword02.FormKey,
            Skyrim.Weapon.dunSilentMoonsEnchSteelSword03.FormKey,
            Skyrim.Weapon.dunSilentMoonsEnchSteelWarAxe01.FormKey,
            Skyrim.Weapon.dunSilentMoonsEnchSteelWarAxe02.FormKey,
            Skyrim.Weapon.dunSilentMoonsEnchSteelWarAxe03.FormKey,
            Skyrim.Weapon.dunValthumeDragonPriestStaff.FormKey,
            Skyrim.Weapon.dunVolunruudOkin.FormKey,
            Skyrim.Weapon.dunVolunruudEduj.FormKey,
            Skyrim.Weapon.dunVolunruudPickaxe.FormKey,
            Skyrim.Weapon.dunVolunruudRelic02.FormKey,
            Skyrim.Weapon.dunVolunruudRelic01.FormKey,
            Skyrim.Weapon.DB05ElvenBow.FormKey,
            Skyrim.Weapon.DBAlainAegisbane.FormKey,
            Skyrim.Weapon.DBBladeOfWoeAstrid.FormKey,
            Skyrim.Weapon.DBBladeOfWoeReward.FormKey,
            Skyrim.Weapon.DA02Dagger.FormKey,
            Skyrim.Weapon.DA03RuefulAxe.FormKey,
            Skyrim.Weapon.DA06GiantClub.FormKey,
            Skyrim.Weapon.DA06Hammer.FormKey,
            Skyrim.Weapon.DA06Volendrung.FormKey,
            Skyrim.Weapon.DA07MehrunesRazor.FormKey,
            Skyrim.Weapon.DA08EbonyBlade.FormKey,
            Skyrim.Weapon.DA08RealEbonyBlade.FormKey,
            Skyrim.Weapon.DA09Dawnbreaker.FormKey,
            Skyrim.Weapon.DA10MaceofMolagBal.FormKey,
            Skyrim.Weapon.DA10RustyMace.FormKey,
            Skyrim.Weapon.DA14BrokenRose.FormKey,
            Skyrim.Weapon.DA14DremoraGreatswordFire03.FormKey,
            Skyrim.Weapon.DA14SanguineRose.FormKey,
            Skyrim.Weapon.DA15Wabbajack.FormKey,
            Skyrim.Weapon.DA16SkullofCorruption.FormKey,
            Skyrim.Weapon.MG07DraugrMagicAxe.FormKey,
            Skyrim.Weapon.MG07DraugrMagicBow.FormKey,
            Skyrim.Weapon.MG07DraugrMagicSword.FormKey,
            Skyrim.Weapon.MG07StaffofMagnus.FormKey,
            Skyrim.Weapon.MGRArniel02Staff.FormKey,
            Skyrim.Weapon.MGRitual05Dagger.FormKey,
            Skyrim.Weapon.MGRKeening.FormKey,
            Skyrim.Weapon.MGRKeeningNonPlayable.FormKey,
            Skyrim.Weapon.MQ105PhantomSword.FormKey,
            Skyrim.Weapon.MQ203AkaviriKatana1.FormKey,
            Skyrim.Weapon.MQ203AkaviriKatana2.FormKey,
            Skyrim.Weapon.MQ203AkaviriKatana3.FormKey,
            Skyrim.Weapon.MQ203AkaviriKatana4.FormKey,
            Skyrim.Weapon.MQ203AkaviriKatana5.FormKey,
            Skyrim.Weapon.MQ303DragonPriestStaff.FormKey,
            Skyrim.Weapon.MQ304DraugrBattleAxeTsun01.FormKey,
            Skyrim.Weapon.MQ304DraugrBattleAxeTsun02.FormKey,
            Skyrim.Weapon.MQ304DraugrBattleAxeTsun03.FormKey,
            Skyrim.Weapon.MQ304DraugrBattleAxeTsun04.FormKey,
            Skyrim.Weapon.MS02Shiv.FormKey,
            Skyrim.Weapon.MS06Staff.FormKey,
            Skyrim.Weapon.POIMageBorvirsDagger.FormKey,
            Skyrim.Weapon.POIMageRundisDagger.FormKey,
            Skyrim.Weapon.T03Nettlebane.FormKey,
            Skyrim.Weapon.TG07Chillrend001.FormKey,
            Skyrim.Weapon.TG07Chillrend002.FormKey,
            Skyrim.Weapon.TG07Chillrend003.FormKey,
            Skyrim.Weapon.TG07Chillrend004.FormKey,
            Skyrim.Weapon.TG07Chillrend005.FormKey,
            Skyrim.Weapon.TG07Chillrend006.FormKey,
            Skyrim.Weapon.SSDRocksplinterPickaxe.FormKey,
            Skyrim.Weapon.C06BladeOfYsgramor.FormKey,
            Skyrim.Weapon.C00GiantClub.FormKey,
            Skyrim.Weapon.NightingaleBlade01.FormKey,
            Skyrim.Weapon.NightingaleBlade02.FormKey,
            Skyrim.Weapon.NightingaleBlade03.FormKey,
            Skyrim.Weapon.NightingaleBlade04.FormKey,
            Skyrim.Weapon.NightingaleBlade05.FormKey,
            Skyrim.Weapon.NightingaleBladeNPC.FormKey,
            Skyrim.Weapon.NightingaleBow01.FormKey,
            Skyrim.Weapon.NightingaleBow02.FormKey,
            Skyrim.Weapon.NightingaleBow03.FormKey,
            Skyrim.Weapon.NightingaleBow04.FormKey,
            Skyrim.Weapon.NightingaleBow05.FormKey,
            Skyrim.Weapon.NightingaleBowNPC.FormKey,
            Dawnguard.Weapon.DLC1AkaviriSword.FormKey,
            Dawnguard.Weapon.DLC1AurielsBow.FormKey,
            Dawnguard.Weapon.DLC1FrostGiantClub.FormKey,
            Dawnguard.Weapon.DLC1HarkonsSword.FormKey,
            Dawnguard.Weapon.DLC1LD_AetherialStaff.FormKey,
            Dawnguard.Weapon.DLC1LD_AetheriumCrestNP.FormKey,
            Dawnguard.Weapon.DLC1LD_KatriaBow.FormKey,
            Dawnguard.Weapon.DLC1LD_KatriaBowNP.FormKey,
            Dawnguard.Weapon.DLC1LD_SkyforgeSteelDaggerNP.FormKey,
            Dawnguard.Weapon.DLC1PrelateDagger.FormKey,
            Dawnguard.Weapon.DLC1PrelateMace.FormKey,
            Dawnguard.Weapon.DLC1RuunvaldStaff.FormKey,
            Dragonborn.Weapon.dlc2MerchBowOfTheStagPrince.FormKey,
            Dragonborn.Weapon.DLC2BloodskalBlade.FormKey,
            Dragonborn.Weapon.DLC2dunBrodirGroveStormfang.FormKey,
            Dragonborn.Weapon.DLC2dunHaknirScimitar01.FormKey,
            Dragonborn.Weapon.DLC2dunHaknirScimitar01NP.FormKey,
            Dragonborn.Weapon.DLC2dunHaknirScimitar02.FormKey,
            Dragonborn.Weapon.DLC2dunHaknirScimitar02NP.FormKey,
            Dragonborn.Weapon.DLC2dunKolbjornRalisPickaxe.FormKey,
            Dragonborn.Weapon.DLC2Horksbane.FormKey,
            Dragonborn.Weapon.DLC2RR01FalxWarhammer.FormKey,
            Dragonborn.Weapon.DLC2RR03NordPickaxe.FormKey,
            Dragonborn.Weapon.DLC2MKMiraakFightStaff1.FormKey,
            Dragonborn.Weapon.DLC2MKMiraakFightStaff2.FormKey,
            Dragonborn.Weapon.DLC2MKMiraakFightStaff3.FormKey,
            Dragonborn.Weapon.DLC2MKMiraakFightStaff4.FormKey,
            Dragonborn.Weapon.DLC2MKMiraakFightStaff5.FormKey,
            Dragonborn.Weapon.DLC2MKMiraakFightStaff6.FormKey,
            Dragonborn.Weapon.DLC2MKMiraakFightSword1.FormKey,
            Dragonborn.Weapon.DLC2MKMiraakFightSword2.FormKey,
            Dragonborn.Weapon.DLC2MKMiraakFightSword3.FormKey,
            Dragonborn.Weapon.DLC2MKMiraakFightSword4.FormKey,
            Dragonborn.Weapon.DLC2MKMiraakFightSword5.FormKey,
            Dragonborn.Weapon.DLC2MKMiraakFightSword6.FormKey,
            Dragonborn.Weapon.DLC2MKMiraakStaff1.FormKey,
            Dragonborn.Weapon.DLC2MKMiraakStaff2.FormKey,
            Dragonborn.Weapon.DLC2MKMiraakStaff3.FormKey,
            Dragonborn.Weapon.DLC2MKMiraakSword1.FormKey,
            Dragonborn.Weapon.DLC2MKMiraakSword2.FormKey,
            Dragonborn.Weapon.DLC2MKMiraakSword3.FormKey,
            Dragonborn.Weapon.DLC2MiraakStaff.FormKey,
            Dragonborn.Weapon.DLC2KagrumezFateBow01.FormKey
        };

        public static Lazy<Settings> _settings = null!;
        public static Settings Settings => _settings.Value;

        public static async Task<int> Main(string[] args)
        {
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetAutogeneratedSettings("Settings", "settings.json", out _settings)
                .SetTypicalOpen(GameRelease.SkyrimSE, "SynOWLLeveledListsAdditions.esp")
                .Run(args);
        }

        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            static LeveledItemEntry CreateNewLvlEntry(IMajorRecordGetter item, short count, short level)
            {
                LeveledItemEntry entry = new()
                {
                    Data = new()
                    {
                        Count = count,
                        Level = level,
                        Reference = new FormLink<IWeaponGetter>(item.FormKey)
                    }
                };

                return entry;
            }

            static string GetSpecialTypeFromKeywords(IWeaponGetter wpn)
            {
                string type = "";

                if (wpn.HasKeyword(Skyrim.Keyword.WeapTypeDagger)
                    || wpn.HasKeyword(Skyrim.Keyword.WeapTypeSword)
                    || wpn.HasKeyword(Skyrim.Keyword.WeapTypeMace)
                    || wpn.HasKeyword(Skyrim.Keyword.WeapTypeWarAxe))
                {
                    type = "1H";
                }
                else if (wpn.HasKeyword(Skyrim.Keyword.WeapTypeWarhammer)
                        || wpn.HasKeyword(Skyrim.Keyword.WeapTypeBattleaxe)
                        || wpn.HasKeyword(Skyrim.Keyword.WeapTypeGreatsword))
                {
                    type = "2H";
                }
                else if (wpn.HasKeyword(Skyrim.Keyword.WeapTypeBow))
                {
                    type = "Bow";
                }
                else if (wpn.HasKeyword(Dawnguard.Keyword.WeapDwarvenCrossbow) 
                            || (wpn.Data is not null && wpn.Data.AnimationType.Equals(WeaponAnimationType.Crossbow)))
                {
                    type = "Crossbow";
                }
                
                return type;
            }

            static FormLink<IKeywordGetter> GetKeywordFromMaterial(FormKey material)
            {
                FormLink<IKeywordGetter> k = new();
                if(material.Equals(Skyrim.MiscItem.IngotCorundum.FormKey))
                {
                    k = Skyrim.Keyword.WeapMaterialSteel;
                }
                else if (material.Equals(Skyrim.MiscItem.IngotDwarven.FormKey))
                {
                    k = Skyrim.Keyword.WeapMaterialDwarven;
                }
                else if (material.Equals(Skyrim.MiscItem.IngotEbony.FormKey))
                {
                    k = Skyrim.Keyword.WeapMaterialEbony;
                }
                else if (material.Equals(Skyrim.MiscItem.IngotIMoonstone.FormKey) || material.Equals(Skyrim.MiscItem.IngotQuicksilver.FormKey))
                {
                    k = Skyrim.Keyword.WeapMaterialElven;
                }
                else if (material.Equals(Skyrim.MiscItem.IngotMalachite.FormKey))
                {
                    k = Skyrim.Keyword.WeapMaterialGlass;
                }
                else if (material.Equals(Skyrim.MiscItem.IngotIron.FormKey))
                {
                    k = Skyrim.Keyword.WeapMaterialIron;
                }
                else if (material.Equals(Skyrim.MiscItem.IngotOrichalcum.FormKey))
                {
                    k = Skyrim.Keyword.WeapMaterialOrcish;
                }
                else if (material.Equals(Skyrim.MiscItem.IngotSteel.FormKey))
                {
                    k = Skyrim.Keyword.WeapMaterialSteel;
                }
                else if (material.Equals(Skyrim.MiscItem.ingotSilver.FormKey))
                {
                    k = Skyrim.Keyword.WeapMaterialSilver;
                }
                else if (material.Equals(Dragonborn.MiscItem.DLC2OreStalhrim.FormKey))
                {
                    k = Dragonborn.Keyword.DLC2WeaponMaterialStalhrim;
                }
                else if (material.Equals(Skyrim.Ingredient.DaedraHeart))
                {
                    k = Skyrim.Keyword.WeapMaterialDaedric;
                }
                else
                {
                    //k = Dragonborn.Keyword.DLC2WeaponMaterialNordic;
                }
                return k;
            }

            // Get OWL main
            if (!state.LoadOrder.TryGetValue("Open World Loot.esp", out var OWL))
            {
                System.Console.WriteLine("'Open World Loot.esp' not found");
                return;
            }

            System.Console.WriteLine("'Open World Loot.esp' found");

            // check if Legacy of the Dragonborn is there
            if (state.LoadOrder.TryGetValue("LegacyoftheDragonborn.esm", out var DBM))
            {
                System.Console.WriteLine("Legacy of the dragonborn was found! It will be ignored!");
            }


            // Initialise the blacklists
            foreach (var weapon in Settings.BlacklistedWeapons)
            {
                WeaponBlacklist.Add(weapon.FormKey);
            }
            foreach (var armour in Settings.BlacklistedArmours)
            {
                ArmourBlacklist.Add(armour.FormKey);
            }

            // Vanilla mods
            HashSet<ModKey> vanillaMods = new() {
                Skyrim.ModKey,
                Update.ModKey,
                Dawnguard.ModKey,
                HearthFires.ModKey,
                Dragonborn.ModKey
            };

            // Weapon material keywords
            HashSet<IFormLinkGetter<IKeywordGetter>> weaponMaterialKeywords = new()
            {
                Skyrim.Keyword.WeapMaterialIron,
                Skyrim.Keyword.WeapMaterialSteel,
                Skyrim.Keyword.WeapMaterialOrcish,
                Skyrim.Keyword.WeapMaterialDwarven,
                Skyrim.Keyword.WeapMaterialElven,
                Skyrim.Keyword.WeapMaterialGlass,
                Skyrim.Keyword.WeapMaterialEbony,
                Skyrim.Keyword.WeapMaterialDaedric,
                Skyrim.Keyword.WeapMaterialImperial,
                Skyrim.Keyword.WeapMaterialSilver,
                Skyrim.Keyword.WeapMaterialFalmer,
                Skyrim.Keyword.WeapMaterialDraugrHoned,
                Skyrim.Keyword.WeapMaterialDraugr,
                Skyrim.Keyword.WeapMaterialSilver,
                Dawnguard.Keyword.DLC1WeapMaterialDragonbone,
                Dragonborn.Keyword.DLC2WeaponMaterialNordic,
                Dragonborn.Keyword.DLC2WeaponMaterialStalhrim
                //Dragonborn.Keyword.WeapMaterialForsworn,
            };

            // Weapon type keywords
            HashSet<IFormLinkGetter<IKeywordGetter>> weaponTypeKeywords = new()
            {
                Skyrim.Keyword.WeapTypeDagger,
                Skyrim.Keyword.WeapTypeSword,
                Skyrim.Keyword.WeapTypeMace,
                Skyrim.Keyword.WeapTypeWarAxe,
                Skyrim.Keyword.WeapTypeBow,
                Skyrim.Keyword.WeapTypeWarhammer,
                Skyrim.Keyword.WeapTypeBattleaxe,
                Skyrim.Keyword.WeapTypeGreatsword,
                Skyrim.Keyword.VendorItemArrow
            };

            // Armour material keywords
            HashSet<IFormLinkGetter<IKeywordGetter>> armourMaterialKeywords = new()
            {
                Skyrim.Keyword.ArmorMaterialIron,
                Skyrim.Keyword.ArmorMaterialSteel,
                Skyrim.Keyword.ArmorMaterialSteelPlate,
                Skyrim.Keyword.ArmorMaterialOrcish,
                Skyrim.Keyword.ArmorMaterialDwarven,
                Skyrim.Keyword.ArmorMaterialElven,
                Skyrim.Keyword.ArmorMaterialElvenGilded,
                Skyrim.Keyword.ArmorMaterialGlass,
                Skyrim.Keyword.ArmorMaterialEbony,
                Skyrim.Keyword.WeapMaterialFalmer,
                Skyrim.Keyword.ArmorMaterialHide,
                Skyrim.Keyword.ArmorMaterialLeather,
                Skyrim.Keyword.ArmorMaterialScaled,
                Skyrim.Keyword.ArmorMaterialDaedric,
                Skyrim.Keyword.ArmorMaterialDragonplate,
                Skyrim.Keyword.ArmorMaterialDragonscale,
                Skyrim.Keyword.ArmorMaterialImperialHeavy,
                Skyrim.Keyword.ArmorMaterialImperialStudded,
                Skyrim.Keyword.ArmorMaterialImperialLight,
                Skyrim.Keyword.ArmorMaterialIronBanded,
                Skyrim.Keyword.ArmorMaterialStormcloak,
                Update.Keyword.ArmorMaterialBearStormcloak,
                Update.Keyword.ArmorMaterialBlades,
                Update.Keyword.ArmorMaterialFalmer,
                Update.Keyword.ArmorMaterialForsworn,
                Update.Keyword.ArmorMaterialForsworn,
                Update.Keyword.ArmorMaterialPenitus,
                Update.Keyword.ArmorMaterialThievesGuild,
                Update.Keyword.ArmorMaterialThievesGuildLeader,
                Dragonborn.Keyword.DLC2ArmorMaterialNordicHeavy,
                Dragonborn.Keyword.DLC2ArmorMaterialNordicLight,
                Dragonborn.Keyword.DLC2ArmorMaterialStalhrimHeavy,
                Dragonborn.Keyword.DLC2ArmorMaterialStalhrimLight,
                Dragonborn.Keyword.DLC2ArmorMaterialChitinHeavy,
                Dragonborn.Keyword.DLC2ArmorMaterialChitinLight,
                Dragonborn.Keyword.DLC2ArmorMaterialBonemoldHeavy,
                Dragonborn.Keyword.DLC2ArmorMaterialBonemoldLight
            };

            // Armour type keywords
            HashSet<IFormLinkGetter<IKeywordGetter>> armourTypeKeywords = new()
            {
                Skyrim.Keyword.ArmorBoots,
                Skyrim.Keyword.ArmorCuirass,
                Skyrim.Keyword.ArmorShield,
                Skyrim.Keyword.ArmorGauntlets,
                Skyrim.Keyword.ArmorHelmet
            };

            // Counters
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;

            System.Console.WriteLine("Starting Patching!");

            // Create a mod-independent list of entries to add to the OWL lists
            Dictionary<string, HashSet<LeveledItemEntry>> leveledItemsToAdd = new();

            // Create a mod-dependent list of entries to add to the OWL lists
            Dictionary<Tuple<ModKey, string>, HashSet<LeveledItemEntry>> leveledItemsToAddPerMod = new();


            // Weapons needing special treatment
            HashSet<LeveledItemEntry> falmerWeapons = new();
            HashSet<LeveledItemEntry> woodWeapons = new();

            // Ignore vanilla
            var loadorder = state.LoadOrder.PriorityOrder;
            if (Settings.IgnoreVanilla)
            {
                loadorder = state.LoadOrder.PriorityOrder.Where(x => !vanillaMods.Contains(x.ModKey));
            }

            // Ignore blacklisted mods
            if(Settings.BlacklistedMods.Count > 0)
            {
                loadorder = loadorder.Where(x => !Settings.BlacklistedMods.Contains(x.ModKey));
            }


            // Ammunition
            if(Settings.FixAmmoKeywords)
            {
                System.Console.WriteLine("Attempting to fix ammunition keywords...");
                foreach (var ammoRecipeGetter in loadorder.WinningOverrides<IConstructibleObjectGetter>())
                {
                    // Ignore null
                    if (ammoRecipeGetter.Items is null) continue;

                    // Ignore items that are not ammunition
                    var ammo = ammoRecipeGetter.CreatedObject.TryResolve<IAmmunitionGetter>(state.LinkCache);
                    if (ammo is null) continue;


                    HashSet<IKeywordGetter> keywords = new();
                    IKeywordGetter? winningKeyword = null;

                    // Dawnguard
                    if (ammo.EditorID is not null && ammo.EditorID.Contains("dawnguard", StringComparison.OrdinalIgnoreCase))
                    {
                        winningKeyword = Dawnguard.Keyword.DLC1DawnguardItem.Resolve(state.LinkCache);
                    }
                    // Nordic
                    else if (ammo.EditorID is not null && ammo.EditorID.Contains("nordic", StringComparison.OrdinalIgnoreCase))
                    {
                        winningKeyword = Dragonborn.Keyword.DLC2WeaponMaterialNordic.Resolve(state.LinkCache);
                    }
                    // Imperial
                    else if (ammo.EditorID is not null && ammo.EditorID.Contains("imperial", StringComparison.OrdinalIgnoreCase))
                    {
                        winningKeyword = Skyrim.Keyword.WeapMaterialImperial.Resolve(state.LinkCache);
                    }
                    // For all the rest, look into the materials for ingots
                    else
                    {
                        // For each item needed to craft
                        foreach (var item in ammoRecipeGetter.Items)
                        {
                            if(item.Item.Item is not null)
                            {
                                FormLink<IKeywordGetter> k = GetKeywordFromMaterial(item.Item.Item.FormKey);
                                var keyword = k.TryResolve(state.LinkCache);
                                if (keyword is null) continue;

                                keywords.Add(keyword);
                            }
                        }

                        // Ignore if there are no materials
                        if (keywords.Count == 0) continue;

                        winningKeyword = keywords.First();

                        // If there are many keywords found... 
                        if (keywords.Count > 1)
                        {
                            // Get the strongest weapon material
                            if (keywords.Contains(Dawnguard.Keyword.DLC1WeapMaterialDragonbone.Resolve(state.LinkCache))) 
                                winningKeyword = Dawnguard.Keyword.DLC1WeapMaterialDragonbone.Resolve(state.LinkCache);
                            else if (keywords.Contains(Skyrim.Keyword.WeapMaterialDaedric.Resolve(state.LinkCache))) 
                                winningKeyword = Skyrim.Keyword.WeapMaterialDaedric.Resolve(state.LinkCache);
                            else if (keywords.Contains(Dragonborn.Keyword.DLC2WeaponMaterialStalhrim.Resolve(state.LinkCache))) 
                                winningKeyword = Dragonborn.Keyword.DLC2WeaponMaterialStalhrim.Resolve(state.LinkCache);
                            else if (keywords.Contains(Skyrim.Keyword.WeapMaterialEbony.Resolve(state.LinkCache))) 
                                winningKeyword = Skyrim.Keyword.WeapMaterialEbony.Resolve(state.LinkCache);
                            else if (keywords.Contains(Skyrim.Keyword.WeapMaterialGlass.Resolve(state.LinkCache))) 
                                winningKeyword = Skyrim.Keyword.WeapMaterialGlass.Resolve(state.LinkCache);
                            else if (keywords.Contains(Dragonborn.Keyword.DLC2WeaponMaterialNordic.Resolve(state.LinkCache))) 
                                winningKeyword = Dragonborn.Keyword.DLC2WeaponMaterialNordic.Resolve(state.LinkCache);
                            else if (keywords.Contains(Skyrim.Keyword.WeapMaterialOrcish.Resolve(state.LinkCache))) 
                                winningKeyword = Skyrim.Keyword.WeapMaterialOrcish.Resolve(state.LinkCache);
                            else if (keywords.Contains(Skyrim.Keyword.WeapMaterialElven.Resolve(state.LinkCache))) 
                                winningKeyword = Skyrim.Keyword.WeapMaterialElven.Resolve(state.LinkCache);
                            else if (keywords.Contains(Skyrim.Keyword.WeapMaterialDwarven.Resolve(state.LinkCache))) 
                                winningKeyword = Skyrim.Keyword.WeapMaterialDwarven.Resolve(state.LinkCache);
                            else if (keywords.Contains(Skyrim.Keyword.WeapMaterialImperial.Resolve(state.LinkCache))) 
                                winningKeyword = Skyrim.Keyword.WeapMaterialImperial.Resolve(state.LinkCache);
                            else if (keywords.Contains(Skyrim.Keyword.WeapMaterialSilver.Resolve(state.LinkCache))) 
                                winningKeyword = Skyrim.Keyword.WeapMaterialSilver.Resolve(state.LinkCache);
                            else if (keywords.Contains(Skyrim.Keyword.WeapMaterialSteel.Resolve(state.LinkCache))) 
                                winningKeyword = Skyrim.Keyword.WeapMaterialSteel.Resolve(state.LinkCache);
                            else if (keywords.Contains(Skyrim.Keyword.WeapMaterialDraugrHoned.Resolve(state.LinkCache))) 
                                winningKeyword = Skyrim.Keyword.WeapMaterialDraugrHoned.Resolve(state.LinkCache);
                            else if (keywords.Contains(Skyrim.Keyword.WeapMaterialIron.Resolve(state.LinkCache))) 
                                winningKeyword = Skyrim.Keyword.WeapMaterialIron.Resolve(state.LinkCache);
                            else if (keywords.Contains(Skyrim.Keyword.WeapMaterialFalmer.Resolve(state.LinkCache))) 
                                winningKeyword = Skyrim.Keyword.WeapMaterialFalmer.Resolve(state.LinkCache);
                            else if (keywords.Contains(Skyrim.Keyword.WeapMaterialDraugr.Resolve(state.LinkCache))) 
                                winningKeyword = Skyrim.Keyword.WeapMaterialDraugr.Resolve(state.LinkCache);
                        }
                    }

                    

                    // Add the keyword to the ammunition if it doesn't have it already
                    if(!ammo.HasKeyword(winningKeyword))
                    {
                        var v = state.PatchMod.Ammunitions.GetOrAddAsOverride(ammo);

                        // Add the new keyword
                        v.Keywords ??= new();
                        v.Keywords.Add(winningKeyword);
                    }
                }
                System.Console.WriteLine("Done fixing ammunition!");
            }

            if (Settings.DoAmmo)
            {
                System.Console.WriteLine("Searching for ammunition...");
                foreach (var ammoGetter in loadorder.WinningOverrides<IAmmunitionGetter>())
                {
                    // Ignore no keywords
                    if (ammoGetter.Keywords is null) continue;

                    // Ignore enchanted
                    if (ammoGetter.Description is not null) continue;

                    // Ignore Legacy of the dragonborn items
                    if (DBM is not null && ammoGetter.FormKey.ModKey.Equals(DBM.ModKey)) continue;

                    // Ignore vanilla
                    if (Settings.IgnoreVanilla && vanillaMods.Contains(ammoGetter.FormKey.ModKey)) continue;

                    // Ignore the blacklisted mods
                    if (Settings.BlacklistedMods.Contains(ammoGetter.FormKey.ModKey)) continue;


                    string material = "";
                    string type = "";

                    // Dawnguard
                    if (ammoGetter.HasKeyword(Dawnguard.Keyword.DLC1DawnguardItem))
                    {
                        material = "Dawnguard";
                    }
                    // Silver
                    else if (ammoGetter.HasKeyword(Skyrim.Keyword.WeapMaterialSilver))
                    {
                        material = "Silver";
                    }
                    // Draugr 
                    else if (ammoGetter.HasKeyword(Skyrim.Keyword.WeapMaterialDraugr))
                    {
                        material = "Draugr";
                    }
                    // Draugr Honed
                    else if (ammoGetter.HasKeyword(Skyrim.Keyword.WeapMaterialDraugrHoned))
                    {
                        material = "DraugrNordHero";
                    }
                    // Forsworn
                    else if (ammoGetter.EditorID is not null && ammoGetter.EditorID.Contains("forsworn", StringComparison.OrdinalIgnoreCase))
                    {
                        material = "Forsworn";
                    }
                    // Nordic
                    else if (ammoGetter.EditorID is not null && ammoGetter.EditorID.Contains("nordic", StringComparison.OrdinalIgnoreCase))
                    {
                        material = "Nordic";
                    }
                    // Imperial
                    else if (ammoGetter.HasKeyword(Skyrim.Keyword.WeapMaterialImperial)
                        || (ammoGetter.EditorID is not null && ammoGetter.EditorID.Contains("imperial", StringComparison.OrdinalIgnoreCase)))
                    {
                        material = "Imperial";
                    }
                    // Falmer
                    else if (ammoGetter.HasKeyword(Skyrim.Keyword.WeapMaterialFalmer) || ammoGetter.HasKeyword(Skyrim.Keyword.WeapMaterialFalmerHoned))
                    {
                        material = "Falmer";
                    }

                    else
                    {
                        // Search all keywords
                        foreach (var keyword in ammoGetter.Keywords)
                        {
                            if (weaponMaterialKeywords.Contains(keyword))
                            {
                                var kw = keyword.TryResolve(state.LinkCache);
                                if (kw is null || kw.EditorID is null) continue;

                                material = kw.EditorID.Replace("DLC2WeaponMaterial", "").Replace("DLC1WeapMaterial", "").Replace("WeapMaterial", "");
                            }
                        }

                    }

                    // Ammo type
                    if (ammoGetter.HasKeyword(Skyrim.Keyword.VendorItemArrow) && !ammoGetter.Flags.HasFlag(Ammunition.Flag.NonBolt))
                    {
                        type = "Bolt";
                    }
                    else if (ammoGetter.HasKeyword(Skyrim.Keyword.VendorItemArrow))
                    {
                        type = "Arrow";
                    }

                    // Ignore if either the material or the type is null
                    if (material == "" || type == "")
                    {
                        if (Settings.Debug)
                            System.Console.WriteLine("> keywords not found: " + material + "/" + type);
                        continue;
                    }

                    if (Settings.Debug)
                        System.Console.WriteLine("> keywords found ");

                    // Form the keys for the dictionaries
                    string key = material + "_" + type;
                    var tuple = new Tuple<ModKey, string>(ammoGetter.FormKey.ModKey, key.ToLower());

                    // Create a new leveled item entry
                    LeveledItemEntry ammoEntry = CreateNewLvlEntry(ammoGetter, 1, 1);

                    // Add the entry also to the mod-independent dictionary
                    leveledItemsToAdd.TryGetValue(key.ToLower(), out var hash);
                    // If it does not exist yet, add it
                    if (hash is null)
                    {
                        leveledItemsToAdd.TryAdd(key.ToLower(), new HashSet<LeveledItemEntry>() { ammoEntry });
                    }
                    // Otherwise, just add it to the existing one
                    else
                    {
                        hash.Add(ammoEntry);
                    }

                    count1++;
                }
                System.Console.WriteLine("Ammunition is done!");
            }



            /// Iterate on all weapons
            System.Console.WriteLine("Searching for weapons...");
            foreach (var weaponGetter in loadorder.WinningOverrides<IWeaponGetter>())
            {
                // Ignore no keywords
                if (weaponGetter.Keywords is null) continue;

                // Ignore enchanted
                if (!weaponGetter.ObjectEffect.IsNull) continue;

                // Ignore daedric artifacts
                if (weaponGetter.HasKeyword(Skyrim.Keyword.VendorItemDaedricArtifact)) continue;

                // Ignore non playable
                if (weaponGetter.Data is not null && weaponGetter.Data.Flags.HasFlag(WeaponData.Flag.NonPlayable)) continue;

                // Ignore can't drop
                if (weaponGetter.Data is not null && weaponGetter.Data.Flags.HasFlag(WeaponData.Flag.CantDrop)) continue;

                // Ignore Legacy of the dragonborn items
                if (DBM is not null && weaponGetter.FormKey.ModKey.Equals(DBM.ModKey)) continue;


                // Ignore vanilla
                if (Settings.IgnoreVanilla && vanillaMods.Contains(weaponGetter.FormKey.ModKey)) continue;

                // Ignore the blacklisted mods
                if (Settings.BlacklistedMods.Contains(weaponGetter.FormKey.ModKey)) continue;

                // Ignore blacklisted weapons
                if (WeaponBlacklist.Contains(weaponGetter.FormKey)) continue;


                string material = "";
                string type = "";
                short level = 1;

                // Dawnguard
                if (weaponGetter.HasKeyword(Dawnguard.Keyword.DLC1DawnguardItem))
                {
                    material = "Dawnguard";

                    type = GetSpecialTypeFromKeywords(weaponGetter);
                }
                // Silver
                else if (weaponGetter.HasKeyword(Skyrim.Keyword.WeapMaterialSilver))
                {
                    material = "Silver";

                    type = GetSpecialTypeFromKeywords(weaponGetter);
                }
                // Draugr 
                else if (weaponGetter.HasKeyword(Skyrim.Keyword.WeapMaterialDraugr) || weaponGetter.HasKeyword(Skyrim.Keyword.WeapMaterialDraugrHoned))
                {
                    // Handle Draugr Nord Hero
                    if (weaponGetter.EditorID is not null && weaponGetter.EditorID.Contains("nordhero", StringComparison.OrdinalIgnoreCase))
                    {
                        material = "DraugrNordHero";
                    }
                    else
                    {
                        material = "Draugr";

                        // Handle Draugr Honed
                        if (weaponGetter.HasKeyword(Skyrim.Keyword.WeapMaterialDraugrHoned))
                        {
                            level = 12;
                        }
                    }

                    type = GetSpecialTypeFromKeywords(weaponGetter);
                }
                // Forsworn
                else if (weaponGetter.EditorID is not null && weaponGetter.EditorID.Contains("forsworn", StringComparison.OrdinalIgnoreCase))
                {
                    material = "Forsworn";

                    type = GetSpecialTypeFromKeywords(weaponGetter);
                }
                // Imperial
                else if (weaponGetter.HasKeyword(Skyrim.Keyword.WeapMaterialImperial)
                    || (weaponGetter.EditorID is not null && weaponGetter.EditorID.Contains("imperial", StringComparison.OrdinalIgnoreCase)))
                {
                    material = "Imperial";

                    type = GetSpecialTypeFromKeywords(weaponGetter);
                }
                // Alikr
                else if (weaponGetter.EditorID is not null && (weaponGetter.EditorID.Contains("scimitar", StringComparison.OrdinalIgnoreCase)
                                                                || weaponGetter.EditorID.Contains("alikr", StringComparison.OrdinalIgnoreCase)
                                                                || weaponGetter.EditorID.Contains("redguard", StringComparison.OrdinalIgnoreCase)))
                {
                    material = "Alikr";

                    type = GetSpecialTypeFromKeywords(weaponGetter);
                }
                // Falmer
                else if (weaponGetter.HasKeyword(Skyrim.Keyword.WeapMaterialFalmer))
                {
                    // Store for later

                    // Create a new leveled item entry
                    falmerWeapons.Add(CreateNewLvlEntry(weaponGetter, 1, 1));

                    count1++;

                    continue;
                }
                // Falmer Honed
                else if (weaponGetter.HasKeyword(Skyrim.Keyword.WeapMaterialFalmerHoned))
                {
                    // Store for later

                    // Create a series of new leveled item entries
                    falmerWeapons.Add(CreateNewLvlEntry(weaponGetter, 1, 18));
                    falmerWeapons.Add(CreateNewLvlEntry(weaponGetter, 1, 19));
                    falmerWeapons.Add(CreateNewLvlEntry(weaponGetter, 1, 20));
                    falmerWeapons.Add(CreateNewLvlEntry(weaponGetter, 1, 21));
                    falmerWeapons.Add(CreateNewLvlEntry(weaponGetter, 1, 25));
                    falmerWeapons.Add(CreateNewLvlEntry(weaponGetter, 1, 26));
                    falmerWeapons.Add(CreateNewLvlEntry(weaponGetter, 1, 27));
                    falmerWeapons.Add(CreateNewLvlEntry(weaponGetter, 1, 28));

                    count1++;

                    continue;
                }
                // All the rest
                else
                {
                    // Search all keywords
                    foreach (var keyword in weaponGetter.Keywords)
                    {
                        // Material
                        if (weaponMaterialKeywords.Contains(keyword))
                        {
                            var kw = keyword.TryResolve(state.LinkCache);
                            if (kw is null || kw.EditorID is null) continue;

                            material = kw.EditorID.Replace("DLC1WeapMaterial", "").Replace("WeapMaterial", "").Replace("DLC2WeaponMaterial", "");
                        }

                        // Fix weapons with armor dragon material
                        else if (keyword.Equals(Skyrim.Keyword.ArmorMaterialDragonplate)
                                 || keyword.Equals(Skyrim.Keyword.ArmorMaterialDragonscale))
                        {
                            material = "Dragonbone";
                        }

                        // Type
                        else if (weaponTypeKeywords.Contains(keyword))
                        {
                            var kw = keyword.TryResolve(state.LinkCache);
                            if (kw is null || kw.EditorID is null) continue;

                            type = kw.EditorID.Replace("WeapType", "").Replace("VendorItem", "");
                        }
                    }

                }

                // Ignore if either the material or the type is null
                if (material == "" || type == "")
                {
                    // Wood weapons
                    if (weaponGetter.HasKeyword(Skyrim.Keyword.WeapMaterialWood))
                    {
                        woodWeapons.Add(CreateNewLvlEntry(weaponGetter, 1, 1));
                    }

                    if (Settings.Debug)
                        System.Console.WriteLine("> keywords not found: " + material + "/" + type);
                    continue;
                }

                if(Settings.Debug)
                    System.Console.WriteLine("> keywords found ");
                
                // Form the keys for the dictionaries
                string key = material + "_" + type;
                var tuple = new Tuple<ModKey, string>(weaponGetter.FormKey.ModKey, key.ToLower());

                // Create a new leveled item entry
                LeveledItemEntry entry = CreateNewLvlEntry(weaponGetter, 1, level);

                // Add the new entry in the mod-dependent dictionary
                leveledItemsToAddPerMod.TryGetValue(tuple, out var entryList);
                if (entryList is null)
                {
                    // new lvlentry
                    leveledItemsToAddPerMod.Add(tuple, new HashSet<LeveledItemEntry>() { entry });
                }
                else
                {
                    if (!entryList.Contains(entry))
                        entryList.Add(entry);
                }

                // Add the entry also to the mod-independent dictionary
                leveledItemsToAdd.TryGetValue(key.ToLower(), out var hash);
                if(hash is null)
                {
                    leveledItemsToAdd.TryAdd(key.ToLower(), new HashSet<LeveledItemEntry>() { entry });
                }
                else
                {
                    hash.Add(entry);
                }

                count1++;
            }
            System.Console.WriteLine("Done with Weapons!");

            /// Iterate on all Armours
            if (Settings.DoArmours || Settings.DoShieldsOnly)
            {
                System.Console.WriteLine("Retrieving armors...");
                
                foreach (var armourGetter in loadorder.WinningOverrides<IArmorGetter>())
                {
                    // If shield only is ticked, ignore if not shield
                    if (Settings.DoShieldsOnly)
                    {
                        if (!armourGetter.HasKeyword(Skyrim.Keyword.ArmorShield)) continue;
                    }

                    // Ignore no keywords
                    if (armourGetter.Keywords is null) continue;

                    // Ignore daedric artifacts
                    if (armourGetter.HasKeyword(Skyrim.Keyword.VendorItemDaedricArtifact)) continue;

                    // Ignore enchanted
                    if (!armourGetter.ObjectEffect.IsNull) continue;

                    // Ignore clothing
                    if (armourGetter.HasKeyword(Skyrim.Keyword.VendorItemClothing)) continue;

                    // Ignore non playable
                    if (armourGetter.MajorFlags.HasFlag(Armor.MajorFlag.NonPlayable)) continue;

                    // Ignore Legacy of the dragonborn items
                    if (DBM is not null && armourGetter.FormKey.ModKey.Equals(DBM.ModKey)) continue;


                    // Ignore vanilla
                    if (Settings.IgnoreVanilla && vanillaMods.Contains(armourGetter.FormKey.ModKey)) continue;

                    // Ignore the blacklisted mods
                    if (Settings.BlacklistedMods.Contains(armourGetter.FormKey.ModKey)) continue;

                    // Ignore blacklisted armours
                    if (ArmourBlacklist.Contains(armourGetter.FormKey)) continue;


                    string material = "";
                    string type = "";

                    // Search all keywords
                    foreach (var keyword in armourGetter.Keywords)
                    {
                        if (armourMaterialKeywords.Contains(keyword))
                        {
                            var kw = keyword.TryResolve(state.LinkCache);
                            if (kw is null || kw.EditorID is null) continue;

                            material = kw.EditorID.Replace("DLC2ArmorMaterial", "").Replace("DLC1ArmorMaterial", "").Replace("ArmorMaterial", "");
                            material = material.Replace("NordicHeavy", "Nordic").Replace("NordicLight", "Nordic");
                            material = material.Replace("BonemoldHeavy", "Bonemold").Replace("BonemoldLight", "Bonemold");
                        }
                        else if (armourTypeKeywords.Contains(keyword))
                        {
                            var kw = keyword.TryResolve(state.LinkCache);
                            if (kw is null || kw.EditorID is null) continue;

                            type = kw.EditorID.Replace("Armor", "").Replace("VendorItem", "");
                        }
                    }

                    // Ignore null
                    if (material == "" || type == "")
                    {
                        if(Settings.Debug)
                            System.Console.WriteLine("> keywords not found: " + material + "/" + type);
                        continue;
                    }
                    


                    // Form the keys for the dictionaries
                    string key = material + "_" + type;
                    var tuple = new Tuple<ModKey, string>(armourGetter.FormKey.ModKey, key.ToLower());

                    // Create a new leveled item entry
                    LeveledItemEntry entry = CreateNewLvlEntry(armourGetter, 1, 1);

                    // Add the new entry in the mod-dependent dictionary
                    leveledItemsToAddPerMod.TryGetValue(tuple, out var entryList);
                    if (entryList is null)
                    {
                        // new lvlentry
                        leveledItemsToAddPerMod.Add(tuple, new HashSet<LeveledItemEntry>() { entry });
                    }
                    else
                    {
                        if (!entryList.Contains(entry))
                            entryList.Add(entry);
                    }

                    // Add the entry also to the mod-independent dictionary
                    leveledItemsToAdd.TryGetValue(key.ToLower(), out var hash);
                    if (hash is null)
                    {
                        leveledItemsToAdd.TryAdd(key.ToLower(), new HashSet<LeveledItemEntry>() { entry });
                    }
                    else
                    {
                        hash.Add(entry);
                    }

                    count2++;
                }
                System.Console.WriteLine("Done with Armors!");
            }
            

            /// Iterate on the mod-dependent dictionary, to create new leveled lists for the bigger ones
            System.Console.WriteLine("Creating new leveled lists...");
            foreach (var lvlentry in leveledItemsToAddPerMod)
            {
                if (lvlentry.Value.Count > Settings.MinAmountLeveledList)
                {
                    // Create a whole new leveled list
                    var lv = state.PatchMod.LeveledItems.AddNew();
                    
                    // Check if it is a weapon or armour
                    var t1 = lvlentry.Value.First().Data?.Reference.TryResolve<IWeaponGetter>(state.LinkCache);
                    var t2 = lvlentry.Value.First().Data?.Reference.TryResolve<IArmorGetter>(state.LinkCache);
                    if(t1 is null && t2 is null) continue;

                    string recordType = "Armor_";
                    if(t1 is not null)
                    {
                        recordType = "Weapon_";
                    }           

                    // Set the new leveled list values
                    lv.EditorID = "OWL_" + recordType + lvlentry.Key.Item2 + "_" + lvlentry.Key.Item1.Name.ToLower();
                    lv.ChanceNone = 0;
                    lv.Flags.SetFlag(LeveledItem.Flag.CalculateForEachItemInCount, true);
                    lv.Flags.SetFlag(LeveledItem.Flag.CalculateFromAllLevelsLessThanOrEqualPlayer, true);
                    lv.Entries = new();
                    lv.Entries.AddRange(lvlentry.Value);

                    // Create a new leveled list entry with that newly created leveled list
                    LeveledItemEntry entry = CreateNewLvlEntry(lv, 1, 1);

                    // Remove all single entries from the mod-independent list
                    leveledItemsToAdd.TryGetValue(lvlentry.Key.Item2, out var hash);
                    if (hash is null) continue;
                    foreach(var value in lvlentry.Value)
                    {
                        hash.Remove(value);
                    }

                    // Add the newly created leveled list to the the mod-independent list
                    if (hash is null)
                    {
                        leveledItemsToAdd.TryAdd(lvlentry.Key.Item2, new HashSet<LeveledItemEntry>() { entry });
                    }
                    else
                    {
                        hash.Add(entry);
                    }

                    count3++;
                }
            }
            System.Console.WriteLine("Created " + count3 + " new leveled lists!");


            /// Iterate on OWL leveled lists
            System.Console.WriteLine("Starting to fill the OWL leveled lists...");
            foreach (var lvlListGetter in state.LoadOrder.PriorityOrder.Where(x => x.ModKey.Equals(OWL.ModKey)).WinningOverrides<ILeveledItemGetter>())
            {
                if (lvlListGetter.EditorID is null) continue;

                if (lvlListGetter.EditorID.StartsWith("OWL_"))
                {
                    // Form the key
                    var split = lvlListGetter.EditorID.Split('_');
                    string material = "";
                    string type = "";

                    var count = split.Length;

                    // Check that the size of split 
                    if (split.Length != 4 && split.Length != 5) continue;

                    // Form the key
                    material = split[2];
                    type = split[3];
                    string key = material + "_" + type;

                    // Get the items to add to the list
                    leveledItemsToAdd.TryGetValue(key.ToLower(), out var hash);
                    if (hash is null || hash.Count == 0) continue;

                    // Get the leveled list
                    var modifiedList = state.PatchMod.LeveledItems.GetOrAddAsOverride(lvlListGetter);

                    // Add all items to the leveled lists, if not already present
                    foreach (var hashEntry in hash)
                    {
                        modifiedList.Entries ??= new();

                        if (modifiedList.Entries.Contains(hashEntry))
                        {
                            if(Settings.Debug)
                                System.Console.WriteLine("Leveled list entry already exists, skipping!");
                        }
                        else
                        {
                            modifiedList.Entries?.Add(hashEntry);
                        }
                    }

                    // Remove the Unused if there, in the EditorID
                    if (split.Count() == 5 && split[4].Equals("unused", StringComparison.OrdinalIgnoreCase))
                    {
                        modifiedList.EditorID = modifiedList.EditorID?.Replace("_Unused", "");
                    }
                }
            }

            /// Handle falmer weapons
            var falmerlist = Skyrim.LeveledItem.LItemFalmerWeapon.TryResolve(state.LinkCache);
            if(falmerlist is not null) {
                var list = state.PatchMod.LeveledItems.GetOrAddAsOverride(falmerlist);
                
                foreach (var entr in falmerWeapons)
                {
                    if (list.Entries is not null && !list.Entries.Contains(entr))
                        list.Entries.Add(entr);
                }
            }

            /// Handle Wood weapons
            // Create a whole new leveled list
            var woodlist = state.PatchMod.LeveledItems.AddNew();

            // Set the new leveled list values
            woodlist.EditorID = "OWL_Weapon_Wood_All";
            woodlist.ChanceNone = 0;
            woodlist.Flags.SetFlag(LeveledItem.Flag.CalculateForEachItemInCount, true);
            woodlist.Flags.SetFlag(LeveledItem.Flag.CalculateFromAllLevelsLessThanOrEqualPlayer, true);
            woodlist.Entries = new();
            woodlist.Entries.AddRange(woodWeapons);

            if (OWL.Mod is null) return;
            var llist = OWL.Mod.LeveledItems.Records.First(x => x.EditorID == "OWL_Weapon_Iron_Sword");
            var test = state.PatchMod.LeveledItems.GetOrAddAsOverride(llist);
            test.Entries ??= new();
            test.Entries.Add(CreateNewLvlEntry(woodlist, 1, 1));
            count1++;



            System.Console.WriteLine("Done filling OWL leveled lists!");
            System.Console.WriteLine(count1 + " weapons and " + count2 + " armours were distributed into OWL's leveled lists.");


            // Reset the counters
            count1 = 0;
            count2 = 0;

            //

            System.Console.WriteLine("All done!");
        }
    }
}
