using System.Reflection;

namespace BarotraumaContentParser
{
	public class BarotraumaVerifier
	{
		public static bool IsValidBarotraumaFolder(string? path)
		{
			if (path == null) return false;
			var contentClasses = Assembly.GetExecutingAssembly().GetTypes().Where(type => typeof(IBarotraumaContent).IsAssignableFrom(type));
			foreach (var c in contentClasses)
			{
				if (c.IsInterface) continue;
				var contentPiece = Activator.CreateInstance(c) as IBarotraumaContent;
				if (contentPiece != null && !File.Exists(Path.Combine(path, contentPiece.RelativePath)))
				{
					return false;
				}
			}
			return true;
		}
	}
}
