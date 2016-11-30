using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Notifier.WebApi.Model
{
    [DataContract]
    public class Notification
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public NotificationType Category { get; set; }

        [DataMember]
        public DateTime CreationStampUTC { get; set; }

        public static IEnumerable<Notification> CreateRandomList()
        {
            var notifs = new List<Notification>();
            var limit = new Random().Next(1, 10);
            var ids = new Random(limit);

            for (var i = 0; i < limit; i++)
            {
                notifs.Add(CreateRandom(ids.Next()));
            }

            return notifs;
        }

        private static Notification CreateRandom(int notificationId)
        {
            var categoryId = notificationId % Enum.GetValues(typeof(NotificationType)).Length;
            return new Notification()
            {
                Id = notificationId,
                Message = "Message #" + notificationId,
                Category = (NotificationType) categoryId,
                Title = "title #" + notificationId,
                CreationStampUTC = DateTime.UtcNow.AddMinutes(-(notificationId % 10))
            };
        }
    }

    [DataContract]
    public enum NotificationType
    {
        [EnumMember] None = 0,
        [EnumMember] Standard,
        [EnumMember] Urgent,
    }
}