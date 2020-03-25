﻿using JetBrains.Annotations;
using Lykke.Service.WalletManagement.Settings.Notifications;
using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.WalletManagement.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class WalletManagementSettings
    {
        public DbSettings Db { get; set; }

        public RabbitMqSettings RabbitMq { get; set; }

        public NotificationsSettings Notifications { get; set; }
        
        public string CustomerSupportPhoneNumber { get; set; }
    }
}
