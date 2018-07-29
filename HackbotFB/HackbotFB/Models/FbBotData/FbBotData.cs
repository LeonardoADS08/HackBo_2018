using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackbotFB.Models.FbBotData
{
    [Serializable]
    public class BotRequest
    {
        public string @object { get; set; }
        public List<BotEntry> entry { get; set; }
    }

    [Serializable]
    public class BotEntry
    {
        public string id { get; set; }
        public long time { get; set; }
        public List<BotMessageReceivedRequest> messaging { get; set; }
    }

    [Serializable]
    public class BotMessageReceivedRequest
    {
        public BotUser sender { get; set; }
        public BotUser recipient { get; set; }
        public string timestamp { get; set; }
        public BotMessage message { get; set; }
        public BotPostback postback { get; set; }

    }

    [Serializable]
    public class BotPostback
    {
        public string payload { get; set; }
    }

    /// <summary>
    /// Objeto Respuesta a serializarse
    /// </summary>

    [Serializable]
    public class BotMessageResponse
    {
        public BotUser recipient { get; set; }
        public MessageResponse message { get; set; }

        public BotMessageResponse()
        {
            recipient = new BotUser();
            message = new MessageResponse();
        }
    }

    [Serializable]
    public class BotMessage
    {
        public string mid { get; set; }
        public List<MessageAttachment> attachments { get; set; }
        public long seq { get; set; }
        public string text { get; set; }
        public QuickReply quick_reply { get; set; }
    }

    [Serializable]
    public class BotUser
    {
        public string id { get; set; }
    }

    [Serializable]
    public class MessageResponse
    {
        public MessageAttachment attachment { get; set; }
        public List<QuickReply> quick_replies { get; set; }
        public string text { get; set; }

        public MessageResponse()
        {
            attachment = new MessageAttachment();
            quick_replies = new List<QuickReply>();
        }
    }

    [Serializable]
    public class QuickReply
    {
        public string content_type { get; set; }
        public string title { get; set; }
        public string payload { get; set; }
    }

    [Serializable]
    public class ResponseButtons
    {
        public string type { get; set; }
        public string title { get; set; }
        public string payload { get; set; }

        public string url { get; set; }
        public string webview_height_ratio { get; set; }
    }

    [Serializable]
    public class MessageAttachment
    {
        public string type { get; set; }
        public MessageAttachmentPayLoad payload { get; set; }
    }

    [Serializable]
    public class MessageAttachmentPayLoad
    {
        public string url { get; set; }
        public string template_type { get; set; }
        public string top_element_style { get; set; }
        public List<PayloadElements> elements { get; set; }
        public List<ResponseButtons> buttons { get; set; }
        public string recipient_name { get; set; }
        public string order_number { get; set; }
        public string currency { get; set; }
        public string payment_method { get; set; }
        public string order_url { get; set; }
        public string timestamp { get; set; }
        public Address address { get; set; }
        public Summary summary { get; set; }
    }

    [Serializable]
    public class PayloadElements
    {
        public string title { get; set; }
        public string image_url { get; set; }
        public string subtitle { get; set; }
        public List<ResponseButtons> buttons { get; set; }
        public string item_url { get; set; }
        public int? quantity { get; set; }
        public decimal? price { get; set; }
        public string currency { get; set; }
    }

    [Serializable]
    public class Address
    {
        public string street_2 { get; set; }

        public string street_1 { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string state { get; set; }
    }

    [Serializable]
    public class Summary
    {
        public decimal? subtotal { get; set; }
        public decimal? shipping_cost { get; set; }
        public decimal? total_tax { get; set; }
        public decimal total_cost { get; set; }
    }
}