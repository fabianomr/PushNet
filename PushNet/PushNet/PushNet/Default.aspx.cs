using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using MoonAPNS;

namespace PushNet
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var binFolderPath = Server.MapPath("bin");
            var file = Path.Combine(binFolderPath, "Certificates.p12");

            var deviceToken = "";
            var payload = new NotificationPayload(deviceToken, "Coloque aqui o texto", 1, "default");
            var notificationList = new List<NotificationPayload>() { payload };

            var push = new PushNotification(true, file, "password");

            var result = push.SendToApple(notificationList);

            foreach (var item in result)
            {
                Response.Write(item);
            }
        }
    }
}