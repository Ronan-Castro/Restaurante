
namespace RestaurantApp.Maui.Utilities;

public static class PathDB
{
    public static string GetPath(string nameDb)
    {

        string pathDbSqlite = string.Empty;

        if (DeviceInfo.Platform.Equals(DevicePlatform.Android))
        {
            pathDbSqlite = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            pathDbSqlite = Path.Combine(pathDbSqlite, nameDb);
        } 
        else if(DeviceInfo.Platform.Equals(DevicePlatform.iOS))
        {
            pathDbSqlite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            pathDbSqlite = Path.Combine(pathDbSqlite,"..","Library", nameDb);
        }
        else if (DeviceInfo.Platform.Equals(DevicePlatform.WinUI))
        {
            // No Windows, você pode usar LocalApplicationData ou outro diretório apropriado
            pathDbSqlite = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            pathDbSqlite = Path.Combine(pathDbSqlite, nameDb);
        }
        return pathDbSqlite;
    }
}
