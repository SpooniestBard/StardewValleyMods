using System;
using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using StardewValley;

namespace Magic.Framework
{
    internal static class Extensions
    {
        /*********
        ** Public methods
        *********/
        public static int GetCurrentMana(this Farmer player)
        {
            return Mod.Mana.GetMana(player);
        }

        public static void AddMana(this Farmer player, int amt)
        {
            Mod.Mana.AddMana(player, amt);
        }

        public static int GetMaxMana(this Farmer player)
        {
            return Mod.Mana.GetMaxMana(player);
        }

        public static void SetMaxMana(this Farmer player, int newCap)
        {
            Mod.Mana.SetMaxMana(player, newCap);
        }

        /// <summary>Get a self-updating cached view of the player's magic metadata.</summary>
        public static SpellBook GetSpellBook(this Farmer player)
        {
            return Magic.GetSpellBook(player);
        }

        /// <summary>Play a local sound centered on the given player.</summary>
        /// <param name="player">The player on which to center the sound.</param>
        /// <param name="audioName">The audio cue name to play.</param>
        public static void LocalSound(this Farmer player, string audioName)
        {
            player?.currentLocation.playSound(audioName, player.Tile);
        }
    }
}
