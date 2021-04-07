using System;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreApiExtensions.EntityFramework.Relational
{
    public enum TextLocation
    {
        Before,
        After
    }

    public class CommandInterceptorOptions
    {
        public string Text { get; set; }
        public TextLocation TextLocation { get; set; }
    }

    public class CustomCommandInterceptor : DbCommandInterceptor
    {
        public CustomCommandInterceptor(CommandInterceptorOptions options, params string[] applyForCommandsContaining) : this(options.Text, options.TextLocation, applyForCommandsContaining)
        {
        }

        public CustomCommandInterceptor(string text, TextLocation textLocation, params string[] applyForCommandsContaining)
        {
            TextLocation = textLocation;
            ApplyForCommandsContaining = applyForCommandsContaining;
            Text = text;
        }

        public string[] ApplyForCommandsContaining { get; }
        public string Text { get; }

        public TextLocation TextLocation { get; }

        public override InterceptionResult<int> NonQueryExecuting(
   DbCommand command,
   CommandEventData eventData,
   InterceptionResult<int> result)
        {
            UpdateCommandText(command);
            return result;
        }

        public override ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            UpdateCommandText(command);
            return new ValueTask<InterceptionResult<int>>(result);
        }

        public override InterceptionResult<DbDataReader> ReaderExecuting(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result)
        {
            UpdateCommandText(command);
            return result;
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result,
            CancellationToken cancellationToken = default)
        {
            UpdateCommandText(command);
            return new ValueTask<InterceptionResult<DbDataReader>>(result);
        }

        public override InterceptionResult<object> ScalarExecuting(
           DbCommand command,
           CommandEventData eventData,
           InterceptionResult<object> result)
        {
            UpdateCommandText(command);
            return result;
        }

        public override ValueTask<InterceptionResult<object>> ScalarExecutingAsync(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<object> result,
            CancellationToken cancellationToken = default)
        {
            UpdateCommandText(command);
            return new ValueTask<InterceptionResult<object>>(result);
        }

        public void UpdateCommandText(DbCommand command)
        {
            if (command.CommandText.Contains(Text) || !ApplyForCommandsContaining.Any(queryToken => command.CommandText.Contains(queryToken)))
            {
                return;
            }

            switch (TextLocation)
            {
                case TextLocation.Before:
                    command.CommandText = $"\r\n{Text}\r\n" + command.CommandText;
                    break;

                case TextLocation.After:
                    command.CommandText += $"\r\n{Text}\r\n";
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}