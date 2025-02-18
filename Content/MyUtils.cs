


namespace EazyBuild.Content
{
    public static class MyUtils
    {
        /// <summary>
        /// 遍历 Tile
        /// </summary>
        public static void ForeachTile(Rectangle rectangle, Action<int, int> action)//, Action<int, int, int, int> lastMethod = null
        {
            int minI = rectangle.X;
            int maxI = rectangle.X + rectangle.Width - 1;
            int minJ = rectangle.Y;
            int maxJ = rectangle.Y + rectangle.Height - 1;
            for (int i = minI; i <= maxI; i++)
            {
                for (int j = minJ; j <= maxJ; j++)
                {
                    action(i, j);
                }
            }
            //lastMethod?.Invoke(minI, minJ, maxI - minI + 1, maxJ - minJ + 1);
        }

        /// <summary>
        /// 遍历 Tile
        /// </summary>

        public static int FindItem(Player player, Func<Item, bool> condition)
        {
            int oneIndex = -1;
            for (int i = 0; i < 50; i++)
            {
                Item item = player.inventory[i];
                if (item.type != ItemID.None && item.stack > 0 && condition(item))
                {
                    if (oneIndex == -1)
                    {
                        oneIndex = i;
                        break;
                    }
                }
            }
            return oneIndex;
        }

    }
}