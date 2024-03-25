using Magic.Framework.Schools;
using SpaceCore;
using StardewValley;
using StardewValley.Buffs;
using StardewValley.GameData.Buffs;

namespace Magic.Framework.Spells
{
    internal class HasteSpell : Spell
    {
        /*********
        ** Public methods
        *********/
        public HasteSpell()
            : base(SchoolId.Life, "haste") { }

        public override bool CanCast(Farmer player, int level)
        {
            if (player == Game1.player)
            {
                if (player.hasBuff("spell:life:haste"))
                    return false;
            }

            return base.CanCast(player, level);
        }

        public override int GetManaCost(Farmer player, int level)
        {
            return 10;
        }

        public override IActiveEffect OnCast(Farmer player, int level, int targetX, int targetY)
        {
            if (player != Game1.player)
                return null;

            if (player.hasBuff("spell:life:haste"))
                return null;

            var buffAttrs = new BuffAttributesData{
                Speed = level + 1,
            };

            Game1.player.applyBuff(new Buff("spell:life:haste", "Haste (spell)", null, (60 + level * 120) * 1000, null, -1, new BuffEffects(buffAttrs)));
            player.AddCustomSkillExperience(Magic.Skill, 5);
            return null;
        }
    }
}
