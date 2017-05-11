using Dapper.SimpleSave;

namespace Dapper.SimpleLoad
{
    /// <summary>
    /// Defines configuration settings which alter SimpleLoad's behaviour. Currently all
    /// relates to logging and how SimpleLoad should handle long running queries, and queries
    /// that handle large results sets.
    /// </summary>
    public static class SimpleLoadConfiguration
    {
        private static ISimpleConfiguration _configuration;

        static SimpleLoadConfiguration()
        {
            _configuration = new BasicConfiguration();
        }

        public static void SetConfiguration(ISimpleConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Number of rows in result set above which SimpleLoad will log a warning.
        /// Ignored if set to 0.
        /// </summary>
        public static int RowCountWarningEmitThreshold
        {
            get { return _configuration.RowCountWarningEmitThreshold; }
            set
            {
                value.IsGreaterThanOrEqualTo(nameof(RowCountWarningEmitThreshold), 0);
                _configuration.RowCountWarningEmitThreshold = value;
            }
        }

        /// <summary>
        /// Number of rows in result set above which SimpleLoad will log an error.
        /// Ignored if set to 0.
        /// </summary>
        public static int RowCountErrorEmitThreshold
        {
            get { return _configuration.RowCountErrorEmitThreshold; }
            set
            {
                value.IsGreaterThanOrEqualTo(nameof(RowCountErrorEmitThreshold), 0);
                _configuration.RowCountErrorEmitThreshold = value;
            }
        }

        /// <summary>
        /// Number of rows in result set above which SimpleLoad will throw an exception.
        /// Ignored if set to 0.
        /// </summary>
        public static int RowCountExceptionThrowThreshold
        {
            get { return _configuration.RowCountExceptionThrowThreshold; }
            set
            {
                value.IsGreaterThanOrEqualTo(nameof(RowCountExceptionThrowThreshold), 0);
                _configuration.RowCountExceptionThrowThreshold = value;
            }
        }

        /// <summary>
        /// Total duration of query and mapping above which SimpleLoad will log a warning.
        /// Ignored if set to 0.
        /// </summary>
        public static long QueryDurationMillisWarningEmitThreshold
        {
            get { return _configuration.QueryDurationMillisWarningEmitThreshold; }
            set
            {
                value.IsGreaterThanOrEqualTo(nameof(QueryDurationMillisWarningEmitThreshold), 0);
                _configuration.QueryDurationMillisWarningEmitThreshold = value;
            }
        }

        /// <summary>
        /// Total duration of query and mapping above which SimpleLoad will log an error.
        /// Ignored if set to 0.
        /// </summary>
        public static long QueryDurationMillisErrorEmitThreshold
        {
            get { return _configuration.QueryDurationMillisErrorEmitThreshold; }
            set
            {
                value.IsGreaterThanOrEqualTo(nameof(QueryDurationMillisErrorEmitThreshold), 0);
                _configuration.QueryDurationMillisErrorEmitThreshold = value;
            }
        }

        /// <summary>
        /// Total duration of query and mapping above which SimpleLoad will throw an exception.
        /// Ignored if set to 0.
        /// </summary>
        public static long QueryDurationMillisExceptionThrowThreshold
        {
            get { return _configuration.QueryDurationMillisExceptionThrowThreshold; }
            set
            {
                value.IsGreaterThanOrEqualTo(nameof(QueryDurationMillisExceptionThrowThreshold), 0);
                _configuration.QueryDurationMillisExceptionThrowThreshold = value;
            }
        }

        /// <summary>
        /// Indicates whether or not query parameters should be included in log output. Off by
        /// default and should not be switched on unless you are certain your query parameters
        /// do not contain sensitive information.
        /// </summary>
        public static bool IncludeParametersInLog
        {
            get { return _configuration.IncludeParametersInLog; }
            set { _configuration.IncludeParametersInLog = value; }
        }

        /// <summary>
        /// Indicates whether or not query parameters should be included in exceptions. Off by
        /// default and should not be switched on unless you are certain your query parameters
        /// do not contain sensitive information.
        /// </summary>
        public static bool IncludeParametersInException
        {
            get { return _configuration.IncludeParametersInException; }
            set { _configuration.IncludeParametersInException = value; }
        }

        public static bool AutoGenerateTableName
        {
            get { return _configuration.AutoGenerateTableName; }
            set { _configuration.AutoGenerateTableName = value; }
        }

        public static bool PluralizeTableName
        {
            get { return _configuration.PluralizeTableName; }
            set { _configuration.PluralizeTableName = value; }
        }
    }
}
