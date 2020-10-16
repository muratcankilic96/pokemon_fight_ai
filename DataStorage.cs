using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonFightAI
{


    class AttackPair<T1, T2> : List<Tuple<T1, T2>>
    {
        public void Add(T1 attack, T2 level)
        {
            Add(new Tuple<T1, T2>(attack, level));
        }
    }

    public enum AttackRef
    {
        STRUGGLE,
        /* GEN 1 */
        POUND, KARATECHOP, DOUBLESLAP, COMETPUNCH, MEGAPUNCH, PAYDAY, FIREPUNCH, ICEPUNCH,
        THUNDERPUNCH, SCRATCH, VICEGRIP, GUILLOTINE, RAZORWIND, SWORDSDANCE, CUT, GUST,
        WINGATTACK, WHIRLWIND, FLY, BIND, SLAM, VINEWHIP, STOMP, DOUBLEKICK,
        MEGAKICK, JUMPKICK, ROLLINGKICK, SANDATTACK, HEADBUTT, HORNATTACK, FURYATTACK, HORNDRILL,
        TACKLE, BODYSLAM, WRAP, TAKEDOWN, THRASH, DOUBLEEDGE, TAILWHIP, POISONSTING,
        TWINEEDLE, PINMISSILE, LEER, BITE, GROWL, ROAR, SING, SUPERSONIC,
        SONICBOOM, DISABLE, ACID, EMBER, FLAMETHROWER, MIST, WATERGUN, HYDROPUMP,
        SURF, ICEBEAM, BLIZZARD, PSYBEAM, BUBBLEBEAM, AURORABEAM, HYPERBEAM, PECK,
        DRILLPECK, SUBMISSION, LOWKICK, COUNTER, SEISMICTOSS, STRENGTH, ABSORB, MEGADRAIN,
        LEECHSEED, GROWTH, RAZORLEAF, SOLARBEAM, POISONPOWDER, STUNSPORE, SLEEPPOWDER, PETALDANCE,
        STRINGSHOT, DRAGONRAGE, FIRESPIN, THUNDERSHOCK, THUNDERBOLT, THUNDERWAVE, THUNDER, ROCKTHROW,
        EARTHQUAKE, FISSURE, DIG, TOXIC, CONFUSION, PSYCHIC, HYPNOSIS, MEDITATE,
        AGILITY, QUICKATTACK, RAGE, TELEPORT, NIGHTSHADE, MIMIC, SCREECH, DOUBLETEAM,
        RECOVER, HARDEN, MINIMIZE, SMOKESCREEN, CONFUSERAY, WITHDRAW, DEFENSECURL, BARRIER,
        LIGHTSCREEN, HAZE, REFLECT, FOCUSENERGY, BIDE, METRONOME, MIRRORMOVE, SELFDESTRUCT,
        EGGBOMB, LICK, SMOG, SLUDGE, BONECLUB, FIREBLAST, WATERFALL, CLAMP,
        SWIFT, SKULLBASH, SPIKECANNON, CONSTRICT, AMNESIA, KINESIS, SOFTBOILED, HIGHJUMPKICK,
        GLARE, DREAMEATER, POISONGAS, BARRAGE, LEECHLIFE, LOVELYKISS, SKYATTACK, TRANSFORM,
        BUBBLE, DIZZYPUNCH, SPORE, FLASH, PSYWAVE, SPLASH, ACIDARMOR, CRABHAMMER,
        EXPLOSION, FURYSWIPES, BONEMERANG, REST, ROCKSLIDE, HYPERFANG, SHARPEN, CONVERSION,
        TRIATTACK, SUPERFANG, SLASH, SUBSTITUTE,

        __placeholder,

        /* GEN 2 */
        SKETCH, TRIPLEKICK, THIEF, SPIDERWEB, MINDREADER, NIGHTMARE, FLAMEWHEEL, SNORE, CURSE,
        FLAIL, CONVERSION2, AEROBLAST, COTTONSPORE, REVERSAL, SPITE, POWDERSNOW, PROTECT,
        MACHPUNCH, SCARYFACE, FEINTATTACK, SWEETKISS, BELLYDRUM, SLUDGEBOMB, MUDSLAP, OCTAZOOKA,
        SPIKES, ZAPCANNON, FORESIGHT, DESTINYBOND, PERISHSONG, ICYWIND, DETECT, BONERUSH, LOCKON, OUTRAGE,
        SANDSTORM, GIGADRAIN, ENDURE, CHARM, ROLLOUT, FALSESWIPE, SWAGGER, MILKDRINK, SPARK, FURYCUTTER,
        STEELWING, MEANLOOK, ATTRACT, SLEEPTALK, HEALBELL, RETURN, PRESENT, FRUSTRATION, SAFEGUARD, PAINSPLIT,
        SACREDFIRE, MAGNITUDE, DYNAMICPUNCH, MEGAHORN, DRAGONBREATH, BATONPASS, ENCORE, PURSUIT, RAPIDSPIN, SWEETSCENT,
        IRONTAIL, METALCLAW, VITALTHROW, MORNINGSUN, SYNTHESIS, MOONLIGHT, HIDDENPOWER, CROSSCHOP, TWISTER, RAINDANCE,
        SUNNYDAY, CRUNCH, MIRRORCOAT, PSYCHUP, EXTREMESPEED, ANCIENTPOWER, SHADOWBALL, FUTURESIGHT, ROCKSMASH, WHIRLPOOL, BEATUP


    }

    public enum StatusRef
    {
        NORMAL,
        POISONED,
        POISONEDBADLY,
        PARALYZED,
        SLEPT,
        BURNT,
        FROZEN,
        FAINTED,
        CONFUSED,
        SUBSTITUTED,
        FLINCHED,
        CURSED,
        TAUNTED,
        LEECHED

    }
    
    public enum TypeRef
    {
        UNKNOWN,
        NORMAL,
        FIGHT,
        FLYING,
        POISON,
        GROUND,
        ROCK,
        BUG,
        GHOST,
        STEEL,
        FIRE,
        WATER,
        GRASS,
        ELECTRIC,
        PSYCHIC,
        ICE,
        DRAGON,
        DARK
    }

    static class DataStorage
    {
        public static List<Pokemon> pokemons = new List<Pokemon>();
        public static List<Attack> attacks = new List<Attack>();
        public static List<PokeType> types = new List<PokeType>();
        public static List<Status> statuses = new List<Status>();

        public static PokeType ReferType(TypeRef t)
        {
            return types.ElementAt((int)t);
        }

        public static Status ReferStatus(StatusRef s)
        {
            return statuses.ElementAt((int)s);
        }

        public static Attack ReferAttack(AttackRef a)
        {
            return attacks.ElementAt((int)a);
        }

        public static Trainer BuildTrainer(PokeInstance[] p)
        {
            Trainer t = new Trainer(p);
            return t;
        }

        public static void BuildStatus()
        {
            statuses.Add(new Status(0, "Normal", ""));
            statuses.Add(new Status(1, "Poisoned", " IS POISONED!", Properties.Resources.psn));
            statuses.Add(new Status(2, "Badly Poisoned", " IS BADLY POISONED!", Properties.Resources.psn));
            statuses.Add(new Status(3, "Paralyzed", " IS PARALYZED AND CAN'T MOVE!", Properties.Resources.par));
            statuses.Add(new Status(4, "Slept", " FELL INTO SLEEP", Properties.Resources.slp));
            statuses.Add(new Status(5, "Burned", " BURNS!", Properties.Resources.brn));
            statuses.Add(new Status(6, "Frozen", " IS FROZEN AND CAN'T MOVE!", Properties.Resources.frz));
            statuses.Add(new Status(7, "Fainted", "", Properties.Resources.fnt));
            statuses.Add(new Status(8, "Confused", " IS CONFUSED!"));
            statuses.Add(new Status(9, "Substituted", " HAS A SUBSTITUTE!"));
            statuses.Add(new Status(10, "Flinched", " IS FLINCHED!"));
            statuses.Add(new Status(11, "Cursed", " IS CURSED!"));
            statuses.Add(new Status(12, "Taunted", " IS TAUNTED!"));
            statuses.Add(new Status(13, "Leeched", " IS BEING LEECHED!"));
        }

        public static void BuildType()
        {
            types.Add(new PokeType(0, "???", null));
            types.Add(new PokeType(1, "Normal", Properties.Resources.normal));
            types.Add(new PokeType(2, "Fight", Properties.Resources.fight));
            types.Add(new PokeType(3, "Flying", Properties.Resources.flying));
            types.Add(new PokeType(4, "Poison", Properties.Resources.poison));
            types.Add(new PokeType(5, "Ground", Properties.Resources.ground));
            types.Add(new PokeType(6, "Rock", Properties.Resources.rock));
            types.Add(new PokeType(7, "Bug", Properties.Resources.bug));
            types.Add(new PokeType(8, "Ghost", Properties.Resources.ghost));
            types.Add(new PokeType(9, "Steel", Properties.Resources.steel));
            types.Add(new PokeType(10, "Fire", Properties.Resources.fire));
            types.Add(new PokeType(11, "Water", Properties.Resources.water));
            types.Add(new PokeType(12, "Grass", Properties.Resources.grass));
            types.Add(new PokeType(13, "Electric", Properties.Resources.electric));
            types.Add(new PokeType(14, "Psychic", Properties.Resources.psychic));
            types.Add(new PokeType(15, "Ice", Properties.Resources.ice));
            types.Add(new PokeType(16, "Dragon", Properties.Resources.dragon));
            types.Add(new PokeType(17, "Dark", Properties.Resources.dark));

            //NORMAL
            ReferType(TypeRef.NORMAL).notEffectiveTo = new PokeType[] { ReferType(TypeRef.GHOST) };
            ReferType(TypeRef.NORMAL).notEffectiveAgainst = new PokeType[] { ReferType(TypeRef.GHOST) };
            ReferType(TypeRef.NORMAL).weakTo = new PokeType[] { ReferType(TypeRef.ROCK), ReferType(TypeRef.STEEL) };
            ReferType(TypeRef.NORMAL).strongAgainst = new PokeType[] { ReferType(TypeRef.FIGHT) };

            //FIGHT 
            ReferType(TypeRef.FIGHT).notEffectiveTo = new PokeType[] { ReferType(TypeRef.GHOST) };
            ReferType(TypeRef.FIGHT).weakAgainst = new PokeType[] { ReferType(TypeRef.ROCK), ReferType(TypeRef.BUG), ReferType(TypeRef.DARK) };
            ReferType(TypeRef.FIGHT).weakTo = new PokeType[] { ReferType(TypeRef.FLYING), ReferType(TypeRef.POISON), ReferType(TypeRef.BUG), ReferType(TypeRef.PSYCHIC) };
            ReferType(TypeRef.FIGHT).strongAgainst = new PokeType[] { ReferType(TypeRef.FLYING), ReferType(TypeRef.PSYCHIC) };
            ReferType(TypeRef.FIGHT).strongAgainst = new PokeType[] { ReferType(TypeRef.NORMAL), ReferType(TypeRef.STEEL), ReferType(TypeRef.ROCK), ReferType(TypeRef.ICE), ReferType(TypeRef.DARK) };

            //FLYING
            ReferType(TypeRef.FLYING).notEffectiveAgainst = new PokeType[] { ReferType(TypeRef.GROUND) };
            ReferType(TypeRef.FLYING).weakAgainst = new PokeType[] { ReferType(TypeRef.FIGHT), ReferType(TypeRef.BUG), ReferType(TypeRef.GRASS) };
            ReferType(TypeRef.FLYING).weakTo = new PokeType[] { ReferType(TypeRef.ROCK), ReferType(TypeRef.ELECTRIC) };
            ReferType(TypeRef.FLYING).strongAgainst = new PokeType[] { ReferType(TypeRef.ROCK), ReferType(TypeRef.ELECTRIC), ReferType(TypeRef.ICE) };
            ReferType(TypeRef.FLYING).strongTo = new PokeType[] { ReferType(TypeRef.FIGHT), ReferType(TypeRef.BUG), ReferType(TypeRef.GRASS) };

            //POISON
            ReferType(TypeRef.POISON).notEffectiveTo = new PokeType[] { ReferType(TypeRef.STEEL) };
            ReferType(TypeRef.POISON).weakAgainst = new PokeType[] { ReferType(TypeRef.FIGHT), ReferType(TypeRef.POISON), ReferType(TypeRef.BUG), ReferType(TypeRef.GRASS) };
            ReferType(TypeRef.POISON).weakTo = new PokeType[] { ReferType(TypeRef.GROUND), ReferType(TypeRef.POISON), ReferType(TypeRef.ROCK), ReferType(TypeRef.GHOST) };
            ReferType(TypeRef.POISON).strongAgainst = new PokeType[] { ReferType(TypeRef.GROUND), ReferType(TypeRef.PSYCHIC) };
            ReferType(TypeRef.POISON).strongTo = new PokeType[] { ReferType(TypeRef.GRASS) };

            //GROUND
            ReferType(TypeRef.GROUND).notEffectiveAgainst = new PokeType[] { ReferType(TypeRef.ELECTRIC) };
            ReferType(TypeRef.GROUND).notEffectiveTo = new PokeType[] { ReferType(TypeRef.FLYING) };
            ReferType(TypeRef.GROUND).weakAgainst = new PokeType[] { ReferType(TypeRef.POISON), ReferType(TypeRef.ROCK) };
            ReferType(TypeRef.GROUND).weakTo = new PokeType[] { ReferType(TypeRef.BUG), ReferType(TypeRef.GRASS) };
            ReferType(TypeRef.GROUND).strongAgainst = new PokeType[] { ReferType(TypeRef.WATER), ReferType(TypeRef.GRASS), ReferType(TypeRef.ICE) };
            ReferType(TypeRef.GROUND).strongTo = new PokeType[] { ReferType(TypeRef.POISON), ReferType(TypeRef.ROCK), ReferType(TypeRef.STEEL), ReferType(TypeRef.FIRE), ReferType(TypeRef.ELECTRIC) };

            //ROCK
            ReferType(TypeRef.ROCK).weakAgainst = new PokeType[] { ReferType(TypeRef.NORMAL), ReferType(TypeRef.FLYING), ReferType(TypeRef.POISON), ReferType(TypeRef.FIRE) };
            ReferType(TypeRef.ROCK).weakTo = new PokeType[] { ReferType(TypeRef.FIGHT), ReferType(TypeRef.GROUND), ReferType(TypeRef.STEEL) };
            ReferType(TypeRef.ROCK).strongAgainst = new PokeType[] { ReferType(TypeRef.FIGHT), ReferType(TypeRef.GROUND), ReferType(TypeRef.STEEL), ReferType(TypeRef.WATER), ReferType(TypeRef.GRASS) };
            ReferType(TypeRef.ROCK).strongTo = new PokeType[] { ReferType(TypeRef.FLYING), ReferType(TypeRef.BUG), ReferType(TypeRef.ICE), ReferType(TypeRef.FIRE) };

            //BUG
            ReferType(TypeRef.BUG).weakAgainst = new PokeType[] { ReferType(TypeRef.FIGHT), ReferType(TypeRef.GROUND), ReferType(TypeRef.GRASS) };
            ReferType(TypeRef.BUG).weakTo = new PokeType[] { ReferType(TypeRef.FIGHT), ReferType(TypeRef.FLYING), ReferType(TypeRef.POISON), ReferType(TypeRef.GHOST), ReferType(TypeRef.STEEL), ReferType(TypeRef.FIRE) };
            ReferType(TypeRef.BUG).strongAgainst = new PokeType[] { ReferType(TypeRef.FLYING), ReferType(TypeRef.ROCK), ReferType(TypeRef.FIRE) };
            ReferType(TypeRef.BUG).strongTo = new PokeType[] { ReferType(TypeRef.GRASS), ReferType(TypeRef.PSYCHIC), ReferType(TypeRef.DARK) };

            //GHOST
            ReferType(TypeRef.GHOST).notEffectiveAgainst = new PokeType[] { ReferType(TypeRef.NORMAL), ReferType(TypeRef.FIGHT) };
            ReferType(TypeRef.GHOST).notEffectiveTo = new PokeType[] { ReferType(TypeRef.NORMAL) };
            ReferType(TypeRef.GHOST).weakAgainst = new PokeType[] { ReferType(TypeRef.POISON), ReferType(TypeRef.BUG) };
            ReferType(TypeRef.GHOST).weakTo = new PokeType[] { ReferType(TypeRef.STEEL), ReferType(TypeRef.DARK) };
            ReferType(TypeRef.GHOST).strongAgainst = new PokeType[] { ReferType(TypeRef.GHOST), ReferType(TypeRef.DARK) };
            ReferType(TypeRef.GHOST).strongTo = new PokeType[] { ReferType(TypeRef.GHOST), ReferType(TypeRef.PSYCHIC) };

            //STEEL
            ReferType(TypeRef.STEEL).notEffectiveAgainst = new PokeType[] { ReferType(TypeRef.POISON) };
            ReferType(TypeRef.STEEL).weakAgainst = new PokeType[] { ReferType(TypeRef.NORMAL), ReferType(TypeRef.FLYING), ReferType(TypeRef.ROCK), ReferType(TypeRef.BUG), ReferType(TypeRef.GHOST), ReferType(TypeRef.STEEL), ReferType(TypeRef.GRASS), ReferType(TypeRef.PSYCHIC), ReferType(TypeRef.ICE), ReferType(TypeRef.DRAGON), ReferType(TypeRef.DARK) };
            ReferType(TypeRef.STEEL).weakTo = new PokeType[] { ReferType(TypeRef.STEEL), ReferType(TypeRef.FIRE), ReferType(TypeRef.WATER), ReferType(TypeRef.ELECTRIC) };
            ReferType(TypeRef.STEEL).strongAgainst = new PokeType[] { ReferType(TypeRef.FIGHT), ReferType(TypeRef.GROUND), ReferType(TypeRef.FIRE) };
            ReferType(TypeRef.STEEL).strongTo = new PokeType[] { ReferType(TypeRef.ROCK), ReferType(TypeRef.ICE) };

            //FIRE
            ReferType(TypeRef.FIRE).weakAgainst = new PokeType[] { ReferType(TypeRef.BUG), ReferType(TypeRef.STEEL), ReferType(TypeRef.FIRE), ReferType(TypeRef.GRASS), ReferType(TypeRef.ICE) };
            ReferType(TypeRef.FIRE).weakTo = new PokeType[] { ReferType(TypeRef.ROCK), ReferType(TypeRef.FIRE), ReferType(TypeRef.WATER), ReferType(TypeRef.DRAGON) };
            ReferType(TypeRef.FIRE).strongAgainst = new PokeType[] { ReferType(TypeRef.GROUND), ReferType(TypeRef.ROCK), ReferType(TypeRef.WATER) };
            ReferType(TypeRef.FIRE).strongTo = new PokeType[] { ReferType(TypeRef.BUG), ReferType(TypeRef.GRASS), ReferType(TypeRef.STEEL), ReferType(TypeRef.ICE) };

            //WATER
            ReferType(TypeRef.WATER).weakAgainst = new PokeType[] { ReferType(TypeRef.WATER), ReferType(TypeRef.STEEL), ReferType(TypeRef.FIRE), ReferType(TypeRef.ICE) };
            ReferType(TypeRef.WATER).weakTo = new PokeType[] { ReferType(TypeRef.GRASS), ReferType(TypeRef.WATER), ReferType(TypeRef.DRAGON) };
            ReferType(TypeRef.WATER).strongAgainst = new PokeType[] { ReferType(TypeRef.GRASS), ReferType(TypeRef.ELECTRIC) };
            ReferType(TypeRef.WATER).strongTo = new PokeType[] { ReferType(TypeRef.ROCK), ReferType(TypeRef.GROUND), ReferType(TypeRef.FIRE) };

            //GRASS
            ReferType(TypeRef.GRASS).weakAgainst = new PokeType[] { ReferType(TypeRef.ELECTRIC), ReferType(TypeRef.GROUND), ReferType(TypeRef.WATER), ReferType(TypeRef.GRASS) };
            ReferType(TypeRef.GRASS).weakTo = new PokeType[] { ReferType(TypeRef.FLYING), ReferType(TypeRef.POISON), ReferType(TypeRef.BUG), ReferType(TypeRef.STEEL), ReferType(TypeRef.GRASS), ReferType(TypeRef.FIRE), ReferType(TypeRef.DRAGON) };
            ReferType(TypeRef.GRASS).strongAgainst = new PokeType[] { ReferType(TypeRef.FLYING), ReferType(TypeRef.POISON), ReferType(TypeRef.BUG), ReferType(TypeRef.FIRE), ReferType(TypeRef.ICE) };
            ReferType(TypeRef.GRASS).strongTo = new PokeType[] { ReferType(TypeRef.ROCK), ReferType(TypeRef.GROUND), ReferType(TypeRef.WATER) };

            //ELECTRIC
            ReferType(TypeRef.ELECTRIC).notEffectiveTo = new PokeType[] { ReferType(TypeRef.GROUND) };
            ReferType(TypeRef.ELECTRIC).weakAgainst = new PokeType[] { ReferType(TypeRef.ELECTRIC), ReferType(TypeRef.FLYING), ReferType(TypeRef.STEEL) };
            ReferType(TypeRef.ELECTRIC).weakTo = new PokeType[] { ReferType(TypeRef.GRASS), ReferType(TypeRef.ELECTRIC), ReferType(TypeRef.DRAGON) };
            ReferType(TypeRef.ELECTRIC).strongAgainst = new PokeType[] { ReferType(TypeRef.GROUND) };
            ReferType(TypeRef.ELECTRIC).strongTo = new PokeType[] { ReferType(TypeRef.FLYING), ReferType(TypeRef.WATER) };

            //PSYCHIC
            ReferType(TypeRef.PSYCHIC).notEffectiveTo = new PokeType[] { ReferType(TypeRef.DARK) };
            ReferType(TypeRef.PSYCHIC).weakAgainst = new PokeType[] { ReferType(TypeRef.FIGHT), ReferType(TypeRef.PSYCHIC) };
            ReferType(TypeRef.PSYCHIC).weakTo = new PokeType[] { ReferType(TypeRef.STEEL), ReferType(TypeRef.PSYCHIC) };
            ReferType(TypeRef.PSYCHIC).strongAgainst = new PokeType[] { ReferType(TypeRef.BUG), ReferType(TypeRef.GHOST), ReferType(TypeRef.DARK) };
            ReferType(TypeRef.PSYCHIC).strongTo = new PokeType[] { ReferType(TypeRef.FIGHT), ReferType(TypeRef.POISON) };

            //ICE
            ReferType(TypeRef.ICE).weakAgainst = new PokeType[] { ReferType(TypeRef.ICE) };
            ReferType(TypeRef.ICE).weakTo = new PokeType[] { ReferType(TypeRef.STEEL), ReferType(TypeRef.FIRE), ReferType(TypeRef.WATER), ReferType(TypeRef.ICE) };
            ReferType(TypeRef.ICE).strongAgainst = new PokeType[] { ReferType(TypeRef.FIGHT), ReferType(TypeRef.ROCK), ReferType(TypeRef.STEEL), ReferType(TypeRef.FIRE) };
            ReferType(TypeRef.ICE).strongTo = new PokeType[] { ReferType(TypeRef.FLYING), ReferType(TypeRef.GROUND), ReferType(TypeRef.GRASS), ReferType(TypeRef.DRAGON) };

            //DRAGON
            ReferType(TypeRef.DRAGON).weakAgainst = new PokeType[] { ReferType(TypeRef.FIRE), ReferType(TypeRef.WATER), ReferType(TypeRef.GRASS), ReferType(TypeRef.ELECTRIC) };
            ReferType(TypeRef.DRAGON).weakTo = new PokeType[] { ReferType(TypeRef.STEEL) };
            ReferType(TypeRef.DRAGON).strongAgainst = new PokeType[] { ReferType(TypeRef.ICE), ReferType(TypeRef.DRAGON) };
            ReferType(TypeRef.DRAGON).strongTo = new PokeType[] { ReferType(TypeRef.DRAGON) };

            //DARK
            ReferType(TypeRef.DARK).notEffectiveAgainst = new PokeType[] { ReferType(TypeRef.PSYCHIC) };
            ReferType(TypeRef.DARK).weakAgainst = new PokeType[] { ReferType(TypeRef.GHOST), ReferType(TypeRef.DARK) };
            ReferType(TypeRef.DARK).weakTo = new PokeType[] { ReferType(TypeRef.FIGHT), ReferType(TypeRef.STEEL), ReferType(TypeRef.DARK) };
            ReferType(TypeRef.DARK).strongAgainst = new PokeType[] { ReferType(TypeRef.FIGHT), ReferType(TypeRef.BUG) };
            ReferType(TypeRef.DARK).strongTo = new PokeType[] { ReferType(TypeRef.GHOST), ReferType(TypeRef.PSYCHIC) };
        }

        public static void BuildAttack()
        {
            //Code individual scripts for these: 13, 19, 50, 54, 67, 68, 69, 91, 99, 
            //                                   101, 102, 107, 112, 113, 114,
            //                                   115, 117, 118, 119, 144, 149, 160, 162
            attacks.Add(new Attack(0, "Struggle", ReferType(TypeRef.NORMAL), -50, 999 /* Bypass */, 4, 1)); ReferAttack(AttackRef.STRUGGLE).userHPMod = -25;
            attacks.Add(new Attack(1, "Pound", ReferType(TypeRef.NORMAL), -40, 100, 4, 35));
            attacks.Add(new Attack(2, "Karate Chop", ReferType(TypeRef.FIGHT), -50, 100, 32, 25));
            attacks.Add(new Attack(3, "Double Slap", ReferType(TypeRef.NORMAL), -15, 85, 4, 10)); ReferAttack(AttackRef.DOUBLESLAP).multiStrike = true;
            attacks.Add(new Attack(4, "Comet Punch", ReferType(TypeRef.NORMAL), -18, 85, 4, 15)); ReferAttack(AttackRef.COMETPUNCH).multiStrike = true;
            attacks.Add(new Attack(5, "Mega Punch", ReferType(TypeRef.NORMAL), -80, 85, 4, 20));
            attacks.Add(new Attack(6, "Pay Day", ReferType(TypeRef.NORMAL), -40, 100, 4, 20));
            attacks.Add(new Attack(7, "Fire Punch", ReferType(TypeRef.FIRE), -75, 100, 4, ReferStatus(StatusRef.BURNT), 10, 15));
            attacks.Add(new Attack(8, "Ice Punch", ReferType(TypeRef.ICE), -75, 100, 4, ReferStatus(StatusRef.FROZEN), 10, 15));
            attacks.Add(new Attack(9, "Thunder Punch", ReferType(TypeRef.ELECTRIC), -75, 100, 4, ReferStatus(StatusRef.PARALYZED), 10, 15)); ReferAttack(AttackRef.THUNDERPUNCH).oppStatusEffectRestrictionType = ReferType(TypeRef.ELECTRIC);
            attacks.Add(new Attack(10, "Scratch", ReferType(TypeRef.NORMAL), -40, 100, 4, 35));
            attacks.Add(new Attack(11, "Vice Grip", ReferType(TypeRef.NORMAL), -55, 100, 4, 30));
            attacks.Add(new Attack(12, "Guillotine", ReferType(TypeRef.NORMAL), 5)); ReferAttack(AttackRef.GUILLOTINE).mc = MoveCategory.ONEHITKO;
            attacks.Add(new Attack(13, "Razor Wind", ReferType(TypeRef.UNKNOWN), -80, 0, 0, 10)); /* SPECIAL! */ ReferAttack(AttackRef.RAZORWIND).mc = MoveCategory.MISC; ReferAttack(AttackRef.RAZORWIND).hasIndividualScript = true;
            attacks.Add(new Attack(14, "Swords Dance", ReferType(TypeRef.NORMAL), 2, 0, 0, 0, 0, 20));
            attacks.Add(new Attack(15, "Cut", ReferType(TypeRef.NORMAL), -50, 95, 4, 35));
            attacks.Add(new Attack(16, "Gust", ReferType(TypeRef.FLYING), -40, 100, 4, 30));
            attacks.Add(new Attack(17, "Wing Attack", ReferType(TypeRef.FLYING), -60, 100, 4, 35));
            attacks.Add(new Attack(18, "Whirlwind", ReferType(TypeRef.NORMAL), 0, 100, 0, 20)); ReferAttack(AttackRef.WHIRLWIND).mc = MoveCategory.SWAPPER; ReferAttack(AttackRef.WHIRLWIND).oppForceSwitchPokemon = true;
            attacks.Add(new Attack(19, "Fly", ReferType(TypeRef.FLYING), -70, 95, 4, 15)); /* SPECIAL! */ ReferAttack(AttackRef.FLY).mc = MoveCategory.MISC; ReferAttack(AttackRef.FLY).hasIndividualScript = true; ReferAttack(AttackRef.FLY).needsToCharge = true;
            attacks.Add(new Attack(20, "Bind", ReferType(TypeRef.NORMAL), -15, 75, 4, 20));  ReferAttack(AttackRef.BIND).multiTurn = true; ReferAttack(AttackRef.BIND).oppFixedAmongTurns = true; ReferAttack(AttackRef.BIND).userFixedAmongTurns = true;
            attacks.Add(new Attack(21, "Slam", ReferType(TypeRef.NORMAL), -80, 75, 4, 20));
            attacks.Add(new Attack(22, "Vine Whip", ReferType(TypeRef.GRASS), -35, 100, 4, 10));
            attacks.Add(new Attack(23, "Stomp", ReferType(TypeRef.NORMAL), -65, 999 /* Bypass */, 4, ReferStatus(StatusRef.FLINCHED), 30, 20));
            attacks.Add(new Attack(24, "Double Kick", ReferType(TypeRef.FIGHT), -30, 100, 4, 30)); ReferAttack(AttackRef.DOUBLEKICK).multiStrike = true; ReferAttack(AttackRef.DOUBLEKICK).multiStrikeMaximum = 2;
            attacks.Add(new Attack(25, "Mega Kick", ReferType(TypeRef.NORMAL), -120, 75, 4, 5)); 
            attacks.Add(new Attack(26, "Jump Kick", ReferType(TypeRef.FIGHT), -70, 95, 4, 5)); ReferAttack(AttackRef.JUMPKICK).missCrashDamage = -35;
            attacks.Add(new Attack(27, "Rolling Kick", ReferType(TypeRef.FIGHT), -60, 85, 4, ReferStatus(StatusRef.FLINCHED), 30, 15));
            attacks.Add(new Attack(28, "Sand Attack", ReferType(TypeRef.GROUND), 0, 0, 0, 0, 0, 100, 15)); ReferAttack(AttackRef.SANDATTACK).oppAccuracyMod = -1;
            attacks.Add(new Attack(29, "Headbutt", ReferType(TypeRef.NORMAL), -70, 100, 4, ReferStatus(StatusRef.FLINCHED), 30, 15));
            attacks.Add(new Attack(30, "Horn Attack", ReferType(TypeRef.NORMAL), -65, 100, 4, 25));
            attacks.Add(new Attack(31, "Fury Attack", ReferType(TypeRef.NORMAL), -20, 85, 4, 15)); ReferAttack(AttackRef.FURYATTACK).multiStrike = true;
            attacks.Add(new Attack(32, "Horn Drill", ReferType(TypeRef.NORMAL), 5));  ReferAttack(AttackRef.HORNDRILL).mc = MoveCategory.ONEHITKO;
            attacks.Add(new Attack(33, "Tackle", ReferType(TypeRef.NORMAL), -35, 95, 4, 35));
            attacks.Add(new Attack(34, "Body Slam", ReferType(TypeRef.NORMAL), -85, 999 /* Bypass */, 4, ReferStatus(StatusRef.PARALYZED), 30, 15)); ReferAttack(AttackRef.BODYSLAM).oppStatusEffectRestrictionType = ReferType(TypeRef.NORMAL);
            attacks.Add(new Attack(35, "Wrap", ReferType(TypeRef.NORMAL), -15, 85, 4, 20)); ReferAttack(AttackRef.WRAP).multiTurn = true; ReferAttack(AttackRef.WRAP).oppFixedAmongTurns = true; ReferAttack(AttackRef.WRAP).userFixedAmongTurns = true;
            attacks.Add(new Attack(36, "Take Down", ReferType(TypeRef.NORMAL), -90, 75, 4, 20)); ReferAttack(AttackRef.TAKEDOWN).userHPMod = -22;
            attacks.Add(new Attack(37, "Thrash", ReferType(TypeRef.NORMAL), -90, 100, 4, 20)); ReferAttack(AttackRef.THRASH).userStatusEffect = ReferStatus(StatusRef.CONFUSED); ReferAttack(AttackRef.THRASH).userStatusProb = 100; ReferAttack(AttackRef.THRASH).multiTurn = true; ReferAttack(AttackRef.THRASH).userFixedAmongTurns = true; ReferAttack(AttackRef.THRASH).multiTurnMaximum = 3;
            attacks.Add(new Attack(38, "Double-Edge", ReferType(TypeRef.NORMAL), -120, 75, 4, 15)); ReferAttack(AttackRef.DOUBLEEDGE).userHPMod = -30;
            attacks.Add(new Attack(39, "Tail Whip", ReferType(TypeRef.NORMAL), 0, -1, 0, 0, 0, 100, 30));
            attacks.Add(new Attack(40, "Poison Sting", ReferType(TypeRef.POISON), -15, 100, 4, ReferStatus(StatusRef.POISONED), 20, 35));
            attacks.Add(new Attack(41, "Twineedle", ReferType(TypeRef.BUG), -25, 100, 4, ReferStatus(StatusRef.POISONED), 20, 20)); ReferAttack(AttackRef.TWINEEDLE).oppStatusEffectRestrictionType = ReferType(TypeRef.POISON); ReferAttack(AttackRef.TWINEEDLE).multiStrike = true; ReferAttack(AttackRef.TWINEEDLE).multiStrikeMaximum = 2;
            attacks.Add(new Attack(42, "Pin Missile", ReferType(TypeRef.BUG), -14, 85, 4, 20)); ReferAttack(AttackRef.PINMISSILE).multiStrike = true;
            attacks.Add(new Attack(43, "Leer", ReferType(TypeRef.NORMAL), 0, -1, 0, 0, 0, 100, 30));
            attacks.Add(new Attack(44, "Bite", ReferType(TypeRef.DARK), -60, 100, 4, ReferStatus(StatusRef.FLINCHED), 30, 25));
            attacks.Add(new Attack(45, "Growl", ReferType(TypeRef.NORMAL), -1, 0, 0, 0, 0, 100, 40));
            attacks.Add(new Attack(46, "Roar", ReferType(TypeRef.NORMAL), 0, 999 /* Bypass */, 0, 20)); ReferAttack(AttackRef.ROAR).mc = MoveCategory.SWAPPER;  ReferAttack(AttackRef.ROAR).oppForceSwitchPokemon = true;
            attacks.Add(new Attack(47, "Sing", ReferType(TypeRef.NORMAL), ReferStatus(StatusRef.SLEPT), 55, 15));
            attacks.Add(new Attack(48, "Supersonic", ReferType(TypeRef.NORMAL), ReferStatus(StatusRef.CONFUSED), 55, 20));
            attacks.Add(new Attack(49, "Sonic Boom", ReferType(TypeRef.NORMAL), -20, 100, 0, 90)); ReferAttack(AttackRef.SONICBOOM).typeChartIgnored = true; ReferAttack(AttackRef.SONICBOOM).fixedDamage = true;
            attacks.Add(new Attack(50, "Disable", ReferType(TypeRef.NORMAL), 20)); /* SPECIAL! */ ReferAttack(AttackRef.DISABLE).hasIndividualScript = true;
            attacks.Add(new Attack(51, "Acid", ReferType(TypeRef.POISON), -40, 100, 4, 0, -1, 0, 0, 0, 10, 30));
            attacks.Add(new Attack(52, "Ember", ReferType(TypeRef.FIRE), -40, 100, 4, ReferStatus(StatusRef.BURNT), 10, 25));
            attacks.Add(new Attack(53, "Flamethrower", ReferType(TypeRef.FIRE), -90, 100, 4, ReferStatus(StatusRef.BURNT), 10, 15));
            attacks.Add(new Attack(54, "Mist", ReferType(TypeRef.ICE), 30)); /* SPECIAL! */ ReferAttack(AttackRef.MIST).hasIndividualScript = true;
            attacks.Add(new Attack(55, "Water Gun", ReferType(TypeRef.WATER), -40, 100, 4, 25));
            attacks.Add(new Attack(56, "Hydro Pump", ReferType(TypeRef.WATER), -120, 80, 4, 5));
            attacks.Add(new Attack(57, "Surf", ReferType(TypeRef.WATER), -95, 100, 4, 15));
            attacks.Add(new Attack(58, "Ice Beam", ReferType(TypeRef.ICE), -95, 100, 4, ReferStatus(StatusRef.FROZEN), 10, 10));
            attacks.Add(new Attack(59, "Blizzard", ReferType(TypeRef.ICE), -120, 70, 4, ReferStatus(StatusRef.FROZEN), 10, 5));
            attacks.Add(new Attack(60, "Psybeam", ReferType(TypeRef.PSYCHIC), -65, 100, 4, ReferStatus(StatusRef.CONFUSED), 10, 20));
            attacks.Add(new Attack(61, "Bubble Beam", ReferType(TypeRef.WATER), -65, 100, 4, 0, 0, 0, 0, -1, 10, 20));
            attacks.Add(new Attack(62, "Aurora Beam", ReferType(TypeRef.ICE), -65, 100, 4, -1, 0, 0, 0, 0, 10, 20));
            attacks.Add(new Attack(63, "Hyper Beam", ReferType(TypeRef.NORMAL), -150, 90, 4, 5)); ReferAttack(AttackRef.HYPERBEAM).needsToRecharge = true;
            attacks.Add(new Attack(64, "Peck", ReferType(TypeRef.NORMAL), -35, 100, 4, 35));
            attacks.Add(new Attack(65, "Drill Peck", ReferType(TypeRef.NORMAL), -80, 80, 4, 20));
            attacks.Add(new Attack(66, "Submission", ReferType(TypeRef.FIGHT), -80, 80, 4, 25)); ReferAttack(AttackRef.SUBMISSION).userHPMod = -20;
            attacks.Add(new Attack(67, "Low Kick", ReferType(TypeRef.FIGHT), 0, 100, 4, 20));     /* SPECIAL! */ ReferAttack(AttackRef.LOWKICK).mc = MoveCategory.MISC; ReferAttack(AttackRef.LOWKICK).hasIndividualScript = true;
            attacks.Add(new Attack(68, "Counter", ReferType(TypeRef.FIGHT), 0, 100, 4, 20));      /* SPECIAL! */ ReferAttack(AttackRef.COUNTER).mc = MoveCategory.MISC; ReferAttack(AttackRef.COUNTER).hasIndividualScript = true; ReferAttack(AttackRef.COUNTER).priority = -1;
            attacks.Add(new Attack(69, "Seismic Toss", ReferType(TypeRef.FIGHT), 0, 100, 4, 20)); /* SPECIAL! */ ReferAttack(AttackRef.SEISMICTOSS).mc = MoveCategory.MISC; ReferAttack(AttackRef.SEISMICTOSS).hasIndividualScript = true;
            attacks.Add(new Attack(70, "Strength", ReferType(TypeRef.NORMAL), -80, 100, 4, 15));
            attacks.Add(new Attack(71, "Absorb", ReferType(TypeRef.GRASS), -20, 100, 4, 20)); ReferAttack(AttackRef.ABSORB).userHPMod = -10;
            attacks.Add(new Attack(72, "Mega Drain", ReferType(TypeRef.GRASS), -40, 100, 4, 10)); ReferAttack(AttackRef.ABSORB).userHPMod = -20;
            attacks.Add(new Attack(73, "Leech Seed", ReferType(TypeRef.GRASS), ReferStatus(StatusRef.LEECHED), 90, 10));
            attacks.Add(new Attack(74, "Growth", ReferType(TypeRef.NORMAL), 0, 0, 1, 0, 0, 20));
            attacks.Add(new Attack(75, "Razor Leaf", ReferType(TypeRef.GRASS), -55, 95, 32, 25));
            attacks.Add(new Attack(76, "Solar Beam", ReferType(TypeRef.GRASS), -120, 100, 4, 10)); ReferAttack(AttackRef.SOLARBEAM).needsToCharge = true;
            attacks.Add(new Attack(77, "Poison Powder", ReferType(TypeRef.POISON), ReferStatus(StatusRef.POISONED), 75, 35));
            attacks.Add(new Attack(78, "Stun Spore", ReferType(TypeRef.GRASS), ReferStatus(StatusRef.PARALYZED), 75, 30));
            attacks.Add(new Attack(79, "Sleep Powder", ReferType(TypeRef.GRASS), ReferStatus(StatusRef.SLEPT), 75, 15));
            attacks.Add(new Attack(80, "Petal Dance", ReferType(TypeRef.GRASS), -70, 100, 4, 20)); ReferAttack(AttackRef.PETALDANCE).userStatusEffect = ReferStatus(StatusRef.CONFUSED); ReferAttack(AttackRef.PETALDANCE).userStatusProb = 100; ReferAttack(AttackRef.PETALDANCE).multiTurn = true; ReferAttack(AttackRef.PETALDANCE).userFixedAmongTurns = true; ReferAttack(AttackRef.PETALDANCE).multiTurnMaximum = 3;
            attacks.Add(new Attack(81, "String Shot", ReferType(TypeRef.BUG), 0, 0, 0, 0, -1, 95, 40));
            attacks.Add(new Attack(82, "Dragon Rage", ReferType(TypeRef.DRAGON), -40, 100, 0, 10)); ReferAttack(AttackRef.DRAGONRAGE).fixedDamage = true;
            attacks.Add(new Attack(83, "Fire Spin", ReferType(TypeRef.FIRE), -15, 70, 4, 15)); ReferAttack(AttackRef.FIRESPIN).defreeze = true;
            attacks.Add(new Attack(84, "Thunder Shock", ReferType(TypeRef.ELECTRIC), -40, 100, 4, ReferStatus(StatusRef.PARALYZED), 10, 30));
            attacks.Add(new Attack(85, "Thunderbolt", ReferType(TypeRef.ELECTRIC), -95, 100, 4, ReferStatus(StatusRef.PARALYZED), 10, 15));
            attacks.Add(new Attack(86, "Thunder Wave", ReferType(TypeRef.ELECTRIC), ReferStatus(StatusRef.PARALYZED), 100, 20));
            attacks.Add(new Attack(87, "Thunder", ReferType(TypeRef.ELECTRIC), -120, 70, 4, ReferStatus(StatusRef.PARALYZED), 30, 10));
            attacks.Add(new Attack(88, "Rock Throw", ReferType(TypeRef.ROCK), -50, 90, 4, 15));
            attacks.Add(new Attack(89, "Earthquake", ReferType(TypeRef.GROUND), -100, 100, 4, 10));
            attacks.Add(new Attack(90, "Fissure", ReferType(TypeRef.GROUND), 5)); ReferAttack(AttackRef.FISSURE).mc = MoveCategory.ONEHITKO;
            attacks.Add(new Attack(91, "Dig", ReferType(TypeRef.GROUND), -70, 95, 1, 15)); /* SPECIAL! */ ReferAttack(AttackRef.DIG).mc = MoveCategory.MISC; ReferAttack(AttackRef.DIG).hasIndividualScript = true; ReferAttack(AttackRef.DIG).needsToCharge = true;
            attacks.Add(new Attack(92, "Toxic", ReferType(TypeRef.POISON), ReferStatus(StatusRef.POISONEDBADLY), 85, 10));
            attacks.Add(new Attack(93, "Confusion", ReferType(TypeRef.PSYCHIC), -50, 100, 4, ReferStatus(StatusRef.CONFUSED), 10, 25));
            attacks.Add(new Attack(94, "Psychic", ReferType(TypeRef.PSYCHIC), -90, 100, 1, 0, 0, 0, -1, 0, 10, 10));
            attacks.Add(new Attack(95, "Hypnosis", ReferType(TypeRef.PSYCHIC), ReferStatus(StatusRef.SLEPT), 60, 20));
            attacks.Add(new Attack(96, "Meditate", ReferType(TypeRef.PSYCHIC), 1, 0, 0, 0, 0, 40));
            attacks.Add(new Attack(97, "Agility", ReferType(TypeRef.PSYCHIC), 0, 0, 0, 0, 2, 40));
            attacks.Add(new Attack(98, "Quick Attack", ReferType(TypeRef.NORMAL), -40, 100, 4, 30)); ReferAttack(AttackRef.QUICKATTACK).priority = 1;
            attacks.Add(new Attack(99, "Rage", ReferType(TypeRef.NORMAL), -20, 100, 4, 20));      /* SPECIAL! */ ReferAttack(AttackRef.RAGE).mc = MoveCategory.MISC; ReferAttack(AttackRef.RAGE).hasIndividualScript = true; ReferAttack(AttackRef.RAGE).multiTurn = true; ReferAttack(AttackRef.RAGE).multiTurnMaximum = 999; ReferAttack(AttackRef.RAGE).userAtkMod = 1;
            attacks.Add(new Attack(100, "Teleport", ReferType(TypeRef.PSYCHIC), 20)); ReferAttack(AttackRef.TELEPORT).mc = MoveCategory.SWAPPER; ReferAttack(AttackRef.TELEPORT).userForceSwitchPokemon = true;
            attacks.Add(new Attack(101, "Night Shade", ReferType(TypeRef.GHOST), 15)); /* SPECIAL! */ ReferAttack(AttackRef.NIGHTSHADE).mc = MoveCategory.MISC; ReferAttack(AttackRef.NIGHTSHADE).hasIndividualScript = true;
            attacks.Add(new Attack(102, "Mimic", ReferType(TypeRef.NORMAL), 10));      /* SPECIAL! */ ReferAttack(AttackRef.MIMIC).mc = MoveCategory.MISC; ReferAttack(AttackRef.MIMIC).hasIndividualScript = true;
            attacks.Add(new Attack(103, "Screech", ReferType(TypeRef.NORMAL), 0, -2, 0, 0, 0, 85, 40));
            attacks.Add(new Attack(104, "Double Team", ReferType(TypeRef.NORMAL), 0, 0, 0, 0, 0, 15));  ReferAttack(AttackRef.DOUBLETEAM).userEvasionMod = 1;
            attacks.Add(new Attack(105, "Recover", ReferType(TypeRef.NORMAL), 20)); ReferAttack(AttackRef.RECOVER).mc = MoveCategory.HEAL; ReferAttack(AttackRef.RECOVER).healPercentage = 50;
            attacks.Add(new Attack(106, "Harden", ReferType(TypeRef.NORMAL), 0, 1, 0, 0, 0, 30));
            attacks.Add(new Attack(107, "Minimize", ReferType(TypeRef.NORMAL), 20)); /* SPECIAL! */ ReferAttack(AttackRef.MINIMIZE).hasIndividualScript = true;
            attacks.Add(new Attack(108, "Smokescreen", ReferType(TypeRef.NORMAL), 0, 0, 0, 0, 0, 100, 30)); ReferAttack(AttackRef.SMOKESCREEN).oppAccuracyMod = -1;
            attacks.Add(new Attack(109, "Confuse Ray", ReferType(TypeRef.GHOST), ReferStatus(StatusRef.CONFUSED), 100, 10));
            attacks.Add(new Attack(110, "Withdraw", ReferType(TypeRef.WATER), 0, 1, 0, 0, 0, 40));
            attacks.Add(new Attack(111, "Defense Curl", ReferType(TypeRef.NORMAL), 0, 1, 0, 0, 0, 40));
            attacks.Add(new Attack(112, "Barrier", ReferType(TypeRef.PSYCHIC), 30)); /* SPECIAL! */ ReferAttack(AttackRef.BARRIER).mc = MoveCategory.MISC; ReferAttack(AttackRef.BARRIER).hasIndividualScript = true; ReferAttack(AttackRef.BARRIER).multiTurn = true; ReferAttack(AttackRef.BARRIER).multiStrikeMinimum = 5;
            attacks.Add(new Attack(113, "Light Screen", ReferType(TypeRef.PSYCHIC), 30)); /* SPECIAL! */ ReferAttack(AttackRef.LIGHTSCREEN).mc = MoveCategory.MISC; ReferAttack(AttackRef.LIGHTSCREEN).hasIndividualScript = true; ReferAttack(AttackRef.LIGHTSCREEN).multiTurn = true; ReferAttack(AttackRef.LIGHTSCREEN).multiStrikeMinimum = 5;
            attacks.Add(new Attack(114, "Haze", ReferType(TypeRef.ICE), 30)); /* SPECIAL! */ ReferAttack(AttackRef.HAZE).mc = MoveCategory.MISC; ReferAttack(AttackRef.HAZE).hasIndividualScript = true;
            attacks.Add(new Attack(115, "Reflect", ReferType(TypeRef.PSYCHIC), 20)); /* SPECIAL! */ ReferAttack(AttackRef.REFLECT).mc = MoveCategory.MISC; ReferAttack(AttackRef.REFLECT).hasIndividualScript = true; ReferAttack(AttackRef.REFLECT).multiTurn = true; ReferAttack(AttackRef.REFLECT).multiStrikeMinimum = 5;
            attacks.Add(new Attack(116, "Focus Energy", ReferType(TypeRef.NORMAL), 0, 0, 0, 0, 0, 15)); ReferAttack(AttackRef.FOCUSENERGY).userCritRateMod = 2;
            attacks.Add(new Attack(117, "Bide", ReferType(TypeRef.NORMAL), 10));      /* SPECIAL! */ ReferAttack(AttackRef.BIDE).mc = MoveCategory.MISC; ReferAttack(AttackRef.BIDE).hasIndividualScript = true; ReferAttack(AttackRef.BIDE).multiTurn = true; ReferAttack(AttackRef.BIDE).multiTurnMaximum = 3;
            attacks.Add(new Attack(118, "Metronome", ReferType(TypeRef.NORMAL), 10));      /* SPECIAL! */ ReferAttack(AttackRef.METRONOME).mc = MoveCategory.MISC; ReferAttack(AttackRef.METRONOME).hasIndividualScript = true;
            attacks.Add(new Attack(119, "Mirror Move", ReferType(TypeRef.FLYING), 20));      /* SPECIAL! */ ReferAttack(AttackRef.MIRRORMOVE).mc = MoveCategory.MISC; ReferAttack(AttackRef.MIRRORMOVE).hasIndividualScript = true;
            attacks.Add(new Attack(120, "Self-Destruct", ReferType(TypeRef.NORMAL), -260, 100, 0, 5)); ReferAttack(AttackRef.SELFDESTRUCT).userHPMod = -9999;
            attacks.Add(new Attack(121, "Egg Bomb", ReferType(TypeRef.NORMAL), -100, 75, 4, 10));
            attacks.Add(new Attack(122, "Lick", ReferType(TypeRef.GHOST), -20, 100, 4, ReferStatus(StatusRef.PARALYZED), 30, 30));
            attacks.Add(new Attack(123, "Smog", ReferType(TypeRef.POISON), -20, 70, 4, ReferStatus(StatusRef.POISONED), 40, 20));
            attacks.Add(new Attack(124, "Sludge", ReferType(TypeRef.POISON), -65, 100, 4, ReferStatus(StatusRef.POISONED), 30, 20));
            attacks.Add(new Attack(125, "Bone Club", ReferType(TypeRef.GROUND), -65, 85, 4, ReferStatus(StatusRef.FLINCHED), 10, 20));
            attacks.Add(new Attack(126, "Fire Blast", ReferType(TypeRef.FIRE), -120, 85, 4, ReferStatus(StatusRef.BURNT), 10, 5));
            attacks.Add(new Attack(127, "Waterfall", ReferType(TypeRef.WATER), -80, 100, 4, 15));
            attacks.Add(new Attack(128, "Clamp", ReferType(TypeRef.WATER), -35, 75, 4, 10)); ReferAttack(AttackRef.CLAMP).multiTurn = true; ReferAttack(AttackRef.CLAMP).userFixedAmongTurns = true;
            attacks.Add(new Attack(129, "Swift", ReferType(TypeRef.NORMAL), -60, 999 /* Bypass */, 4, 20));
            attacks.Add(new Attack(130, "Skull Bash", ReferType(TypeRef.NORMAL), -130, 100, 4, 15)); ReferAttack(AttackRef.SKULLBASH).needsToCharge = true;
            attacks.Add(new Attack(131, "Spike Cannon", ReferType(TypeRef.NORMAL), -15, 85, 4, 20)); ReferAttack(AttackRef.SPIKECANNON).multiStrike = true;
            attacks.Add(new Attack(132, "Constrict", ReferType(TypeRef.NORMAL), -10, 100, 4, 0, 0, 0, 0, -1, 10, 35));
            attacks.Add(new Attack(133, "Amnesia", ReferType(TypeRef.PSYCHIC), 0, 0, 0, 2, 0, 20));
            attacks.Add(new Attack(134, "Kinesis", ReferType(TypeRef.PSYCHIC), 0, 0, 0, 0, 0, 80, 20)); ReferAttack(AttackRef.KINESIS).oppAccuracyMod = -1;
            attacks.Add(new Attack(135, "Soft Boiled", ReferType(TypeRef.NORMAL), 10)); ReferAttack(AttackRef.SOFTBOILED).mc = MoveCategory.HEAL; ReferAttack(AttackRef.SOFTBOILED).healPercentage = 50;
            attacks.Add(new Attack(136, "High Jump Kick", ReferType(TypeRef.FIGHT), -85, 90, 4, 20)); ReferAttack(AttackRef.JUMPKICK).missCrashDamage = -42;
            attacks.Add(new Attack(137, "Glare", ReferType(TypeRef.NORMAL), ReferStatus(StatusRef.PARALYZED), 75, 30)); ReferAttack(AttackRef.GLARE).typeChartIgnored = true;
            attacks.Add(new Attack(138, "Dream Eater", ReferType(TypeRef.PSYCHIC), -100, 100, 4, 15)); ReferAttack(AttackRef.DREAMEATER).oppDamageAffectsOnlyInStatus = ReferStatus(StatusRef.SLEPT);
            attacks.Add(new Attack(139, "Poison Gas", ReferType(TypeRef.POISON), ReferStatus(StatusRef.POISONED), 55, 40));
            attacks.Add(new Attack(140, "Barrage", ReferType(TypeRef.NORMAL), -15, 85, 4, 20)); ReferAttack(AttackRef.BARRAGE).multiStrike = true;
            attacks.Add(new Attack(141, "Leech Life", ReferType(TypeRef.BUG), -20, 100, 4, 15)); ReferAttack(AttackRef.LEECHLIFE).userHPMod = 10;
            attacks.Add(new Attack(142, "Lovely Kiss", ReferType(TypeRef.NORMAL), ReferStatus(StatusRef.SLEPT), 75, 10));
            attacks.Add(new Attack(143, "Sky Attack", ReferType(TypeRef.FLYING), -140, 90, 4, ReferStatus(StatusRef.FLINCHED), 30, 5)); ReferAttack(AttackRef.SKYATTACK).needsToCharge = true;
            attacks.Add(new Attack(144, "Transform", ReferType(TypeRef.NORMAL), 10));      /* SPECIAL! */ ReferAttack(AttackRef.TRANSFORM).mc = MoveCategory.MISC; ReferAttack(AttackRef.TRANSFORM).hasIndividualScript = true;
            attacks.Add(new Attack(145, "Bubble", ReferType(TypeRef.WATER), -20, 100, 4, 0, 0, 0, 0, -1, 10, 30));
            attacks.Add(new Attack(146, "Dizzy Punch", ReferType(TypeRef.NORMAL), -70, 100, 4, 10));
            attacks.Add(new Attack(147, "Spore", ReferType(TypeRef.GRASS), ReferStatus(StatusRef.SLEPT), 100, 15));
            attacks.Add(new Attack(148, "Flash", ReferType(TypeRef.NORMAL), 0, 0, 0, 0, 0, 70, 20)); ReferAttack(AttackRef.FLASH).oppAccuracyMod = -1;
            attacks.Add(new Attack(149, "Psywave", ReferType(TypeRef.PSYCHIC), 0, 100, 4, 15)); /* SPECIAL! */ ReferAttack(AttackRef.PSYWAVE).hasIndividualScript = true;
            attacks.Add(new Attack(150, "Splash", ReferType(TypeRef.NORMAL), 40));
            attacks.Add(new Attack(151, "Defense Curl", ReferType(TypeRef.POISON), 0, 2, 0, 0, 0, 40));
            attacks.Add(new Attack(152, "Crabhammer", ReferType(TypeRef.WATER), -90, 85, 32, 10));
            attacks.Add(new Attack(153, "Explosion", ReferType(TypeRef.NORMAL), -340, 100, 0, 5)); ReferAttack(AttackRef.EXPLOSION).userHPMod = -9999;
            attacks.Add(new Attack(154, "Fury Swipes", ReferType(TypeRef.NORMAL), -18, 80, 4, 15)); ReferAttack(AttackRef.FURYSWIPES).multiStrike = true;
            attacks.Add(new Attack(155, "Bonemerang", ReferType(TypeRef.GROUND), -50, 90, 4, 10)); ReferAttack(AttackRef.BONEMERANG).multiStrike = true; ReferAttack(AttackRef.BONEMERANG).multiStrikeMaximum = 2;
            attacks.Add(new Attack(156, "Rest", ReferType(TypeRef.PSYCHIC), 10)); ReferAttack(AttackRef.REST).mc = MoveCategory.HEAL; ReferAttack(AttackRef.REST).healPercentage = 100; ReferAttack(AttackRef.REST).userStatusEffect = ReferStatus(StatusRef.SLEPT);
            attacks.Add(new Attack(157, "Rock Slide", ReferType(TypeRef.ROCK), -75, 90, 4, 10));
            attacks.Add(new Attack(158, "Hyper Fang", ReferType(TypeRef.NORMAL), -80, 90, 4, ReferStatus(StatusRef.FLINCHED), 10, 15));
            attacks.Add(new Attack(159, "Sharpen", ReferType(TypeRef.NORMAL), 1, 0, 0, 0, 0, 30));
            attacks.Add(new Attack(160, "Conversion", ReferType(TypeRef.NORMAL), 30)); /* SPECIAL! */ ReferAttack(AttackRef.CONVERSION).hasIndividualScript = true;
            attacks.Add(new Attack(161, "Tri Attack", ReferType(TypeRef.NORMAL), -80, 100, 4, 10));
            attacks.Add(new Attack(162, "Super Fang", ReferType(TypeRef.NORMAL), 0, 90, 4, 10)); /* SPECIAL! */ ReferAttack(AttackRef.SUPERFANG).hasIndividualScript = true; ReferAttack(AttackRef.SUPERFANG).typeChartIgnored = true;
            attacks.Add(new Attack(163, "Slash", ReferType(TypeRef.NORMAL), -70, 100, 32, 20));
            attacks.Add(new Attack(164, "Substitute", ReferType(TypeRef.NORMAL), 10)); ReferAttack(AttackRef.SUBSTITUTE).userStatusEffect = ReferStatus(StatusRef.SUBSTITUTED); ReferAttack(AttackRef.SUBSTITUTE).userStatusProb = 100;
        }

        public static void BuildPokemon()
        {
            pokemons.Add(new Pokemon(0, "MISSINGNO."));
            //BULBASAUR
            pokemons.Add(new Pokemon(1, "Bulbasaur", 45, 49, 49, 65, 65, 45, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.TACKLE), 1 },
                { ReferAttack(AttackRef.GROWL), 4 },
                { ReferAttack(AttackRef.LEECHSEED), 7 },
                { ReferAttack(AttackRef.VINEWHIP), 10 },
                { ReferAttack(AttackRef.POISONPOWDER), 15 },
                { ReferAttack(AttackRef.SLEEPPOWDER), 15 },
                { ReferAttack(AttackRef.RAZORLEAF), 20 },
                //{ ReferAttack(AttackRef.SWEETSCENT), 25 },
                { ReferAttack(AttackRef.GROWTH), 32 },
                //{ ReferAttack(AttackRef.SYNTHESIS), 39 },
                { ReferAttack(AttackRef.SOLARBEAM), 46 }}, 
                ReferType(TypeRef.GRASS), ReferType(TypeRef.POISON), false, Properties.Resources.f1, Properties.Resources.b1, 7));

            //IVYSAUR
            pokemons.Add(new Pokemon(2, "Ivysaur", 60, 62, 63, 80, 80, 60, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.TACKLE), 1 },
                { ReferAttack(AttackRef.GROWL), 4 },
                { ReferAttack(AttackRef.LEECHSEED), 7 },
                { ReferAttack(AttackRef.VINEWHIP), 10 },
                { ReferAttack(AttackRef.POISONPOWDER), 15 },
                { ReferAttack(AttackRef.SLEEPPOWDER), 15 },
                { ReferAttack(AttackRef.RAZORLEAF), 22 },
                //{ ReferAttack(AttackRef.SWEETSCENT), 29 },
                { ReferAttack(AttackRef.GROWTH), 38 },
                //{ ReferAttack(AttackRef.SYNTHESIS), 47 },
                { ReferAttack(AttackRef.SOLARBEAM), 56 }},
                ReferType(TypeRef.GRASS), ReferType(TypeRef.POISON), false, Properties.Resources.f2, Properties.Resources.b2, 13));

            //VENUSAUR
            pokemons.Add(new Pokemon(3, "Venusaur", 80, 82, 83, 100, 100, 80, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.TACKLE), 1 },
                { ReferAttack(AttackRef.GROWL), 4 },
                { ReferAttack(AttackRef.LEECHSEED), 7 },
                { ReferAttack(AttackRef.VINEWHIP), 10 },
                { ReferAttack(AttackRef.POISONPOWDER), 15 },
                { ReferAttack(AttackRef.SLEEPPOWDER), 15 },
                { ReferAttack(AttackRef.RAZORLEAF), 22 },
                //{ ReferAttack(AttackRef.SWEETSCENT), 29 },
                { ReferAttack(AttackRef.GROWTH), 41 },
                //{ ReferAttack(AttackRef.SYNTHESIS), 53 },
                { ReferAttack(AttackRef.SOLARBEAM), 65 }},
                ReferType(TypeRef.GRASS), ReferType(TypeRef.POISON), false, Properties.Resources.f3, Properties.Resources.b3, 100));
            //CHARMANDER
            pokemons.Add(new Pokemon(4, "Charmander", 39, 52, 43, 60, 50, 65, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.SCRATCH), 1 },
                { ReferAttack(AttackRef.GROWL), 1 },
                { ReferAttack(AttackRef.CUT), 1 },
                { ReferAttack(AttackRef.EMBER), 7 },
                { ReferAttack(AttackRef.SMOKESCREEN), 13 },
                //{ ReferAttack(AttackRef.METALCLAW), 13 },
                { ReferAttack(AttackRef.RAGE), 19 },
                //{ ReferAttack(AttackRef.SCARYFACE), 25 },
                { ReferAttack(AttackRef.FLAMETHROWER), 31 },
                { ReferAttack(AttackRef.SLASH), 37 },
                { ReferAttack(AttackRef.DRAGONRAGE), 43 },
                { ReferAttack(AttackRef.FIRESPIN), 49 }},
                ReferType(TypeRef.FIRE), null, false, Properties.Resources.f4, Properties.Resources.b4, 8));
            //CHARMELEON
            pokemons.Add(new Pokemon(5, "Charmeleon", 58, 64, 58, 80, 65, 80, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.SCRATCH), 1 },
                { ReferAttack(AttackRef.GROWL), 1 },
                { ReferAttack(AttackRef.CUT), 1 },
                { ReferAttack(AttackRef.EMBER), 7 },
                { ReferAttack(AttackRef.SMOKESCREEN), 13 },
                //{ ReferAttack(AttackRef.METALCLAW), 13 },
                { ReferAttack(AttackRef.RAGE), 20 },
                //{ ReferAttack(AttackRef.SCARYFACE), 27 },
                { ReferAttack(AttackRef.FLAMETHROWER), 34 },
                { ReferAttack(AttackRef.SLASH), 41 },
                { ReferAttack(AttackRef.DRAGONRAGE), 48 },
                { ReferAttack(AttackRef.FIRESPIN), 55 }},
                ReferType(TypeRef.FIRE), null, false, Properties.Resources.f5, Properties.Resources.b5, 19));
            //CHARIZARD
            pokemons.Add(new Pokemon(6, "Charizard", 78, 84, 78, 109, 85, 100, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.SCRATCH), 1 },
                { ReferAttack(AttackRef.GROWL), 1 },
                { ReferAttack(AttackRef.CUT), 1 },
                { ReferAttack(AttackRef.FLY), 1 },
                { ReferAttack(AttackRef.EMBER), 7 },
                { ReferAttack(AttackRef.SMOKESCREEN), 13 },
                //{ ReferAttack(AttackRef.METALCLAW), 13 },
                { ReferAttack(AttackRef.RAGE), 20 },
                //{ ReferAttack(AttackRef.SCARYFACE), 27 },
                { ReferAttack(AttackRef.FLAMETHROWER), 34 },
                { ReferAttack(AttackRef.SLASH), 44 },
                { ReferAttack(AttackRef.DRAGONRAGE), 54 },
                { ReferAttack(AttackRef.FIRESPIN), 64 }},
                ReferType(TypeRef.FIRE), ReferType(TypeRef.FLYING), false, Properties.Resources.f6, Properties.Resources.b6, 90));
            //SQUIRTLE
            pokemons.Add(new Pokemon(7, "Squirtle", 44, 48, 65, 50, 64, 43, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.TACKLE), 1 },
                { ReferAttack(AttackRef.TAILWHIP), 1 },
                { ReferAttack(AttackRef.SURF), 1 },
                { ReferAttack(AttackRef.STRENGTH), 1 },
                { ReferAttack(AttackRef.BUBBLE), 7 },
                { ReferAttack(AttackRef.WITHDRAW), 10 },
                { ReferAttack(AttackRef.WATERGUN), 13 },
                { ReferAttack(AttackRef.BITE), 18 },
                //{ ReferAttack(AttackRef.RAPIDSPIN), 23 },
                //{ ReferAttack(AttackRef.PROTECT), 28 },
                //{ ReferAttack(AttackRef.RAINDANCE), 33 },
                { ReferAttack(AttackRef.SKULLBASH), 40 },
                { ReferAttack(AttackRef.HYDROPUMP), 47 }},
                ReferType(TypeRef.WATER), null, false, Properties.Resources.f7, Properties.Resources.b7, 9));
            //WARTORTLE
            pokemons.Add(new Pokemon(8, "Wartortle", 59, 63, 80, 65, 80, 58, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.TACKLE), 1 },
                { ReferAttack(AttackRef.TAILWHIP), 1 },
                { ReferAttack(AttackRef.SURF), 1 },
                { ReferAttack(AttackRef.STRENGTH), 1 },
                { ReferAttack(AttackRef.BUBBLE), 7 },
                { ReferAttack(AttackRef.WITHDRAW), 10 },
                { ReferAttack(AttackRef.WATERGUN), 13 },
                { ReferAttack(AttackRef.BITE), 19 },
                //{ ReferAttack(AttackRef.RAPIDSPIN), 25 },
                //{ ReferAttack(AttackRef.PROTECT), 31 },
                //{ ReferAttack(AttackRef.RAINDANCE), 37 },
                { ReferAttack(AttackRef.SKULLBASH), 45 },
                { ReferAttack(AttackRef.HYDROPUMP), 53 }},
                ReferType(TypeRef.WATER), null, false, Properties.Resources.f8, Properties.Resources.b8, 22));
            //BLASTOISE
            pokemons.Add(new Pokemon(9, "Blastoise", 79, 83, 100, 85, 105, 78, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.TACKLE), 1 },
                { ReferAttack(AttackRef.TAILWHIP), 1 },
                { ReferAttack(AttackRef.SURF), 1 },
                { ReferAttack(AttackRef.STRENGTH), 1 },
                { ReferAttack(AttackRef.BUBBLE), 7 },
                { ReferAttack(AttackRef.WITHDRAW), 10 },
                { ReferAttack(AttackRef.WATERGUN), 13 },
                { ReferAttack(AttackRef.BITE), 19 },
                //{ ReferAttack(AttackRef.RAPIDSPIN), 25 },
                //{ ReferAttack(AttackRef.PROTECT), 31 },
                //{ ReferAttack(AttackRef.RAINDANCE), 42 },
                { ReferAttack(AttackRef.SKULLBASH), 55 },
                { ReferAttack(AttackRef.HYDROPUMP), 68 }},
                ReferType(TypeRef.WATER), null, false, Properties.Resources.f9, Properties.Resources.b9, 85));
            //CATERPIE
            pokemons.Add(new Pokemon(10, "Caterpie", 45, 30, 35, 20, 20, 45, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.TACKLE), 1 },
                { ReferAttack(AttackRef.STRINGSHOT), 1 }},
                ReferType(TypeRef.BUG), null, false, Properties.Resources.f10, Properties.Resources.b10, 3));
            //METAPOD
            pokemons.Add(new Pokemon(11, "Metapod", 50, 20, 55, 25, 25, 30, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.HARDEN), 1 }},
                ReferType(TypeRef.BUG), null, false, Properties.Resources.f11, Properties.Resources.b11, 10));
            //BUTTERFREE
            pokemons.Add(new Pokemon(12, "Butterfree", 60, 45, 50, 80, 80, 70, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.TOXIC), 1 },
                { ReferAttack(AttackRef.FLASH), 1 },
                { ReferAttack(AttackRef.CONFUSION), 10 },
                { ReferAttack(AttackRef.POISONPOWDER), 13 },
                { ReferAttack(AttackRef.STUNSPORE), 14 },
                { ReferAttack(AttackRef.SLEEPPOWDER), 15 },
                { ReferAttack(AttackRef.SUPERSONIC), 18 },
                { ReferAttack(AttackRef.WHIRLWIND), 23 },
                { ReferAttack(AttackRef.GUST), 28 },
                { ReferAttack(AttackRef.PSYBEAM), 34 }/*,
                { ReferAttack(AttackRef.SAFEGUARD), 40 }*/},
                ReferType(TypeRef.BUG), ReferType(TypeRef.FLYING), false, Properties.Resources.f12, Properties.Resources.b12, 32));
            //WEEDLE
            pokemons.Add(new Pokemon(13, "Weedle", 40, 35, 30, 20, 20, 50, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.POISONSTING), 1 },
                { ReferAttack(AttackRef.STRINGSHOT), 1 }},
                ReferType(TypeRef.BUG), ReferType(TypeRef.POISON), false, Properties.Resources.f13, Properties.Resources.b13, 3));
            //KAKUNA
            pokemons.Add(new Pokemon(14, "Kakuna", 45, 25, 50, 25, 25, 35, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.HARDEN), 1 }},
                ReferType(TypeRef.BUG), ReferType(TypeRef.POISON), false, Properties.Resources.f14, Properties.Resources.b14, 10));
            //BEEDRILL
            pokemons.Add(new Pokemon(15, "Beedrill", 65, 80, 40, 45, 80, 75, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.TOXIC), 1 },
                { ReferAttack(AttackRef.CUT), 1 },
                { ReferAttack(AttackRef.FURYATTACK), 10 },
                { ReferAttack(AttackRef.FOCUSENERGY), 15 },
                { ReferAttack(AttackRef.TWINEEDLE), 20 },
                { ReferAttack(AttackRef.RAGE), 25 },
                //{ ReferAttack(AttackRef.PURSUIT), 30 },
                { ReferAttack(AttackRef.PINMISSILE), 35 },
                { ReferAttack(AttackRef.AGILITY), 40 }},
                ReferType(TypeRef.BUG), ReferType(TypeRef.POISON), false, Properties.Resources.f15, Properties.Resources.b15, 30));
            //PIDGEY
            pokemons.Add(new Pokemon(16, "Pidgey", 40, 45, 40, 35, 35, 35, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.TACKLE), 1 },
                { ReferAttack(AttackRef.FLY), 1 },
                { ReferAttack(AttackRef.SANDATTACK), 5 },
                { ReferAttack(AttackRef.GUST), 9 },
                { ReferAttack(AttackRef.QUICKATTACK), 13 },
                { ReferAttack(AttackRef.WHIRLWIND), 19 },
                { ReferAttack(AttackRef.WINGATTACK), 25 },
                { ReferAttack(AttackRef.AGILITY), 39 },
                { ReferAttack(AttackRef.MIRRORMOVE), 47 }},
                ReferType(TypeRef.NORMAL), ReferType(TypeRef.FLYING), false, Properties.Resources.f16, Properties.Resources.b16, 2));
            //PIDGEOTTO
            pokemons.Add(new Pokemon(17, "Pidgeotto", 63, 60, 55, 50, 50, 71, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.TACKLE), 1 },
                { ReferAttack(AttackRef.FLY), 1 },
                { ReferAttack(AttackRef.SANDATTACK), 5 },
                { ReferAttack(AttackRef.GUST), 9 },
                { ReferAttack(AttackRef.QUICKATTACK), 13 },
                { ReferAttack(AttackRef.WHIRLWIND), 20 },
                { ReferAttack(AttackRef.WINGATTACK), 27 },
                { ReferAttack(AttackRef.AGILITY), 43 },
                { ReferAttack(AttackRef.MIRRORMOVE), 52 }},
                ReferType(TypeRef.NORMAL), ReferType(TypeRef.FLYING), false, Properties.Resources.f17, Properties.Resources.b17, 30));
            //PIDGEOT
            pokemons.Add(new Pokemon(18, "Pidgeot", 83, 80, 75, 70, 70, 91, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.TACKLE), 1 },
                { ReferAttack(AttackRef.FLY), 1 },
                { ReferAttack(AttackRef.SANDATTACK), 5 },
                { ReferAttack(AttackRef.GUST), 9 },
                { ReferAttack(AttackRef.QUICKATTACK), 13 },
                { ReferAttack(AttackRef.WHIRLWIND), 20 },
                { ReferAttack(AttackRef.WINGATTACK), 27 },
                { ReferAttack(AttackRef.AGILITY), 48 },
                { ReferAttack(AttackRef.MIRRORMOVE), 62 }},
                ReferType(TypeRef.NORMAL), ReferType(TypeRef.FLYING), false, Properties.Resources.f18, Properties.Resources.b18, 40));
            //RATTATA
            pokemons.Add(new Pokemon(19, "Rattata", 30, 56, 35, 25, 35, 72, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.TACKLE), 1 },
                { ReferAttack(AttackRef.CUT), 1 },
                { ReferAttack(AttackRef.TAILWHIP), 1 },
                { ReferAttack(AttackRef.QUICKATTACK), 7 },
                { ReferAttack(AttackRef.HYPERFANG), 13 },
                { ReferAttack(AttackRef.FOCUSENERGY), 20 },
                //{ ReferAttack(AttackRef.PURSUIT), 27 },
                { ReferAttack(AttackRef.SUPERFANG), 34 }},
                ReferType(TypeRef.NORMAL), null, false, Properties.Resources.f19, Properties.Resources.b19, 4));
            //RATICATE
            pokemons.Add(new Pokemon(20, "Raticate", 55, 81, 60, 50, 70, 97, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.TACKLE), 1 },
                { ReferAttack(AttackRef.CUT), 1 },
                { ReferAttack(AttackRef.TAILWHIP), 1 },
                { ReferAttack(AttackRef.STRENGTH), 1 },
                { ReferAttack(AttackRef.QUICKATTACK), 7 },
                { ReferAttack(AttackRef.HYPERFANG), 13 },
                { ReferAttack(AttackRef.FOCUSENERGY), 20 },
                //{ ReferAttack(AttackRef.SCARYFACE), 20 },
                //{ ReferAttack(AttackRef.PURSUIT), 30 },
                { ReferAttack(AttackRef.SUPERFANG), 40 }},
                ReferType(TypeRef.NORMAL), null, false, Properties.Resources.f20, Properties.Resources.b20, 19));
            //SPEAROW
            pokemons.Add(new Pokemon(21, "Spearow", 40, 60, 30, 31, 31, 70, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.PECK), 1 },
                { ReferAttack(AttackRef.FLY), 1 },
                { ReferAttack(AttackRef.GROWL), 1 },
                { ReferAttack(AttackRef.LEER), 7 },
                { ReferAttack(AttackRef.FURYATTACK), 13 },
                //{ ReferAttack(AttackRef.PURSUIT), 19 },
                { ReferAttack(AttackRef.MIRRORMOVE), 31 },
                { ReferAttack(AttackRef.DRILLPECK), 37 },
                { ReferAttack(AttackRef.AGILITY), 43 }},
                ReferType(TypeRef.NORMAL), ReferType(TypeRef.FLYING), false, Properties.Resources.f21, Properties.Resources.b21, 2));
            //FEAROW
            pokemons.Add(new Pokemon(22, "Fearow", 65, 90, 65, 61, 61, 100, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.PECK), 1 },
                { ReferAttack(AttackRef.FLY), 1 },
                { ReferAttack(AttackRef.GROWL), 1 },
                { ReferAttack(AttackRef.LEER), 7 },
                { ReferAttack(AttackRef.FURYATTACK), 13 },
                //{ ReferAttack(AttackRef.PURSUIT), 26 },
                { ReferAttack(AttackRef.MIRRORMOVE), 32 },
                { ReferAttack(AttackRef.DRILLPECK), 40 },
                { ReferAttack(AttackRef.AGILITY), 47 }},
                ReferType(TypeRef.NORMAL), ReferType(TypeRef.FLYING), false, Properties.Resources.f22, Properties.Resources.b22, 38));
            //EKANS
            pokemons.Add(new Pokemon(23, "Ekans", 35, 60, 44, 40, 54, 55, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.WRAP), 1 },
                { ReferAttack(AttackRef.STRENGTH), 1 },
                { ReferAttack(AttackRef.LEER), 1 },
                { ReferAttack(AttackRef.POISONSTING), 9 },
                { ReferAttack(AttackRef.BITE), 15 },
                { ReferAttack(AttackRef.GLARE), 23 },
                { ReferAttack(AttackRef.SCREECH), 29 },
                { ReferAttack(AttackRef.ACID), 37 },
                { ReferAttack(AttackRef.HAZE), 43 }},
                ReferType(TypeRef.POISON), null, false, Properties.Resources.f23, Properties.Resources.b23, 7));
            //ARBOK
            pokemons.Add(new Pokemon(24, "Arbok", 60, 85, 69, 65, 79, 80, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.WRAP), 1 },
                { ReferAttack(AttackRef.STRENGTH), 1 },
                { ReferAttack(AttackRef.LEER), 1 },
                { ReferAttack(AttackRef.POISONSTING), 9 },
                { ReferAttack(AttackRef.BITE), 15 },
                { ReferAttack(AttackRef.GLARE), 25 },
                { ReferAttack(AttackRef.SCREECH), 33 },
                { ReferAttack(AttackRef.ACID), 43 },
                { ReferAttack(AttackRef.HAZE), 51 }},
                ReferType(TypeRef.POISON), null, false, Properties.Resources.f24, Properties.Resources.b24, 65));
            //PIKACHU
            pokemons.Add(new Pokemon(25, "Pikachu", 35, 55, 30, 50, 40, 90, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.FLASH), 1 },
                { ReferAttack(AttackRef.STRENGTH), 1 },
                { ReferAttack(AttackRef.THUNDERSHOCK), 1 },
                { ReferAttack(AttackRef.GROWL), 1 },
                { ReferAttack(AttackRef.TAILWHIP), 6 },
                { ReferAttack(AttackRef.THUNDERWAVE), 8 },
                { ReferAttack(AttackRef.QUICKATTACK), 11 },
                { ReferAttack(AttackRef.DOUBLETEAM), 15 },
                { ReferAttack(AttackRef.SLAM), 20 },
                { ReferAttack(AttackRef.THUNDERBOLT), 26 },
                { ReferAttack(AttackRef.AGILITY), 33 },
                { ReferAttack(AttackRef.THUNDER), 41 },
                { ReferAttack(AttackRef.LIGHTSCREEN), 50 }},
                ReferType(TypeRef.ELECTRIC), null, false, Properties.Resources.f25, Properties.Resources.b25, 6));
            //RAICHU
            pokemons.Add(new Pokemon(26, "Raichu", 60, 90, 55, 90, 80, 100, new AttackPair<Attack, int> {
                { ReferAttack(AttackRef.FLASH), 1 },
                { ReferAttack(AttackRef.STRENGTH), 1 },
                { ReferAttack(AttackRef.THUNDERBOLT), 1 },
                { ReferAttack(AttackRef.QUICKATTACK), 1 },
                { ReferAttack(AttackRef.THUNDERSHOCK), 1 },
                { ReferAttack(AttackRef.GROWL), 1 },
                { ReferAttack(AttackRef.TAILWHIP), 1 },
                { ReferAttack(AttackRef.THUNDERWAVE), 8 },
                { ReferAttack(AttackRef.DOUBLETEAM), 15 },
                { ReferAttack(AttackRef.SLAM), 20 },
                { ReferAttack(AttackRef.THUNDERBOLT), 26 },
                { ReferAttack(AttackRef.AGILITY), 33 },
                { ReferAttack(AttackRef.THUNDER), 41 },
                { ReferAttack(AttackRef.LIGHTSCREEN), 50 }},
                ReferType(TypeRef.ELECTRIC), null, false, Properties.Resources.f26, Properties.Resources.b26, 30));
        }
    }
}
