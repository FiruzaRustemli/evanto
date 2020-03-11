namespace Evanto.BL.Operations.UserOperations
{
    public class CreateAvatarInput : OperationParameters
    {
        public string MediaType { get; set; }
        public string Container { get; set; }      
        public string Extension { get; set; }
    }
    public class CreateAvatarOutput
    {
        public string Path { get; set; }
        public bool IsUpdated { get; set; }
    }
}
