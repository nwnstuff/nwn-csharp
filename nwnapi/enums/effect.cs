namespace NWN
{
    public enum EffectTypeEngine
    {
        Invalid                       = 0,
        Haste                         = 1,
        DamageResistance              = 2,
        Slow                          = 3,
        Resurrection                  = 4,
        Disease                       = 5,
        SummonCreature                = 6,
        Regenerate                    = 7,
        SetState                      = 8,
        SetStateInternal              = 9,
        AttackIncrease                = 10,
        AttackDecrease                = 11,
        DamageReduction               = 12,
        DamageIncrease                = 13,
        DamageDecrease                = 14,
        TemporaryHitpoints            = 15,
        DamageImmunityIncrease        = 16,
        DamageImmunityDecrease        = 17,
        Entangle                      = 18,
        Death                         = 19,
        Knockdown                     = 20,
        Deaf                          = 21,
        Immunity                      = 22,
        SetAIState                    = 23,
        EnemyAttackBonus              = 24,
        ArcaneSpellFailure            = 25,
        SavingThrowIncrease           = 26,
        SavingThrowDecrease           = 27,
        MovementSpeedIncrease         = 28,
        MovementSpeedDecrease         = 29,
        VisualEffect                  = 30,
        AreaOfEffect                  = 31,
        Beam                          = 32,
        SpellResistanceIncrease       = 33,
        SpellResistanceDecrease       = 34,
        Poison                        = 35,
        AbilityIncrease               = 36,
        AbilityDecrease               = 37,
        Damage                        = 38,
        Heal                          = 39,
        Link                          = 40,
        HasteInternal                 = 41,
        SlowInternal                  = 42,
        ModifyNumAttacks              = 44,
        Curse                         = 45,
        Silence                       = 46,
        Invisibility                  = 47,
        ACIncrease                    = 48,
        ACDecrease                    = 49,
        SpellImmunity                 = 50,
        DispelAllMagic                = 51,
        DispelBestMagic               = 52,
        Taunt                         = 53,
        Light                         = 54,
        SkillIncrease                 = 55,
        SkillDecrease                 = 56,
        HitPointChangeWhenDying       = 57,
        SetWalkAnimation              = 58,
        LimitMovementSpeed            = 59,
        DamageShield                  = 61,
        Polymorph                     = 62,
        Sanctuary                     = 63,
        Timestop                      = 64,
        SpellLevelAbsorption          = 65,
        Icon                          = 67,
        RacialType                    = 68,
        Vision                        = 69,
        SeeInvisible                  = 70,
        Ultravision                   = 71,
        Trueseeing                    = 72,
        Blindness                     = 73,
        Darkness                      = 74,
        MissChance                    = 75,
        Concealment                   = 76,
        TurnResistanceIncrease        = 77,
        BonusSpellOfLevel             = 78,
        DisappearAppear               = 79,
        Disappear                     = 80,
        Appear                        = 81,
        NegativeLevel                 = 82,
        BonusFeat                     = 83,
        Wounding                      = 84,
        Swarm                         = 85,
        VampiricRegeneration          = 86,
        Disarm                        = 87,
        TurnResistanceDecrease        = 88,
        BlindnessInactive             = 89,
        Petrify                       = 90,
        ItemProperty                  = 91,
        SpellFailure                  = 92,
        CutsceneGhost                 = 93,
        CutsceneImmobile              = 94,
        DefensiveStance               = 95,
    }


    public enum EffectTypeScript
    {
        Invalideffect               = 0,
        DamageResistance            = 1,
//      AbilityBonus                = 2,
        Regenerate                  = 3,
//      SavingThrowBonus            = 4,
//      ModifyAc                    = 5,
//      AttackBonus                 = 6,
        DamageReduction             = 7,
//      DamageBonus                 = 8,
        TemporaryHitpoints          = 9,
//      DamageImmunity              = 10,
        Entangle                    = 11,
        Invulnerable                = 12,
        Deaf                        = 13,
        Resurrection                = 14,
        Immunity                    = 15,
//      Blind                       = 16,
        EnemyAttackBonus            = 17,
        ArcaneSpellFailure          = 18,
//      MovementSpeed               = 19,
        AreaOfEffect                = 20,
        Beam                        = 21,
//      SpellResistance             = 22,
        Charmed                     = 23,
        Confused                    = 24,
        Frightened                  = 25,
        Dominated                   = 26,
        Paralyze                    = 27,
        Dazed                       = 28,
        Stunned                     = 29,
        Sleep                       = 30,
        Poison                      = 31,
        Disease                     = 32,
        Curse                       = 33,
        Silence                     = 34,
        Turned                      = 35,
        Haste                       = 36,
        Slow                        = 37,
        AbilityIncrease             = 38,
        AbilityDecrease             = 39,
        AttackIncrease              = 40,
        AttackDecrease              = 41,
        DamageIncrease              = 42,
        DamageDecrease              = 43,
        DamageImmunityIncrease      = 44,
        DamageImmunityDecrease      = 45,
        ACIncrease                  = 46,
        ACDecrease                  = 47,
        MovementSpeedIncrease       = 48,
        MovementSpeedDecrease       = 49,
        SavingThrowIncrease         = 50,
        SavingThrowDecrease         = 51,
        SpellResistanceIncrease     = 52,
        SpellResistanceDecrease     = 53,
        SkillIncrease               = 54,
        SkillDecrease               = 55,
        Invisibility                = 56,
        ImprovedInvisibility        = 57,
        Darkness                    = 58,
        DispelMagicAll              = 59,
        ElementalShield             = 60,
        NegativeLevel               = 61,
        Polymorph                   = 62,
        Sanctuary                   = 63,
        TrueSeeing                  = 64,
        SeeInvisible                = 65,
        Timestop                    = 66,
        Blindness                   = 67,
        SpellLevelAbsorption        = 68,
        DispelMagicBest             = 69,
        Ultravision                 = 70,
        MissChance                  = 71,
        Concealment                 = 72,
        SpellImmunity               = 73,
        Visualeffect                = 74,
        DisappearAppear             = 75,
        Swarm                       = 76,
        TurnResistanceDecrease      = 77,
        TurnResistanceIncrease      = 78,
        Petrify                     = 79,
        CutsceneParalyze            = 80,
        Ethereal                    = 81,
        SpellFailure                = 82,
        CutsceneGhost               = 83,
        CutsceneImmobilize          = 84,
    }

    [System.Flags]
    public enum EffectDurationType
    {
        Instant   = 0,
        Temporary = 1,
        Permanent = 2,
        Equipped  = 3,
        Innate    = 4,
        Mask      = 0x7,
    }

    [System.Flags]
    public enum EffectSubType
    {
        Magical       = 8,
        Supernatural  = 16,
        Extraordinary = 24,
        Mask          = 0x18,
    }

}
