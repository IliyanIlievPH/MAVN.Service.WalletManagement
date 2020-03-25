﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Common;
using Lykke.Common.Log;
using Falcon.Numerics;
using Lykke.RabbitMqBroker.Publisher;
using Lykke.Service.NotificationSystem.SubscriberContract;
using Lykke.Service.WalletManagement.Domain.Publishers;
using Lykke.Service.WalletManagement.Domain.Services;

namespace Lykke.Service.WalletManagement.DomainServices.Publishers
{
    public class PushNotificationsPublisher : JsonRabbitPublisher<PushNotificationEvent>, IPushNotificationsPublisher
    {
        private readonly IPushNotificationsSettingsService _pushNotificationsSettingsService;
        private readonly IMoneyFormatter _moneyFormatter;

        public PushNotificationsPublisher(
            ILogFactory logFactory,
            string connectionString,
            string exchangeName,
            IPushNotificationsSettingsService pushNotificationsSettingsService, 
            IMoneyFormatter moneyFormatter)
            : base(logFactory, connectionString, exchangeName)
        {
            _pushNotificationsSettingsService = pushNotificationsSettingsService;
            _moneyFormatter = moneyFormatter;
        }

        public Task PublishP2PSucceededForSenderAsync(string customerId)
        {
            return PublishAsync(new PushNotificationEvent
            {
                CustomerId = customerId,
                MessageTemplateId = _pushNotificationsSettingsService.P2PTransferSucceededForSenderTemplateId,
                Source = $"{AppEnvironment.Name} - {AppEnvironment.Version}",
                CustomPayload = new Dictionary<string, string> { { "route", "transaction-history" } }
            });
        }

        public Task PublishP2PSucceededForReceiverAsync(string customerId, Money18 amount, string senderEmail)
        {
            return PublishAsync(new PushNotificationEvent
            {
                CustomerId = customerId,
                MessageTemplateId = _pushNotificationsSettingsService.P2PTransferSucceededForReceiverTemplateId,
                Source = $"{AppEnvironment.Name} - {AppEnvironment.Version}",
                TemplateParameters =
                    new Dictionary<string, string> { { "Amount", _moneyFormatter.FormatAmountToDisplayString(amount) }, { "SenderEmail", senderEmail } },
                CustomPayload = new Dictionary<string, string> { { "route", "transaction-history" } },
            });
        }

        public Task PublishP2PFailedForSenderAsync(string customerId)
        {
            return PublishAsync(new PushNotificationEvent
            {
                CustomerId = customerId,
                MessageTemplateId = _pushNotificationsSettingsService.P2PTransferFailedForSenderTemplateId,
                Source = $"{AppEnvironment.Name} - {AppEnvironment.Version}",
                CustomPayload = new Dictionary<string, string> { { "route", "transaction-history" } }
            });
        }

        public Task PublishCampaignCompletedAsync(string customerId, Money18 amount, string campaignName)
        {
            return PublishAsync(new PushNotificationEvent
            {
                CustomerId = customerId,
                MessageTemplateId = _pushNotificationsSettingsService.CampaignCompletedTemplateId,
                Source = $"{AppEnvironment.Name} - {AppEnvironment.Version}",
                TemplateParameters = new Dictionary<string, string>
                {
                    {"Amount", _moneyFormatter.FormatAmountToDisplayString(amount)}, {"CampaignName", campaignName}
                }
            });
        }

        public Task PublishCampaignConditionCompletedAsync(string customerId, Money18 amount, string campaignName,
            string conditionName)
        {
            return PublishAsync(new PushNotificationEvent
            {
                CustomerId = customerId,
                MessageTemplateId = _pushNotificationsSettingsService.CampaignConditionCompletedTemplateId,
                Source = $"{AppEnvironment.Name} - {AppEnvironment.Version}",
                TemplateParameters = new Dictionary<string, string>
                {
                    {"Amount", _moneyFormatter.FormatAmountToDisplayString(amount)},
                    {"CampaignName", campaignName},
                    {"ConditionName", conditionName}
                }
            });
        }

        public Task PublishPartnerPaymentCreatedAsync(string customerId, string paymentRequestId)
        {
            return PublishAsync(new PushNotificationEvent
            {
                CustomerId = customerId,
                MessageTemplateId = _pushNotificationsSettingsService.PartnerPaymentCreatedTemplateId,
                Source = $"{AppEnvironment.Name} - {AppEnvironment.Version}",
                CustomPayload =
                    new Dictionary<string, string> { { "route", "payment-request" }, { "paymentId", paymentRequestId } }
            });
        }

        public Task PublishPaymentTransferAcceptedAsync(string customerId, string invoiceId, Money18 balance)
        {
            return PublishAsync(new PushNotificationEvent
            {
                CustomerId = customerId,
                MessageTemplateId = _pushNotificationsSettingsService.PaymentTransferAcceptedTemplateId,
                Source = $"{AppEnvironment.Name} - {AppEnvironment.Version}",
                CustomPayload = new Dictionary<string, string> { { "route", "wallet" } },
                TemplateParameters = new Dictionary<string, string>
                {
                    {"InvoiceId", invoiceId},
                    { "TokensBalance", _moneyFormatter.FormatAmountToDisplayString(balance)}
                }
            });
        }

        public Task PublishPaymentTransferRejectedAsync(string customerId, string invoiceId)
        {
            return PublishAsync(new PushNotificationEvent
            {
                CustomerId = customerId,
                MessageTemplateId = _pushNotificationsSettingsService.PaymentTransferRejectedTemplateId,
                Source = $"{AppEnvironment.Name} - {AppEnvironment.Version}",
                CustomPayload = new Dictionary<string, string> { { "route", "wallet" } },
                TemplateParameters = new Dictionary<string, string> { { "InvoiceId", invoiceId } }
            });
        }
    }
}
