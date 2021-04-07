using System.Collections.Generic;

namespace NetCoreApiExtensions.EntityFramework.Relational.SqlInterceptors
{
    public class HintCommandInterceptor : CustomCommandInterceptor
    {
        public static readonly Dictionary<HintType, CommandInterceptorOptions> HintDictionary = new Dictionary<HintType, CommandInterceptorOptions>
                                                                                                   {
                                                                                                       {HintType.Recompile, new CommandInterceptorOptions{TextLocation = TextLocation.After, Text = " OPTION(RECOMPILE) "}}
                                                                                                   };

        public HintCommandInterceptor(HintType hintType, params string[] applyForCommandsContaining) : base(HintDictionary[hintType], applyForCommandsContaining)
        {
        }

        public enum HintType
        {
            Recompile
        }
    }
}