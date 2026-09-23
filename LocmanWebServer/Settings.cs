using System;
using System.Configuration;

namespace LocmanWebServer
{
    // Настройки подключения берутся из App.config (см. ключи Locman.*).
    public class Settings
    {
        public string Server;           // IP-адрес сервера MSSQL
        public string User;             // пользователь SQL
        public string Password;         // пароль SQL
        public int ConnectionTimeout;   // таймаут подключения, сек.
        // Список городов: "ИмяБазы=Отображаемое имя" через ";".
        // Catalog — это имя базы данных MSSQL (как в оригинале: Murmansk, Apatit...).
        public string CitiesRaw;

        public static Settings Load()
        {
            Settings s = new Settings();
            s.Server = Get("Locman.Server", "192.168.50.15");
            s.User = Get("Locman.User", "ctx");
            s.Password = Get("Locman.Password", "super");
            int t;
            s.ConnectionTimeout = int.TryParse(Get("Locman.ConnectionTimeout", "480"), out t) ? t : 480;
            s.CitiesRaw = Get("Locman.Cities",
                "Murmansk=Мурманск;Apatit=Апатиты;Кандалакша=Кандалакша;Печенга=Печенга;" +
                "Североморск=Североморск;Мончегорск=Мончегорск");
            return s;
        }

        static string Get(string key, string def)
        {
            string v = ConfigurationManager.AppSettings[key];
            return string.IsNullOrEmpty(v) ? def : v;
        }

        public string ConnectionString(string catalog)
        {
            // Формат строки подключения — как ConnectionStrings.SQL в оригинальном проекте.
            return string.Format(
                "Data Source={0};Initial Catalog={1};User ID={2};Password={3};Connection Timeout={4}",
                Server, catalog.Replace("'", "''"), User, Password, ConnectionTimeout);
        }
    }
}
