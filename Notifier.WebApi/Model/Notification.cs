using System.Runtime.Serialization;

namespace Notifier.WebApi.Model
{
    [DataContract]
    public class NotificationBase
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string Title { get; set; }
    }

    [DataContract]
    public class Notification : NotificationBase
    {
        [DataMember]
        public NotificationType Category { get; set; }
    }

    [DataContract]
    public enum NotificationType
    {
        [EnumMember] None,
        [EnumMember] Standard,
        [EnumMember] Urgent,
    }
}