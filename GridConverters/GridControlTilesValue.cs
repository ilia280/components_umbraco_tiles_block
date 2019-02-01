using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Values;

namespace Graph.Components.TilesBlock
{
	public class GridControlTileValue : GridControlValueBase
	{
		public GridControlTileItem[] Tabs { get; protected set; }

		public GridControlTileValue(GridControl control, JToken obj) : base(control, obj as JObject)
		{
			this.Tabs = new GridControlTileItem[0];
			if (obj != null)
			{
				this.Tabs = JsonConvert.DeserializeObject<GridControlTileItem[]>(obj.ToString());
			}
		}

		public static GridControlTileValue Parse(GridControl control, JToken obj)
		{
			if (obj != null)
				return new GridControlTileValue(control, obj);
			return (GridControlTileValue) null;
		}
	}
}
