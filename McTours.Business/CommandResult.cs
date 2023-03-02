namespace McTours.Business
{
    public class CommandResult
    {
        private const string DefaultSuccessMessage = "İşlem Başarılı!!";
        private const string DefaultFailureMessage = "İşlem Başarısız!!";

        private CommandResult()
        {

        }

        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public string ErrorMessage { get; private set; }

        public static CommandResult Success()
        {
            return Success(DefaultSuccessMessage);
        }

        public static CommandResult Success(string message)
        {
            return new CommandResult()
            {
                IsSuccess = true,
                Message = message
            };
        }

        public static CommandResult Failure()
        {
            return Failure(DefaultFailureMessage);
        }

        public static CommandResult Failure(string message)
        {
            return new CommandResult()
            {
                IsSuccess = false,
                Message = message,
            };
        }

        public static CommandResult Error(Exception ex)
        {
            return Error(DefaultFailureMessage, ex);
        }

        public static CommandResult Error(string message, Exception ex)
        {
            return new CommandResult()
            {
                IsSuccess = false,
                Message = message,
                ErrorMessage = ex.ToString()
            };
        }

    }
}
