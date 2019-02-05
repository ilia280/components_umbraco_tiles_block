using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Umbraco.Web;

namespace Graph.Components.TilesBlock
{
	public class TilesJsonConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(IGridControlTileItem);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var tile = JObject.Load(reader);
			switch (tile["type"].ToString())
			{
				case "newsTile":
					return MapToNewsTile(tile);
				case "customTile":
					return tile.ToObject<GridControlCustomTile>(serializer);
				default:
					return null;
			}
		}

		private static object MapToNewsTile(JObject tile)
		{
			var contentId = tile.Value<int>("contentId");
			if (contentId > 0)
			{
				var item = new UmbracoHelper(UmbracoContext.Current).TypedContent(contentId);
				if (item != null)
				{
					var newsTile = new GridControlNewsTile
					{
						Title = item.GetPropertyValue<string>("title")
					};

					return newsTile;
				}
			}
			

			return null;
		}

		public override bool CanWrite => false;

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
		}
	}
}

