using alchemistri.Content.Items;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using alchemistri.Content.TileEntities;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;
using Terraria.UI;
using System;

namespace alchemistri.Content.Tiles
{
    public class AntiDrillTile : ModTile
    {
        public static int[] ores = [
            3460,947,366,365,364,14,13,12,11 // luminite, chlorophyte, adamantite, mythril, cobalt, demonite, silver, gold, copper, iron
          ];
        public static int[] weightings = [
            1,   9,  10, 11, 30, 40,41,50,51
        ]; 
        public static int totalOreOdds = weightings.Sum(x => x);
        public static int GetRandomOre()
        {
            int x = Main.rand.Next(0, totalOreOdds);
            for (int i = 0; i < weightings.Length - 1; i++)
            {
                if ((x -= weightings[i]) < 0) return ores[i];
            }
            return ores.Last();
        }
        public override void SetStaticDefaults()
        {
            TileID.Sets.BasicDresser[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.IsAContainer[Type] = true;
            AdjTiles = [TileID.Containers];
            Main.tileSolid[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileContainer[Type] = true;
            RegisterItemDrop(ModContent.ItemType<AntiDrill>());
            AddMapEntry(new Color(75, 0, 50));
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, true);
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(Chest.AfterPlacement_Hook, -1, 0, false);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.addTile(Type);
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            // ModTileEntity.Kill() handles checking if the tile entity exists and destroying it if it does exist in the world for you
            // The tile coordinate parameters already refer to the top-left corner of the multitile
            ModContent.GetInstance<AntiDrillTileEntity>().Kill(i, j);
        }
        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            Main.mouseRightRelease = false;
            int left = i;
            int top = j;
            if (tile.TileFrameX % 36 != 0)
            {
                left--;
            }
            if (tile.TileFrameY != 0)
            {
                top--;
            }
            if (player.sign > -1)
            {
                SoundEngine.PlaySound(SoundID.MenuClose);
                player.sign = -1;
                Main.editSign = false;
                Main.npcChatText = string.Empty;
            }

            if (Main.editChest)
            {
                SoundEngine.PlaySound(SoundID.MenuTick);
                Main.editChest = false;
                Main.npcChatText = string.Empty;
            }
            if (player.editedChestName)
            {
                NetMessage.SendData(MessageID.SyncPlayerChest, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f);
                player.editedChestName = false;
            }
            if (player.talkNPC > -1)
            {
                player.SetTalkNPC(-1);
                Main.npcChatCornerItem = 0;
                Main.npcChatText = string.Empty;
            }

            int chest = Chest.FindChestByGuessing(left, top);
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                if (left == player.chestX && top == player.chestY && player.chest >= 0)
                {
                    player.chest = -1;
                    Recipe.FindRecipes();
                    SoundEngine.PlaySound(SoundID.MenuClose);
                }
                else
                {
                    NetMessage.SendData(MessageID.RequestChestOpen, -1, -1, null, left, (float)top, 0f, 0f, 0, 0, 0);
                    Main.stackSplit = 600;
                }
            }
            else
            {
                if (chest >= 0)
                {
                    Main.stackSplit = 600;
                    if (chest == player.chest)
                    {
                        player.chest = -1;
                        SoundEngine.PlaySound(SoundID.MenuClose);
                    }
                    else
                    {
                        player.chest = chest;
                        Main.playerInventory = true;
                        Main.recBigList = false;
                        player.chestX = i;
                        player.chestY = j;
                        SoundEngine.PlaySound(player.chest < 0 ? SoundID.MenuOpen : SoundID.MenuTick);
                    }

                    Recipe.FindRecipes();
                    ItemSorting.SortChest();
                    return true;
                }

            }
            return false;
        }
        public override void AnimateTile(ref int frame, ref int frameCounter) { }
        public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset) { }
        public override void RandomUpdate(int i, int j)
        {
            if (HasAdditionalDrills(i, j)) AddOre(i, j);
            AddOre(i, j);
        }
        public void AddOre(int i, int j)
        {
            if (Chest.FindChest(i, j) == -1) return;
            int oreID = GetRandomOre();
            for (int inventoryIndex = 0; inventoryIndex < 39; inventoryIndex++)
            {
                if (Main.chest[Chest.FindChest(i, j)].item[inventoryIndex].type == ItemID.None)
                {
                    Main.chest[Chest.FindChest(i, j)].item[inventoryIndex].SetDefaults(oreID);
                    break;
                }
            }
        }
        public bool HasAdditionalDrills(int i, int j)
        {
            if(Chest.FindChest(i, j) == -1) return false;
            Item[] itemList = Main.chest[Chest.FindChest(i, j)].item;
            for (int inventoryIndex = 0; inventoryIndex < 39; inventoryIndex++)
            {
                if (itemList[inventoryIndex].type == ModContent.ItemType<AdditionalDrills>())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
