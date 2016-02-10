using MSP.MSPDataServices;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace MSP.Common
{
    public sealed class TileUpdater : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            XmlDocument tileData = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquareText04);

            var service = new BlogService();
            var entries = await service.GetPreviewPosts();
            
            tileData.GetElementsByTagName("text")[0].InnerText = entries[0].Title;
            TileNotification notification = new TileNotification(tileData);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
        }
    }
}
