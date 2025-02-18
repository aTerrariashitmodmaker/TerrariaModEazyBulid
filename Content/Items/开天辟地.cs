using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace EazyBuild.Content.Items
{
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class 开天辟地 : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.EazyBuild.hjson' file.
		public override void SetDefaults()
		{
			Item.damage = 0;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.buyPrice(silver: 1);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public static void 大方框(Player player)
		{
			Point point = player.Center.ToTileCoordinates();//获取玩家坐标转换成方块坐标

			Rectangle r0 = new Rectangle(point.X - 93, point.Y - 60, 187, 135);//定义一个矩形
			Rectangle r1 = new Rectangle(point.X - 93, point.Y - 60, 187, 1);//定义一个矩形
			Rectangle r2 = new Rectangle(point.X - 93, point.Y + 75, 187, 1);//定义一个矩形
			Rectangle r3 = new Rectangle(point.X - 93, point.Y - 60, 1, 135);//定义一个矩形
			Rectangle r4 = new Rectangle(point.X + 93, point.Y - 60, 1, 135);//定义一个矩形
			MyUtils.ForeachTile(r0, (i, j) =>
			{
				WorldGen.KillTile(i, j, false, false, true);
				WorldGen.KillWall(i, j);
			});
			MyUtils.ForeachTile(r1, (i, j) =>
			{
				WorldGen.PlaceTile(i, j, new Item(ItemID.Wood).createTile);
			});
			MyUtils.ForeachTile(r2, (i, j) =>
			{
				WorldGen.PlaceTile(i, j, new Item(ItemID.Wood).createTile);
			});
			MyUtils.ForeachTile(r3, (i, j) =>
			{
				WorldGen.PlaceTile(i, j, new Item(ItemID.Wood).createTile);
			});
			MyUtils.ForeachTile(r4, (i, j) =>
			{
				WorldGen.PlaceTile(i, j, new Item(ItemID.Wood).createTile);
			});
		}
		public static void 中间隧道(Player player)
		{
			Point point = player.Center.ToTileCoordinates();//获取玩家坐标转换成方块坐标

			Rectangle r0 = new Rectangle(point.X - 2, point.Y + 2, 5, 1);//定义一个矩形
			Rectangle r1 = new Rectangle(point.X - 2, point.Y - 60, 5, 1);//定义一个矩形
			Rectangle r2 = new Rectangle(point.X - 2, point.Y + 75, 5, 1);//定义一个矩形
			Rectangle r3 = new Rectangle(point.X - 2, point.Y - 60, 1, 135);//定义一个矩形
			Rectangle r4 = new Rectangle(point.X + 2, point.Y - 60, 1, 135);//定义一个矩形
			Rectangle r5 = new Rectangle(point.X - 1, point.Y - 59, 3, 135);//定义一个矩形
			Rectangle r6 = new Rectangle(point.X - 1, point.Y + 12, 3, 1);//平台离开雪地
			MyUtils.ForeachTile(r5, (i, j) =>
			{
				WorldGen.KillTile(i, j, false, false, true);
				WorldGen.KillWall(i, j);
				WorldGen.PlaceWall(i, j, WallID.Wood);
			});//墙壁
			MyUtils.ForeachTile(r0, (i, j) =>
			{
				WorldGen.KillTile(i, j, false, false, true);//杀死矩形0
				WorldGen.PlaceTile(i, j, new Item(ItemID.WoodPlatform).createTile);//替换矩形0

			});//关闭矩形1
			MyUtils.ForeachTile(r1, (i, j) =>
			{
				WorldGen.KillTile(i, j, false, false, true);
				WorldGen.PlaceTile(i, j, new Item(ItemID.WoodPlatform).createTile);
			});//关闭矩形2
			MyUtils.ForeachTile(r2, (i, j) =>
			{
				WorldGen.KillTile(i, j, false, false, true);
				WorldGen.PlaceTile(i, j, new Item(ItemID.WoodPlatform).createTile);
			});//关闭矩形3
			MyUtils.ForeachTile(r3, (i, j) =>
			{
				WorldGen.KillTile(i, j, false, false, true);
				WorldGen.PlaceTile(i, j, new Item(ItemID.Wood).createTile);
			});//墙壁1
			MyUtils.ForeachTile(r4, (i, j) =>
			{
				WorldGen.KillTile(i, j, false, false, true);
				WorldGen.PlaceTile(i, j, new Item(ItemID.Wood).createTile);
			});//墙壁2
			MyUtils.ForeachTile(r6, (i, j) =>
					{
						WorldGen.KillTile(i, j, false, false, true);
						WorldGen.PlaceTile(i, j, new Item(ItemID.WoodPlatform).createTile);
					});//关闭矩形3
		}

		public static void 左边隧道(Player player)
		{
			Point point = player.Center.ToTileCoordinates();//获取玩家坐标转换成方块坐标

			Rectangle r0 = new Rectangle(point.X - 93, point.Y + 2, 91, 1);//下边墙壁
			Rectangle r1 = new Rectangle(point.X - 93, point.Y - 14, 81, 1);//上边墙壁
			Rectangle r2 = new Rectangle(point.X - 12, point.Y - 14, 1, 6);//小框竖
			Rectangle r3 = new Rectangle(point.X - 12, point.Y - 8, 10, 1);//小框横
			Rectangle r4 = new Rectangle(point.X - 92, point.Y - 13, 90, 15);//玻璃墙壁

			Rectangle r6 = new Rectangle(point.X - 11, point.Y - 13, 9, 1);//岩浆

			MyUtils.ForeachTile(r0, (i, j) =>
			{
				WorldGen.PlaceTile(i, j, new Item(ItemID.Wood).createTile);
			});
			MyUtils.ForeachTile(r1, (i, j) =>
			{
				WorldGen.PlaceTile(i, j, new Item(ItemID.Wood).createTile);
			});
			MyUtils.ForeachTile(r2, (i, j) =>
			{
				WorldGen.PlaceTile(i, j, new Item(ItemID.Wood).createTile);
			});
			MyUtils.ForeachTile(r3, (i, j) =>
			{
				WorldGen.PlaceTile(i, j, new Item(ItemID.Wood).createTile);
			});
			MyUtils.ForeachTile(r4, (i, j) =>
			{
				WorldGen.PlaceWall(i, j, WallID.Glass);
			});

			MyUtils.ForeachTile(r6, (i, j) =>
						{
							WorldGen.PlaceLiquid(i, j, 1, 255);
						});
		}
		public static void 右边隧道(Player player)
		{
			Point point = player.Center.ToTileCoordinates();//获取玩家坐标转换成方块坐标

			Rectangle r0 = new Rectangle(point.X + 3, point.Y - 28, 60, 25);//雪块
			Rectangle r1 = new Rectangle(point.X + 10, point.Y + 3, 15, 20);//猩红
			Rectangle r3 = new Rectangle(point.X + 3, point.Y - 28 - 25, 60, 25);//沙子
			Rectangle r4 = new Rectangle(point.X + 3, point.Y + 3, 5, 28);
			MyUtils.ForeachTile(r0, (i, j) =>
			{
				WorldGen.PlaceTile(i, j, new Item(ItemID.Sandstone).createTile);
			});
			MyUtils.ForeachTile(r1, (i, j) =>
			{
				WorldGen.PlaceTile(i, j, new Item(ItemID.EbonstoneBlock).createTile);
			});
			MyUtils.ForeachTile(r3, (i, j) =>
			{
				WorldGen.PlaceTile(i, j, new Item(ItemID.SnowBlock).createTile);
			});
			MyUtils.ForeachTile(r4, (i, j) =>
			{
				WorldGen.PlaceTile(i, j, TileID.Hive);
			});
		}
		public static void 钓鱼台(Player player)
		{
			Point point = player.Center.ToTileCoordinates();//获取玩家坐标转换成方块坐标
			Rectangle r0 = new Rectangle(point.X - 24, point.Y + 3, 1, 34);//纵向
			Rectangle r1 = new Rectangle(point.X - 24, point.Y + 3 + 34 - 1, 22, 1);//横向
			Rectangle r2 = new Rectangle(point.X - 22, point.Y + 4, 20, 30);//横向

			Rectangle r3 = new Rectangle(point.X - 23, point.Y + 2, 21, 1);//平台替换
			MyUtils.ForeachTile(r0, (i, j) =>
			{
				WorldGen.PlaceTile(i, j, new Item(ItemID.Wood).createTile);
			});

			MyUtils.ForeachTile(r1, (i, j) =>
			{
				WorldGen.PlaceTile(i, j, new Item(ItemID.Wood).createTile);
			});

			MyUtils.ForeachTile(r2, (i, j) =>
						{
							WorldGen.PlaceLiquid(i, j, 0, 255);
						});

			MyUtils.ForeachTile(r3, (i, j) =>
			{
				WorldGen.ReplaceTile(i, j, (ushort)new Item(ItemID.WoodPlatform).createTile, 0);
			});

		}
		public static void 细节调整(Player player)
		{
			Point point = player.Center.ToTileCoordinates();
			WorldGen.PlaceTile(point.X - 1, point.Y + 1, TileID.WaterCandle);
			WorldGen.PlaceTile(point.X + 1, point.Y + 1, TileID.ShadowCandle);
			Rectangle r0 = new Rectangle(point.X - 2, point.Y - 2, 1, 4);//左门
			Rectangle r1 = new Rectangle(point.X + 2, point.Y - 2, 1, 4);//右门
			Rectangle r2 = new Rectangle(point.X - 92, point.Y - 14, 22, 1);//左边小块替换石头
			Rectangle r3 = new Rectangle(point.X - 92, point.Y - 15, 22, 1);//左边小块上替换丛林草
			Rectangle r4 = new Rectangle(point.X - 92, point.Y - 13, 22, 1);//左边小块下替换石头
			Rectangle r5 = new Rectangle(point.X - 92, point.Y - 12, 22, 1);//左边小块蘑菇草
			Rectangle r6 = new Rectangle(point.X - 92 + 20, point.Y - 12, 58, 1);//左边小块蘑菇草

			Rectangle r9 = new Rectangle(point.X - 7, point.Y - 1, 2, 3);//蜘蛛墙
			Rectangle r10 = new Rectangle(point.X - 92, point.Y - 17, 22, 1);//左边小块上替换腐化沙
			Rectangle r11 = new Rectangle(point.X - 92, point.Y - 18, 22, 1);//左边小块上替换珍珠沙

			MyUtils.ForeachTile(r0, (i, j) =>
			{
				WorldGen.ReplaceTile(i, j, (ushort)new Item(ItemID.WoodPlatform).createTile, 0);//替换矩形0

			});//关闭矩形1
			MyUtils.ForeachTile(r1, (i, j) =>
			{
				WorldGen.ReplaceTile(i, j, (ushort)new Item(ItemID.WoodPlatform).createTile, 0);//替换矩形0
			});//关闭矩形2
			MyUtils.ForeachTile(r2, (i, j) =>
			{
				WorldGen.ReplaceTile(i, j, (ushort)new Item(ItemID.StoneBlock).createTile, 0);//替换矩形0
			});//关闭矩形2
			MyUtils.ForeachTile(r3, (i, j) =>
			{
				WorldGen.PlaceTile(i, j, TileID.Mud);//替换矩形0
				WorldGen.PlaceTile(i, j, TileID.JungleGrass);//替换矩形0


			});//丛林草
			MyUtils.ForeachTile(r4, (i, j) =>
			{
				WorldGen.PlaceTile(i, j, (ushort)new Item(ItemID.StoneBlock).createTile);//替换矩形0
			});//关闭矩形2
			MyUtils.ForeachTile(r5, (i, j) =>
			{
				WorldGen.PlaceTile(i, j, TileID.Mud);//替换矩形0
				WorldGen.PlaceTile(i, j, TileID.MushroomGrass);//替换矩形0
			});//关闭矩形2
			MyUtils.ForeachTile(r6, (i, j) =>
			{
				WorldGen.PlaceTile(i, j, TileID.Dirt);//替换矩形0
			});//关闭矩形2

			MyUtils.ForeachTile(r9, (i, j) =>
			{

				WorldGen.PlaceWall(i, j, (ushort)new Item(ItemID.SpiderWallUnsafe).createWall);
				WorldGen.ReplaceWall(i, j, (ushort)new Item(ItemID.SpiderWallUnsafe).createWall);
			});//关闭矩形2
			MyUtils.ForeachTile(r10, (i, j) =>
			{
				WorldGen.PlaceTile(i, j, TileID.CorruptHardenedSand);//替换矩形0
				WorldGen.PlaceWall(i, j, (ushort)new Item(ItemID.SandstoneWallUnsafe).createWall);
			});//关闭矩形2
			MyUtils.ForeachTile(r11, (i, j) =>
			{
				WorldGen.PlaceTile(i, j, TileID.HallowHardenedSand);//替换矩形0
				WorldGen.PlaceWall(i, j, (ushort)new Item(ItemID.SandstoneWallUnsafe).createWall);
			});//关闭矩形2

		}
		bool flg = true;
		int c = 0;
		public override void HoldItem(Player player)
		{
			if (c > 0) c--;
			if (c == 0) flg = true;
			base.HoldItem(player);
		}
		public override bool? UseItem(Player player)
		{
			if (flg)
			{
				flg = false;
				c = 240;
				大方框(player);
				中间隧道(player);
				左边隧道(player);
				右边隧道(player);
				钓鱼台(player);
				细节调整(player);
			}
			return base.UseItem(player);
		}
		public override bool PreDrawTooltipLine(DrawableTooltipLine line, ref int yOffset)
		{
			if (line.Mod == "Terraria" && line.Name == "ItemName")
			{

				Main.spriteBatch.End(); //end and begin main.spritebatch to apply a shader
				Main.spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Main.UIScaleMatrix);
				GameShaders.Armor.Apply(GameShaders.Armor.GetShaderIdFromItemId(4778), Item);
				Utils.DrawBorderString(Main.spriteBatch, line.Text, new Vector2(line.X, line.Y), Color.White, 1.2f); //draw the tooltip manually
				Main.spriteBatch.End(); //then end and begin again to make remaining tooltip lines draw in the default way
				Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Main.UIScaleMatrix);
				return false;
			}
			return true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 100);
			recipe.AddIngredient(ItemID.SnowBlock, 100);
			recipe.AddIngredient(ItemID.MudBlock, 100);
			recipe.AddIngredient(ItemID.SandBlock, 50);
			recipe.AddIngredient(ItemID.BottledWater, 20);
			recipe.AddIngredient(ItemID.LavaBucket, 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
