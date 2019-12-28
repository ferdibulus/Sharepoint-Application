using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Administration;


namespace FilmListeleme.Lists.Film_EventReceiver
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class Film_EventReceiver : SPItemEventReceiver
    {
        /// <summary>
        /// An item is being added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            base.ItemAdded(properties);
            
            var Mesaj = "Kullanıcı:" + properties.UserDisplayName + "Tarih:" + DateTime.Now.ToString() + " " + properties.ListItem.Title + "başlıklı kayıt eklendi.";

        }

        /// <summary>
        /// An item is being updated.
        /// </summary>
        public override void ItemUpdated(SPItemEventProperties properties)
        {
            base.ItemUpdated(properties);
            var Mesaj = "Kullanıcı:" + properties.UserDisplayName + "Tarih:" + DateTime.Now.ToString() + " " + properties.ListItem.Title + "başlıklı kayıt güncellendi.";

        }

        /// <summary>
        /// An item is being deleted.
        /// </summary>
        public override void ItemDeleted(SPItemEventProperties properties)
        {
            base.ItemDeleted(properties);
        
            var Mesaj = "Kullanıcı:" + properties.UserDisplayName + "Tarih:" + DateTime.Now.ToString() + " " + properties.ListItem.Title + "başlıklı kayıt silindi.";
        }

        public void WriteULS(string Mesaj)
        {
            var Kategori = new SPDiagnosticsCategory("Liste Güncellenmesi", TraceSeverity.Monitorable, EventSeverity.Information);
            SPDiagnosticsService.Local.WriteTrace(1, Kategori, TraceSeverity.Monitorable, Mesaj, null);

        }
    }
}