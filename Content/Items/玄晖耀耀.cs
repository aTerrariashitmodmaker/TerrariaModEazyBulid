using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace EazyBuild.Content.Items
{
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class 玄晖耀耀 : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.EazyBuild.hjson' file.
		public override void SetDefaults()
		{
			Item.damage = 0;
			Item.width = 18;
			Item.height = 20;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.buyPrice(silver: 1);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		static bool 周围没火把(Rectangle r)
		{
			bool flag = true;
			MyUtils.ForeachTile(r, (i, j) =>
			{
				if (i < 0 || j < 0 || i >= Main.maxTilesX || j >= Main.maxTilesY) i = j = 0;

				Tile t = Main.tile[i, j];

				if (TileID.Sets.Torch[t.TileType])
				{
					flag = false;
				}


			});
			return flag;
		}
		public static void 点火把(Player player)
		{
			Point point = player.Center.ToTileCoordinates();//获取玩家坐标转换成方块坐标
			Rectangle rectangle = new Rectangle(point.X - 50, point.Y - 50, 100, 100);//此区域为玩家周围50格范围
			int oneIndex = MyUtils.FindItem(player, item =>
			{
				if (item.createTile > TileID.Dirt)
				{
					return TileID.Sets.Torch[item.createTile];
				}
				else
				{
					return false;
				}
			});

			Item targetItem = player.inventory[oneIndex];
			if (oneIndex == -1)
			{
				targetItem.SetDefaults(ItemID.Torch);
			}
			MyUtils.ForeachTile(rectangle, (i, j) =>
			{
				if (i < 0 || j < 0 || i >= Main.maxTilesX || j >= Main.maxTilesY) i = j = 0;
				Tile t = Main.tile[i, j];
				if (TileID.Sets.Torch[t.TileType])
				{
					return;
				}
				if (t.WallType > 0 || !t.HasTile)
				{
					if (周围没火把(new Rectangle(i - 5, j - 5, 10, 10)))
					{
						//WorldGen.PlaceTile(i, j, targetItem.createTile, false, false);
						WorldGen.PlaceObject(i, j, targetItem.createTile);

					}
				}
			});
		}
		public override bool CanUseItem(Player player)
		{
			点火把(player);
			return base.CanUseItem(player);
		}
		public override bool PreDrawTooltipLine(DrawableTooltipLine line, ref int yOffset)
		{
			if (line.Mod == "Terraria" && line.Name == "ItemName")
			{

				Main.spriteBatch.End(); //end and begin main.spritebatch to apply a shader
				Main.spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Main.UIScaleMatrix);
				GameShaders.Armor.Apply(GameShaders.Armor.GetShaderIdFromItemId(3526), Item);
				Utils.DrawBorderString(Main.spriteBatch, line.Text, new Vector2(line.X, line.Y), new Color(248, 131, 121), 1.2f); //draw the tooltip manually
				Main.spriteBatch.End(); //then end and begin again to make remaining tooltip lines draw in the default way
				Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Main.UIScaleMatrix);
				return false;
			}
			return true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Torch, 21);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
