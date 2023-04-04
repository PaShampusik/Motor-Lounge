using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Lounge.Views
{
    public class GlobalSetting
    {
        public const string MockTag = "Mock";
        public const string DefaultEndpoint = "http://YOUR_IP_OR_DNS_NAME"; // i.e.: "http://YOUR_IP" or "http://YOUR_DNS_NAME"

        private string _baseIdentityEndpoint;
        private string _baseGatewayMotorEndpoint;
        private string _baseGatewayByingEndpoint;

        public GlobalSetting()
        {
            AuthToken = "INSERT AUTHENTICATION TOKEN";

            BaseIdentityEndpoint = DefaultEndpoint;
            BaseGatewayMotorEndpoint = DefaultEndpoint;
            BaseGatewayMarketingEndpoint = DefaultEndpoint;
        }

        public static GlobalSetting Instance { get; } = new GlobalSetting();

        public string BaseIdentityEndpoint
        {
            get => _baseIdentityEndpoint;
            set
            {
                _baseIdentityEndpoint = value;
                UpdateEndpoint(_baseIdentityEndpoint);
            }
        }

        public string BaseGatewayMotorEndpoint
        {
            get => _baseGatewayMotorEndpoint;
            set
            {
                _baseGatewayMotorEndpoint = value;
                UpdateGatewayShoppingEndpoint(_baseGatewayMotorEndpoint);
            }
        }

        public string BaseGatewayMarketingEndpoint
        {
            get => _baseGatewayByingEndpoint;
            set
            {
                _baseGatewayByingEndpoint = value;
                UpdateGatewayMarketingEndpoint(_baseGatewayByingEndpoint);
            }
        }

        public string ClientId { get; } = "xamarin";

        public string ClientSecret { get; } = "secret";

        public string AuthToken { get; set; }

        public string RegisterWebsite { get; set; }

        public string AuthorizeEndpoint { get; set; }

        public string UserInfoEndpoint { get; set; }

        public string TokenEndpoint { get; set; }

        public string LogoutEndpoint { get; set; }

        public string Callback { get; set; }

        public string LogoutCallback { get; set; }

        public string GatewayShoppingEndpoint { get; set; }

        public string GatewayMarketingEndpoint { get; set; }

        private void UpdateEndpoint(string endpoint)
        {
            RegisterWebsite = $"{endpoint}/Account/Register";
            LogoutCallback = $"{endpoint}/Account/Redirecting";

            var connectBaseEndpoint = $"{endpoint}/connect";
            AuthorizeEndpoint = $"{connectBaseEndpoint}/authorize";
            UserInfoEndpoint = $"{connectBaseEndpoint}/userinfo";
            TokenEndpoint = $"{connectBaseEndpoint}/token";
            LogoutEndpoint = $"{connectBaseEndpoint}/endsession";

            var baseUri = GlobalSetting.ExtractBaseUri(endpoint);
            Callback = $"{baseUri}/xamarincallback";
        }

        private void UpdateGatewayShoppingEndpoint(string endpoint)
        {
            GatewayShoppingEndpoint = endpoint;
        }

        private void UpdateGatewayMarketingEndpoint(string endpoint)
        {
            GatewayMarketingEndpoint = endpoint;
        }

        private static string ExtractBaseUri(string endpoint)
        {
            try
            {
                var uri = new Uri(endpoint);
                var baseUri = uri.GetLeftPart(UriPartial.Authority);

                return baseUri;
            }
            catch (Exception ex)
            {
                _ = ex;
                return DefaultEndpoint;
            }
        }
    }
}
