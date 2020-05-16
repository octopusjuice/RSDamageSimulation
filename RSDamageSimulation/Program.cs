using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace RS_Damage
{
   class Program
   {
      static void Main(string[] args)
      {
         while (true)
         {
            Character c = new Character()
            {
               StartingAdrenaline = 100,
               AlwaysFlanks = true,
               AlwaysLunges = true,
               AlwaysWalksBleeds = false,
               AlwaysThreshesWithASR = true,
               AlwaysUltsWithROV = true,
               AlwaysUsesPlantedFeet = true,
               UsesOverkillAfterUltIfAvailable = true,
               BuildsToUltBeforeUsingThresholdsIfAvailable = true,

               FuryOfTheSmallActive = true,

               CracklingRank = 4,
               ImpatientRank = 4,
               BitingRank = 4,
               AftershockRank = 4,
               InvigoratingRank = 4,
               PreciseRank = 6,
               EquilibriumRank = 2,
               PreciseRankWithFlanking = 6,
               EquilibriumRankWithFlanking = 1,
               LungingRank = 4,
               FlankingRank = 4,
               RelentlessRank = 5,

               AbilityDamage = 2104,
               WeaponDamage = 3242,

               DamageIncreaseFromPrayer = 12,

               Logging = true
            };

            if (!GetCustomInput(args, c))
            {
               Console.ReadKey();
               continue;
            }

            StreamWriter f = File.CreateText("Output.txt");

            Console.SetOut(f);

            double averageDamage = c.FindAverageGem(100);

            StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);

            Console.WriteLine($"------Average damage: {averageDamage}");

            Console.WriteLine();
            Console.Write("Press 'o' to open output. Press any key to run again.");

            if (Console.ReadKey().Key == ConsoleKey.O)
            {
               Process.Start("Output.txt");
            }

            Console.WriteLine();

            f.Close();
         }
      }

      private static bool GetCustomInput(string[] args, Character c)
      {
         if (args.Length == 1 && string.Equals(args[0], "userinput"))
         {
            try
            {
               Console.WriteLine("Enter custom values. Press enter for default. Use command line parameter \"default\" for base gear.");
               Console.WriteLine();

               string line;

               Console.Write("StartingAdrenaline: ");
               line = Console.ReadLine();
               if (!string.IsNullOrWhiteSpace(line)) c.StartingAdrenaline = double.Parse(line);

               Console.Write("AlwaysFlanks (y/n): ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.AlwaysFlanks = string.Equals(line, "y", StringComparison.OrdinalIgnoreCase);

               Console.WriteLine();
               Console.Write("AlwaysLunges (y/n): ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.AlwaysLunges = string.Equals(line, "y", StringComparison.OrdinalIgnoreCase);

               Console.WriteLine();
               Console.Write("AlwaysWalksBleeds (y/n): ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.AlwaysWalksBleeds = string.Equals(line, "y", StringComparison.OrdinalIgnoreCase);

               Console.WriteLine();
               Console.Write("AlwaysThreshesWithASR (y/n): ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.AlwaysThreshesWithASR = string.Equals(line, "y", StringComparison.OrdinalIgnoreCase);

               Console.WriteLine();
               Console.Write("AlwaysUltsWithROV (y/n): ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.AlwaysUltsWithROV = string.Equals(line, "y", StringComparison.OrdinalIgnoreCase);

               Console.WriteLine();
               Console.Write("AlwaysUsesPlantedFeet (y/n): ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.AlwaysUsesPlantedFeet = string.Equals(line, "y", StringComparison.OrdinalIgnoreCase);

               Console.WriteLine();
               Console.Write("UsesOverkillAfterUltIfAvailable (y/n): ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.UsesOverkillAfterUltIfAvailable = string.Equals(line, "y", StringComparison.OrdinalIgnoreCase);

               Console.WriteLine();
               Console.Write("BuildsToUltBeforeUsingThresholdsIfAvailable (y/n): ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.BuildsToUltBeforeUsingThresholdsIfAvailable = string.Equals(line, "y", StringComparison.OrdinalIgnoreCase);

               Console.WriteLine();
               Console.Write("FuryOfTheSmallActive (y/n): ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.FuryOfTheSmallActive = string.Equals(line, "y", StringComparison.OrdinalIgnoreCase);

               Console.WriteLine();
               Console.Write("CracklingRank: ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.CracklingRank = int.Parse(line);

               Console.WriteLine();
               Console.Write("ImpatientRank: ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.ImpatientRank = int.Parse(line);

               Console.WriteLine();
               Console.Write("BitingRank: ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.BitingRank = int.Parse(line);

               Console.WriteLine();
               Console.Write("AftershockRank: ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.AftershockRank = int.Parse(line);

               Console.WriteLine();
               Console.Write("InvigoratingRank: ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.InvigoratingRank = int.Parse(line);

               Console.WriteLine();
               Console.Write("PreciseRank: ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.PreciseRank = int.Parse(line);

               Console.WriteLine();
               Console.Write("EquilibriumRank: ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.EquilibriumRank = int.Parse(line);

               Console.WriteLine();
               Console.Write("PreciseRankWithFlanking: ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.PreciseRankWithFlanking = int.Parse(line);

               Console.WriteLine();
               Console.Write("EquilibriumRankWithFlanking: ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.EquilibriumRankWithFlanking = int.Parse(line);

               Console.WriteLine();
               Console.Write("LungingRank: ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.LungingRank = int.Parse(line);

               Console.WriteLine();
               Console.Write("FlankingRank: ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.FlankingRank = int.Parse(line);

               Console.WriteLine();
               Console.Write("RelentlessRank: ");
               line = "" + Console.ReadKey().KeyChar;
               if (!string.IsNullOrWhiteSpace(line)) c.RelentlessRank = int.Parse(line);

               Console.WriteLine();
               Console.Write("AbilityDamage: ");
               line = Console.ReadLine();
               if (!string.IsNullOrWhiteSpace(line)) c.AbilityDamage = int.Parse(line);

               Console.Write("WeaponDamage: ");
               line = Console.ReadLine();
               if (!string.IsNullOrWhiteSpace(line)) c.WeaponDamage = int.Parse(line);

               Console.Write("DamageIncreaseFromPrayer: ");
               line = Console.ReadLine();
               if (!string.IsNullOrWhiteSpace(line)) c.DamageIncreaseFromPrayer = int.Parse(line);

               return true;
            }
            catch
            {
               Console.WriteLine("Invalid input");
               return false;
            }
         }
         else if (args.Length == 0)
         {
            try
            {
               Console.WriteLine("Paste input here. Use command line parameter \"default\" for base gear. Use \"userinput\" for user input.");
               c.StartingAdrenaline = double.Parse(Console.ReadLine());
               c.AlwaysFlanks = string.Equals(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase);
               c.AlwaysLunges = string.Equals(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase);
               c.AlwaysWalksBleeds = string.Equals(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase);
               c.AlwaysThreshesWithASR = string.Equals(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase);
               c.AlwaysUltsWithROV = string.Equals(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase);
               c.AlwaysUsesPlantedFeet = string.Equals(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase);
               c.UsesOverkillAfterUltIfAvailable = string.Equals(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase);
               c.BuildsToUltBeforeUsingThresholdsIfAvailable = string.Equals(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase);
               c.FuryOfTheSmallActive = string.Equals(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase);
               c.CracklingRank = int.Parse(Console.ReadLine());
               c.ImpatientRank = int.Parse(Console.ReadLine());
               c.BitingRank = int.Parse(Console.ReadLine());
               c.AftershockRank = int.Parse(Console.ReadLine());
               c.InvigoratingRank = int.Parse(Console.ReadLine());
               c.PreciseRank = int.Parse(Console.ReadLine());
               c.EquilibriumRank = int.Parse(Console.ReadLine());
               c.PreciseRankWithFlanking = int.Parse(Console.ReadLine());
               c.EquilibriumRankWithFlanking = int.Parse(Console.ReadLine());
               c.LungingRank = int.Parse(Console.ReadLine());
               c.FlankingRank = int.Parse(Console.ReadLine());
               c.RelentlessRank = int.Parse(Console.ReadLine());
               c.AbilityDamage = int.Parse(Console.ReadLine());
               c.WeaponDamage = int.Parse(Console.ReadLine());
               c.DamageIncreaseFromPrayer = int.Parse(Console.ReadLine());

               return true;
            }
            catch
            {
               Console.WriteLine("Invalid input");
               return false;
            }
         }
         else
         {
            Console.WriteLine("Using defaults.");
            return true;
         }
      }
   }

   class Ability
   {
      public string Name;

      public int Duration; // In ticks

      public int Cooldown; // In ticks
      public int CooldownRemaining;

      public double MinimumDamage;
      public double MaximumDamage;

      public bool IsAffectedByFlanking;
      public bool IsAffectedByLunging;
      public bool IsAffectedByWalking;
      public bool DealsDoubleDamageAgainstStunned;
      public bool IncreasesDamageOfNextHit;
      public bool AddsCritChanceToNextHit;
      public bool LosslessAutoAttackExceptAfterCombos;   // Abilities like detonate

      public int StunOrBindDuration;   // Duration of stuns or binds in ticks
      public int WalkMultiplier;
      public int DamageIncrease;
      public int AddedCritChance;
      public int NumberOfHits;   // For calculating individual crits

      public AbilityType Type;

      public WeaponRequirement WeaponReq;

      public bool IsCombo; // Can't 4TAA after combos
      public bool IsBleed; // Not affected by some damage modifiers
   }

   enum AbilityType { Basic, Threshold, Ultimate }
   enum WeaponRequirement { None, DualWield, TwoHand }

   class Character
   {
      public List<Ability> UsedAbilities;
      public List<Ability> Abilities;
      public bool AlwaysFlanks;
      public bool AlwaysLunges;
      public bool AlwaysWalksBleeds;
      public bool AlwaysUsesPlantedFeet;
      public bool AlwaysThreshesWithASR;
      public bool AlwaysUltsWithROV;
      public bool UsesOverkillAfterUltIfAvailable;
      public bool BuildsToUltBeforeUsingThresholdsIfAvailable;

      public bool FuryOfTheSmallActive;
      public double StartingAdrenaline;

      public double AbilityDamage;
      public double WeaponDamage;
      public double DamageIncreaseFromPrayer;

      public int CracklingRank;
      public int ImpatientRank;
      public int BitingRank;
      public int AftershockRank;
      public int InvigoratingRank;
      public int PreciseRank;
      public int EquilibriumRank;
      public int EquilibriumRankWithFlanking;
      public int PreciseRankWithFlanking;
      public int LungingRank;
      public int FlankingRank;
      public int RelentlessRank;

      private double DamageDealt;
      private double LastAbilityDamage;
      private double LastAftershockTriggerDamage;

      private double Adrenaline;
      private int AbilityCooldown;
      private int ASRCooldown;
      private int CracklingCooldown;
      private int SunshineTicksRemaining;
      private int OverkillCooldownRemaining;
      private int OverkillTicksRemaining;
      private int StunnedTicksRemaining;
      private bool AutoAttackQueued;

      public bool Logging;

      private Random r = new Random();

      public void UseStrongestAbilityAvailable()
      {
         Ability ChosenAbility = null;
         double ChosenAbilityAverageDamage = 0;
         double ChosenAbilityMaxDamage = 0;
         double ChosenAbilityMinDamage = 0;

         foreach (Ability a in Abilities)
         {
            if (a.CooldownRemaining > 0) continue;

            if (a.Type == AbilityType.Threshold && Adrenaline < 50) continue;

            if (a.Type == AbilityType.Ultimate && Adrenaline < 100) continue;

            if (a.Type == AbilityType.Threshold && SunshineTicksRemaining <= 0 && BuildsToUltBeforeUsingThresholdsIfAvailable && UltAvailableOrShouldBuild()) continue; // The check for SunshineTicksRemaining <= 0 should be unnecessary, but I left it in anyway

            double maximumDamage = a.MaximumDamage;
            double minimumDamage = a.MinimumDamage;
            double averageDamage;

            // Sunshine bleed - not affected by precise/equilibrium or prayer
            if (a.Type == AbilityType.Ultimate)
            {
               averageDamage = AbilityDamage * (maximumDamage + minimumDamage) / 200;
            }
            // Precise/Equilibrium
            else if (!a.IsBleed)
            {
               int pRank = (a.IsAffectedByFlanking && AlwaysFlanks) ? PreciseRankWithFlanking : PreciseRank;
               int eRank = (a.IsAffectedByFlanking && AlwaysFlanks) ? EquilibriumRankWithFlanking : EquilibriumRank;

               minimumDamage += pRank * 0.015 * a.MaximumDamage;

               double damageRange = a.MaximumDamage - a.MinimumDamage;

               maximumDamage -= (0.01 * eRank * damageRange);
               minimumDamage += (0.03 * eRank * damageRange);

               // Flanking
               if (a.IsAffectedByFlanking && AlwaysFlanks)
               {
                  if (a.Type == AbilityType.Basic)
                  {
                     minimumDamage += 0.4 * FlankingRank * minimumDamage;
                     maximumDamage += 0.4 * FlankingRank * maximumDamage;
                  }
                  else if (a.Type == AbilityType.Threshold)
                  {
                     minimumDamage += 0.15 * FlankingRank * minimumDamage;
                     maximumDamage += 0.15 * FlankingRank * maximumDamage;
                  }
               }

               averageDamage = (minimumDamage + maximumDamage) / 2;
            }

            // Lunging and Walking Bleeds
            else if (a.IsAffectedByLunging && AlwaysLunges)
            {
               double minimumHitChance = a.MinimumDamage / (a.MaximumDamage + 20 * LungingRank);
               averageDamage = a.MinimumDamage * minimumHitChance + (1 - minimumHitChance) * ((a.MinimumDamage + a.MaximumDamage) / 2 + 10 * LungingRank);

               if (a.IsAffectedByWalking && AlwaysWalksBleeds) averageDamage *= 1.5;
            }

            // NOT Lunging Bleeds
            else
            {
               double minimumHitChance = a.MinimumDamage / (a.MaximumDamage);
               averageDamage = a.MinimumDamage * minimumHitChance + (1 - minimumHitChance) * ((a.MinimumDamage + a.MaximumDamage) / 2);

               if (a.IsAffectedByWalking && AlwaysWalksBleeds) averageDamage *= 2;
            }

            // Sunshine bleed damage was calculated earlier
            if (a.Type != AbilityType.Ultimate)
            {
               averageDamage = (a.DealsDoubleDamageAgainstStunned && StunnedTicksRemaining > 0 ? 2 : 1) * (a.IsBleed ? 1 : 1 + DamageIncreaseFromPrayer / 100) * (SunshineTicksRemaining > 0 && !a.IsBleed ? 1.5 : 1) * averageDamage * AbilityDamage / 100;
               minimumDamage = (a.DealsDoubleDamageAgainstStunned && StunnedTicksRemaining > 0 ? 2 : 1) * (a.IsBleed ? 1 : 1 + DamageIncreaseFromPrayer / 100) * (SunshineTicksRemaining > 0 && !a.IsBleed ? 1.5 : 1) * minimumDamage * AbilityDamage / 100;
               maximumDamage = (a.DealsDoubleDamageAgainstStunned && StunnedTicksRemaining > 0 ? 2 : 1) * (a.IsBleed ? 1 : 1 + DamageIncreaseFromPrayer / 100) * (SunshineTicksRemaining > 0 && !a.IsBleed ? 1.5 : 1) * maximumDamage * AbilityDamage / 100;
            }

            double currentAverageDamagePerTick = averageDamage / (a.Duration == 0 ? 3 : a.Duration);
            double chosenAverageDamagePerTick = ChosenAbility == null ? 0 : ChosenAbilityAverageDamage / (ChosenAbility.Duration == 0 ? 3 : ChosenAbility.Duration);
            if (currentAverageDamagePerTick > chosenAverageDamagePerTick)
            {
               ChosenAbility = a;
               ChosenAbilityAverageDamage = averageDamage;
               ChosenAbilityMaxDamage = maximumDamage;
               ChosenAbilityMinDamage = minimumDamage;
            }

            if (a.Type == AbilityType.Ultimate)
            {
               if (AlwaysUsesPlantedFeet) averageDamage = 0;

               ChosenAbility = a;
               ChosenAbilityAverageDamage = averageDamage;
               ChosenAbilityMaxDamage = maximumDamage;
               ChosenAbilityMinDamage = minimumDamage;

               break;
            }
         }

         int numBitingProcs = 0;
         int numPrevAbilityCritProcs = 0;
         int numCurrAbilityCritProcs = 0;

         if (ChosenAbility != null)
         {
            double damage = 0;

            if (ChosenAbility.IsBleed || ChosenAbility.Type == AbilityType.Ultimate)
            {
               damage = ChosenAbilityAverageDamage;
            }
            // Forced crits
            else
            {
               if (ChosenAbility.NumberOfHits == 0) ChosenAbility.NumberOfHits = 1;

               for (int i = 0; i < ChosenAbility.NumberOfHits; i++)
               {
                  bool bitingProc = false;
                  bool previousAbilityCritProc = false; // From abilities like concentrated blast
                  bool currentAbilityCritProc = false;

                  bitingProc = r.Next(99) < BitingRank * 2;
                  if (bitingProc) numBitingProcs++;
                  else if (UsedAbilities.Count > 0 && UsedAbilities[UsedAbilities.Count - 1] != null && i == 0)
                  {
                     previousAbilityCritProc = r.Next(99) < UsedAbilities[UsedAbilities.Count - 1].AddedCritChance;
                     if (previousAbilityCritProc) numPrevAbilityCritProcs++;
                  }
                  if (!bitingProc && !previousAbilityCritProc && ChosenAbility.AddsCritChanceToNextHit && i > 0)
                  {
                     currentAbilityCritProc = r.Next(99) < i * ChosenAbility.AddedCritChance / ChosenAbility.NumberOfHits;
                     if (currentAbilityCritProc) numCurrAbilityCritProcs++;
                  }

                  double minDamage = ChosenAbilityMinDamage / ChosenAbility.NumberOfHits;
                  double maxDamage = ChosenAbilityMaxDamage / ChosenAbility.NumberOfHits;

                  if (bitingProc || previousAbilityCritProc || currentAbilityCritProc)
                  {
                     minDamage = 0.95 * (maxDamage - minDamage) + minDamage;
                  }

                  damage += (minDamage + maxDamage) / 2;
               }
            }

            LastAbilityDamage = damage;
            DamageDealt += LastAbilityDamage;

            UsedAbilities.Add(ChosenAbility);

            ChosenAbility.CooldownRemaining = ChosenAbility.Cooldown;

            AbilityCooldown = ChosenAbility.Duration == 0 ? 3 : ChosenAbility.Duration;

            if (Logging)
            {
               Console.WriteLine($"  Used {ChosenAbility.Name}" + $" for {LastAbilityDamage} damage");

               if (!UsedAbilities[UsedAbilities.Count - 1].IsBleed && UsedAbilities[UsedAbilities.Count - 1].Type != AbilityType.Ultimate)
               {
                  Console.Write($"  {numBitingProcs} Biting procs on {ChosenAbility.Name}");
                  if (UsedAbilities.Count > 1 && UsedAbilities[UsedAbilities.Count - 2] != null && UsedAbilities[UsedAbilities.Count - 2].AddsCritChanceToNextHit)
                     Console.Write($", {numPrevAbilityCritProcs} forced crits from {UsedAbilities[UsedAbilities.Count - 2].Name}");
                  if (ChosenAbility.AddsCritChanceToNextHit) Console.Write($", {numCurrAbilityCritProcs} forced crits from current ability");
                  Console.WriteLine();
               }
            }

            if (!AlwaysFlanks && ChosenAbility.StunOrBindDuration > 0)
            {
               StunnedTicksRemaining = ChosenAbility.StunOrBindDuration;

               if (Logging) Console.WriteLine($"  Target stunned or bound for {ChosenAbility.StunOrBindDuration} ticks");
            }

            if(ChosenAbility.LosslessAutoAttackExceptAfterCombos && (UsedAbilities.Count < 2 || (UsedAbilities[UsedAbilities.Count - 2] != null && !UsedAbilities[UsedAbilities.Count - 2].IsCombo)))
            {
               AutoAttackQueued = true;

               if (Logging) Console.WriteLine("  AutoAttack queued");

            }

            switch (ChosenAbility.Type)
            {
               case AbilityType.Basic:
                  Adrenaline += FuryOfTheSmallActive ? 9 : 8;
                  if (r.Next(99) < ImpatientRank * 9)
                  {
                     Adrenaline += 3;
                     if (Logging) Console.WriteLine("  Impatient perk activated");
                  }

                  if (Adrenaline > 100) Adrenaline = 100;

                  break;
               case AbilityType.Threshold:
                  if (ASRCooldown == 0 && AlwaysThreshesWithASR && r.Next(9) == 0)
                  {
                     ASRCooldown = 50;
                     if (Logging) Console.WriteLine("  ASR activated");
                     break;
                  }
                  else if (r.Next(99) < RelentlessRank)
                  {
                     if (Logging) Console.WriteLine("  Relentless activated");
                     break;
                  }
                  else
                  {
                     Adrenaline -= 15;
                  }
                  break;
               case AbilityType.Ultimate:
                  if (r.Next(99) < RelentlessRank)
                  {
                     if (Logging) Console.WriteLine("  Relentless activated");
                     break;
                  }
                  else if (AlwaysUltsWithROV)
                  {
                     if (Logging) Console.WriteLine("  ROV activated");
                     Adrenaline = 10;
                  }
                  else
                  {
                     Adrenaline = 0;
                  }
                  break;
            }
         }

         if (ChosenAbility.Type == AbilityType.Ultimate) SunshineTicksRemaining = AlwaysUsesPlantedFeet ? 63 : 50;
      }

      private bool UltAvailable()
      {
         if (Adrenaline < 100) return false;

         foreach (Ability a in Abilities)
         {
            if (a.Type != AbilityType.Ultimate) continue;

            if (a.CooldownRemaining <= 0) return true;
         }

         return false;
      }

      private bool UltAvailableOrShouldBuild()
      {
         foreach (Ability a in Abilities)
         {
            if (a.Type != AbilityType.Ultimate) continue;

            if (a.CooldownRemaining <= 0) return true;

            if (ShouldBuildBeforeUlt(a.CooldownRemaining)) return true;
         }

         return false;
      }

      private bool ShouldBuildBeforeUlt(int cooldownRemaining)
      {
         int adrenPerBasic = FuryOfTheSmallActive ? 9 : 8;

         int abilitiesBeforeUltCooledDown = cooldownRemaining / 3;

         int adrenGainedBeforeUltCooledDown = adrenPerBasic * abilitiesBeforeUltCooledDown;

         if (adrenGainedBeforeUltCooledDown + Adrenaline >= 115) return false;
         else return true;
      }

      public void SimulateFiveMinuteGem()
      {
         ResetCharacter();

         for (int tick = 0; tick < 500; tick++)
         {
            if (Logging) Console.WriteLine($"--Tick #{tick}--");

            if (AbilityCooldown > 0) AbilityCooldown--;
            if (OverkillCooldownRemaining > 0) OverkillCooldownRemaining--;
            if (ASRCooldown > 0) ASRCooldown--;
            if (CracklingCooldown > 0) CracklingCooldown--;
            if (StunnedTicksRemaining > 0) StunnedTicksRemaining--;

            foreach (Ability a in Abilities)
            {
               if (a.CooldownRemaining > 0) a.CooldownRemaining--;
            }

            if (SunshineTicksRemaining > 0)
            {
               if (Logging) Console.WriteLine("  (Sunshine active)");
            }

            if (ASRCooldown > 0)
            {
               if (Logging) Console.WriteLine("  (ASR on cooldown)");
            }

            if (UsedAbilities.Count > 0 && UsedAbilities[UsedAbilities.Count - 1] != null && UsedAbilities[UsedAbilities.Count - 1].Type == AbilityType.Ultimate && UsesOverkillAfterUltIfAvailable && OverkillCooldownRemaining == 0)
            {
               // Drink overkill
               OverkillTicksRemaining = 10;
               OverkillCooldownRemaining = 200;

               if (Logging) Console.WriteLine("  Drank overkill");
            }

            if (CracklingRank > 0 && CracklingCooldown == 0)
            {
               double cracklingDamage = 0.5 * CracklingRank * AbilityDamage;
               DamageDealt += cracklingDamage;

               if (Logging) Console.WriteLine($"  Crackling caused {cracklingDamage} damage");
               CracklingCooldown = 100;
            }

            if (AftershockRank > 0 && DamageDealt - LastAftershockTriggerDamage > 50000)
            {
               double aftershockDamage = 0.318 * AftershockRank * AbilityDamage;
               DamageDealt += aftershockDamage;

               LastAftershockTriggerDamage = DamageDealt;

               if (Logging) Console.WriteLine($"  Aftershock caused {aftershockDamage} damage");
            }

            if (AbilityCooldown == 0)
            {
               // 4TAA
               if (UsedAbilities.Count > 0 && UsedAbilities[UsedAbilities.Count - 1] != null &&       // Last ability is not an AutoAttack
                   UsedAbilities[UsedAbilities.Count - 1].WeaponReq != WeaponRequirement.TwoHand &&   // Last ability can be fired with DualWield
                  !UsedAbilities[UsedAbilities.Count - 1].IsCombo &&                                  // Last ability is not a combo attack
                  (UsedAbilities.Count < 2 || UsedAbilities[UsedAbilities.Count - 2] != null) &&      // Last ability was not fired with an AutoAttack
                  !UltAvailable() &&                                                                  // Ultimate is not available (should cast the ult immediately, since it comes with a free AutoAttack)
                  !AutoAttackQueued)                                                                  // AutoAttack is not already queued
               {
                  AutoAttackQueued = true;

                  if (Logging) Console.WriteLine("  AutoAttack queued");
               }
               else // Ability
               {
                  if(AutoAttackQueued)
                  {
                     DoAutoAttack();

                     AutoAttackQueued = false;
                  }

                  UseStrongestAbilityAvailable();
               }
            }

            if (OverkillTicksRemaining > 0)
            {
               Adrenaline += 4;
               OverkillTicksRemaining--;
            }
            if (SunshineTicksRemaining > 0) SunshineTicksRemaining--;

            if (Logging) Console.WriteLine($"  Adrenaline: {Adrenaline}");
            Thread.Sleep(0);
         }

         if (Logging) Console.WriteLine();
         Console.WriteLine($"Total damage dealt: {DamageDealt}");
         Thread.Sleep(0);
      }

      public double FindAverageGem(int samples)
      {
         double totalDamage = 0;
         for (int i = 0; i < samples; i++)
         {
            SimulateFiveMinuteGem();
            totalDamage += DamageDealt;
         }

         return totalDamage / samples;
      }

      private void ResetCharacter()
      {
         AbilityCooldown = 0;
         ASRCooldown = 0;
         CracklingCooldown = 0;
         OverkillCooldownRemaining = 0;
         OverkillTicksRemaining = 0;
         SunshineTicksRemaining = 0;
         StunnedTicksRemaining = 0;
         AutoAttackQueued = false;

         DamageDealt = 0;
         LastAbilityDamage = 0;
         LastAftershockTriggerDamage = 0;

         UsedAbilities = new List<Ability>();
         AddMagicAbilities();

         Adrenaline = StartingAdrenaline;
      }

      private void DoAutoAttack()
      {
         double minimumDamage = 0;
         double maximumDamage = WeaponDamage;
         double averageDamage;

         minimumDamage += PreciseRank * 0.015 * maximumDamage;

         maximumDamage -= (0.01 * EquilibriumRank * WeaponDamage);
         minimumDamage += (0.03 * EquilibriumRank * WeaponDamage);

         bool bitingProc = false;
         if (r.Next(99) < BitingRank * 2)
         {
            minimumDamage = 0.95 * (maximumDamage - minimumDamage) + minimumDamage;

            bitingProc = true;
         }

         averageDamage = (maximumDamage + minimumDamage) / 2;

         double damage = (1 + DamageIncreaseFromPrayer / 100) * (SunshineTicksRemaining > 0 ? 1.5 : 1) * averageDamage;

         DamageDealt += damage;

         UsedAbilities.Add(null);

         Adrenaline += 2 + 0.2 * InvigoratingRank;

         if (Adrenaline > 100) Adrenaline = 100;

         if (Logging)
         {
            Console.WriteLine($"  Used AutoAttack" + $" for {damage} damage");

            if (bitingProc) Console.WriteLine("  Biting proc on AutoAttack");
         }
      }

      private void AddMagicAbilities()
      {
         Abilities = new List<Ability>();

         // Wrack
         Abilities.Add(new Ability()
         {
            Name = "Wrack",
            MaximumDamage = 94,
            MinimumDamage = 94 * 0.2,

            Cooldown = 5,

            DealsDoubleDamageAgainstStunned = true,

            Type = AbilityType.Basic,
         });

         // Impact
         Abilities.Add(new Ability()
         {
            Name = "Impact",
            MaximumDamage = 100,
            MinimumDamage = 20,

            IsAffectedByFlanking = true,

            Cooldown = 25,

            StunOrBindDuration = 2,

            Type = AbilityType.Basic
         });

         // Dragon Breath
         Abilities.Add(new Ability()
         {
            Name = "Dragon Breath",
            MinimumDamage = 188 * 0.2,
            MaximumDamage = 188,

            Cooldown = 16, // Verify

            Type = AbilityType.Basic
         });

         // Sonic Wave
         Abilities.Add(new Ability()
         {
            Name = "Sonic Wave",
            MaximumDamage = 157,
            MinimumDamage = 157 * 0.2,

            Cooldown = 8, // Verify

            IncreasesDamageOfNextHit = true,
            DamageIncrease = 7,

            Type = AbilityType.Basic,

            WeaponReq = WeaponRequirement.TwoHand
         });

         // Concentrated Blast
         Abilities.Add(new Ability()
         {
            Name = "Concentrated Blast",
            MaximumDamage = 157,
            MinimumDamage = 157 * 0.2,

            Cooldown = 8, // Verify

            AddsCritChanceToNextHit = true,
            AddedCritChance = 10,

            Type = AbilityType.Basic,

            WeaponReq = WeaponRequirement.DualWield,

            NumberOfHits = 2,
            IsCombo = true
         });

         // Chain
         Abilities.Add(new Ability()
         {
            Name = "Chain",
            MaximumDamage = 100,
            MinimumDamage = 20,

            Cooldown = 16, // Verify

            Type = AbilityType.Basic
         });

         // Combust
         Abilities.Add(new Ability()
         {
            Name = "Combust",
            MaximumDamage = 188,
            MinimumDamage = 100,

            IsAffectedByLunging = true,
            IsAffectedByWalking = true,

            WalkMultiplier = 2,

            Cooldown = 25,

            Type = AbilityType.Basic,

            IsBleed = true
         });

         // Corruption Blast
         Abilities.Add(new Ability()
         {
            Name = "Corruption Blast",
            MaximumDamage = 300,
            MinimumDamage = 100,

            Cooldown = 25,

            Type = AbilityType.Basic,

            IsBleed = true
         });

         // Sacrifice
         Abilities.Add(new Ability()
         {
            Name = "Sacrifice",
            MaximumDamage = 100,
            MinimumDamage = 20,

            Cooldown = 50,

            Type = AbilityType.Basic
         });

         // Tuska's Wrath
         Abilities.Add(new Ability()
         {
            Name = "Tuska's Wrath",
            MaximumDamage = 110,
            MinimumDamage = 22,

            Cooldown = 25,

            Type = AbilityType.Basic
         });

         // Wild Magic
         Abilities.Add(new Ability()
         {
            Name = "Wild Magic",
            MaximumDamage = 430,
            MinimumDamage = 100,

            Cooldown = 33, // Verify

            Type = AbilityType.Threshold,

            NumberOfHits = 2
         });

         // Deep Impact
         Abilities.Add(new Ability()
         {
            Name = "Deep Impact",
            MaximumDamage = 200,
            MinimumDamage = 40,

            IsAffectedByFlanking = true,

            Cooldown = 25, // Verify

            StunOrBindDuration = 6,

            Type = AbilityType.Threshold
         });

         // Asphyxiate
         Abilities.Add(new Ability()
         {
            Name = "Axphyxiate",
            MaximumDamage = 752,
            MinimumDamage = 752 * 0.2,

            Duration = 7,

            StunOrBindDuration = 6,

            Cooldown = 33, // Verify

            Type = AbilityType.Threshold,

            NumberOfHits = 4,
            IsCombo = true
         });

         // Detonate
         Abilities.Add(new Ability()
         {
            Name = "Detonate",
            MaximumDamage = 280,
            MinimumDamage = 80,

            Cooldown = 50,

            Type = AbilityType.Threshold,

            LosslessAutoAttackExceptAfterCombos = true
         });

         // Smoke Tendrils
         Abilities.Add(new Ability()
         {
            Name = "Smoke Tendrils",
            MaximumDamage = 225,
            MinimumDamage = 225 * 0.2,

            Cooldown = 75,

            Type = AbilityType.Threshold,

            NumberOfHits = 2,
            IsCombo = true
         });

         // Sunshine
         Abilities.Add(new Ability()
         {
            Name = "Sunshine",
            MaximumDamage = 320, // Bleed Damage
            MinimumDamage = 160,

            Cooldown = 100,

            Type = AbilityType.Ultimate,

            LosslessAutoAttackExceptAfterCombos = true
         });
      }
   }
}