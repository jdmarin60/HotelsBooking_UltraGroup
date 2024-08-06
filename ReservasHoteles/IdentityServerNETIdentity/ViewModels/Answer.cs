namespace IdentityServerNETIdentity.ViewModels
{
    public class AnswerResponse
    {
        public static PetitionResponse Answer(bool _success, string _message, object _result)
        {
            return new PetitionResponse()
            {
                Success = _success,
                Message = _message,
                Result = _result
            };
        }
    }
}
