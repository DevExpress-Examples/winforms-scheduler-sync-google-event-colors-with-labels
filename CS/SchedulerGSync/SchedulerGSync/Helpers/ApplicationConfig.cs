using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace SchedulerGSync {
    public class ApplicationConfig {
        public static ApplicationConfig Instance { get; private set; } = Load();

        static ApplicationConfig Load() {
            var fileInfo = new FileInfo($"{nameof(SchedulerGSync)}.appsettings");
            if (!fileInfo.Exists)
                return new ApplicationConfig();
            XmlSerializer serializer = new XmlSerializer(typeof(ApplicationConfig));
            using (var fileStream = fileInfo.OpenRead())
                return (ApplicationConfig)serializer.Deserialize(fileStream);
        }

        public ApplicationConfig() { }

        public string CalendarId { get; set; }

        public void Save() {
            var fileInfo = new FileInfo($"{nameof(SchedulerGSync)}.appsettings");
            XmlSerializer serializer = new XmlSerializer(typeof(ApplicationConfig));
            using (var fileStream = fileInfo.OpenWrite())
                serializer.Serialize(fileStream, this);
        }
    }
}
