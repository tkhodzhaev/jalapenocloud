namespace JalapenoCloud.Common.Navigation
{
    public static class Locations
    {
        public static readonly Location Administrator = new Location("Administrator", "~/Administrator.aspx");
        public static readonly Location Administrators = new Location("Administrators", "~/Administrators.aspx");
        public static readonly Location Clients = new Location("Clients", "~/Clients.aspx");
        public static readonly Location Default = new Location("Default", "~/Default.aspx");
        public static readonly Location Error = new Location("Error", "~/Error.aspx");
        public static readonly Location Login = new Location("Login", "~/Login.aspx");
        public static readonly Location Logs = new Location("Logs", "~/Logs.aspx");
        public static readonly Location Settings = new Location("Settings", "~/Settings.aspx");
        public static readonly Location SmsHashes = new Location("SMS Hashes", "~/SmsHashes.aspx");
        public static readonly Location Spammers = new Location("Spammers", "~/Spammers.aspx");
        public static readonly Location Statistics = new Location("Statistics", "~/Statistics.aspx");
        public static readonly Location Users = new Location("Users", "~/Users.aspx");
    }
}