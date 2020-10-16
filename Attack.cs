using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace PokemonFightAI
{
    public enum MoveCategory
    {
        DAMAGING,
        OPSTATMOD,
        USRSTATMOD,
        OPSTATUSCHNG,
        DMGSTATUSCHNG,
        DMGSTATMOD,
        SWAPPER,
        ONEHITKO,
        HEAL,
        MISC
    }

     class Attack
    {
        public int id;
        public string name;
        public PokeType type = DataStorage.ReferType(TypeRef.UNKNOWN);
        public MoveCategory mc;
        public int userHPMod = 0;
        public int userAtkMod = 0;
        public int userDefMod = 0;
        public int userSpAtkMod = 0;
        public int userSpDefMod = 0;
        public int userSpeedMod = 0;
        public int userAccuracyMod = 0;
        public int userEvasionMod = 0;
        public int userCritRateMod = 0;
        public int oppHPMod = 0;
        public int oppAtkMod = 0;
        public int oppDefMod = 0;
        public int oppSpAtkMod = 0;
        public int oppSpDefMod = 0;
        public int oppSpeedMod = 0;
        public int oppAccuracyMod = 0;
        public int oppEvasionMod = 0;
        public int oppCritRateMod = 0;
        public int modifierProb = 100;
        public int accuracy = 100;
        public int critThreshold = 1;
        public Status userStatusEffect;
        public Status oppStatusEffect;
        public int userStatusProb = 0;
        public int oppStatusProb = 0;
        public int PP = 1;

        // SPECIAL PARAMETERS
        public bool multiStrike = false;
        public int priority = 0;
        public int healPercentage = 0;
        public bool needsToCharge = false;
        public bool needsToRecharge = false;
        public bool fixedDamage = true;
        public bool defreeze = false;
        public bool typeChartIgnored = false;
        public int multiStrikeMinimum = 2;
        public int multiStrikeMaximum = 5;
        public bool multiTurn = false;
        public bool oppFixedAmongTurns = true;
        public bool userFixedAmongTurns = true;
        public int multiTurnMinimum = 2;
        public int multiTurnMaximum = 5;
        public bool hasIndividualScript = false;
        public bool oppForceSwitchPokemon = false;
        public bool userForceSwitchPokemon = false;
        public int missCrashDamage = 0;
        public PokeType oppStatusEffectRestrictionType;
        public Status oppDamageAffectsOnlyInStatus;

        // NON-FIXED VARIABLES FOR CONTINUATION
        public int continuationTurnsChosen = 1;
        public int continuationTurn = 1;

        // Damaging Move
        public Attack(int id, string name, PokeType type, int oppHPMod, int accuracy, int critThreshold, int PP)
        {
            mc = MoveCategory.DAMAGING;
            this.id = id;
            this.name = name;
            this.type = type;
            this.oppHPMod = oppHPMod;
            this.accuracy = accuracy;
            this.critThreshold = critThreshold;
            this.PP = PP;
        }

        // Opponent Stat Modifier Move
        public Attack(int id, string name, PokeType type, int oppAtkMod, int oppDefMod, int oppSpAtkMod, int oppSpDefMod, int oppSpeedMod, int accuracy, int PP)
        {
            mc = MoveCategory.OPSTATMOD;
            this.id = id;
            this.name = name;
            this.type = type;
            this.oppAtkMod = oppAtkMod;
            this.oppDefMod = oppDefMod;
            this.oppSpAtkMod = oppSpAtkMod;
            this.oppSpDefMod = oppSpDefMod;
            this.oppSpeedMod = oppSpeedMod;
            this.accuracy = accuracy;
            this.PP = PP;
        }

        // User Stat Modifier Move
        public Attack(int id, string name, PokeType type, int userAtkMod, int userDefMod, int userSpAtkMod, int userSpDefMod, int userSpeedMod, int PP)
        {
            mc = MoveCategory.USRSTATMOD;
            this.id = id;
            this.name = name;
            this.type = type;
            this.userAtkMod = userAtkMod;
            this.userDefMod = userDefMod;
            this.userSpAtkMod = userSpAtkMod;
            this.userSpDefMod = userSpDefMod;
            this.userSpeedMod = userSpeedMod;
            this.PP = PP;
        }

        // Opponent Status-changer Move
        public Attack(int id, string name, PokeType type, Status oppStatusEffect, int accuracy, int PP)
        {
            mc = MoveCategory.OPSTATUSCHNG;
            this.id = id;
            this.name = name;
            this.type = type;
            this.oppStatusEffect = oppStatusEffect;
            oppStatusProb = 100;
            this.accuracy = accuracy;
            this.PP = PP;
        }

        // Damaging Move with Status-changer Effect
        public Attack(int id, string name, PokeType type, int oppHPMod, int accuracy, int critThreshold, Status oppStatusEffect, int oppStatusProb, int PP)
        {
            mc = MoveCategory.DMGSTATUSCHNG;
            this.id = id;
            this.name = name;
            this.type = type;
            this.oppHPMod = oppHPMod;
            this.accuracy = accuracy;
            this.critThreshold = critThreshold;
            this.oppStatusEffect = oppStatusEffect;
            this.oppStatusProb = oppStatusProb;
            this.PP = PP;
        }

        // Damaging Move with Stat Modifier Effect
        public Attack(int id, string name, PokeType type, int oppHPMod, int accuracy, int critThreshold, int oppAtkMod, int oppDefMod, int oppSpAtkMod, int oppSpDefMod, int oppSpeedMod, int modifierProb, int PP)
        {
            mc = MoveCategory.DMGSTATMOD;
            this.id = id;
            this.name = name;
            this.type = type;
            this.oppHPMod = oppHPMod;
            this.accuracy = accuracy;
            this.critThreshold = critThreshold;
            this.oppAtkMod = oppAtkMod;
            this.oppDefMod = oppDefMod;
            this.oppSpAtkMod = oppSpAtkMod;
            this.oppSpDefMod = oppSpDefMod;
            this.oppSpeedMod = oppSpeedMod;
            this.modifierProb = modifierProb;
            this.PP = PP;
        }

        // Miscellaneous Move
        public Attack(int id, string name, PokeType type, int userHPMod, int userAtkMod, int userDefMod, int userSpAtkMod, int userSpDefMod, int userSpeedMod,
        int oppHPMod, int oppAtkMod, int oppDefMod, int oppSpAtkMod, int oppSpDefMod, int oppSpeedMod, int accuracy, int critThreshold, 
        Status userStatusEffect, Status oppStatusEffect, int userStatusProb, int oppStatusProb, int PP)
        {
            mc = MoveCategory.MISC;
            this.id = id;
            this.name = name;
            this.type = type;
            this.userHPMod = userHPMod;
            this.userAtkMod = userAtkMod;
            this.userDefMod = userDefMod;
            this.userSpAtkMod = userSpAtkMod;
            this.userSpDefMod = userSpDefMod;
            this.userSpeedMod = userSpeedMod;
            this.oppHPMod = oppHPMod;
            this.oppAtkMod = oppAtkMod;
            this.oppDefMod = oppDefMod;
            this.oppSpAtkMod = oppSpAtkMod;
            this.oppSpDefMod = oppSpDefMod;
            this.oppSpeedMod = oppSpeedMod;
            this.accuracy = accuracy;
            this.critThreshold = critThreshold;
            this.userStatusEffect = userStatusEffect;
            this.userStatusProb = userStatusProb;
            this.PP = PP;
        }

        public Attack(int id, string name, PokeType type, int PP)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.PP = PP;
        }

        public double GetTypeEffectivenessModifier(PokeType attack, PokeType type1, PokeType type2)
        {
            double modval_type1 = 1, modval_type2 = 1;
            if(attack.strongTo != null) if (Array.Exists(attack.strongTo, a => a == type1)) modval_type1 = 2;
            if(attack.weakTo != null) if (Array.Exists(attack.weakTo, a => a == type1)) modval_type1 = 0.5;
            if(attack.notEffectiveTo != null) if (Array.Exists(attack.notEffectiveTo, a => a == type1)) modval_type1 = 0;
            if(type2 != null) {
                if (attack.strongTo != null) if (Array.Exists(attack.strongTo, a => a == type2)) modval_type2 = 2;
                if (attack.weakTo != null) if (Array.Exists(attack.weakTo, a => a == type2)) modval_type2 = 0.5;
                if (attack.notEffectiveTo != null) if (Array.Exists(attack.notEffectiveTo, a => a == type2)) modval_type2 = 0;
            }
            return (modval_type1 * modval_type2);
        }

        public void DecideSpecialOrNormalModifier(PokeType type, PokeInstance agent, PokeInstance opponent, out float atk, out float def)
        {
            if(type == DataStorage.ReferType(TypeRef.NORMAL) || type == DataStorage.ReferType(TypeRef.FIGHT))
            {
                atk = agent.CertainValue(agent.cAttack, agent.sAttack);
                def = opponent.CertainValue(opponent.cAttack, opponent.sAttack);
            }
            else
            {
                atk = agent.CertainValue(agent.cSpAtk, agent.sSpAtk);
                def = opponent.CertainValue(opponent.cSpDef, opponent.sSpDef);
            }
        }

        // MULTI STRIKE
        public void MultiStrike(PokeInstance agent, PokeInstance opponent)
        {
            int strikeCount = 0;
            DecideSpecialOrNormalModifier(type, agent, opponent, out float agnatk, out float oppdef);
            if ((!opponent.digging || type == DataStorage.ReferType(TypeRef.GROUND)) &&
            (!opponent.flight || type == DataStorage.ReferType(TypeRef.FLYING)))
            {
                double modifier;
                float newBase = 1, startBase = 1;
                int exactDamage;
                if (multiStrikeMaximum - multiStrikeMinimum != 0)
                    strikeCount = (new Random().Next() % (multiStrikeMaximum - multiStrikeMinimum)) + multiStrikeMinimum;
                else
                    strikeCount = multiStrikeMaximum;
                int accuracyCalculated = (int)Math.Floor(Math.Pow(1.2F, agent.sAccuracy) * 100);
                int evasionCalculated = (int)Math.Floor(Math.Pow(1.2F, agent.sEvasion) * 100);
                Debug.WriteLine("Accuracy equation: " + accuracyCalculated + "/" + evasionCalculated);
                int probability = accuracy * (accuracyCalculated / evasionCalculated);
                // TYPE MODIFIER
                if ((modifier = GetTypeEffectivenessModifier(type, opponent.p.type1, opponent.p.type2)) == 0)
                {
                    BattleMechanics.form.WriteAuto("BUT IT'S UNEFFECTIVE!");
                    Debug.WriteLine(modifier + " IS THE MODIFIER!");
                    Debug.WriteLine("THE COEFFICIENT IS " + newBase + "!");
                    newBase = (int)(newBase * modifier);
                    startBase = newBase;
                }
                else
                {
                    for (int i = 0; i < strikeCount && opponent.remHP > 0; i++) {
                        if (i > 0) newBase = startBase;
                        if (CalculateProbability(probability))
                        {

                            if (critThreshold != 0)
                            {
                                float t = agent.CertainValue((agent.CertainValue(agent.cSpeed, agent.sSpeed) + 76) * 100 * critThreshold / 4096, agent.sCritRate);
                                Debug.WriteLine(t + " IS A CRITICAL PROBABILITY VALUE!");
                                if (CalculateProbability((int)t) && i == 0)
                                {
                                    newBase *= (2 * ((float)agent.level) + 5) / (((float)agent.level) + 5); // CRIT MODIFIER
                                    Debug.WriteLine("THE COEFFICIENT IS " + newBase + "!");
                                    BattleMechanics.form.WriteAuto("IT'S A CRITICAL HIT!");
                                }
                            }
                            if (agent.status == DataStorage.ReferStatus(StatusRef.BURNT)) newBase = newBase / 2; // BURN MODIFIER
                            Debug.WriteLine("THE COEFFICIENT IS " + newBase + "!");
                            newBase = (newBase * (((new Random().Next() % 15) + 86) / (float)100)); // RANDOM MODIFIER
                            Debug.WriteLine("THE COEFFICIENT IS " + newBase + "!");
                            // EXACT DAMAGE
                            exactDamage = (int)((((2 * ((float)agent.level)) / 5 + 2) * ((float)oppHPMod * -1) * (agnatk / oppdef)) / 50);
                            Debug.WriteLine(exactDamage + " WITHOUT MODIFIER!");
                            exactDamage = (int)((exactDamage + 2) * modifier * newBase);
                            Debug.WriteLine(exactDamage + " HIT THAT DAMAGE!");
                            opponent.remHP -= exactDamage;
                            if (opponent.remHP <= 0) { opponent.remHP = 0; }
                            BattleMechanics.differentationControl = new Thread(new ThreadStart(BattleMechanics.form.differentiate));
                            BattleMechanics.differentationControl.Start();
                            BattleMechanics.differentationControl.Join();
                            if (opponent.remHP <= 0) { BattleMechanics.Faint(opponent); }
                            BattleMechanics.form.WriteAuto("HIT!");
                        }
                        else
                        {
                            // MISSED
                            BattleMechanics.form.Write("MISS!");
                        }
                    }
                    if (modifier < 1) BattleMechanics.form.WriteAuto(agent.p.name + " HIT " + opponent.p.name + "\n" + strikeCount + " TIME(S) AND IT'S NOT VERY EFFECTIVE!");
                    if (modifier == 1) BattleMechanics.form.WriteAuto(agent.p.name + " HIT " + opponent.p.name + "\n" + strikeCount + " TIME(S) FOR SOME DAMAGE!");
                    if (modifier > 1) BattleMechanics.form.WriteAuto(agent.p.name + " HIT " + opponent.p.name + "\n" + strikeCount + " TIME(S) AND IT'S SUPER EFFECTIVE!");
                }
            }
            else
            {
                // FAILED DUE TO DIG/FLY
                BattleMechanics.form.WriteAuto("BUT IT FAILED!");
            }
        }

        public void SingleStrike(PokeInstance agent, PokeInstance opponent)
        {
            DecideSpecialOrNormalModifier(type, agent, opponent, out float agnatk, out float oppdef);
            double modifier;
            float newBase = 1;
            int exactDamage;
            if ((!opponent.digging || type == DataStorage.ReferType(TypeRef.GROUND)) &&
            (!opponent.flight || type == DataStorage.ReferType(TypeRef.FLYING)))
            {
                int accuracyCalculated = (int)Math.Floor(Math.Pow(1.2F, agent.sAccuracy) * 100);
                int evasionCalculated = (int)Math.Floor(Math.Pow(1.2F, agent.sEvasion) * 100);
                Debug.WriteLine("Accuracy equation: " + accuracyCalculated + "/" + evasionCalculated);
                int probability = (int) (accuracy * (float) (accuracyCalculated / evasionCalculated));
                if (CalculateProbability(probability))
                {
                    // IF DAMAGING TYPE
                    if (oppHPMod < 0)
                    {

                        // TYPE MODIFIER
                        if ((modifier = GetTypeEffectivenessModifier(type, opponent.p.type1, opponent.p.type2)) == 0)
                        {
                            BattleMechanics.form.WriteAuto("BUT IT'S UNEFFECTIVE!");
                        }
                        else
                        {
                            Debug.WriteLine(modifier + " IS THE MODIFIER!");
                            Debug.WriteLine("THE COEFFICIENT IS " + newBase + "!");
                            newBase = (int)(newBase * modifier);
                            if (modifier < 1) BattleMechanics.form.WriteAuto(agent.p.name + " HIT " + opponent.p.name + "\nAND IT'S NOT VERY EFFECTIVE!");
                            if (modifier == 1) BattleMechanics.form.WriteAuto(agent.p.name + " HIT " + opponent.p.name + "\nFOR SOME DAMAGE!");
                            if (modifier > 1) BattleMechanics.form.WriteAuto(agent.p.name + " HIT " + opponent.p.name + "\nAND IT'S SUPER EFFECTIVE!");
                            if (critThreshold != 0)
                            {
                                float t = agent.CertainValue((agent.CertainValue(agent.cSpeed, agent.sSpeed) + 76) * 100 * critThreshold / 4096, agent.sCritRate);
                                Debug.WriteLine(t + " IS A CRITICAL PROBABILITY VALUE!");
                                if (CalculateProbability((int)t))
                                {
                                    newBase *= (2 * ((float)agent.level) + 5) / (((float)agent.level) + 5); // CRIT MODIFIER
                                    Debug.WriteLine("THE COEFFICIENT IS " + newBase + "!");
                                    BattleMechanics.form.WriteAuto("IT'S A CRITICAL HIT!");
                                }
                            }
                            if (agent.status == DataStorage.ReferStatus(StatusRef.BURNT)) newBase = newBase / 2; // BURN MODIFIER
                            Debug.WriteLine("THE COEFFICIENT IS " + newBase + "!");
                            newBase = (newBase * (((new Random().Next() % 15) + 86) / (float)100)); // RANDOM MODIFIER
                            Debug.WriteLine("THE COEFFICIENT IS " + newBase + "!");
                            // EXACT DAMAGE
                            exactDamage = (int)((((2 * ((float)agent.level)) / 5 + 2) * ((float)oppHPMod * -1) * (agnatk / oppdef)) / 50);
                            Debug.WriteLine(exactDamage + " WITHOUT MODIFIER!");
                            exactDamage = (int)((exactDamage + 2) * modifier * newBase);
                            Debug.WriteLine(exactDamage + " HIT THAT DAMAGE!");
                            opponent.remHP -= exactDamage;
                            if (opponent.remHP <= 0) { opponent.remHP = 0; }
                            BattleMechanics.differentationControl = new Thread(new ThreadStart(BattleMechanics.form.differentiate));
                            BattleMechanics.differentationControl.Start();
                            BattleMechanics.differentationControl.Join();
                            if (opponent.remHP <= 0) { BattleMechanics.Faint(opponent); }
                        }
                    }
                }
                else
                {
                    // MISSED
                    BattleMechanics.form.Write("BUT " + agent.p.name + "'S ATTACK MISSED!");
                }
            }
            else
            {
                // FAILED DUE TO DIG/FLY
                BattleMechanics.form.WriteAuto("BUT IT FAILED!");
            }

        }

        public void InflictStatusEffect(Status s, PokeInstance p)
        {
            p.status = s;
            BattleMechanics.StatusLog(p, s);
        }

        public bool CalculateProbability(int prob)
        {
            Random r = new Random();
            if (((r.Next() % 100) + 1) < prob) return true;
            else return false;
        }

        public void ModifierLog(PokeInstance p, string logstat, int statval, int orgstat)
        {
            string effect = "";
            if (orgstat < 6) { 
                if (statval <= -3) effect = "INCREDIBLY FELL";
                if (statval == -2) effect = "GREATLY FELL";
                if (statval == -1) effect = "FELL";
                if (statval == 1) effect = "ROSE";
                if (statval == 2) effect = "GREATLY ROSE";
                if (statval >= 3) effect = "INCREDIBLY ROSE";
            }
            else
            {
                effect = "CAN'T CHANGE ANYMORE";
            }

            BattleMechanics.form.Write(p.p.name + "'S " + logstat + " " + effect + "!");
        }

        public void ModifierControl(PokeInstance agent, PokeInstance opponent)
        {
            if (oppSpeedMod    != 0) ModifierLog(opponent, "SPEED", oppSpeedMod, opponent.sSpeed);
            if (oppAtkMod      != 0) ModifierLog(opponent, "ATTACK", oppAtkMod, opponent.sAttack);
            if (oppDefMod      != 0) ModifierLog(opponent, "DEFENSE", oppDefMod, opponent.sDefense);
            if (oppSpAtkMod    != 0) ModifierLog(opponent, "SPECIAL ATTACK\n", oppSpAtkMod, opponent.sSpAtk);
            if (oppSpDefMod    != 0) ModifierLog(opponent, "SPECIAL DEFENSE\n", oppSpDefMod, opponent.sSpDef);
            if (oppCritRateMod != 0) ModifierLog(opponent, "CRITICAL RATE\n", oppCritRateMod, opponent.sCritRate);
            if (oppEvasionMod  != 0) ModifierLog(opponent, "EVASION", oppEvasionMod, opponent.sEvasion);
            if (oppAccuracyMod != 0) ModifierLog(opponent, "ACCURACY", oppAccuracyMod, opponent.sAccuracy);

            if (userSpeedMod != 0) ModifierLog(agent, "SPEED", userSpeedMod, agent.sSpeed);
            if (userAtkMod != 0) ModifierLog(agent, "ATTACK", userAtkMod, agent.sAttack);
            if (userDefMod != 0) ModifierLog(agent, "DEFENSE", userDefMod, agent.sDefense);
            if (userSpAtkMod != 0) ModifierLog(agent, "SPECIAL ATTACK\n", userSpAtkMod, agent.sSpAtk);
            if (userSpDefMod != 0) ModifierLog(agent, "SPECIAL DEFENSE\n", userSpDefMod, agent.sSpDef);
            if (userCritRateMod != 0) ModifierLog(agent, "CRITICAL RATE\n", userCritRateMod, agent.sCritRate);
            if (userEvasionMod != 0) ModifierLog(agent, "EVASION", userEvasionMod, agent.sEvasion);
            if (userAccuracyMod != 0) ModifierLog(agent, "ACCURACY", userAccuracyMod, agent.sAccuracy);

            opponent.sSpeed    += oppSpeedMod;      if (Math.Abs(opponent.sSpeed)    >= 6) { opponent.sSpeed    = Math.Sign(opponent.sSpeed)    * 6; }
            opponent.sAttack   += oppAtkMod;        if (Math.Abs(opponent.sAttack)   >= 6) { opponent.sAttack   = Math.Sign(opponent.sAttack)   * 6; }
            opponent.sDefense  += oppDefMod;        if (Math.Abs(opponent.sDefense)  >= 6) { opponent.sDefense  = Math.Sign(opponent.sDefense)  * 6; }
            opponent.sSpAtk    += oppSpAtkMod;      if (Math.Abs(opponent.sSpAtk)    >= 6) { opponent.sSpAtk    = Math.Sign(opponent.sSpAtk)    * 6; }
            opponent.sSpDef    += oppSpDefMod;      if (Math.Abs(opponent.sSpDef)    >= 6) { opponent.sSpDef    = Math.Sign(opponent.sSpDef)    * 6; }
            opponent.sCritRate += oppCritRateMod;   if (Math.Abs(opponent.sCritRate) >= 6) { opponent.sCritRate = Math.Sign(opponent.sCritRate) * 6; }
            opponent.sEvasion  += oppEvasionMod;    if (Math.Abs(opponent.sEvasion)  >= 6) { opponent.sEvasion  = Math.Sign(opponent.sEvasion)  * 6; }
            opponent.sAccuracy += oppAccuracyMod;   if (Math.Abs(opponent.sAccuracy) >= 6) { opponent.sAccuracy = Math.Sign(opponent.sAccuracy) * 6; }
            agent.sSpeed       += userSpeedMod;     if (Math.Abs(agent.sSpeed)       >= 6) { agent.sSpeed       = Math.Sign(opponent.sSpeed)    * 6; }
            agent.sAttack      += userAtkMod;       if (Math.Abs(agent.sAttack)      >= 6) { agent.sAttack      = Math.Sign(opponent.sAttack)   * 6; }
            agent.sDefense     += userDefMod;       if (Math.Abs(agent.sDefense)     >= 6) { agent.sDefense     = Math.Sign(opponent.sDefense)  * 6; }
            agent.sSpAtk       += userSpAtkMod;     if (Math.Abs(agent.sSpAtk)       >= 6) { agent.sSpAtk       = Math.Sign(opponent.sSpAtk)    * 6; }
            agent.sSpDef       += userSpDefMod;     if (Math.Abs(agent.sSpDef)       >= 6) { agent.sSpDef       = Math.Sign(opponent.sSpDef)    * 6; }
            agent.sCritRate    += userCritRateMod;  if (Math.Abs(agent.sCritRate)    >= 6) { agent.sCritRate    = Math.Sign(opponent.sCritRate) * 6; }
            agent.sEvasion     += userEvasionMod;   if (Math.Abs(agent.sEvasion)     >= 6) { agent.sEvasion     = Math.Sign(opponent.sEvasion)  * 6; }
            agent.sAccuracy    += userAccuracyMod;  if (Math.Abs(agent.sAccuracy)    >= 6) { agent.sAccuracy    = Math.Sign(opponent.sAccuracy) * 6; }
        }

        public void Use(PokeInstance agent, PokeInstance opponent)
        {
            
            if (hasIndividualScript) ExecuteIndividualEffect(agent, opponent);
            else
            {
                if (multiStrike) MultiStrike(agent, opponent); else SingleStrike(agent, opponent);
            }
            if (oppStatusEffect != null)
            {
                if (CalculateProbability(oppStatusProb)) InflictStatusEffect(oppStatusEffect, opponent);
                else if (mc == MoveCategory.OPSTATUSCHNG)
                    BattleMechanics.form.Write("BUT IT FAILED!");
            }
            if (userStatusEffect != null)
            {
                if (CalculateProbability(userStatusProb)) InflictStatusEffect(userStatusEffect, opponent);
                    BattleMechanics.form.Write("BUT IT FAILED!");
            }
            ModifierControl(agent, opponent);
        }

        public virtual void ExecuteIndividualEffect(PokeInstance agent, PokeInstance opponent)
        {
            // Must be overridden.
            BattleMechanics.form.Write("BUT IT FAILED!"); 
        }

        public override string ToString()
        {
            return name;
        }
    }
}