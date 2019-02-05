namespace Graph.Components.TilesBlock
{
	public class GridControlNewsTile : IGridControlTileItem
	{
		public string Title { get; set; }
	}

	public class GridControlCustomTile : IGridControlTileItem
	{
		public string Title { get; set; }
		public string Description { get; set; }
	}

	public interface IGridControlTileItem
	{
	}
}
