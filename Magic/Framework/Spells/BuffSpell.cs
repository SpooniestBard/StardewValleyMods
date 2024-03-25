using Magic.Framework.Schools;
using SpaceCore;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Buffs;
using StardewValley.GameData.Buffs;

namespace Magic.Framework.Spells
{
    internal class BuffSpell : Spell
    {
        /*********
        ** Public methods
        *********/
        public BuffSpell()
            : base(SchoolId.Life, "buff") { }

        public override bool CanCast(Farmer player, int level)
        {
            if (player == Game1.player)
            {
                if (player.hasBuff("spell:life:buff"))
                    return false;
            }

            return base.CanCast(player, level);
        }

        public override int GetManaCost(Farmer player, int level)
        {
            return 25;
        }

        public override IActiveEffect OnCast(Farmer player, int level, int targetX, int targetY)
        {
            if (player != Game1.player)
                return null;

            if (player.hasBuff("spell:life:buff"))
                return null;

            int l = level + 1;
            int farm = l, fish = l, mine = l, luck = l, forage = l, def = 0 /*1*/, atk = 2;
            atk = l switch
            {
                2 => 5,
                3 => 10,
                _ => atk
            };

            var buffAttrs = new BuffAttributesData{
                FarmingLevel = farm,
                FishingLevel = fish,
                MiningLevel = mine,
                LuckLevel = luck,
                ForagingLevel = forage,
                Defense = def,
                Attack = atk
            };

            Game1.player.applyBuff(new Buff("spell:life:buff", "Buff (spell)", null, (60 + level * 120) * 1000, null, -1, new BuffEffects(buffAttrs)));
            player.AddCustomSkillExperience(Magic.Skill, 10);
            return null;
        }
    }
}
