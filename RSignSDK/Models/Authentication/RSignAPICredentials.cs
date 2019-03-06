namespace RSignSDK.Models.Authentication
{
    /// <summary>
    /// The credentials provided by RPost to authenticate your integration.
    /// </summary>
    public sealed class RSignAPICredentials
    {
        /// <summary>
        /// RSign API user name or email address
        /// </summary>
        public string EmailId { get; set; }

        /// <summary>
        /// RSign API password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// RSign secret key provided by RPost to identify client
        /// </summary>
        public string ReferenceKey { get; set; }

        /// <summary>
        /// The credentials provided by RPost to authenticate your integration.
        /// </summary>
        /// <param name="emailId">RSign API user name or email address</param>
        /// <param name="password">RSign password</param>
        /// <param name="referenceKey">RSign secret key provided by RPost to identify client</param>
        public RSignAPICredentials(string emailId, string password, string referenceKey)
        {
            EmailId = emailId;
            Password = password;
            ReferenceKey = referenceKey;
        }
    }
}