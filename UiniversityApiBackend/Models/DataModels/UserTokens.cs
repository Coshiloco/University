namespace UiniversityApiBackend.Models.DataModels
{
    public class UserTokens
    {
        public int Id { get; set; }
        
        /*Representa un toque global que sirve como identificador*/

        public string Token { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public TimeSpan Validity { get; set; }
        
        /* EL time Span es para que tu tengas un tiempo
         antes de que el token expire*/

        public string RefreshToken { get; set; }
        public string EmailId { get; set; }
        public Guid GuidId { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
