namespace GraphConsoleAppV3
{
    internal class AppModeConstants
    {
        public const string ClientSecret = "OR6IhEb//aCvf8As0N5GyWF/Ph5WIhJ0IxtNLN788oU=";
        //Boost: YZ7AaVE6YXZgcLzY4WT+GoEzHRChYFVHY9pWBIEYFKI=
        //public const string ClientSecret = "YZ7AaVE6YXZgcLzY4WT+GoEzHRChYFVHY9pWBIEYFKI=";
        public const string TenantName = "tsmpntsystems.onmicrosoft.com";
        public const string AuthString = GlobalConstants.AuthString + TenantName;
    }

    internal class UserModeConstants
    {
        public const string AuthString = GlobalConstants.AuthString + "common/";
    }

    internal class GlobalConstants
    {
        public const string AuthString = "https://login.microsoftonline.com/";        
        public const string ResourceUrl = "https://graph.windows.net";
        public const string GraphServiceObjectId = "00000002-0000-0000-c000-000000000000";
        public const string TenantId = "bcd24e06-5a02-45ef-8eb1-0989b7231e5b";
        public const string ClientId = "f91d0fce-516d-4875-b86e-037fa3404b97";
        //Boost d18d7568-3f52-4fff-b6cf-1ccac49c9a02
        //public const string ClientId = "d18d7568-3f52-4fff-b6cf-1ccac49c9a02";
    }
}
