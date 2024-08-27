
namespace Company.UI.Logging
{
    public class EntityLogger : ILogger
    {
        private readonly ILogger _logger;


        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            throw new NotImplementedException();
        }

        
        //    var result = await _repository.GetAsync(id);
        //    if (result is null)
        //    {
        //        _logger.LogWarning(AppLogEvents.ReadNotFound, "GetAsync({Id}) not found", id);
        //    }

        //    return result;
        //}
    }
}
